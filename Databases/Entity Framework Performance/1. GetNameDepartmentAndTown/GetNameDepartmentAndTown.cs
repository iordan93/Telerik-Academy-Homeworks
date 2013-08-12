namespace _1.GetNameDepartmentAndTown
{
    using System;
    using System.Linq;
    using TelerikAcademyModel;

    public class GetNameDepartmentAndTown
    {
        public static void Main()
        {
            using (var telerikAcademy = new TelerikAcademyEntities())
            {
                // 338 queries
                foreach (var employee in telerikAcademy.Employees)
                {
                    Console.WriteLine("{0} | {1} | {2}", employee.FirstName + " " + employee.LastName, employee.Department.Name, employee.Address.Town.Name);
                }

                //// 1 query
                //foreach (var employee in telerikAcademy.Employees.Include("Department").Include("Address.Town"))
                //{
                //    Console.WriteLine("{0} | {1} | {2}", employee.FirstName + " " + employee.LastName, employee.Department.Name, employee.Address.Town.Name);
                //}
            }
        }
    }
}
