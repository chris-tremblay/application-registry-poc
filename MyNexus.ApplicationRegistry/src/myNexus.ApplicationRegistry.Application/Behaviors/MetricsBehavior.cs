using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Meter;
using App.Metrics.Timer;
using MediatR;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Application.Behaviors
{
    /// <summary>
    ///   A behavior used to publish metrics for each request.
    /// </summary>
    /// <typeparam name="TRequest">The type of request.</typeparam>
    /// <typeparam name="TResponse">The type of response.</typeparam>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1311:Static readonly fields must begin with upper-case letter", Justification = "These names are formatted for our Prometheus tooling.")]
    internal class MetricsBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
    {
        /* IMPORTANT:
         * We have tooling looking for these metrics. Do not change their names unless you change the tooling
         * as well. In case you are wondering, these names, and the units, are based on the Prometheus standards.
         */

        // TODO- Change this context name for your app
        private static readonly string context = "ir_rates";

        // Used for Kubernetes auto-scaling
        [SuppressMessage("Naming Rules", "SA1310", Justification = "Prometheus required naming convention.")]
        private static readonly TimerOptions k8s_scaling_request_duration_seconds = new TimerOptions()
        {
            Context = context,
            Name = nameof(k8s_scaling_request_duration_seconds),
            MeasurementUnit = App.Metrics.Unit.Requests,
            DurationUnit = TimeUnit.Seconds,
            RateUnit = TimeUnit.Seconds,
        };

        // Used for Kubernetes auto-scaling
        [SuppressMessage("Naming Rules", "SA1310", Justification = "Prometheus required naming convention.")]
        private static readonly MeterOptions k8s_scaling_requests_per_second = new MeterOptions()
        {
            Context = context,
            Name = nameof(k8s_scaling_requests_per_second),
            MeasurementUnit = App.Metrics.Unit.Requests,
            RateUnit = TimeUnit.Seconds,
        };

        // Per command/query execution metrics
        [SuppressMessage("Naming Rules", "SA1310", Justification = "Prometheus required naming convention.")]
        private static readonly TimerOptions request_duration_seconds = new TimerOptions()
        {
            Context = context,
            Name = nameof(request_duration_seconds),
            MeasurementUnit = App.Metrics.Unit.Requests,
            DurationUnit = TimeUnit.Seconds,
            RateUnit = TimeUnit.Seconds,
        };

        // Per command/query error metrics
        [SuppressMessage("Naming Rules", "SA1310", Justification = "Prometheus required naming convention.")]
        private static readonly MeterOptions request_errors_per_second = new MeterOptions()
        {
            Context = context,
            Name = nameof(request_errors_per_second),
            MeasurementUnit = App.Metrics.Unit.Errors,
            RateUnit = TimeUnit.Seconds,
        };

        // Per command/query error metrics
        [SuppressMessage("Naming Rules", "SA1310", Justification = "Prometheus required naming convention.")]
        private static readonly CounterOptions request_errors_total = new CounterOptions()
        {
            Context = context,
            Name = nameof(request_errors_total),
            MeasurementUnit = App.Metrics.Unit.Errors,
        };

        // Per command/query execution metrics
        [SuppressMessage("Naming Rules", "SA1310", Justification = "Prometheus required naming convention.")]
        private static readonly MeterOptions requests_per_second = new MeterOptions()
        {
            Context = context,
            Name = nameof(requests_per_second),
            MeasurementUnit = App.Metrics.Unit.Requests,
            RateUnit = TimeUnit.Seconds,
        };

        // Per command/query execution metrics
        [SuppressMessage("Naming Rules", "SA1310", Justification = "Prometheus required naming convention.")]
        private static readonly CounterOptions requests_total = new CounterOptions()
        {
            Context = context,
            Name = nameof(requests_total),
            MeasurementUnit = App.Metrics.Unit.Requests,
        };

        /// <summary>
        ///   The metrics instance we write to.
        /// </summary>
        private readonly IMetrics metrics;

        /// <summary>
        ///   Initializes a new instance of the <see cref="MetricsBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="metrics">The metrics instance we write to.</param>
        public MetricsBehavior(IMetrics metrics)
        {
            this.metrics = metrics;
        }

        /// <summary>
        ///   Writes metrics about the the current request.
        /// </summary>
        /// <param name="request">The request to authorize.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <param name="next">The next request in the pipeline.</param>
        /// <returns>The response from the request handler.</returns>
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            /* CAUTION CAUTION CAUTION !!
             * Please read this from the Prometheus docs [with my additions]:
             * Remember that every unique combination of key-value label pairs ['Tags' in App.Metrics termiology]
             * represents a new time series, which can dramatically increase the amount of data stored. Do not use
             * labels to store dimensions with high cardinality (many different label values), such as user IDs,
             * email addresses, or other unbounded sets of values.
             *
             * NOW SOME FURTHER DISCUSSION:
             * Below we are tagging the name of every command and query. This gives us the great capability to
             * identify precisely which command or query could be taking a long time or generating a lot of errors.
             * But with this capability comes the cost of maintaining a separate time series for each one. As long
             * as the number of commands and queries is reasonable, this is fine, but if we add several hundered, or
             * God help us thousands of commands and queries over time, well, you can see the dilemma.
             *
             * Another potential issue is this: if you write Prometheus functions over the metrics, you typically
             * have to write them across all the variations of labels (tags) in order to get an aggregate view. So
             * if you write such a function across the currently known commands and queries, and then you add new
             * ones later, well, now your functions are wrong. The solution to this particular dilemma is actually
             * fairly simple. Just create a new metric that ommits the tags and perform your function on that. We
             * actually have an example of this below in the 'k8s_scaling_*' metrics, which do not tag the commands
             * and queries and thus represents an aggregate view across all of them.
             */
            var requestType = request is MyNexus.ApplicationRegistry.Application.Queries.QueryBase<TResponse> ? "Query" : "Command";
            var requestName = typeof(TRequest).Name;

            var tags = new MetricTags(
                new[] { "request_type", "request_name" },
                new[] { requestType, requestName });

            using (metrics.Measure.Timer.Time(k8s_scaling_request_duration_seconds)) // Don't put tags on this one
            using (metrics.Measure.Timer.Time(request_duration_seconds, tags))
            {
                try
                {
                    metrics.Measure.Counter.Increment(requests_total, tags);
                    metrics.Measure.Meter.Mark(requests_per_second, tags);
                    metrics.Measure.Meter.Mark(k8s_scaling_requests_per_second); // Don't put tags on this one

                    return await next();
                }
                catch
                {
                    metrics.Measure.Counter.Increment(request_errors_total, tags);
                    metrics.Measure.Meter.Mark(request_errors_per_second, tags);

                    throw;
                }
            }
        }
    }
}