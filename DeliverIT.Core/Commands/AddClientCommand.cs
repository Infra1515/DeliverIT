using System;
using System.Linq;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Models;
using DeliverIT.Models.Countries;

namespace DeliverIT.Core.Commands
{
    public class AddClientCommand : ICommand
    {
        private readonly IDeliverITFactory factory;
        private readonly IDataStore dataStore;
        private readonly IWriter writer;
        private readonly IReader reader;

        public AddClientCommand(
            IDataStore dataStore, 
            IDeliverITFactory factory,
            IWriter writer, 
            IReader reader)
        {
            this.dataStore = dataStore;
            this.factory = factory;
            this.writer = writer;
            this.reader = reader;
        }
        public void Execute()
        {
            this.writer.Write("Username: ");
            string username = Console.ReadLine();
            
            this.writer.Write("Password: ");
            string password = Console.ReadLine();
            
            this.writer.Write("First name: ");
            string firstName = Console.ReadLine();
            
            this.writer.Write("Last name: ");
            string lastName = Console.ReadLine();
            
            this.writer.Write("Email: ");
            string email = Console.ReadLine();
            
            this.writer.Write("Phone number: ");
            string phoneNumber = Console.ReadLine();
            
            this.writer.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            this.writer.Write("Gender: ");
            GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), this.reader.ReadLine());
            
            this.writer.WriteLine("--- Address ---");
            this.writer.Write("Country: ");
            string countryString = this.reader.ReadLine();

            Country country;

            switch ((CountryType)Enum.Parse(typeof(CountryType), countryString))
            {
                case CountryType.Bulgaria:
                    country = new Bulgaria();
                    break;

                case CountryType.Serbia:
                    country = new Serbia();
                    break;

                case CountryType.Russia:
                    country = new Russia();
                    break;

                default:
                    throw new ArgumentException("We don't ship to this country yet!");
            }
            
            this.writer.Write("City: ");
            string city = this.reader.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Validator.ValidateCityInCountry(city, country, Constants.NoSuchCity);
            Console.ResetColor();

            this.writer.Write("Street name: ");
            string streetName = this.reader.ReadLine();

            this.writer.Write("Street number: ");
            string streetNumber = this.reader.ReadLine();

            Address userAddress = new Address(country, streetName, streetNumber, city);

            var isUserPresent = this.dataStore.Users
                .FirstOrDefault(u => u.Username.Equals(username));

            // todo constants di 

            if (isUserPresent != null)
                throw new ArgumentException(string.Format(
                       Constants.UserAlreadyExists, isUserPresent.GetType().Name, isUserPresent.Username));


            var client = this.factory.CreateClient(username, password, firstName, lastName, email, age, phoneNumber, userAddress, gender);

            this.dataStore.Users.Add(client);

            Console.ForegroundColor = ConsoleColor.Green;
            this.writer.WriteLine(string.Format(Constants.RegisteredClient, client.Username));
            Console.ResetColor();
        }
    }
}
