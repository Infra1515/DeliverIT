using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Data.Contracts;
using DeliverIT.Data.Models;

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
