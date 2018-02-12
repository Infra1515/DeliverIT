using System;
using System.Collections.Generic;
using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Commands.CreateCommands
{
    public class CreateAddress : ICreateAddress
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IAddressFactory addressFactory;
        private readonly ICountryFactory countryFactory;

        public CreateAddress(
            IWriter writer, 
            IReader reader, 
            IAddressFactory deliverItFactory, 
            ICountryFactory countryFactory)
        {
            this.writer = writer;
            this.reader = reader;
            this.addressFactory = deliverItFactory;
            this.countryFactory = countryFactory;
        }
        
        public IAddress Create(IList<string> commandParameters)
        {
            //writer.WriteLine("--- Address ---");
            //writer.Write("Country: ");
            //string countryString = reader.ReadLine();

            //ICountry country = this.countryFactory.CreateCountry(countryString);

            //writer.Write("City: ");
            //string city = reader.ReadLine();

            //Console.ForegroundColor = ConsoleColor.Red;
            //Validator.ValidateCityInCountry(city, country, Constants.NoSuchCity);
            //Console.ResetColor();

            //writer.Write("Street name: ");
            //string streetName = reader.ReadLine();

            //writer.Write("Street number: ");
            //string streetNumber = reader.ReadLine();

            var countryAsString = commandParameters[0];
            var cityAsString = commandParameters[1];
            var streetNameAsString = commandParameters[2];
            var streetNumberAsString = commandParameters[3];

            var country = this.countryFactory.CreateCountry(countryAsString);

            var userAddress = this.addressFactory.CreateAddress(country, streetNameAsString, streetNumberAsString, cityAsString);

            return userAddress;
        }
    }
}
