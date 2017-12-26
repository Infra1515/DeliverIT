using System;
using System.Collections.Generic;
using System.Text;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Core.Utilities;
using DeliverIT.Models;
using DeliverIT.Models.Countries;
using DeliverIT.Models.Users.Clients;
using DeliverIT.Models.Users.Clients.Abstract;
using DeliverIT.Models.Users.Couriers;
using DeliverIT.Models.Users.Couriers.Abstract;

namespace DeliverIT.Core.Engine
{
    public class DeliverITEngine : IEngine
    {
        private static readonly IEngine SingleInstance = new DeliverITEngine();
        private static readonly StringBuilder sb = new StringBuilder();

        private readonly IDeliverITFactory factory;
        private ICollection<Client> clients;
        private ICollection<IOrder> orders;


        private DeliverITEngine()
        {
            this.factory = new DeliverITFactory();
            this.clients = new List<Client>();
            this.orders = new List<IOrder>();
            //implement others
        }

        public static IEngine Instance
        {
            get { return SingleInstance; }
        }

        public void Start()
        {
            Console.WriteLine(MenuText());

            do
            {
                int.TryParse(Console.ReadLine(), out var userChoise);

                var isValidChoise = Enum.IsDefined(typeof(Selections), userChoise);

                if (!isValidChoise)
                    userChoise = (int)Selections.Invalid;

                if (userChoise == (int)Selections.Exit)
                    break;

                switch ((Selections)userChoise)
                {
                    case Selections.AddClient:
                        PrintUserOutput();
                        break;

                    case Selections.PlaceOrder:
                        Console.WriteLine("Choose a courier: ");
                        Console.WriteLine("8." + new Gosheedy().ToString());
                        Console.WriteLine("9." + new Peshont().ToString());
                        CreateCourier(int.Parse(Console.ReadLine()));

                        Console.WriteLine("--- Sender information ---");
                        PrintUserOutput();

                        Console.WriteLine("--- Receiver information ---");
                        PrintUserOutput();


                        break;

                    case Selections.AddCourier: //optional?
                        Console.WriteLine("Implement adding a courier ...");
                        break;

                    case Selections.AllClients:
                        Console.WriteLine(this.ShowAllClients());
                        break;

                    case Selections.AllOrders:
                        Console.WriteLine(this.ShowAllOrders());
                        break;

                    case Selections.AllLocations:
                        Console.WriteLine(ShowAllLocations());
                        break;

                    case Selections.Invalid:
                        Console.WriteLine("Invalid option selected! Please select a valid option!");
                        break;
                }
            }
            while (true);
        }

        private void RegisterClient(string firstName, string lastName, string email, string phoneNumber,
            int years, Address address, GenderType gender)
        {
            var user = this.factory.CreateClient(firstName, lastName, email, phoneNumber, years, address, gender);

            Console.WriteLine(string.Format(Constants.RegisteredClient, firstName)); //todo implement with RETURN NOT CW    
        }

        private void PlaceOrder(Courier courier, Sender sender, Receiver receiver, DateTime sendDate, DateTime dueDate,
            decimal deliveryPrice, bool isDelivered, Country address, Product product)
        {
            
        }

        private void PrintUserOutput()
        {
            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Years: ");
            int years = int.Parse(Console.ReadLine());

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

                case CountryType.Germany:
                    country = new Germany();
                    break;

                case CountryType.Russia:
                    country = new Russia(); ;
                    break;

                default:
                    country = new Bulgaria();
                    break;
            }

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("Street name: ");
            string streetName = Console.ReadLine();

            Console.Write("Street number: ");
            string streetNumber = Console.ReadLine();

            Address userAddress = new Address(country, streetName, streetNumber, city);
            this.RegisterClient(firstName, lastName, email, phoneNumber, years, userAddress, gender);
        }

        private string ShowAllClients()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var client in this.clients)
            {
                sb.Append(client.ToString()); //must implement TOSTRING method
            }

            return sb.ToString();
        }
        
        private string ShowAllOrders()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var order in this.orders)
            {
                sb.Append(order.ToString()); //must implement TOSTRING method
            }

            return sb.ToString();
        }

        private void CreateCourier(int choice)
        {
            Courier courier = new Gosheedy();
            switch (choice)
            {
                case 8:
                    courier =  new Gosheedy();

                    Console.WriteLine($"{courier.GetType().Name} chosen successfully!");
                    break;
                case 9: 
                    courier =  new Peshont();

                    Console.WriteLine($"{courier.GetType().Name} chosen successfully!");
                    break;
                default:
                    Console.WriteLine("Invalid command entered!");
                    break;
            }
        }

        private string ShowAllLocations()
        {
            var counter = 1;
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("--- Delivery locations ---");
            strBuilder.AppendLine(counter.ToString()+  ". " + CountryType.Bulgaria.ToString());
            counter++;
            strBuilder.AppendLine(counter.ToString() + ". " + CountryType.Russia.ToString());
            counter++;
            strBuilder.AppendLine(counter.ToString() + ". " + CountryType.Germany.ToString());
            return strBuilder.ToString();
        }

        private string MenuText()
        {
            sb.AppendLine("DeliverIT Menu Options\n");
            sb.AppendLine("----- Control Options -----\n");
            sb.AppendLine("1. Add new clients.");
            sb.AppendLine("2. Place orders for client.");
            sb.AppendLine("3. Add couriers.\n");
            sb.AppendLine("----- List Options -----\n");
            sb.AppendLine("4. List all clients.");
            sb.AppendLine("5. List all orders.");
            sb.AppendLine("6. List delivery locations.\n");
            sb.AppendLine("7. Exit menu.");

            return sb.ToString();
        }
    }
}