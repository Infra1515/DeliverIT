using Bytes2you.Validation;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;

namespace DeliverIT.Models
{
    public class Product : IProduct
    {
        private static int id = 0;
        private double volume;

        public Product(
            double x, 
            double y, 
            double z, 
            bool isFragile, 
            double weight, 
            ProductType productType)
        {
            Guard.WhenArgument(weight, "weight not negative").IsLessThanOrEqual(0).Throw();

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

        public double Volume
        {
            get { return this.volume; }
            set
            {
                Guard.WhenArgument(value, "volume").IsLessThanOrEqual(0).Throw();
                this.volume = value;
            }
        }

        public int Id { get => id; }

        public decimal DeliveryPrice { get; set; }

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
