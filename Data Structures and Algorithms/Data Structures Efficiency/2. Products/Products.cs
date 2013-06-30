namespace _2.Products
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class Products
    {
        private static readonly OrderedMultiDictionary<decimal, Product> productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            StreamReader inputFile = new StreamReader("../../input.txt");
            Console.SetIn(inputFile);

            StringBuilder output = new StringBuilder();
            string line = line = Console.ReadLine();

            while (line != null)
            {
                var parts = line.Split(new[] { ' ' }, 2);
                var name = parts[0];
                var parameters = parts[1].Split(';');

                string result = null;

                switch (name)
                {
                    case "Add":
                        result = AddProduct(name: parameters[0], price: decimal.Parse(parameters[1]), vendor: parameters[2]);
                        break;

                    case "Find":
                        result = FindProducts(decimal.Parse(parameters[0]), decimal.Parse(parameters[1]));
                        break;

                    default:
                        throw new InvalidOperationException("The given command is invalid.");
                }

                output.AppendLine(result);

                line = Console.ReadLine();
            }

            Console.Write(output.ToString());
        }

        private static string FindProducts(decimal minPrice, decimal maxPrice)
        {
            var result = productsByPrice.Range(minPrice, true, maxPrice, true);
            result.Values.OrderBy(p => p.Price);

            if (result.Count == 0)
            {
                throw new ArgumentException("There are no products within the given range.");
            }

            return string.Join(Environment.NewLine, result);
        }

        private static string AddProduct(string name, decimal price, string vendor)
        {
            var product = new Product(name, price, vendor);
            productsByPrice[price].Add(product);

            return "Product added.";
        }
    }
}