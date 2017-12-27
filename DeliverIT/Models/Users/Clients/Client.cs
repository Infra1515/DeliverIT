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
        private readonly IList<IOrder> ordersList;
        private ClientType clientType;
        private static int id = 0;
        public Client(string firstName, string lastName, string email, string phoneNumber,
                        int years, Address address, GenderType gender, ClientType clientType) 
            : base(firstName, lastName, email, phoneNumber, years, address, gender)
        {
            id++;
            this.ordersList = new List<IOrder>();
            this.ClientType = clientType;
        }

        public IList<IOrder> OrdersList { get => new List<IOrder>(ordersList); }
        public ClientType ClientType { get => clientType; protected set => clientType = value; }
        public int Id { get => id; }
        public void DisplayOrderList()
        {
            Console.WriteLine($"Total orders for {this.FirstName} {this.LastName}");
            foreach(var order in this.OrdersList)
            {
                Console.WriteLine("--------------");
                Console.WriteLine(order.ToString());
                Console.WriteLine("---------------");
            }
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
