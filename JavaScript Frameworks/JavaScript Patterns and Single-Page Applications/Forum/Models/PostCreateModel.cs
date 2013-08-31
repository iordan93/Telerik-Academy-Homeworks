namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public class PostCreateModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "tags")]
        public ICollection<string> Tags { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}