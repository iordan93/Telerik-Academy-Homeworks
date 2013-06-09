namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface ICatalog
    {
        /// <summary>
        /// Adds a content item to the current catalog.
        /// </summary>
        /// <param name="content">The content item to be added.</param>
        void Add(IContent content);

        /// <summary>
        /// Searches for items with the specified title in the catalog and returns any available matches.
        /// </summary>
        /// <param name="title">The title of the element to search for.</param>
        /// <param name="elementsCount">The maximal number of elements to look for.</param>
        /// <returns>Returns the content of the catalog represented as IEnumerable&lt;IContent&gt;.</returns>
        IEnumerable<IContent> GetCatalogContent(string title, int elementsCount);

        /// <summary>
        /// Updates all elements pointing to a given URL from the catalog with a new URL.
        /// </summary>
        /// <param name="oldUrl">The URL to be replaced.</param>
        /// <param name="newUrl">The URL which should replace the old one.</param>
        /// <returns>Returns the number of elements affected by the update.</returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}
