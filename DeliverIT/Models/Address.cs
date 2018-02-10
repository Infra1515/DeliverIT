using DeliverIT.Common;
using DeliverIT.Contracts;

namespace DeliverIT.Models
{
    public class Address : IAddress
    {
        private ICountry country;
        private string streetName;
        private string streetNumber;
        private string city;

        public Address(
            ICountry country, 
            string streetName, 
            string streetNumber, 
            string city)
        {
            this.Country = country;
            this.StreetName = streetName;
            this.StreetNumber = streetNumber;
            this.City = city;
        }
        
        public ICountry Country
        {
            get => country;
            set
            {
                Validator.ValidateNotNull(value);
                this.country = value;
            }
        }

        public string StreetName
        {
            get => streetName;
            set
            {
                Validator.ValidateNotNull(value);
                this.streetName = value;
            }
        }
        public string City
        {
            get => city;
            set
            {
                Validator.ValidateNotNull(value);
                this.city = value;
            }
        }
        public string StreetNumber
        {
            get => streetNumber;
            set
            {
                Validator.ValidateNotNull(value);
                this.streetNumber = value;
            }
        }

        public override string ToString()
        {
            return $" -- Country: {this.Country.GetType().Name}\n" +
                $" -- City: {this.City}\n" +
                $" -- Street Name: {this.StreetName}\n" +
                $" -- Number: {this.StreetNumber}";
        }
    }
}

