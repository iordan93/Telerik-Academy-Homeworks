using System;
using System.Collections.Generic;
using System.Linq;
class Work : IComparable
{
    public string Name { get; set; }
    public ushort Rating { get; set; }

    public Work(string work)
    {
        string[] workSplit = work.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
        this.Name = workSplit[0];
        this.Rating = ushort.Parse(workSplit[1]);
    }

    // Needed for IComparable to work. The returned number must be negative
    public int CompareTo(object obj)
    {
        Work compareTo = obj as Work;
        return -this.Rating.CompareTo(compareTo.Rating);
    }
}

class Employee : IComparable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Work Work { get; set; }

    public Employee(string names, Work work)
    {
        string[] namesSplit = names.Split(' ');
        this.FirstName = namesSplit[0];
        this.LastName = namesSplit[1];
        this.Work = work;
    }

    public int CompareTo(object obj)
    {
        // Compare employees first by work, then by last name, then by first name
        Employee compareTo = obj as Employee;
        if (this.Work.CompareTo(compareTo.Work) == 0)
        {
            if (this.LastName.CompareTo(compareTo.LastName) == 0)
            {
                return this.FirstName.CompareTo(compareTo.FirstName);
            }
            else return this.LastName.CompareTo(compareTo.LastName);
        }
        else return this.Work.CompareTo(compareTo.Work);
    }

    // Write an employee ito the console
    public override string ToString()
    {
        return string.Format("{0} {1}", this.FirstName, this.LastName);
    }
}


class Employees
{
    static void Main()
    {

        int N = int.Parse(Console.ReadLine());
        List<Work> work = new List<Work>();
        for (int i = 1; i <= N; i++)
        {
            string workInput = Console.ReadLine();
            work.Add(new Work(workInput));
        }

        int M = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();
        for (int i = 1; i <= M; i++)
        {
            string employeeString = Console.ReadLine();
            string[] employeeSplit = employeeString.Split(new string[] { " - " }, StringSplitOptions.None);
            Work employeeWork = work.First(x => x.Name == employeeSplit[1]);
            employees.Add(new Employee(employeeSplit[0], employeeWork));
        }

        // Sort by using the custom IComparable
        employees.Sort();

        foreach (Employee employee in employees)
        {
            Console.WriteLine(employee.ToString());
        }
    }

}