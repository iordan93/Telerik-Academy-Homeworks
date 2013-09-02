using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Forum.Models
{
    [DataContract]
    public class PostCreateModel
    {
        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }
    }
}