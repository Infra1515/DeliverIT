using Bytes2you.Validation;
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
                Guard.WhenArgument(value, "country null").IsNull().Throw();
                this.country = value;
            }
        }

        public string StreetName
        {
            get => streetName;
            set
            {
                Guard.WhenArgument(value, "street name null").IsNull().Throw();
                this.streetName = value;
            }
        }
        public string City
        {
            get => city;
            set
            {
                Guard.WhenArgument(value, "city null").IsNull().Throw();
                this.city = value;
            }
        }
        public string StreetNumber
        {
            get => streetNumber;
            set
            {
                Guard.WhenArgument(value, "street number null").IsNull().Throw();
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

