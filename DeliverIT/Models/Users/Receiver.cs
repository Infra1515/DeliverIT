using DeliverIT.Common;
using DeliverIT.Contracts;
using System.Collections.Generic;

namespace DeliverIT.Models.Users
{
    public class Receiver : Client
    {
        private List<IOrder> pendingOrders;

        public Receiver(string username, string firstName, string lastName, string password, string email, string phoneNumber,
                int age, Address address, GenderType gender) 
            : base(username, firstName, lastName, password, email, phoneNumber, age, address, gender)
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
