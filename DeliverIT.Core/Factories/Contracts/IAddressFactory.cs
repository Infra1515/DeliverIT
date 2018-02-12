using DeliverIT.Contracts;

namespace DeliverIT.Core.Factories.Contracts
{
    public interface IAddressFactory
    {
        IAddress CreateAddress(ICountry country, string streetName, string streetNumber, string city);
    }
}
