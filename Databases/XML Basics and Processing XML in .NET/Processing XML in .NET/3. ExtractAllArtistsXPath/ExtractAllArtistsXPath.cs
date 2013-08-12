namespace _3.ExtractAllArtistsXPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class ExtractAllArtistsXPath
    {
        public static void Main()
        {
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load("../../../catalogue.xml");

            Dictionary<string, int> albumsCount = new Dictionary<string, int>();
            XmlNodeList albums = catalogue.SelectNodes("/catalogue/album");
            foreach (XmlNode album in albums)
            {
                string artist = album.SelectSingleNode("artist").InnerText;

                if (!albumsCount.Keys.Contains(artist))
                {
                    albumsCount[artist] = 1;
                }
                else
                {
                    albumsCount[artist]++;
                }
            }

            foreach (var kvp in albumsCount)
            {
                Console.WriteLine("{0} -> {1} {2}", kvp.Key, kvp.Value, kvp.Value == 1 ? "song" : "songs");
            }
        }
    }
}
