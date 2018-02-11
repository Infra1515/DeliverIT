using System;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Models;

namespace DeliverIT.Core.Factories
{
    public class OrderFactory : IOrderFactory
    {
        public IOrder CreateOrder(ICourier courier, IClient sender, IClient receiver, DeliveryType deliveryType, DateTime sendDate, DateTime dueDate,
            OrderState orderState, IProduct product, int postalCode)
        {
            return new Order(courier, sender, receiver, deliveryType, sendDate, dueDate, orderState, product, postalCode);
        }
    }
}
