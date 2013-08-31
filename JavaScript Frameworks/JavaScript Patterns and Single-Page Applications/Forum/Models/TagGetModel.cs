namespace Forum.Models
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;
    using ForumModels;

    [DataContract]
    public class TagGetModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        public static TagGetModel FromTag(Tag tag)
        {
            TagGetModel tagModel = new TagGetModel()
            {
                Id = tag.Id,
                Name = tag.Name
            };

            return tagModel;
        }
    }
}