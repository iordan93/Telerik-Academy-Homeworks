namespace _2.WebChat.Models
{
    using System;

    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        public User Author { get; set; }
    }
}