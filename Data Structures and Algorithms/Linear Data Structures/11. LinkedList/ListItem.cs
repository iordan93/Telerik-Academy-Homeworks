namespace LinkedList
{
    using System;

    public class ListItem<T>
    {
        public ListItem(T value)
            : this(value, null, null)
        {
        }

        public ListItem(T value, ListItem<T> nextItem, ListItem<T> previousItem)
        {
            this.Value = value;
            this.NextItem = nextItem;
            this.PreviousItem = previousItem;
        }

        public T Value { get; set; }

        public ListItem<T> NextItem { get; set; }

        public ListItem<T> PreviousItem { get; set; }
    }
}
