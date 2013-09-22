using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _1.FileUpload.Models
{
    public class FileEntryContext : DbContext
    {
        public FileEntryContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<FileEntry> FileEntries { get; set; }
    }
}