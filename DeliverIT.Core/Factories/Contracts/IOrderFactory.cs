using System;
using DeliverIT.Data.Contracts;
using DeliverIT.Data.Common.Enums;

namespace DeliverIT.Core.Factories.Contracts
{
    public interface IOrderFactory
    {
        IOrder CreateOrder(ICourier courier, IClient sender, IClient receiver, DeliveryType deliveryType, DateTime sendDate, DateTime dueDate,
            OrderState orderState, IProduct product, int postalCode);
    }
}
