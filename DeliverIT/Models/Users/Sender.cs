﻿namespace DeliverIT
{
    using DeliverIT.Common;
    using DeliverIT.Contracts;
    using System;
    using System.Collections.Generic;

    public class Sender : Client
    {
        private List<IOrder> sendingOrders; // orders that are not received yet


        public Sender(string firstName, string lastName, string email, string phoneNumber,
                        int years, Country country, GenderType gender) 
            : base(firstName, lastName, email, phoneNumber, years, country, gender)
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