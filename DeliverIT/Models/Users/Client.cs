using System;
using System.Collections.Generic;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Models.Users.Abstract;

namespace DeliverIT.Models.Users
{
    public class Client : Person, IClient
    {
        // must fix id
        private static int id = 0;
        private ClientType clientType;

        public Client
            (
                string username,
                string password,
                string firstName, 
                string lastName,
                string email,
                int age,
                string phoneNumber,
                Address address,
                GenderType gender
            )
            : base(username, password, firstName, lastName, email, age, phoneNumber, address, gender, UserRole.Operator)
        {
            this.Id = id++;
            this.ClientType = clientType;
        }

        public int Id { get; protected set; }
        public ClientType ClientType { get => clientType; set => clientType = value; }

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
            return $"ID: {this.Id}\r\n" + base.ToString() + $"\r\nClient Type : {this.ClientType}";
        }
    }
}
