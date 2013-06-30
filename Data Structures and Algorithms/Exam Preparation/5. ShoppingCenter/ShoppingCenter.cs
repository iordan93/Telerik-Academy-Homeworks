namespace _5.ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class ShoppingCenterInterface
    {
        private static ShoppingCenter shoppingCenter = new ShoppingCenter();
        private static StringBuilder output = new StringBuilder();

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                ParseCommand(command);
            }

            Console.Write(output.ToString());
        }

        public static void ParseCommand(string command)
        {
            int firstSpace = command.IndexOf(' ');
            string[] commandParams = command.Substring(firstSpace + 1).Split(';');

            switch (command.Substring(0, firstSpace))
            {
                case "AddProduct":
                    output.AppendLine(shoppingCenter.AddProduct(commandParams[0], double.Parse(commandParams[1]), commandParams[2]));
                    break;
                case "DeleteProducts":
                    if (commandParams.Length == 1)
                    {
                        output.AppendLine(shoppingCenter.DeleteProducts(commandParams[0]));
                    }
                    else
                    {
                        output.AppendLine((shoppingCenter.DeleteProducts(commandParams[0], commandParams[1])));
                    }

                    break;
                case "FindProductsByName":
                    output.Append(shoppingCenter.FindProductsByName(commandParams[0]));
                    break;
                case "FindProductsByPriceRange":
                    output.Append(shoppingCenter.FindProductsByPriceRange(double.Parse(commandParams[0]), double.Parse(commandParams[1])));
                    break;
                case "FindProductsByProducer":
                    output.Append(shoppingCenter.FindProductsByProducer(commandParams[0]));
                    break;
            }
        }
    }

    public class ShoppingCenter
    {
        private readonly MultiDictionary<string, Product> productsByName =
            new MultiDictionary<string, Product>(true);

        private readonly MultiDictionary<string, Product> productsByProducer =
            new MultiDictionary<string, Product>(true);

        private readonly MultiDictionary<Tuple<string, string>, Product> productsByNameAndProducer =
            new MultiDictionary<Tuple<string, string>, Product>(true);

        private readonly OrderedMultiDictionary<double, Product> productsByPrice =
            new OrderedMultiDictionary<double, Product>(true, (x, y) => x.CompareTo(y), (x, y) => 0);

        public string AddProduct(string name, double price, string producer)
        {
            Product newProduct = new Product(name, price, producer);

            this.productsByName[name].Add(newProduct);
            this.productsByProducer[producer].Add(newProduct);
            this.productsByNameAndProducer[Tuple.Create<string, string>(name, producer)].Add(newProduct);
            this.productsByPrice[price].Add(newProduct);

            return "Product added";
        }

        public string DeleteProducts(string name, string producer)
        {
            var pair = Tuple.Create<string, string>(name, producer);
            ICollection<Product> productsToDelete = this.productsByNameAndProducer[pair];
            int productsCount = productsToDelete.Count;

            foreach (var product in productsToDelete)
            {
                this.productsByName[product.Name].Remove(product);
                this.productsByProducer[product.Producer].Remove(product);
                this.productsByPrice[product.Price].Remove(product);
            }

            this.productsByNameAndProducer.Remove(pair);

            if (productsCount == 0)
            {
                return "No products found";
            }
            else
            {
                return string.Format("{0} products deleted", productsCount);
            }
        }

        public string DeleteProducts(string producer)
        {
            ICollection<Product> productsToDelete = this.productsByProducer[producer];
            int productsCount = productsToDelete.Count;

            foreach (var product in productsToDelete)
            {
                this.productsByName[product.Name].Remove(product);
                this.productsByNameAndProducer[Tuple.Create<string, string>(product.Name, product.Producer)].Remove(product);
                this.productsByPrice[product.Price].Remove(product);
            }

            this.productsByProducer.Remove(producer);

            if (productsCount == 0)
            {
                return "No products found";
            }
            else
            {
                return string.Format("{0} products deleted", productsCount);
            }
        }

        public string FindProductsByName(string name)
        {
            var products = this.productsByName[name].OrderBy(x => x.Producer);

            if (!products.Any())
            {
                return "No products found\r\n";
            }

            StringBuilder result = new StringBuilder();
            foreach (var product in products)
            {
                result.AppendLine(product.ToString());
            }

            return result.ToString();
        }

        public string FindProductsByPriceRange(double low, double high)
        {
            var products = this.productsByPrice.Range(low, true, high, true).Values.OrderBy(x => x.Name).ThenBy(x => x.Producer);
            if (!products.Any())
            {
                return "No products found\r\n";
            }

            StringBuilder result = new StringBuilder();

            foreach (var product in products)
            {
                result.AppendLine(product.ToString());
            }

            return result.ToString();
        }

        public string FindProductsByProducer(string producer)
        {
            var products = this.productsByProducer[producer].OrderBy(x => x.Name);

            if (!products.Any())
            {
                return "No products found\r\n";
            }

            StringBuilder result = new StringBuilder();
            foreach (var product in products)
            {
                result.AppendLine(product.ToString());
            }

            return result.ToString();
        }
    }

    public class Product : IComparable<Product>
    {
        public Product(string name, double price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Producer { get; set; }

        public int CompareTo(Product other)
        {
            if (this.Name == other.Name)
            {
                if (this.Price == other.Price)
                {
                    return this.Producer.CompareTo(other.Producer);
                }

                return this.Price.CompareTo(other.Price);
            }

            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
        }
    }
}