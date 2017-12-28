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
        private ClientType clientType;
        private static int id = 0;
        public Client(string firstName, string lastName, string email, string phoneNumber,
                        int years, Address address, GenderType gender, ClientType clientType, string userName) 
            : base(firstName, lastName, email, phoneNumber, years, address, gender, userName)
        {
            id++;
            this.ClientType = clientType;
        }

        public ClientType ClientType { get => clientType; set => clientType = value; }

        public int Id { get => id; }


        public void ShowAllNotPendingOrders(IList<IOrder> orders)
        {
            foreach(var order in this.OrdersList)
            {
                if(order.OrderState == OrderState.Delivered)
                {
                    Console.WriteLine(order.ToString());
                }
            }
        }

        public void ShowReceivedOrders(IList<IOrder> orders)
        {
            foreach(var order in this.OrdersList)
            {
                if(order.OrderState == OrderState.Delivered && 
                    order.Receiver == this)
                {
                    Console.WriteLine(order.ToString());
                }
            }
        }

        public void ShowSentOrders(IList<IOrder> orders)
        {
            foreach (var order in this.OrdersList)
            {
                if (order.OrderState == OrderState.Delivered &&
                    order.Sender == this)
                {
                    Console.WriteLine(order.ToString());
                }
            }
        }

        public void ShowExpectedSendOrders(IList<IOrder> orders)
        {
            foreach (var order in this.OrdersList)
            {
                if (order.OrderState == OrderState.NotDelivered &&
                    order.Sender == this)
                {
                    Console.WriteLine(order.ToString());
                }
            }
        }

        public void ShowExpectedReceiveOrders(IList<IOrder> orders)
        {
            foreach (var order in this.OrdersList)
            {
                if (order.OrderState == OrderState.NotDelivered &&
                    order.Receiver == this)
                {
                    Console.WriteLine(order.ToString());
                }
            }
        }

        public override string ToString()
        {
            return $"Client ID: {this.Id}" + base.ToString() + $"Client Type : {this.ClientType}";
        }

    }
}
