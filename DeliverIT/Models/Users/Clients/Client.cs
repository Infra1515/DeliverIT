using System;
using System.Collections.Generic;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Models.Users.Abstract;
using DeliverIT.Models.Contracts;

namespace DeliverIT.Models.Users.Clients.Abstract
{
    public class Client : User, IClient
    {
        private IList<IOrder> ordersList;
        private ClientType clientType;
        private static int id = 0;
        public Client(string firstName, string lastName, string email, string phoneNumber,
                        int years, Address address, GenderType gender, ClientType clientType) 
            : base(firstName, lastName, email, phoneNumber, years, address, gender)
        {
            id++;
            //InstanceId = id;
            this.OrdersList = new List<IOrder>();
            this.ClientType = clientType;
        }

        public IList<IOrder> OrdersList { get => ordersList; set => ordersList = value; }
        public ClientType ClientType { get => clientType; set => clientType = value; }
        public int Id { get => id; }
        public void DisplayOrderList()
        {
            //method for displaying order list
        }

        public void ShowAllOrders(IList<IOrder> orders)
        {
            throw new NotImplementedException();
        }

        public void ShowReceivedOrders(IList<IOrder> orders)
        {
            throw new NotImplementedException();
        }

        public void ShowSentOrders(IList<IOrder> orders)
        {
            throw new NotImplementedException();
        }

        public void ShowExpectedSendOrders(IList<IOrder> orders)
        {
            throw new NotImplementedException();
        }

        public void ShowExpectedReceiveOrders(IList<IOrder> orders)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Client ID: {this.Id}" + base.ToString() + $"Client Type : {this.ClientType}";
        }
    }
}
