using System;
using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Models;
using DeliverIT.Common.Enums;
using DeliverIT.Models.Users;

namespace DeliverIT.Core.Factories
{
    public interface IDeliverITFactory
    {
        IOrder CreateOrder(ICourier courier, IClient sender, IClient receiver, DeliveryType deliveryType, DateTime sendDate, DateTime dueDate,
                           OrderState orderState, IProduct product, int postalCode);

        IProduct CreateProduct(double x, double y, double z, bool isFragile, double weight,
            ProductType productType);

        IAddress CreateAddress(ICountry country, string streetName, string streetNumber, string city);
    }
}
