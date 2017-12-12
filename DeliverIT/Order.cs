namespace DeliverIT
{
    using DeliverIT.Common;
    using System;

    public class Order
    {
        private Courier courier;
        private Sender sender;
        private Receiver receiver;
        private DateTime sendDate;
        private DateTime reveiveDate;
        private Size size;
        private DeliveryType deliveryType;
        private decimal price;
        private static int id;
        private bool isFragile;
        private bool isPaid;
        private double weight;
        private string address; //needed to be fixed
    }
}
