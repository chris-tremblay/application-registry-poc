using System.Collections.Generic;

namespace MyNexus.ApplicationRegistry.Domain.Models
{
    /// <summary>
    ///   A micro application that contains injectable widgets.
    /// </summary>
    public interface IMicroApplication
    {
        /// <summary>
        ///   Gets or sets the name of the root element of the micro-application.
        /// </summary>
        public string AppElementName { get; set; }

        /// <summary>
        ///   Gets or sets the fully qualified application name. This is usually the repository name.
        /// </summary>
        public string Fqan { get; set; }

        /// <summary>
        ///   Gets or sets a list of Script URLs that should be injected when the micro-app is loaded. These URLs should
        ///   contain the custom-element definitions.
        /// </summary>
        public IEnumerable<string> ScriptUrls { get; set; }
    }
}