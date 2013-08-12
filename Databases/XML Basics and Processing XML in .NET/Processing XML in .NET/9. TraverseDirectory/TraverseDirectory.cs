namespace _9.TraverseDirectory
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class TraverseDirectory
    {
        public static void Main()
        {
            Console.WriteLine("Enter the path to the starting folder:");
            string path = Console.ReadLine();
            string outpitFilePath = "../../file-structure.xml";

            DirectoryInfo directory = new DirectoryInfo(path);

            XmlTextWriter writer = new XmlTextWriter("../../files.xml", Encoding.GetEncoding("windows-1251"));
            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directories");

                TraverseDirectoryDFS(writer, directory);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("The document was created successfully. Look for it in the main program folder.");
        }

        private static void TraverseDirectoryDFS(XmlTextWriter writer, DirectoryInfo directory)
        {
            writer.WriteStartElement("dir");
            writer.WriteString(directory.Name);
            foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
            {
                TraverseDirectoryDFS(writer, directoryInfo);
            }

            writer.WriteEndElement();

            foreach (FileInfo fileInfo in directory.GetFiles())
            {
                writer.WriteElementString("file", fileInfo.Name);
            }
        }
    }
}
