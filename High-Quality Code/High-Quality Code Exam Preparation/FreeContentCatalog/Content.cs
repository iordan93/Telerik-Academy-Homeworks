namespace FreeContentCatalog
{
    using System;
    using System.Linq;

    public class Content : IComparable, IContent
    {
        public Content(ContentType type, params string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)CommandAttributes.Title];
            this.Author = commandParams[(int)CommandAttributes.Author];
            this.Size = long.Parse(commandParams[(int)CommandAttributes.Size]);
            this.Url = commandParams[(int)CommandAttributes.Url];
            this.TextRepresentation = this.ToString();
        }

        public ContentType Type { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public string Url { get; set; }

        public string TextRepresentation { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Content otherContent = obj as Content;
            if (otherContent != null)
            {
                int comparisonResult = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);
                return comparisonResult;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = string.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.Url);
            return output;
        }
    }
}