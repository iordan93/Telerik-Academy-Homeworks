namespace Forum.Models
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public class CommentGetModel
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "commentedBy")]
        public string Author { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime CreationDate { get; set; }
    }
}