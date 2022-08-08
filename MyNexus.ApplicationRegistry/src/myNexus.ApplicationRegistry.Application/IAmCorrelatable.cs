namespace MyNexus.ApplicationRegistry.Application
{
    /// <summary>
    ///   An interface marking a feature as being correlatable.
    /// </summary>
    public interface IAmCorrelatable
    {
        /// <summary>
        ///   Gets the correlationId.
        /// </summary>
        CorrelationId CorrelationId { get; }
    }
}