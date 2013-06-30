namespace _2.Products
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price, string vendor, string barcode = "0")
        {
            this.Name = name;
            this.Price = price;
            this.Vendor = vendor;
            this.Barcode = barcode;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public string Vendor { get; private set; }

        public string Barcode { get; private set; }

        public int CompareTo(Product other)
        {
            return string.Compare(this.Name, other.Name);
        }

        public override string ToString()
        {
            return string.Format("{0} : {1:F2}, Vendor: {2}, Barcode: {3}", this.Name, this.Price, this.Vendor, this.Barcode);
        }
    }
}
