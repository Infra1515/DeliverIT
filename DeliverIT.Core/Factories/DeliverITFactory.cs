using System;
using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Models;
using DeliverIT.Common.Enums;
using DeliverIT.Models.Countries;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Factories
{
    public class DeliverITFactory : IDeliverITFactory
    {
        public IOrder CreateOrder(ICourier courier, IClient sender, IClient receiver, DeliveryType deliveryType, DateTime sendDate, DateTime dueDate,
                           OrderState orderState, IProduct product, int postalCode)
        {
            return new Order(courier, sender, receiver, deliveryType, sendDate, dueDate, orderState, product, postalCode);
        }

        public IProduct CreateProduct(double x, double y, double z, bool isFragile, double weight, ProductType productType)
        {
            return new Product(x, y, z, isFragile, weight, productType);
        }

        public IAddress CreateAddress(ICountry country, string streetName, string streetNumber, string city)
        {
            return new Address(country, streetName, streetNumber, city);
        }

        public ICountry CreateCountry(string countryName)
        {
            switch ((CountryType)Enum.Parse(typeof(CountryType), countryName))
            {
                case CountryType.Bulgaria:
                    return new Bulgaria();

                case CountryType.Serbia:
                    return new Serbia();

                case CountryType.Russia:
                    return new Russia();

                default:
                    throw new ArgumentException("We don't ship to this country yet!");
            }
        }
    }
}
