using System.Collections.Generic;

namespace MyNexus.ApplicationRegistry.Domain.Models
{
    /// <summary>
    ///   A Micro-App containing widgets that can be used accross applications.
    /// </summary>
    public class MicroApplication : IMicroApplication
    {
        /// <summary>
        ///   Gets or sets the name of the root element of the micro-application.
        /// </summary>
        public string AppElementName { get; set; }

        /// <summary>
        ///   Gets or sets configuration settings for the applicaiton and/or widgets.
        /// </summary>
        public object Configuration { get; set; }

        /// <summary>
        ///   Gets or sets the fully qualified application name. This is usually the repository name.
        /// </summary>
        public string Fqan { get; set; }

        /// <summary>
        ///   Gets or sets a list of Script URLs that should be injected when the micro-app is loaded. These URLs should
        ///   contain the custom-element definitions.
        /// </summary>
        public IEnumerable<string> ScriptUrls { get; set; }

        /// <summary>
        ///   Gets or sets a list of Style URLs that should be injected when the micro-app is loaded.
        /// </summary>
        public IEnumerable<string> StyleUrls { get; set; }

        /// <summary>
        ///   Gets or sets a list of widgets provided by the application. The widget names should be the custom element name.
        /// </summary>
        public IEnumerable<Widget> Widgets { get; set; }
    }
}