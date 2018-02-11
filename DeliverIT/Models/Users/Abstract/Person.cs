﻿using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using System;
using System.Collections.Generic;
using Bytes2you.Validation;

namespace DeliverIT.Models.Users.Abstract
{
    public abstract class Person : User, IPerson
    {
        private int age;
        private string phoneNumber;
        private IAddress address;
        private GenderType gender;
        private List<IOrder> ordersList;

        protected Person(string username, string password, string firstName, string lastName, string email, int age, string phoneNumber, IAddress address,
            GenderType gender, UserRole role)
            : base(username, password, firstName, lastName, email, role)
        {
            this.Age = age;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.gender = gender;
            this.ordersList = new List<IOrder>();
        }

        public IList<IOrder> OrdersList { get => new List<IOrder>(ordersList); }

        public int Age
        {
            get { return this.age; }
            private set
            {
                Validator.ValidateYears(value, Constants.MinAge, Constants.MaxAge, Constants.InvalidYears);

                this.age = value;
            }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            private set
            {

                Guard.WhenArgument(value, "phone number null").IsNull().Throw();
                this.phoneNumber = value;
            }
        }

        public IAddress Address
        {
            get
            {
                return this.address;
            }
            private set
            {
                Guard.WhenArgument(value, "address null").IsNull().Throw();
                this.address = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            private set
            {
                this.gender = value;
            }
        }

        public IAddress ShowCurrentAddress()
        {
            return this.Address;
        }

        public void AddOrder(IOrder order)
        {
            this.ordersList.Add(order);
        }

        public void RemoveOrder(IOrder order)
        {
            this.ordersList.Remove(order);
        }

        public void DisplayOrderList()
        {
            Console.WriteLine($"Total orders for {this.FirstName} {this.LastName}");
            foreach (var order in OrdersList)
            {
                Console.WriteLine("--------------");
                Console.WriteLine(order.ToString());
                Console.WriteLine("---------------");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Telephone: { this.PhoneNumber}\n" +
                $"Address: \n" +
                $"{this.Address.ToString()}\n" +
                $"Age : {this.Age}\n" +
                $"Sex: {this.Gender}\n";
        }
    }
}
