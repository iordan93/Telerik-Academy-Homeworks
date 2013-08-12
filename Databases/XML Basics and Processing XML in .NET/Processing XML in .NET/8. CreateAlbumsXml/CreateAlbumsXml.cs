namespace _8.CreateAlbumsXml
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;
    using System.Xml;

    public class CreateAlbumsXml
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            XmlDocument catalogue = new XmlDocument();
            catalogue.Load("../../../catalogue.xml");

            XmlNodeList albums = catalogue.SelectNodes("/catalogue/album");

            XmlTextWriter writer = new XmlTextWriter("../../album.xml", Encoding.UTF8);
            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");
                
                foreach (XmlNode album in albums)
                {
                    writer.WriteStartElement("album");
                    writer.WriteElementString("name", album["name"].InnerText);
                    writer.WriteElementString("artist", album["artist"].InnerText);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("The document was created successfully. Look for it in the main program folder.");
        }
    }
}
