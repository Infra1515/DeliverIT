using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using System;
using System.Collections.Generic;

namespace DeliverIT.Models.Users.Abstract
{
    public abstract class Person : User, IPerson
    {
        private int age;
        private string phoneNumber;
        private Address address;
        private GenderType gender;
        private List<IOrder> ordersList;

        public Person(string username, string password, string firstName, string lastName, string email, int age, string phoneNumber, Address address,
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

                Validator.ValidatePhoneNumber(value);
                this.phoneNumber = value;
            }
        }

        public Address Address
        {
            get
            {
                return this.address;
            }
            private set
            {
                Validator.ValidateNotNull(value);
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
                Validator.ValidateNotNull(value);
                this.gender = value;
            }
        }

        public Address ShowCurrentAddress()
        {
            //method showing curr address
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
                $"Sex: {this.Gender}";
        }
    }
}
