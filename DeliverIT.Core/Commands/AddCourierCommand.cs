using System;
using System.Collections.Generic;
using System.Linq;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Models;
using DeliverIT.Models.Countries;

namespace DeliverIT.Core.Commands
{
    public class AddCourierCommand : ICommand
    {
        private readonly IDataStore dataStore;
        private readonly IDeliverITFactory factory;

        public AddCourierCommand(IDataStore dataStore, IDeliverITFactory factory)
        {
            this.dataStore = dataStore;
            this.factory = factory;
        }

        public void Execute()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Gender: ");
            GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), Console.ReadLine());

            Console.WriteLine("--- Address ---");
            Console.Write("Country: ");
            string countryString = Console.ReadLine();

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

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Validator.ValidateCityInCountry(city, country, Constants.NoSuchCity);
            Console.ResetColor();

            Console.Write("Street name: ");
            string streetName = Console.ReadLine();

            Console.Write("Street number: ");
            string streetNumber = Console.ReadLine();

            Console.Write("Enter maximum allowed weight that the courier can carry: ");
            double allowedWeight = double.Parse(Console.ReadLine());

            Console.Write("Enter maximum allowed volume that the courier can carry: ");
            double allowedVolume = double.Parse(Console.ReadLine());

            Address userAddress = new Address(country, streetName, streetNumber, city);

            var isUserPresent = this.dataStore.Users
                .FirstOrDefault(u => u.Username.Equals(username));

            if (isUserPresent != null)
                throw new ArgumentException(string.Format(
                       Constants.UserAlreadyExists, isUserPresent.GetType().Name, isUserPresent.Username));


            var courier = this.factory.CreateCourier(username, password, firstName, lastName, email, age, phoneNumber, userAddress, gender, allowedWeight, allowedVolume);

            this.dataStore.Users.Add(courier);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Constants.RegisteredCourier, courier.Username);
            Console.ResetColor();
        }
    }
}
