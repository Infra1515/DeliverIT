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
        Size Size { get; set; }
        DeliveryType DeliveryType { get; set; }
        decimal Price { get; set; }
        int Id { get; set; }
        bool IsFragile { get; set; }
        bool IsDelivered { get; set; }
        double Weight { get; set; }
        Address Address { get; set; } //needed to be fixed (string or not) 
    }
}
