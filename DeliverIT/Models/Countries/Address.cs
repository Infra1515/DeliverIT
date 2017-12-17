namespace DeliverIT
{
    using DeliverIT.Common.Enums;
    using System.Collections.Generic;

    public abstract class Address
    {
        private string name;
        private decimal tax;
        private string telephoneCode;
        private string postalCode;
        private string timeZone;
        private Continent continent;
        Dictionary<string, int> citysAndZips = new Dictionary<string, int>();

        public Address(string name, decimal tax, string telephoneCode, string postalCode, 
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
        public string Name { get => name; set => name = value; }
        public decimal Tax { get => tax; set => tax = value; }
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
