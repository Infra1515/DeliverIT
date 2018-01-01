using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;

namespace DeliverIT.Models
{
    public class Product : IProduct
    {
        private static int id = 0;
        private decimal deliveryPrice;
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

        public decimal DeliveryPrice { get => deliveryPrice; set => deliveryPrice = value; }

        public override string ToString()
        {
            return $"\r\n- ID: {this.Id}\n" +
                $" -- Dimensions: {this.Dimensions.X} x {this.Dimensions.Y} x {this.Dimensions.Z}\n" +
                $" -- Is Fragile: {this.IsFragile}\n" +
                $" -- Weight: {this.Weight}\n" +
                $" -- Volume: {this.Volume}\n" +
                $" -- Type: {this.ProductType}\n\n";
        }
    }
}
