using DeliverIT.Common;
using DeliverIT.Models.Users.Couriers;
using System;
using DeliverIT.Models.Users.Clients;
using DeliverIT.Models.Users.Couriers.Abstract;
using DeliverIT.Common.Enums;
using DeliverIT.Models.Users.Clients.Abstract;
using DeliverIT.Models;

namespace DeliverIT.Contracts
{
    public interface IOrder
    {
        //todo: use const for calculating the price (isFragile, tax)

        Courier Courier { get; set; }
        Client Sender { get; set; }
        Client Receiver { get; set; }
        DateTime SendDate { get; set; }
        DateTime DueDate { get; set; }
        DeliveryType DeliveryType { get; set; }
        decimal DeliveryPrice { get; set; }
        OrderState OrderState{ get; set; }
        Address Address { get; set; } //needed to be fixed (string or not) 
        int InstanceId { get;}
        decimal CalculatePrice();
    }
}
