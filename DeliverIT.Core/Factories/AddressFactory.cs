using DeliverIT.Contracts;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Models;

namespace DeliverIT.Core.Factories
{
    public class AddressFactory : IAddressFactory
    {
        public IAddress CreateAddress(ICountry country, string streetName, string streetNumber, string city)
        {
            return new Address(country, streetName, streetNumber, city);
        }
    }
}
