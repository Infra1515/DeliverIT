using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Models;

namespace DeliverIT.Data.Contracts
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
