using System.Collections;
using System.Net;
using System.Runtime.CompilerServices;

namespace DeliverIT
{
    using DeliverIT.Common;
    using DeliverIT.Contracts;
    using DeliverIT.Models;
    using System;

    public class Order : IOrder
    {
        private DateTime sendDate;
        private DateTime dueDate;
        private static int id = 0;

        public Order(Courier courier, Sender sender, Receiver receiver, DateTime sendDate, DateTime dueDate, 
             decimal deliveryPrice, bool isDelivered, Country address)
        {
            Id += 1;
            this.Courier = courier;
            this.Sender = sender;
            this.Receiver = receiver;
            this.SendDate = sendDate;
            this.DueDate = dueDate;
            this.DeliveryPrice = deliveryPrice;
            this.IsDelivered = isDelivered; //enum? deliveryState (delivered, not delivered, damaged, not accepted, lost.......)
            this.Address = address;
        }

        public Courier Courier { get; set; }
        public Sender Sender { get; set; }
        public Receiver Receiver { get; set; }

        public DateTime SendDate
        {
            get { return this.sendDate; }
            set
            {
                Validator.ValidateSendAndDueDate(value, Constants.InvalidSendDate);

                this.sendDate = value;
            }
        }
        public DateTime DueDate
        {
            get { return this.dueDate; }
            set
            {
                Validator.ValidateSendAndDueDate(value, Constants.InvalidDueDate);

                this.dueDate = value;
            }
        }
        public Country Address { get ; set ; }
        public Product Product { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public decimal DeliveryPrice { get; set; }
        public static int Id { get { return id; } private set { id = value; }}
        public bool IsDelivered { get ; set ; }

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
            this.DeliveryPrice /= (decimal)this.Sender.ClientType; // change delivery price using client type coeff

            return this.DeliveryPrice;

            //method for calculating order price (delivery type, country tax, size, isFragile)
        }
    }
}
