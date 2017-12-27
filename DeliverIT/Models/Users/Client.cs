using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using System;
using System.Collections.Generic;

namespace DeliverIT.Models.Users
{
    public class Client : User
    {
        private IList<IOrder> ordersList;
        private ClientType clientType;
        private static int id = 0;

        public IList<IOrder> OrdersList { get => ordersList; set => ordersList = value; }
        public ClientType ClientType { get => clientType; set => clientType = value; }

        public Client(string firstName, string lastName, string password, string email, string phoneNumber,
                        int years, Address address, GenderType gender) 
            : base(firstName, lastName, password, UserRole.Normal, email, phoneNumber, years, address, gender)
        {
            id += 1;
            this.OrdersList = new List<IOrder>();
        }

        void DisplayOrderList()
        {
            //method for displaying order list
        }

        void ShowAllOrders(IList<IOrder> allOrders)
        {
            throw new NotImplementedException();
        }

        void ShowReceivedOrders(IList<IOrder> allReceivedOrders)
        {
            throw new NotImplementedException();
        }

        void ShowSentOrders(IList<IOrder> allSentOrders)
        {
            throw new NotImplementedException();
        }
    }
}
