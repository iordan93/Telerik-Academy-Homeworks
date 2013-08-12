namespace _4.DeleteAlbums
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Xml;

    public class DeleteAlbums
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            XmlDocument catalogue = new XmlDocument();
            catalogue.Load("../../../catalogue.xml");

            var nodesToRemove = catalogue.SelectNodes("/catalogue/album/price");
            foreach (XmlNode node in nodesToRemove)
            {
                decimal price = decimal.Parse(node.InnerText);
                if (price > 20)
                {
                    node.ParentNode.RemoveAll();
                }
            }

            Console.WriteLine("Remaining albums after deleting:");
            foreach (XmlNode album in catalogue.SelectNodes("/catalogue/album"))
            {
                if (album.ChildNodes.Count != 0)
                {
                    Console.WriteLine(album["name"].InnerText);
                }
            }
        }
    }
}
