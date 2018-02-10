﻿using System;
using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Commands
{
    public class CreateAddress : ICreateAddress
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly CountryFactory factory;
        private readonly IDeliverITFactory deliverItFactory;

        public CreateAddress(
            IWriter writer, 
            IReader reader, 
            CountryFactory factory, 
            IDeliverITFactory deliverItFactory)
        {
            this.writer = writer;
            this.reader = reader;
            this.factory = factory;
            this.deliverItFactory = deliverItFactory;
        }
        
        public IAddress Create()
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

            var userAddress = this.deliverItFactory.CreateAddress(country, streetName, streetNumber, city);

            return userAddress;
        }
    }
}