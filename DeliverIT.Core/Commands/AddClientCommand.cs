using System;
using System.Linq;
using DeliverIT.Core.Contracts;
using DeliverIT.Data;
using DeliverIT.Core.Factories;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Utilities.IOUtilities.Contracts;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Common;

namespace DeliverIT.Core.Commands
{
    public class AddClientCommand : ICommand
    {
        private readonly IUserFactory userFactory;
        private readonly IDataStore dataStore;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ICreateAddress createAddress;
        private readonly ICommandParser commandParser;

        public AddClientCommand(
            IDataStore dataStore, 
            IUserFactory userFactory,
            IWriter writer, 
            IReader reader,
            ICreateAddress createAddress,
            ICommandParser commandParser)
        {
            this.dataStore = dataStore;
            this.userFactory = userFactory;
            this.writer = writer;
            this.reader = reader;
            this.createAddress = createAddress;
            this.commandParser = commandParser;

        }
        public string Execute()
        {
            var userParams = this.commandParser.UserInfoParseCommandParameters();
            var username = userParams[0];
            var password = userParams[1];
            var firstName = userParams[2];
            var lastName = userParams[3];
            var email = userParams[4];
            var phoneNumber = userParams[5];
            var age = int.Parse(userParams[6]);
            var gender = (GenderType)Enum.Parse(typeof(GenderType),
                userParams[7]);

            var userAddressInfo = this.commandParser.AddressInfoParseCommandParameters();
            var userAddress = this.createAddress.Create(userAddressInfo);

            var isUserPresent = this.dataStore.Users
                .FirstOrDefault(u => u.Username.Equals(username));

            if (isUserPresent != null)
            {
                throw new ArgumentException(string.Format(Constants.UserAlreadyExists, isUserPresent.GetType().Name, isUserPresent.Username));
            }

            var client = this.userFactory.CreateClient(username, password, firstName, lastName, email, age, phoneNumber, userAddress, gender);

            this.dataStore.Users.Add(client);

            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format(Constants.RegisteredClient, client.Username);
        }
    }
}
