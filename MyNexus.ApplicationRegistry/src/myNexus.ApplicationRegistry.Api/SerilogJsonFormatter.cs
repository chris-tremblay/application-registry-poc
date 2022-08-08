using Serilog.Formatting.Json;

namespace MyNexus.ApplicationRegistry.Web
{
    /// <summary>
    ///   A custom json formatter based on Serilog's JsonFormatter.
    /// </summary>
    public class SerilogJsonFormatter : JsonFormatter
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="SerilogJsonFormatter"/> class.
        /// </summary>
        public SerilogJsonFormatter()
            : base(renderMessage: true)
        {
        }
    }
}