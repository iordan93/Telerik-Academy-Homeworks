namespace SchoolSystem
{
    using System;

    public static class IdManager
    {
        public const int MinStudentId = 10000;
        public const int MaxStudentId = 99999;

        private static int currentStudentId = MinStudentId;

        public static int CurrentStudentId
        {
            get
            {
                if (currentStudentId < MinStudentId || currentStudentId > MaxStudentId)
                {
                    throw new ArgumentOutOfRangeException("Student Id", string.Format("The current student ID is out of range. It must be between {0} and {1}", MinStudentId, MaxStudentId));
                }

                int currentId = currentStudentId;
                currentStudentId++;
                return currentId;
            }
        }
    }
}
