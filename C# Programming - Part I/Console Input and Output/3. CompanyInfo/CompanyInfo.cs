using System;

    class CompanyInfo
    {
        static void Main()
        {
            Console.Write("Company name: ");
            string companyName = Console.ReadLine();
            Console.Write("Company address: ");
            string companyAddress = Console.ReadLine();
            Console.Write("Company phone number: ");
            ulong companyPhone = ulong.Parse(Console.ReadLine());
            Console.Write("Company fax number: ");
            ulong companyFax = ulong.Parse(Console.ReadLine());
            Console.Write("Company website: ");
            string companyWebsite = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Manager's first name: ");
            string managerFirstName = Console.ReadLine();
            Console.Write("Manager's last name: ");
            string managerLastName = Console.ReadLine();
            Console.Write("Manager's age: ");
            byte managerAge = byte.Parse(Console.ReadLine());
            Console.Write("Manager's phone number: ");
            string managerPhone = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Company name: {0}", companyName);
            Console.WriteLine("Company address: {0}", companyAddress);
            Console.WriteLine("Company phone number: {0}", companyPhone);
            Console.WriteLine("Company fax number: {0}", companyFax);
            Console.WriteLine("Company website: {0}", companyWebsite);
            Console.WriteLine();
            Console.WriteLine("Manager's first name: {0}", managerFirstName);
            Console.WriteLine("Manager's last name: {0}", managerLastName);
            Console.WriteLine("Manager's age: {0}", managerAge);
            Console.WriteLine("Manager's phone number: {0}", managerPhone);
        }
    }
