using System;
using DeliverIT.Contracts;
using System.Collections.Generic;
using Bytes2you.Validation;

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
            Guard.WhenArgument(city, "add city null").IsNull().Throw();
            this.CitysAndZips.Add(city, zip);
        }

        public void RemoveCityWithZip(string city)
        {
            Guard.WhenArgument(city, "remove city null").IsNull().Throw();
            if (!this.CitysAndZips.ContainsKey(city))
            {
                throw new ArgumentException("No such city for that country.");
            }
            this.CitysAndZips.Remove(city);
        }

    }
}
