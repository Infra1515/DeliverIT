using System.Collections.Generic;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Utilities.IOUtilities.Contracts;
using DeliverIT.Data.Contracts;

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
