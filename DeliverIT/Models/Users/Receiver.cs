using DeliverIT.Common;
using DeliverIT.Contracts;
using System.Collections.Generic;

namespace DeliverIT.Models.Users
{
    public class Receiver : Client
    {
        private List<IOrder> pendingOrders;

        public Receiver(string firstName, string lastName, string password, string email, string phoneNumber,
                int years, Address address, GenderType gender) 
            : base(firstName, lastName, password, email, phoneNumber, years, address, gender)
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
