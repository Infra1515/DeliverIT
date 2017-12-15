namespace DeliverIT
{
    using DeliverIT.Common;
    using DeliverIT.Contracts;
    using System;

    public class Order : IOrder
    {
        private uint price;

        public Courier Courier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Sender Sender { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Receiver Receiver { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime SendDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime ReveiveDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
            price = 0;
            return price;

            //method for calculating order price (delivery type, country tax, size, isFragile)
        }
    }
}
