namespace Forum.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class UserLoggedInModel
    {
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "sessionKey")]        
        public string SessionKey { get; set; }
    }
}