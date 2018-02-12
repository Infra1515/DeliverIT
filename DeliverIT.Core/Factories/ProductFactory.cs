using System;
using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Models;
using DeliverIT.Common.Enums;
using DeliverIT.Models.Countries;

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
