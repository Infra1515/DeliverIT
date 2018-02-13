using System.Collections.Generic;
using System.Text;
using Bytes2you.Validation;
using DeliverIT.Data.Common;
using DeliverIT.Data.Contracts;
using DeliverIT.Data.Common.Enums;

namespace DeliverIT.Models.Users.Abstract
{
    public class Person : User, IPerson
    {
        private int age;
        private string phoneNumber;
        private IAddress address;
        private GenderType gender;
        private List<IOrder> ordersList;

        public Person(string username, string password, string firstName, string lastName, string email, int age, string phoneNumber, IAddress address,
            GenderType gender, UserRole role)
            : base(username, password, firstName, lastName, email, role)
        {
            Guard.WhenArgument(address, "address null").IsNull().Throw();

            Guard.WhenArgument(age, "years").IsLessThan(Constants.MinAge).Throw();
            Guard.WhenArgument(age, "years").IsGreaterThan(Constants.MaxAge).Throw();

            Guard.WhenArgument(phoneNumber, "phone number null").IsNull().Throw();
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
                this.age = value;
            }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            private set
            {
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

        public string DisplayOrderList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Total orders for {this.FirstName} {this.LastName}");
            foreach (var order in OrdersList)
            {
                sb.AppendLine("--------------");
                sb.AppendLine(order.ToString());
                sb.AppendLine("---------------");
            }

            return sb.ToString();
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
