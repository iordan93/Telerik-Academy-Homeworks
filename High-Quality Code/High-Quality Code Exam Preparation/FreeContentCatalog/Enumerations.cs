namespace FreeContentCatalog
{
    using System;
    using System.Linq;

    public enum CommandType
    {
        AddBook,
        AddMovie, 
        AddSong,
        AddApplication,
        Update, 
        Find
    }

    public enum ContentType
    {
        Book,
        Movie,
        Song,
        Application
    }

    public enum CommandAttributes
    {
        Title,
        Author,
        Size,
        Url
    }
}
