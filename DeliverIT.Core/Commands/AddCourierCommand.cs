using System;
using System.Collections.Generic;
using System.Linq;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Core.Commands.Parsers;
using DeliverIT.Core.Commands.Providers;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Data;

namespace DeliverIT.Core.Commands
{
    public class AddCourierCommand : ICommand
    {
        private readonly IDataStore dataStore;
        private readonly IUserFactory userFactory;
        private readonly ICreateAddress createAddress;
        private readonly ICommandParser addressInfoCommandParser;

        public AddCourierCommand(
            IDataStore dataStore, 
            IUserFactory userFactory, 
            ICreateAddress createAddress,
            ICommandParser addressInfoCommandParser)
        {
            this.dataStore = dataStore;
            this.userFactory = userFactory;
            this.createAddress = createAddress;
            this.addressInfoCommandParser = addressInfoCommandParser;
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
            var allowedWeight = double.Parse(commandParameters[7]);
            var allowedVolume = double.Parse(commandParameters[8]);

            var userAddressInfo = this.addressInfoCommandParser.Parse();
            var userAddress = this.createAddress.Create(userAddressInfo);

            var isUserPresent = this.dataStore.Users
                .FirstOrDefault(u => u.Username.Equals(username));

            if (isUserPresent != null)
            {
                throw new ArgumentException(string.Format(Constants.UserAlreadyExists, isUserPresent.GetType().Name, isUserPresent.Username));
            }

            var courier = this.userFactory.CreateCourier(username, password,
                firstName, lastName, email, age, phoneNumber, userAddress,
                gender, allowedWeight, allowedVolume);

            this.dataStore.Users.Add(courier);

            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format(Constants.RegisteredCourier, courier.Username);
        }
    }
}
