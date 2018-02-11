using System;
using System.Linq;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Commands
{
    public class AddCourierCommand : ICommand
    {
        private readonly IDataStore dataStore;
        private readonly IUserFactory userFactory;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ICreateAddress createAddress;

        public AddCourierCommand(
            IDataStore dataStore, 
            IUserFactory userFactory, 
            IWriter writer, 
            IReader reader,
            ICreateAddress createAddress)
        {
            this.dataStore = dataStore;
            this.userFactory = userFactory;
            this.writer = writer;
            this.reader = reader;
            this.createAddress = createAddress;
        }

        public string Execute()
        {
            this.writer.Write("Username: ");
            string username = this.reader.ReadLine();

            this.writer.Write("Password: ");
            string password = this.reader.ReadLine();

            this.writer.Write("First name: ");
            string firstName = this.reader.ReadLine();

            this.writer.Write("Last name: ");
            string lastName = this.reader.ReadLine();

            this.writer.Write("Email: ");
            string email = this.reader.ReadLine();

            this.writer.Write("Phone number: ");
            string phoneNumber = this.reader.ReadLine();

            this.writer.Write("Age: ");
            int age = int.Parse(this.reader.ReadLine());

            this.writer.Write("Gender: ");
            GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), this.reader.ReadLine());

            var userAddress = this.createAddress.Create();

            this.writer.Write("Enter maximum allowed weight that the courier can carry: ");
            double allowedWeight = double.Parse(this.reader.ReadLine());

            this.writer.Write("Enter maximum allowed volume that the courier can carry: ");
            double allowedVolume = double.Parse(this.reader.ReadLine());


            var isUserPresent = this.dataStore.Users
                .FirstOrDefault(u => u.Username.Equals(username));

            if (isUserPresent != null)
                throw new ArgumentException(string.Format(
                       Constants.UserAlreadyExists, isUserPresent.GetType().Name, isUserPresent.Username));


            var courier = this.userFactory.CreateCourier(username, password,
                firstName, lastName, email, age, phoneNumber, userAddress,
                gender, allowedWeight, allowedVolume);

            this.dataStore.Users.Add(courier);

            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format(Constants.RegisteredCourier, courier.Username);
        }
    }
}
