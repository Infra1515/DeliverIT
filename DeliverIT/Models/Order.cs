using System;
using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Common.Enums;
using DeliverIT.Models.Users;

namespace DeliverIT.Models
{
    public class Order : IOrder
    {
        private DateTime sendDate;
        private DateTime dueDate;
        private static int id = 0;
        private readonly int postalCode;

        public Order(ICourier courier, IClient sender, IClient receiver, DateTime sendDate, DateTime dueDate,
                 OrderState orderState, IProduct product, int postalCode)
        {
            this.Id = id++;
            this.Courier = courier;
            this.Sender = sender;
            this.Receiver = receiver;
            this.SendDate = sendDate;
            this.DueDate = dueDate;
            this.OrderState = orderState;
            this.Product = product;
            this.postalCode = postalCode;
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
                Validator.ValidateSendDate(value, Constants.InvalidSendDate);
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
                Validator.ValidateSendDate(value, Constants.InvalidDueDate);
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
            //this.DeliveryPrice /= (decimal)this.Sender.ClientType; // change delivery price using client type coeff

            return this.DeliveryPrice;
        }

        public override string ToString()
        {
            return $"- Courier: {this.Courier.FirstName} {this.Courier.LastName}\n" +
                   $"- Sender: {this.Sender.FirstName} {this.Sender.LastName}\n" +
                   $"- Receiver: {this.Receiver.FirstName} {this.Receiver.LastName}\n" +
                   $"- Send date: {this.SendDate}\n- Due date: {this.DueDate}\n" +
                   $"- Delivery price: {this.CalculatePrice()}\n- OrderState: {this.OrderState}\n" +
                   $"- Delivery Address:\n" +
                   $"{this.Receiver.Address.ToString()}\n" +
                   $"- Product: {this.Product.ToString()}\n";
        }
    }
}
