using System;
using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Models.Users.Clients;
using DeliverIT.Models.Users.Couriers.Abstract;
using DeliverIT.Common.Enums;
using DeliverIT.Models.Users.Clients.Abstract;

namespace DeliverIT.Models
{

    public class Order : IOrder
    {
        private DateTime sendDate;
        private DateTime dueDate;
        private static int id = 0;
        private readonly int instanceId;
        private readonly int postalCode;

        public Order(Courier courier, Client sender, Client receiver, DateTime sendDate, DateTime dueDate,
                 OrderState orderState, Address address, Product product, int postalCode)
        {
            Id += 1;
            instanceId = Id;
            this.Courier = courier;
            this.Sender = sender;
            this.Receiver = receiver;
            this.SendDate = sendDate;
            this.DueDate = dueDate;
            this.OrderState = orderState;
            this.Address = address;
            this.Product = product;
            this.postalCode = postalCode;
        }

        public Courier Courier { get; set; }
        public Client Sender { get; set; }
        public Client Receiver { get; set; }

        public Address Address { get; set; }
        public Product Product { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public decimal DeliveryPrice { get; set; }
        public static int Id { get { return id; } private set { id = value; } }
        public OrderState OrderState { get; set; }
        public int InstanceId => instanceId;

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

        public int PostalCode => postalCode;

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
            this.DeliveryPrice /= (decimal)this.Sender.ClientType; // change delivery price using client type coeff

            return this.DeliveryPrice;
        }

        public override string ToString()
        {
            return $"- Courier: {this.Courier.FirstName} {this.Courier.LastName}\n- " +
                   $"Sender: {this.Sender.FirstName} {this.Sender.LastName}\n- Receiver: {this.Receiver.FirstName} {this.Receiver.LastName}" +
                   $"\n- Send date: {this.SendDate}\n- Due date: {this.DueDate}" +
                   $"\n- Delivery price: {this.DeliveryPrice}\n- OrderState: {this.OrderState}" +
                   $"\n- Address: {this.Address.ToString()}\n- Product: {this.Product.ToString()}";
        }
    }
}
