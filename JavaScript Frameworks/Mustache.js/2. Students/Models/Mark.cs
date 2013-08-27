namespace _2.StudentsServices.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract(Name = "mark")]
    public class Mark
    {
        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "score")]
        public double Score { get; set; }
    }
}