﻿using Bytes2you.Validation;
using DeliverIT.Data.Common;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Contracts;
using System;

namespace DeliverIT.Data.Models
{
    public class Order : IOrder
    {
        private DateTime sendDate;
        private DateTime dueDate;
        private static int id = 0;
        private readonly int postalCode;

        public Order(
            ICourier courier,
            IClient sender,
            IClient receiver,
            DeliveryType deliveryType,
            DateTime sendDate,
            DateTime dueDate,
            OrderState orderState,
            IProduct product,
            int postalCode)
        {
            Guard.WhenArgument(courier, "courier null").IsNull().Throw();
            Guard.WhenArgument(sender, "sender null").IsNull().Throw();
            Guard.WhenArgument(receiver, "receiver null").IsNull().Throw();
            Guard.WhenArgument(product, "product null").IsNull().Throw();

            this.Id = ++id;
            this.Courier = courier;
            this.Sender = sender;
            this.Receiver = receiver;
            this.DeliveryType = deliveryType;
            this.SendDate = sendDate;
            this.DueDate = dueDate;
            this.OrderState = orderState;
            this.Product = product;
            this.postalCode = postalCode;
            this.DeliveryType = deliveryType;
        }

        public int Id { get; protected set; }
        public ICourier Courier { get; set; }
        public IClient Sender { get; set; }
        public IClient Receiver { get; set; }
        public IProduct Product { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public decimal DeliveryPrice { get; set; }
        public int PostalCode => postalCode;
        public OrderState OrderState { get; set; }
        public DateTime SendDate
        {
            get
            {
                return this.sendDate;
            }
            set
            {
                this.sendDate = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
            set
            {
                this.dueDate = value;
            }
        }

        //method for calculating order price (delivery type, country tax, size, isFragile)
        public decimal CalculatePrice()
        {
            this.DeliveryPrice = Constants.PriceForKg;

            if (this.Product.Weight > 1)
            {
                this.DeliveryPrice += ((decimal)this.Product.Weight - 1) * Constants.PriceForKg; //used for pricing if weight is over 1kg
            }

            if (this.Product.IsFragile)
            {
                this.DeliveryPrice *= Constants.FragileCoefficient; //used for pricing if fragile
            }

            this.DeliveryPrice *= (decimal)this.DeliveryType; // multiply the price for delivery using express/standart delivery coefficient
            this.DeliveryPrice *= this.Receiver.Address.Country.Tax; // multiply the price using country tax

            return this.DeliveryPrice;
        }

        public override string ToString()
        {
            return $"- Courier: {this.Courier.FirstName} {this.Courier.LastName}\n" +
                   $"- Sender: {this.Sender.FirstName} {this.Sender.LastName}\n" +
                   $"- Receiver: {this.Receiver.FirstName} {this.Receiver.LastName}\n" +
                   $"- Send date: {this.SendDate}\n- Due date: {this.DueDate}\n" +
                   $"- Delivery price: {this.CalculatePrice()}\n" +
                   $"- OrderState: {this.OrderState}\n" +
                   $"- Delivery Address:\n" +
                   $"{this.Receiver.Address.ToString()}\n" +
                   $"- Product: {this.Product.ToString()}\n";
        }
    }
}