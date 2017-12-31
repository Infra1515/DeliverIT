﻿using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Models;
using DeliverIT.Models.Users;
using System.Collections.Generic;

namespace DeliverIT
{
    public class Sender : Client
    {
        private List<IOrder> sendingOrders; // orders that are not received yet


        public Sender(string firstName, string lastName, string email, string phoneNumber,
                        int years, Address address, GenderType gender) 
            : base(firstName, lastName, email, phoneNumber, years, address, gender)
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