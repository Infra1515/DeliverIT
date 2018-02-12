using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Data;

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
        public string Execute(IList<string> commandParameters)
        {
            var username = commandParameters[0];
            var password = commandParameters[1];
            var firstName = commandParameters[2];
            var lastName = commandParameters[3];
            var email = commandParameters[4];
            var phoneNumber = commandParameters[5];
            var age = int.Parse(commandParameters[6]);
            var gender = (GenderType)Enum.Parse(typeof(GenderType),
                commandParameters[7]);
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

            //this.writer.Write("Username: ");
            //string username = this.reader.ReadLine();

            //this.writer.Write("Password: ");
            //string password = this.reader.ReadLine();

            //this.writer.Write("First name: ");
            //string firstName = this.reader.ReadLine();

            //this.writer.Write("Last name: ");
            //string lastName = this.reader.ReadLine();

            //this.writer.Write("Email: ");
            //string email = this.reader.ReadLine();

            //this.writer.Write("Phone number: ");
            //string phoneNumber = this.reader.ReadLine();

            //this.writer.Write("Age: ");
            //int age = int.Parse(this.reader.ReadLine());

            //this.writer.Write("Gender: ");
            //GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), this.reader.ReadLine());

            //var userAddress = this.createCommand.Create();

            //var isUserPresent = this.dataStore.Users
            //    .FirstOrDefault(u => u.Username.Equals(username));

            //if (isUserPresent != null)
            //    throw new ArgumentException(string.Format(Constants.UserAlreadyExists, isUserPresent.GetType().Name, isUserPresent.Username));


            //var client = this.userFactory.CreateClient(username, password, firstName, lastName, email, age, phoneNumber, userAddress, gender);

            //this.dataStore.Users.Add(client);

            //Console.ForegroundColor = ConsoleColor.Green;
            //return string.Format(Constants.RegisteredClient, client.Username);
        }
    }
}
