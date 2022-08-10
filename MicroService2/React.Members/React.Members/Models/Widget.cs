using System.Collections.Generic;

namespace React.Members.Models
{
    /// <summary>
    ///   A widget that can be reused in other applications.
    /// </summary>
    public class Widget
    {
        /// <summary>
        ///   Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///   Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///   Gets or sets the name.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
    }
}