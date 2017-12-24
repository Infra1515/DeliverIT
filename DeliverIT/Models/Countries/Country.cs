using DeliverIT.Contracts;

namespace DeliverIT
{
    using DeliverIT.Common.Enums;
    using System.Collections.Generic;

    //timezone, continent, telephonecode (?need?)
    public class Country : ICountry
    {
        public Country(string name, decimal tax, string telephoneCode, string postalCode,
            string timeZone, Continent continent)
        {
            this.Name = name;
            this.Tax = tax;
            this.TelephoneCode = telephoneCode;
            this.PostalCode = postalCode;
            this.TimeZone = timeZone;
            this.Continent = continent;
            this.CitysAndZips = new Dictionary<string, int>();
        }

        //public TYPE Type { get; set; }
        public string Name { get; set; }
        public decimal Tax { get; set; }
        public string TelephoneCode { get; set; }
        public string PostalCode { get; set; }
        public string TimeZone { get; set; }
        public Continent Continent { get; set; }
        public Dictionary<string, int> CitysAndZips { get; set; }

        public void AddCityWithZip(string city, int zip)
        {
            this.CitysAndZips.Add(city, zip);
        }

        public void RemoveCityWithZip(string city, int zip)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCityWithZip(string city)
        {
            this.CitysAndZips.Remove(city);
        }

    }
}
