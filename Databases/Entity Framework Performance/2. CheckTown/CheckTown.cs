namespace _2.CheckTown
{
    using System;
    using System.Linq;
    using TelerikAcademyModel;

    public class CheckTown
    {
        public static void Main()
        {
            using (var telerikAcademy = new TelerikAcademyEntities())
            {
                // More than 500 queries
                var employees = telerikAcademy.Employees.ToList().
                    Select(x => x.Address).ToList().
                    Select(x => x.Town).ToList().
                    Where(x => x.Name == "Sofia").ToList();

                //// 1 query
                //var employees = telerikAcademy.Employees.
                //   Select(x => x.Address).
                //   Select(x => x.Town).
                //   Where(x => x.Name == "Sofia").ToList();
            }
        }
    }
}
