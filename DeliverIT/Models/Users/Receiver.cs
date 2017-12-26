using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Models;
using DeliverIT.Models.Users;
using System.Collections.Generic;

namespace DeliverIT
{
    public class Receiver : Client
    {
        private List<IOrder> pendingOrders;

        public Receiver(string firstName, string lastName, string email, string phoneNumber,
                int years, Address address, GenderType gender) 
            : base(firstName, lastName, email, phoneNumber, years, address, gender)
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
