using DeliverIT.Data.Contracts;

namespace DeliverIT.Core.Factories.Contracts
{
    public interface ICountryFactory
    {
        ICountry CreateCountry(string countryName);
    }
}
