using DeliverIT.Common.Enums;
using DeliverIT.Models;

namespace DeliverIT.Contracts
{
    public interface IProduct
    {
        int Id { get; }
        bool IsFragile { get; }
        double Weight { get; }
        Dimensions Dimensions { get; set; }
        ProductType ProductType { get; set; }
        double Volume { get; set; }
        
    }
}
