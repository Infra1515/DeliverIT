using System;
using System.Collections.Generic;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Models.Users.Abstract;

namespace DeliverIT.Models.Users.Clients.Abstract
{
    public class Client : User
    {
        private IList<IOrder> ordersList;
        private ClientType clientType;
        private static int id = 0;
        private int instanceId;
        public Client(string firstName, string lastName, string email, string phoneNumber,
                        int years, Address address, GenderType gender, ClientType clientType) 
            : base(firstName, lastName, email, phoneNumber, years, address, gender)
        {
            id += 1;
            InstanceId = id;
            this.OrdersList = new List<IOrder>();
            this.ClientType = clientType;
        }

        public IList<IOrder> OrdersList { get => ordersList; set => ordersList = value; }
        public ClientType ClientType { get => clientType; set => clientType = value; }
        public int InstanceId { get => instanceId; set => instanceId = value; }


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

        void ShowExpectedSendOrders(IList<IOrder> expectedSentOrders)
        {
            throw new NotImplementedException();
        }

        void ShowExpectedReceiveOrders(IList<IOrder> expectedReceiveOrders)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Client ID: {this.InstanceId}" + base.ToString() + $"Client Type : {this.ClientType}";
        }
    }
}
