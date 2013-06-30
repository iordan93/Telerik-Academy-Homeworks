namespace _2.FindProducts
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class FindProducts
    {
        private static OrderedBag<Product> products = new OrderedBag<Product>();

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();

            StreamReader productsFile = new StreamReader("../../products.txt");
            string product = productsFile.ReadLine();
            while (product != null)
            {
                string[] parts = product.Split(new char[] { '|' }).Select(x => x.Trim()).ToArray();

                string name = parts[0];
                decimal price = decimal.Parse(parts[1]);
                products.Add(new Product(name, price));

                product = productsFile.ReadLine();
            }

            StreamReader commandsFile = new StreamReader("../../searches.txt");
            string command = commandsFile.ReadLine();
            while (command != null)
            {
                string[] parts = command.Split(new char[] { '|' }).Select(x => x.Trim()).ToArray();

                decimal lowerBound = decimal.Parse(parts[0]);
                decimal upperBound = decimal.Parse(parts[1]);

                var items = products.Range(new Product("min", lowerBound), true, new Product("max", upperBound), true).Take(20);
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }

                command = commandsFile.ReadLine();
            }

            timer.Stop();
            Console.WriteLine(timer.Elapsed);
        }
    }
}