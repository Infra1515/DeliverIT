using System;
using DeliverIT.Common;
using DeliverIT.Models.Users;
using DeliverIT.Models;

namespace DeliverIT.Core.Factories
{
    public class DeliverITFactory : IDeliverITFactory
    {
        public Client CreateClient(string firstName, string lastName, string password, string email, string phoneNumber, int years,
            Address address, GenderType gender)
        {
            return new Client(firstName, lastName, password, email, phoneNumber, years, address, gender);
        }

        public Order PlaceOrder()
        {
            throw new NotImplementedException();
        }

    }
}
