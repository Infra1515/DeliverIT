using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;

namespace DeliverIT.Core.Factories
{
    public class DeliverITFactory : IDeliverITFactory
    {
        public Client CreateClient(string firstName, string lastName, string email, string phoneNumber, int years, Country address,
            GenderType gender)
        {
            return new Client(firstName, lastName, email, phoneNumber, years, address, gender);
        }

        public Order PlaceOrder()
        {
            throw new NotImplementedException();
        }

        public ICountry CreateCountry(string name, decimal tax, string telephoneCode, string postalCode,
            string timeZone, Continent continent)
        {
            return new Country(name,tax, telephoneCode, postalCode, timeZone, Continent.Europe);
        }
    }
}
