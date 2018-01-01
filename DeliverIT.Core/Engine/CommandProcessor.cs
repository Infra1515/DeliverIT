using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Models;
using DeliverIT.Models.Countries;
using DeliverIT.Models.Users;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DeliverIT.Core.Engine
{
    public class CommandProcessor
    {
        private readonly IDeliverITFactory factory;
        private readonly ICollection<IUser> users;
        private IUser loggedUser;
        private readonly ICollection<IOrder> orders;

        public IDeliverITFactory Factory => this.factory;

        public ICollection<IUser> Users => this.users;

        public ICollection<IOrder> Orders => this.orders;

        public IUser LoggedUser { get => this.loggedUser; set => this.loggedUser = value; }

        public CommandProcessor()
        {
            this.users = new List<IUser>();
            this.orders = new List<IOrder>();
            this.factory = new DeliverITFactory();
            this.LoggedUser = null;
        }


        public IUser AddUser(string type)
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

            Console.Write("Years: ");
            int years = int.Parse(Console.ReadLine()); //possible exceptions

            Console.Write("Gender: ");
            GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), Console.ReadLine()); //possible ex

            Console.WriteLine("--- Address ---");
            Console.Write("Country: ");
            string countryString = Console.ReadLine(); // check for null

            Country country;

            switch ((CountryType)Enum.Parse(typeof(CountryType), countryString))
            {
                case CountryType.Bulgaria:
                    country = new Bulgaria();
                    break;

                case CountryType.Germany:
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
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Street name: ");
            string streetName = Console.ReadLine();

            Console.Write("Street number: ");
            string streetNumber = Console.ReadLine();

            Address userAddress = new Address(country, streetName, streetNumber, city);

            string userTypeInfo;
            switch (type)
            {
                case "Client":
                    userTypeInfo = Constants.RegisteredClient;
                    break;
                case "Courier":
                    userTypeInfo = Constants.RegisteredCourier;
                    break;
                default:
                    throw new ArgumentException("No such client type!");
            }

            foreach (IUser user in this.Users)
            {
                if (user.Username == username)
                {
                    throw new ArgumentException(string.Format(
                        Constants.UserAlreadyExists, user.GetType().Name, user.Username));
                }
            }
            if (type == "Client")
            {
                IClient client = this.Factory.CreateClient(username, password, firstName, lastName, email,
                        years, phoneNumber, userAddress, gender);
                this.Users.Add(client);
                Console.WriteLine(userTypeInfo, client.Username);
                return client;
            }
            else
            {
                Console.Write("Enter maximum allowed weight that the courier can carry: ");
                double allowedWeight = double.Parse(Console.ReadLine());
                Console.Write("Enter maximum allowed volume that the courier can carry: ");
                double allowedVolume = double.Parse(Console.ReadLine());
                ICourier courier = this.Factory.CreateCourier(username, password, firstName, lastName,
                    email, years, phoneNumber, userAddress, gender, allowedWeight, allowedVolume);
                return courier;
            }
        }

        public IProduct AddProduct()
        {

            Console.Write("Dimensions(X Y Z): ");
            var dimensions = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double x = dimensions[0];
            double y = dimensions[1];
            double z = dimensions[2];

            Console.Write("Is the product fragile? ");
            string isFragileStr = Console.ReadLine().ToLower().Trim(); // possible null - needs validation!!
            bool isFragile = isFragileStr == "yes";

            Console.Write("What is the product weight? ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write($"What is the product type?\r\n" +
                "Available:  Clothes, Accessories, Electronics, Other: ");
            string productTypeString = Console.ReadLine().ToLower().Trim();
            ProductType productType;
            switch (productTypeString)
            {
                case "clothes":
                    productType = ProductType.Clothes;
                    break;
                case "accessories":
                    productType = ProductType.Clothes;
                    break;
                case "electronics":
                    productType = ProductType.Electronics;
                    break;
                case "other":
                    productType = ProductType.Other;
                    break;
                default:
                    productType = ProductType.Other;
                    break;
            }
            IProduct product = this.Factory.CreateProduct(x, y, z, isFragile, weight, productType);
            Console.WriteLine($"Product with ID {product.Id} was added succesfully!");

            return product;

        }

        public IOrder AddOrder()
        {
            string choice;
            ICourier courier = (ICourier)this.Users.FirstOrDefault(x => x.Role == UserRole.Normal);

            if (this.LoggedUser.Role == UserRole.Administrator)
            {
                Console.WriteLine("--- Courier Information ---");
                Console.WriteLine(@"To choose already registered Courier press 'C' and type his username");
                Console.WriteLine("Or press 'R' to register a new Courier");
                choice = Console.ReadLine();
                if (choice == "C")
                {
                    Console.Write("Type username: ");
                    string username = Console.ReadLine();
                    // how to avoid type casting?
                    foreach (var user in this.Users)
                    {
                        if (user.Role == UserRole.Normal && user.Username == username)
                        {
                            courier = (Courier)user;
                        }
                    }
                    if (courier == null)
                    {

                        throw new ArgumentNullException("No courier found!");
                    }
                    else
                    {
                        Console.WriteLine($"Courier {courier.FirstName} {courier.LastName} choosen successfully!");
                    }
                }
                else
                {
                    Console.WriteLine("Register the new Courier: ");
                    courier = (ICourier)AddUser("Courier");
                    Console.WriteLine($"Courier {courier.FirstName} {courier.LastName} choosen succesfully!");
                }
            }

            Console.WriteLine("--- Sender information ---");
            Console.WriteLine(@"To choose already registered user press 'C' and type his username");
            Console.WriteLine("Or press 'R' to register a new user");
            IClient sender;
            choice = Console.ReadLine();
            if (choice == "C")
            {
                Console.WriteLine("Type username: ");
                string username = Console.ReadLine();
                // how to avoid type casting?
                sender = (IClient)this.Users.FirstOrDefault(x => x.Username == username);
                if (sender == null)
                {
                    throw new ArgumentNullException(Constants.NoSuchUser);
                }
                sender.ClientType = ClientType.Sender;
                Console.WriteLine($"Sender {sender.FirstName} {sender.LastName} choosen successfully!");
            }
            else
            {
                Console.WriteLine("Register the new user: ");
                sender = (IClient)AddUser("Client");
                sender.ClientType = ClientType.Sender;
                Console.WriteLine($"Sender {sender.FirstName} {sender.LastName} choosen successfully!");
            }

            Console.WriteLine("--- Receiver information ---");
            Console.WriteLine(@"To choose already registered user press 'C' and type his username");
            Console.WriteLine("Or press 'R' to register a new user");
            IClient receiver;
            choice = Console.ReadLine();
            if (choice == "C")
            {
                Console.WriteLine("Type username: ");
                string username = Console.ReadLine();
                receiver = (Client)this.Users.FirstOrDefault(x => x.Username == username);
                if (receiver == null)
                {
                    throw new ArgumentNullException(Constants.NoSuchUser);
                }
                else
                {
                    receiver.ClientType = ClientType.Receiver;
                    Console.WriteLine($"Receiver {receiver.FirstName} {receiver.LastName} choosen successfully!");
                }
            }
            else
            {
                Console.WriteLine("Register the new user: ");
                receiver = (IClient)AddUser("Client");
                receiver.ClientType = ClientType.Receiver;
                Console.WriteLine($"Receiver {receiver.FirstName} {receiver.LastName} choosen successfully!");
            }

            Console.Write("---Product information---");
            IProduct product = AddProduct();

            Console.Write("Enter date of sending (Day/Month/Year): ");
            DateTime sendDate = DateTime.ParseExact(Console.ReadLine(),
                                "d/M/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Enter due date for delivery(Day/Month/Year): ");
            DateTime dueDate = DateTime.ParseExact(Console.ReadLine(),
                            "d/M/yyyy", CultureInfo.InvariantCulture);

            int postalCode = receiver.Address.Country.CitysAndZips[receiver.Address.City];

            IOrder order = this.Factory.CreateOrder(courier, sender, receiver, sendDate, dueDate,
                OrderState.NotDelivered, product, postalCode);
            Console.WriteLine($"Order with ID {order.Id} created!");

            this.Orders.Add(order);

            receiver.AddOrder(order);

            sender.AddOrder(order);

            courier.AddOrder(order);

            return order;
        }


        public string ShowAllClients()
        {
            StringBuilder sb = new StringBuilder();
            if (this.users.Count == 0)
            {
                sb.AppendLine("No clients registered!");
            }
            else
            {
                foreach (var client in this.users)
                {
                    sb.AppendLine(client.ToString()); //must implement TOSTRING method
                    sb.AppendLine("-----------------------");
                }
            }
            return sb.ToString();
        }

        public string ShowAllOrders()
        {
            var sb = new StringBuilder();
            if (this.orders.Any())
            {
                foreach (var order in orders)
                {
                    sb.AppendLine(order.ToString());
                }
            }
            else
            {
                sb.AppendLine("No orders placed yet!");
            }

            return sb.ToString();
        }

        public string ShowAllLocations()
        {
            var counter = 1;
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("--- Delivery locations ---");
            strBuilder.AppendLine(counter + ". " + CountryType.Bulgaria);
            counter++;
            strBuilder.AppendLine(counter + ". " + CountryType.Russia);
            counter++;
            strBuilder.AppendLine(counter + ". " + CountryType.Germany);
            return strBuilder.ToString();
        }

    }
}
