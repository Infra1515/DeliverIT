using System;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Data.Contracts;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Models.Countries;

namespace DeliverIT.Core.Factories
{
    public class CountryFactory : ICountryFactory
    {
        public ICountry CreateCountry(string countryName)
        {
            switch ((CountryType)Enum.Parse(typeof(CountryType), countryName))
            {
                case CountryType.Bulgaria:
                    return new Bulgaria();

                case CountryType.Serbia:
                    return new Serbia();

                case CountryType.Russia:
                    return new Russia();

                default:
                    throw new ArgumentException("We don't ship to this country yet!");
            }
        }
    }
}
