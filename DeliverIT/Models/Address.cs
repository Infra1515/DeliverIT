using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Models
{
    public class Address
    {
        private Country country;
        private string streetName;
        private string streetNumber;
        private string city;

        public Address(Country country, string streetName, string streetNumber, string city)
        {
            this.Country = country;
            this.StreetName = streetName;
            this.StreetNumber = streetNumber;
            this.City = city;
        }
        // TODO: Validation
        public Country Country { get => country; set => country = value; }
        public string StreetName { get => streetName; set => streetName = value; }
        public string City { get => city; set => city = value; }
        public string StreetNumber { get => streetNumber; set => streetNumber = value; }
    }
}
