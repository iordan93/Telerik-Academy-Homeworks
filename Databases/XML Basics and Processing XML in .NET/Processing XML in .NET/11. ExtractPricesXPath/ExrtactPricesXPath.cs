namespace _11.ExtractPricesXPath
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Xml;

    public class ExrtactPricesXPath
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load("../../../catalogue.xml");

            // To test with my data, set the year to 1980 for example
            string query = "/catalogue/album[year<2008]";
            XmlNodeList prices = catalogue.SelectNodes(query);

            foreach (XmlNode priceNode in prices)
            {
                string albumName = priceNode.SelectSingleNode("name").InnerText;
                string price = priceNode.SelectSingleNode("price").InnerText;
                Console.WriteLine("{0} -> {1}", albumName, price);
            }
        }
    }
}
