using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Models;
using DeliverIT.Models.Countries;

namespace DeliverIT.Core.Commands
{
    public class CreateAddress
    {
        //private readonly IWriter writer;
        //private readonly IReader reader;
        //private readonly CountryFactory factory;

        public IAddress Create(IWriter writer, IReader reader, CountryFactory factory)
        {
            writer.WriteLine("--- Address ---");
            writer.Write("Country: ");
            string countryString = reader.ReadLine();

            ICountry country = factory.CreateCountry(countryString);

            writer.Write("City: ");
            string city = reader.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Validator.ValidateCityInCountry(city, country, Constants.NoSuchCity);
            Console.ResetColor();

            writer.Write("Street name: ");
            string streetName = reader.ReadLine();

            writer.Write("Street number: ");
            string streetNumber = reader.ReadLine();

            Address userAddress = new Address(country, streetName, streetNumber, city);

            return userAddress;
        }
    }
}
