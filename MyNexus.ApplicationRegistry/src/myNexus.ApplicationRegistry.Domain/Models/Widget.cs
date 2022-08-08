using System.Collections.Generic;

namespace MyNexus.ApplicationRegistry.Domain.Models
{
    /// <summary>
    ///   A widget that can be used by applications.
    /// </summary>
    public class Widget
    {
        /// <summary>
        ///   Gets or sets a description of the widget.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///   Gets or sets the name of the widget.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///   Gets or sets a list of tags used to help classify a widget.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
    }
}