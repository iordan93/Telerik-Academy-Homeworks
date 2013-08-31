namespace Forum.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class UserRegisteredModel
    {
        [DataMember(Name="username")]
        public string Username { get; set; }

        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }
    }
}