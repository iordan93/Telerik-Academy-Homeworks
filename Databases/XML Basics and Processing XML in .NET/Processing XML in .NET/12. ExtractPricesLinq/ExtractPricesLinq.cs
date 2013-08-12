namespace _12.ExtractPricesLinq
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Xml.Linq;

    public class ExtractPricesLinq
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            XDocument xmlDoc = XDocument.Load("../../../catalogue.xml");

            // To test with my data, set the year to 1980 for example
            var albums = xmlDoc.Descendants("album")
                               .Where(a => int.Parse(a.Element("year").Value) < 2008)
                               .Select(a => new
                               {
                                   Title = a.Element("name").Value,
                                   Price = a.Element("price").Value
                               });

            foreach (var album in albums)
            {
                Console.WriteLine("{0}-> {1}", album.Title, album.Price);
            }
        }
    }
}