using DeliverIT.Common;
using System;
using DeliverIT.Common.Enums;
using DeliverIT.Models.Users;

namespace DeliverIT.Contracts
{
    public interface IOrder
    {
        ICourier Courier { get; set; }
        IClient Sender { get; set; }
        IClient Receiver { get; set; }
        DateTime SendDate { get; set; }
        DateTime DueDate { get; set; }
        DeliveryType DeliveryType { get; set; }
        decimal DeliveryPrice { get; set; }
        OrderState OrderState{ get; set; }
        IProduct Product { get; set; }
        decimal CalculatePrice();
        int PostalCode { get; }
        int Id { get; }
    }
}
