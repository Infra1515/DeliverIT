using System.Collections;
using System.Net;

namespace DeliverIT
{
    using DeliverIT.Common;
    using DeliverIT.Contracts;
    using DeliverIT.Models;
    using System;
    public class Order : IOrder
    {
        private decimal priceForDelivery;

        public Order(Courier courier, Sender sender, Receiver receiver, DateTime sendDate, DateTime dueDate, 
            DeliveryType deliveryType, decimal price, int id, bool isFragile, bool isDelivered, Address address)
        {
            this.Courier = courier;
            this.Sender = sender;
            this.Receiver = receiver;
            this.SendDate = sendDate;
            this.DueDate = dueDate;
            this.DeliveryType = deliveryType;
            this.Id = id;
            this.IsDelivered = isDelivered;
            this.Address = address;
        }

        public Courier Courier { get; set; }
        public Sender Sender { get; set; }
        public Receiver Receiver { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime DueDate { get; set; }
        public DeliveryType DeliveryType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal DeliveryPrice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDelivered { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Address Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Product Product { get; set; }

        public decimal CalculatePrice()
        {
            priceForDelivery = Constants.PriceForKg;

            if (this.Product.Weight > 1)
            {
                priceForDelivery += ((decimal)this.Product.Weight - 1) * Constants.PriceForKg;
            }

            priceForDelivery *= (decimal)this.DeliveryType; // multiply the price for delivery using express/standart delivery coefficient
            priceForDelivery *= this.Receiver.Country.Tax; // multiply the price using tax of country

            return priceForDelivery;

            //method for calculating order price (delivery type, country tax, size, isFragile)
        }
    }
}
