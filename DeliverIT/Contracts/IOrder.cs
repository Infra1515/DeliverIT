using DeliverIT.Data.Common.Enums;
using System;

namespace DeliverIT.Data.Contracts
{
    public interface IOrder
    {
        ICourier Courier { get; set; }
        IClient Sender { get; set; }
        IClient Receiver { get; set; }
        DateTime SendDate { get; set; }
        DateTime DueDate { get; set; }
        DeliveryType DeliveryType { get; set; }
        decimal DeliveryPrice { get; }
        OrderState OrderState{ get; set; }
        IProduct Product { get; set; }
        decimal CalculatePrice();
        int PostalCode { get; }
        int Id { get; }
    }
}
