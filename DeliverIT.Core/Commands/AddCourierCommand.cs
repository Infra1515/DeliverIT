using System;
using System.Linq;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Data;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Common;

namespace DeliverIT.Core.Commands
{
    public class AddCourierCommand : ICommand
    {
        private readonly IDataStore dataStore;
        private readonly IUserFactory userFactory;
        private readonly ICreateAddress createAddress;
        private readonly ICommandParser commandParser;

        public AddCourierCommand(
            IDataStore dataStore,
            IUserFactory userFactory,
            ICreateAddress createAddress,
            ICommandParser commandParser)
        {
            this.dataStore = dataStore;
            this.userFactory = userFactory;
            this.createAddress = createAddress;
            this.commandParser = commandParser;
        }

        public string Execute()
        {
            var courierInfo = this.commandParser.CourierInfoParseCommandParameters();

            var username = courierInfo[0];
            var password = courierInfo[1];
            var firstName = courierInfo[2];
            var lastName = courierInfo[3];
            var email = courierInfo[4];
            var phoneNumber = courierInfo[5];
            var age = int.Parse(courierInfo[6]);
            var gender = (GenderType)Enum.Parse(typeof(GenderType),
                courierInfo[7]);
            var allowedWeight = double.Parse(courierInfo[8]);
            var allowedVolume = double.Parse(courierInfo[9]);

            var userAddressInfo = this.commandParser.AddressInfoParseCommandParameters();
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
