namespace Forum.Models
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public class CommentCreateModel
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}