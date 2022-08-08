using System.Collections.Generic;

namespace MyNexus.ApplicationRegistry.Data.Queries.ElementSearch
{
    /// <summary>
    ///   A record returned from an <see cref="IProvideElementSearchQueryData"/>.
    /// </summary>
    public class ElementSearchQueryResult
    {
        /// <summary>
        ///   Gets or sets the application name.
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        ///   Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///   Gets or sets the element name.
        /// </summary>
        public string ElementName { get; set; }

        /// <summary>
        ///   Gets or sets the tags.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
    }
}