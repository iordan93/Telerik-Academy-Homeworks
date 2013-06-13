namespace _3.CalculateSumOfFileSizes
{
    using System;

    public class File
    {
        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public File(string name)
            : this(name, 0)
        {
        }

        public string Name { get; private set; }

        public long Size { get; private set; }
    }
}
