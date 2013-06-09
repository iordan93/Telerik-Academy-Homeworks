namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Catalog : ICatalog
    {
        private readonly MultiDictionary<string, IContent> urls;
        private readonly OrderedMultiDictionary<string, IContent> titles;

        public Catalog(bool allowDuplicates = true)
        {
            this.titles = new OrderedMultiDictionary<string, IContent>(allowDuplicates);
            this.urls = new MultiDictionary<string, IContent>(allowDuplicates);
            this.ElementsCount = 0;
        }

        public int ElementsCount { get; private set; }

        public void Add(IContent content)
        {
            this.titles.Add(content.Title, content);
            this.urls.Add(content.Url, content);
            this.ElementsCount++;
        }

        public IEnumerable<IContent> GetCatalogContent(string title, int numberOfElements)
        {
            IEnumerable<IContent> catalogContent =
                from content in this.titles[title]
                select content;

            return catalogContent.Take(numberOfElements);
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            List<IContent> contentToList = this.urls[oldUrl].ToList();
            int elementsCount = contentToList.Count;

            this.urls.Remove(oldUrl);

            foreach (IContent content in contentToList)
            {
                content.Url = newUrl;
                this.urls.Add(content.Url, content);
            }

            return elementsCount;
        }
    }
}