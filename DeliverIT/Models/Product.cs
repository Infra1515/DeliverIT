using DeliverIT.Common.Enums;

namespace DeliverIT.Models
{
    public class Product
    {
        private static int id = 0;
        private readonly int instanceId;
        public Product(double x, double y, double z, bool isFragile, double weight, ProductType productType)
        {
            id++;
            instanceId = id;
            this.Dimensions = new Dimensions(x, y, z);
            this.Volume = this.Dimensions.CalculateVolume();
            this.IsFragile = isFragile;
            this.Weight = weight;
            this.ProductType = productType;
        }

        public bool IsFragile { get; }

        public double Weight { get; }

        public Dimensions Dimensions { get; set; }

        private ProductType ProductType { get; set; }

        public double Volume { get; set; }

        public int InstanceId => instanceId;

        public override string ToString()
        {
            return $"Product ID: {this.InstanceId} -- " +
                $"Product Dimensions: {this.Dimensions.X} {this.Dimensions.Y} {this.Dimensions.Z} -- " +
                $"Is Fragile: {this.IsFragile} -- Weight: {this.Weight} -- Volume: {this.Volume}" +
                $"Product Type: {this.ProductType}";
        }
    }
}
