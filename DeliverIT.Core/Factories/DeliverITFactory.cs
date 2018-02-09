﻿using System;
using DeliverIT.Common;
using DeliverIT.Models.Users;
using DeliverIT.Contracts;
using DeliverIT.Models;
using DeliverIT.Common.Enums;

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
    }
}
