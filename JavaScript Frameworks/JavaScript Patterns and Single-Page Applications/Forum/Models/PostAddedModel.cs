using System.Runtime.Serialization;

namespace Forum.Models
{
    [DataContract]
    public class PostAddedModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
    }
}