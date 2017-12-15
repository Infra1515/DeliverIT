namespace DeliverIT
{
    using DeliverIT.Common;
    using DeliverIT.Contracts;
    using System;

    public class Order : IOrder
    {
        private uint priceForDelivery;

        public Order(Courier courier, Sender sender, Receiver receiver, DateTime sendDate, DateTime receiveDate, 
            DeliveryType deliveryType, decimal price, int id, bool isFragile, bool isPaid, double weight, string address)
        {
            this.Courier = courier;
            this.Sender = sender;
            this.Receiver = receiver;
            this.SendDate = sendDate;
            this.ReceiveDate = receiveDate;
            this.DeliveryType = deliveryType;
            this.Price = price;
            this.Id = id;
            this.IsFragile = isFragile;
            this.IsPaid = isPaid;
            this.Weight = weight;
            this.Address = address;
        }

        public Courier Courier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Sender Sender { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Receiver Receiver { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime SendDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime ReceiveDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Size Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DeliveryType DeliveryType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsFragile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsPaid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Weight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public uint CalculatePrice()
        {
            priceForDelivery = 0;
            return priceForDelivery;

            //method for calculating order price (delivery type, country tax, size, isFragile)
        }
    }
}
