namespace _3.CalculateSumOfFileSizes
{
    using System;
    using System.IO;
    using System.Numerics;

    public class CalculateSumOfFileSizes
    {
        public static void Main()
        {
            Console.Write("Enter the folder to start the traversal at: ");
            string rootFolderName = Console.ReadLine();
            if (rootFolderName.IndexOf('\\') == -1)
            {
                rootFolderName = rootFolderName + '\\';
            }

            Folder rootFolder = CreateFolderTree(rootFolderName);
            BigInteger size = rootFolder.GetSize();
            Console.WriteLine("The size of the folder {0} is {1} bytes.", rootFolderName, size);
        }

        public static Folder CreateFolderTree(string rootFolderName)
        {
            Folder rootFolder = new Folder(rootFolderName);

            try
            {
                string[] innerFolders = Directory.GetDirectories(rootFolder.Name);
                foreach (string innerFolder in innerFolders)
                {
                    rootFolder.AddFolder(CreateFolderTree(innerFolder));
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("There was a problem with opening a folder: {0}", ex.Message);
            }

            try
            {
                string[] files = Directory.GetFiles(rootFolder.Name);
                foreach (string fileName in files)
                {
                    File currentFile = new File(fileName, new FileInfo(fileName).Length);
                    rootFolder.AddFile(currentFile);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                 Console.WriteLine("There was a problem with opening a file: {0}", ex.Message);
            }

            return rootFolder;
        }
    }
}
