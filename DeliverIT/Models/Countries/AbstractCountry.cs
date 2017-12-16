namespace DeliverIT
{
    using DeliverIT.Common;
    using DeliverIT.Common.Enums;
    using System;
    using System.Collections.Generic;
    using Bytes2you.Validation;

    public abstract class Country
    {
        private string name;
        private int tax;
        private string telephoneCode;
        private string postalCode;
        private string timeZone;
        private Continent continent;
        Dictionary<string, int> citysAndZips = new Dictionary<string, int>();

        public Country(string name, int tax, string telephoneCode, string postsalCode, 
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

        public string Name { get => name; set => name = value; }
        public int Tax { get => tax; set => tax = value; }
        public string TelephoneCode { get => telephoneCode; set => telephoneCode = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string TimeZone { get => timeZone; set => timeZone = value; }
        public Continent Continent { get => continent; set => continent = value; }
        public Dictionary<string, int> CitysAndZips { get => citysAndZips; set => citysAndZips = value; }

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
