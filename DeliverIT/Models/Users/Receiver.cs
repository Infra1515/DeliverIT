namespace DeliverIT
{
    using DeliverIT.Common;
    using DeliverIT.Contracts;
    using System;
    using System.Collections.Generic;

    public class Receiver : Client
    {
        private List<IOrder> pendingOrders;

        public Receiver(string firstName, string lastName, string email, string phoneNumber,
                int years, Country country, GenderType gender) 
            : base(firstName, lastName, email, phoneNumber, years, country, gender)
        {
            this.PendingOrders = new List<IOrder>();
        }

        public List<IOrder> PendingOrders { get => pendingOrders; set => pendingOrders = value; }

        void ShowPendingOrders()
        {
            //method for showing pending orders 
        }
    }
}
