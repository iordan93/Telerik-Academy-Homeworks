namespace _10.TraverseDirectoryLinq
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    public class TraverseDirectoryLinq
    {
        public static void Main()
        {
            Console.WriteLine("Enter the path to the starting folder:");
            string path = Console.ReadLine();

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            XDocument document = new XDocument(TraverseDirectoryDFS(directoryInfo));

            XmlTextWriter writer = new XmlTextWriter("../../files.xml", Encoding.UTF8);
            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                document.WriteTo(writer);
            }

            Console.WriteLine("The document was created successfully. Look for it in the main program folder.");
        }

        private static XElement TraverseDirectoryDFS(DirectoryInfo directory)
        {
            XElement directories = new XElement("directories");

            var subdirectories = directory.GetDirectories().ToList();
            foreach (var subdirectory in subdirectories)
            {
                directories.Add(TraverseSubdirectory(subdirectory));
            }

            foreach (var file in directory.GetFiles())
            {
                directories.Add(new XElement("file", file.Name));
            }

            return directories;
        }

        private static XElement TraverseSubdirectory(DirectoryInfo directory)
        {
            var currentDirectory = new XElement("dir", new XAttribute("name", directory.Name));

            var subdirectories = directory.GetDirectories().ToList();
            foreach (var subDir in subdirectories)
            {
                currentDirectory.Add(TraverseSubdirectory(subDir));
            }

            foreach (var file in directory.GetFiles())
            {
                currentDirectory.Add(new XElement("file", file.Name));
            }

            return currentDirectory;
        }
    }
}
