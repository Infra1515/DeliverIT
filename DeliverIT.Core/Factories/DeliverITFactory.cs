using System;
using DeliverIT.Common;
using DeliverIT.Models.Users;
using DeliverIT.Models;
using DeliverIT.Models.Contracts;
using DeliverIT.Common.Enums;

namespace DeliverIT.Core.Factories
{
    public class DeliverITFactory : IDeliverITFactory
    {
        public Client CreateClient(string username, string firstName, string lastName, string password, string email, string phoneNumber, int age,
            Address address, GenderType gender)
        {
            return new Client(username, firstName, lastName, password, email, phoneNumber, age, address, gender);
        }

        public IUser CreateAdmin(string username, string firstName, string lastName, string password, string email, string phoneNumber, int age,
            Address address, GenderType gender)
        {
            return new Administrator(username, firstName, lastName, password, UserRole.Administrator, email, phoneNumber, age, address, gender);
        }

        public Order PlaceOrder()
        {
            throw new NotImplementedException();
        }

    }
}
