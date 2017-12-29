using DeliverIT.Common;
using System;
using DeliverIT.Common.Enums;
using DeliverIT.Models;
using DeliverIT.Models.Users;

namespace DeliverIT.Contracts
{
    public interface IOrder
    {
        Courier Courier { get; set; }
        Client Sender { get; set; }
        Client Receiver { get; set; }
        DateTime SendDate { get; set; }
        DateTime DueDate { get; set; }
        DeliveryType DeliveryType { get; set; }
        decimal DeliveryPrice { get; set; }
        OrderState OrderState{ get; set; }
        Address Address { get; set; }
        IProduct Product { get; set; }
        decimal CalculatePrice();
        int PostalCode { get; }
        int Id { get; }
    }
}
