using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _1.FileUpload.Models
{
    public class FileEntry
    {
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}