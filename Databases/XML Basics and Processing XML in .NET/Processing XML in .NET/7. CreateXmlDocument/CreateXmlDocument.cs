namespace _7.CreateXmlDocument
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class CreateXmlDocument
    {
        public static void Main()
        {
            XmlTextWriter writer = new XmlTextWriter("../../person.xml", Encoding.UTF8);
            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("person");
                
                StreamReader input = new StreamReader("../../input.txt");
                writer.WriteElementString("name", input.ReadLine());
                writer.WriteElementString("address", input.ReadLine());
                writer.WriteElementString("telephone", input.ReadLine());

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("The document was created successfully. Look for it in the main program folder.");
        }
    }
}
