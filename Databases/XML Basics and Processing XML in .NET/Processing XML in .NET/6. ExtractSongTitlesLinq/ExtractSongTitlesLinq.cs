namespace _6.ExtractSongTitlesLinq
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Xml.Linq;

    public class ExtractSongTitlesLinq
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            XDocument catalogue = XDocument.Load("../../../catalogue.xml");

            var songs = catalogue.Descendants("song").Select(n => n.Element("title").Value);

            Console.WriteLine("Song names:");
            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }
    }
}
