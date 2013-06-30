using System;

public class Salaries
{
    private static long[] salaries;

    public static void Main()
    {
        int numberOfEmployees = int.Parse(Console.ReadLine());
        bool[,] hasServants = new bool[numberOfEmployees, numberOfEmployees];
        salaries = new long[numberOfEmployees];

        for (int i = 0; i < numberOfEmployees; i++)
        {
            string currentEmployee = Console.ReadLine();
            for (int j = 0; j < numberOfEmployees; j++)
            {
                if (currentEmployee[j] == 'Y')
                {
                    hasServants[i, j] = true;
                }
            }
        }

        long salariesSum = 0;
        for (int employee = 0; employee < numberOfEmployees; employee++)
        {
            salariesSum += GetEmployeeSalary(employee, hasServants);
        }

        Console.WriteLine(salariesSum);
    }

    private static long GetEmployeeSalary(int employeeIndex, bool[,] hasServants)
    {
        if (salaries[employeeIndex] != 0)
        {
            return salaries[employeeIndex];
        }

        long salary = 0;
        for (int i = 0; i < hasServants.GetLength(1); i++)
        {
            if (hasServants[employeeIndex, i])
            {
                salary += GetEmployeeSalary(i, hasServants);
            }
        }

        if (salary == 0)
        {
            salary = 1;
        }

        salaries[employeeIndex] = salary;
        return salary;
    }
}
