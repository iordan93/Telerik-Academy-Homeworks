namespace _3.CalculateSumOfFileSizes
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class Folder
    {
        public Folder(string name, List<Folder> folders, List<File> files)
        {
            this.Name = name;
            this.Folders = folders;
            this.Files = files;
        }

        public Folder(string name)
            : this(name, new List<Folder>(), new List<File>())
        {
        }

        public string Name { get; set; }

        public List<Folder> Folders { get; set; }

        public List<File> Files { get; set; }

        public BigInteger GetSize()
        {
            BigInteger size = 0;

            foreach (var innerFolder in this.Folders)
            {
                size += innerFolder.GetSize();
            }

            foreach (var file in this.Files)
            {
                size += file.Size;
            }

            return size;
        }

        public void AddFolder(Folder folder)
        {
            this.Folders.Add(folder);
        }

        public void AddFile(File file)
        {
            this.Files.Add(file);
        }
    }
}
