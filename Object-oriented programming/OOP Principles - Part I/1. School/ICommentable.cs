using System;

namespace _1.School
{
    interface ICommentable
    {
        // The interface contains a comment (string) and two methods to add the comment
        // All classes which implement ICommentable must have the property and implement the methods
        string Comment
        {
            get;
            set;
        }

        void AddComment(string comment);
    }
}
