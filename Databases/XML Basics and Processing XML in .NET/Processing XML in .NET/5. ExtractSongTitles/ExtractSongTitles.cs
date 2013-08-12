namespace _5.ExtractSongTitles
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Xml;

    public class ExtractSongTitles
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            using (XmlReader catalogue = XmlReader.Create("../../../catalogue.xml"))
            {
                Console.WriteLine("Song names:");
                while (catalogue.Read())
                {
                    if ((catalogue.NodeType == XmlNodeType.Element) &&
                        (catalogue.Name == "title"))
                    {
                        Console.WriteLine(catalogue.ReadElementString());
                    }
                }
            }
        }
    }
}
