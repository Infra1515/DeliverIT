using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Contracts;
using DeliverIT.Data.Models;

namespace DeliverIT.Core.Factories
{
    public class ProductFactory : IProductFactory
    {
        public IProduct CreateProduct(double x, double y, double z, bool isFragile, double weight, ProductType productType)
        {
            return new Product(x, y, z, isFragile, weight, productType);
        }
    }
}
