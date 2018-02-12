using System;
using DeliverIT.Contracts;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Core.IOUtilities.Contracts;

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
        
        public IAddress Create()
        {
            writer.WriteLine("--- Address ---");
            writer.Write("Country: ");
            string countryString = reader.ReadLine();

            ICountry country = this.countryFactory.CreateCountry(countryString);

            writer.Write("City: ");
            string city = reader.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.ResetColor();

            writer.Write("Street name: ");
            string streetName = reader.ReadLine();

            writer.Write("Street number: ");
            string streetNumber = reader.ReadLine();

            var userAddress = this.addressFactory.CreateAddress(country, streetName, streetNumber, city);

            return userAddress;
        }
    }
}
