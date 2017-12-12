using DeliverIT.Common;
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
        DateTime ReveiveDate { get; set; }
        Size Size { get; set; }
        DeliveryType DeliveryType { get; set; }
        decimal Price { get; set; }
        int Id { get; set; }
        bool IsFragile { get; set; }
        bool IsPaid { get; set; }
        double Weight { get; set; }
        string Address { get; set; } //needed to be fixed (string or not) 
    }
}
