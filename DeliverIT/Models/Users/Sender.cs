using DeliverIT.Common;
using DeliverIT.Contracts;
using System.Collections.Generic;

namespace DeliverIT.Models.Users
{
    public class Sender : Client
    {
        private List<IOrder> sendingOrders; // orders that are not received yet


        public Sender(string username, string firstName, string lastName, string password, string email, string phoneNumber,
                        int age, Address address, GenderType gender) 
            : base(username, firstName, lastName, password, email, phoneNumber, age, address, gender)
        {
            this.sendingOrders = new List<IOrder>();
        }

        public List<IOrder> SendingOrders { get => sendingOrders; set => sendingOrders = value; }

        void ShowSendingOrders()
        {
            //method for displaying sending orders
        }
    }
}
