using System.Collections.Generic;

namespace DeliverIT.Contracts
{
    public interface ICountry
    {
        string Name { get; }
        string PostalCode { get; }
        string TimeZone { get; }
        Dictionary<string, int> CitysAndZips { get; }

        void AddCityWithZip(string city, int zip);
        void RemoveCityWithZip(string city);
    }
}
