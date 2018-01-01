using DeliverIT.Contracts;
using System.Collections.Generic;

namespace DeliverIT.Models.Countries
{
    public abstract class Country : ICountry
    {
        protected Country(string name, decimal tax)
        {
            this.Name = name;
            this.Tax = tax;
            this.CitysAndZips = new Dictionary<string, int>();
        }

        public string Name { get; protected set; }
        public decimal Tax { get; protected set; }
        public string PostalCode { get; protected set; }
        public string TimeZone { get; protected set; }

        public Dictionary<string, int> CitysAndZips { get; set; }

        public void AddCityWithZip(string city, int zip)
        {
            this.CitysAndZips.Add(city, zip);
        }

        public void RemoveCityWithZip(string city)
        {
            this.CitysAndZips.Remove(city);
        }

    }
}
