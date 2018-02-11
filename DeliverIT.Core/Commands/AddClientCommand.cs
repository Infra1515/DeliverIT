using System;
using System.Linq;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Commands
{
    public class AddClientCommand : ICommand
    {
        private readonly IUserFactory userFactory;
        private readonly IDataStore dataStore;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ICreateAddress createCommand;

        public AddClientCommand(
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
            this.createCommand = createAddress;
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

            var userAddress = this.createCommand.Create();

            var isUserPresent = this.dataStore.Users
                .FirstOrDefault(u => u.Username.Equals(username));
            
            if (isUserPresent != null)
                throw new ArgumentException(string.Format(Constants.UserAlreadyExists, isUserPresent.GetType().Name, isUserPresent.Username));


            var client = this.userFactory.CreateClient(username, password, firstName, lastName, email, age, phoneNumber, userAddress, gender);

            this.dataStore.Users.Add(client);

            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format(Constants.RegisteredClient, client.Username);
        }
    }
}
