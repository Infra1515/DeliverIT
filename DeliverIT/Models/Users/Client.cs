using System.Collections.Generic;
using System.Text;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Models.Users.Abstract;

namespace DeliverIT.Models.Users
{
    public class Client : Person, IClient
    {
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
                IAddress address,
                GenderType gender
                
            )
            : base(username, password, firstName, lastName, email, age, phoneNumber, address, gender, UserRole.Operator)
        {
            this.Id = ++id;
            this.ClientType = clientType;
        }

        public int Id { get; protected set; }
        public ClientType ClientType { get => this.clientType; set => this.clientType = value; }

        public string ShowAllNotPendingOrders(IList<IOrder> orders)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var order in this.OrdersList)
            {
                if(order.OrderState == OrderState.Delivered)
                {
                    sb.AppendLine(order.ToString());
                }
            }

            return sb.ToString();
        }

        public string ShowReceivedOrders(IList<IOrder> orders)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var order in this.OrdersList)
            {
                if(order.OrderState == OrderState.Delivered && 
                    order.Receiver == this)
                {
                    sb.AppendLine(order.ToString());
                }
            }

            return sb.ToString();
        }

        public string ShowSentOrders(IList<IOrder> orders)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var order in this.OrdersList)
            {
                if (order.OrderState == OrderState.Delivered &&
                    order.Sender == this)
                {
                    sb.AppendLine(order.ToString());
                }
            }

            return sb.ToString();
        }

        public string ShowExpectedSendOrders(IList<IOrder> orders)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var order in this.OrdersList)
            {
                if (order.OrderState == OrderState.NotDelivered &&
                    order.Sender == this)
                {
                    sb.AppendLine(order.ToString());
                }
            }

            return sb.ToString();
        }

        public string ShowExpectedReceiveOrders(IList<IOrder> orders)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var order in this.OrdersList)
            {
                if (order.OrderState == OrderState.NotDelivered &&
                    order.Receiver == this)
                {
                    sb.AppendLine(order.ToString());
                }
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return $"ID: {this.Id}\r\n" + base.ToString() + $"\r\nClient Type : {this.ClientType}";
        }
    }
}
