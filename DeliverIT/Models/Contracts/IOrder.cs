﻿using DeliverIT.Common;
using DeliverIT.Models;
using System;
using DeliverIT.Models.Users.Clients;
using DeliverIT.Models.Users.Couriers.Abstract;
using DeliverIT.Common.Enums;

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
        OrderState OrderState{ get; set; }
        Address Address { get; set; } //needed to be fixed (string or not) 
        decimal CalculatePrice();
    }
}
