namespace StudentsModels
{
    using System;

    public class Mark
    {
        public int Id { get; set; }

        public virtual Student Student { get; set; }

        public string Subject { get; set; }

        public double Value { get; set; }
    }
}