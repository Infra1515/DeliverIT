using DeliverIT.Common;
using DeliverIT.Models.Users;
using System;
using DeliverIT.Models.Users.Clients;
using DeliverIT.Models.Users.Couriers.Abstract;
using DeliverIT.Common.Enums;
using DeliverIT.Models.Users.Clients.Abstract;
using DeliverIT.Models;
using DeliverIT.Models.Contracts;

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
