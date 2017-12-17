using DeliverIT.Common.Enums;

namespace DeliverIT.Models
{
    public class Product
    {
        public string Name { get; set; }
        public bool IsFragile { get; set; }
        public double Weight { get; set; }
        public Size Dimensions { get; set; }
        public ProductType Type { get; set; }
    }
}
