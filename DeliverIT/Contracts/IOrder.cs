using DeliverIT.Common;
using DeliverIT.Models;
using System;

namespace DeliverIT.Contracts
{
    public interface IOrder
    {

        //todo: use const for calculating the price (isFragile, tax)
        

        Courier Courier { get; set; }
        Sender Sender { get; set; }
        Receiver Receiver { get; set; }
        DateTime SendDate { get; set; }
        DateTime DueDate { get; set; }
        DeliveryType DeliveryType { get; set; }
        decimal DeliveryPrice { get; set; }
        bool IsDelivered { get; set; }
        Address Address { get; set; } //needed to be fixed (string or not) 
        decimal CalculatePrice();
    }
}
