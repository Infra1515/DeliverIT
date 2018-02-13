using System.Collections.Generic;

namespace DeliverIT.Data.Contracts
{
    public interface ICountry
    {
        string Name { get; }
        string PostalCode { get; }
        string TimeZone { get; }
        decimal Tax { get; }
        Dictionary<string, int> CitysAndZips { get; }

        void AddCityWithZip(string city, int zip);
        void RemoveCityWithZip(string city);

    }
}
