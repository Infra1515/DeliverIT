using DeliverIT.Common.Enums;
using DeliverIT.Contracts;

namespace DeliverIT.Models
{
    public class Product : IProduct
    {
        private static int id = 0;
        public Product(double x, double y, double z, bool isFragile, double weight, ProductType productType)
        {
            id++;
            this.Dimensions = new Dimensions(x, y, z);
            this.Volume = this.Dimensions.CalculateVolume();
            this.IsFragile = isFragile;
            this.Weight = weight;
            this.ProductType = productType;
        }

        public bool IsFragile { get; }

        public double Weight { get; }

        public Dimensions Dimensions { get; set; }

        public ProductType ProductType { get; set; }

        public double Volume { get; set; }

        public int Id { get => id; }

        public override string ToString()
        {
            return $"- Product ID: {this.Id}\n" +
                $" -- Product Dimensions: {this.Dimensions.X} {this.Dimensions.Y} {this.Dimensions.Z}\n" +
                $" -- Is Fragile: {this.IsFragile}\n" +
                $" -- Weight: {this.Weight}\n" +
                $" -- Volume: {this.Volume}\n" +
                $" -- Product Type: {this.ProductType}\n\n";
        }
    }
}
