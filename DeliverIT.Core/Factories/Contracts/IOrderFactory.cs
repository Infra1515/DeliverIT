using System;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;

namespace DeliverIT.Core.Factories.Contracts
{
    public interface IOrderFactory
    {
        IOrder CreateOrder(ICourier courier, IClient sender, IClient receiver, DeliveryType deliveryType, DateTime sendDate, DateTime dueDate,
            OrderState orderState, IProduct product, int postalCode);
    }
}
