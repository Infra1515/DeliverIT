using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Contracts;

namespace DeliverIT.Core.Factories
{
    public interface IProductFactory
    {
        IProduct CreateProduct(double x, double y, double z, bool isFragile, double weight,
            ProductType productType);
    }
}
