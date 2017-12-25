using System;
using System.Collections.Generic;
using System.Text;
using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Core.Utilities;
using DeliverIT.Models;

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
                        //Console.WriteLine("Implement creating of a client ...");

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

                        // How to make string country into class Country
                        // ie user enters Bulgaria = program sets user Country to Bulgaria
                        Console.Write("Country: ");
                        Country country = (Country)Enum.Parse(typeof(Country), Console.ReadLine());

                        Console.Write("City: ");
                        string city = Console.ReadLine();

                        Console.Write("Street name: ");
                        string streetName = Console.ReadLine();

                        Console.Write("Street number: ");
                        string streetNumber = Console.ReadLine();

                        Address userAddres = new Address(country, streetName, streetNumber, city);
                        this.RegisterClient(firstName, lastName, email, phoneNumber, years, userAddres, gender);
                        break;

                    case Selections.PlaceOrder:
                        Console.WriteLine("Implement placing of an order ...");
                        break;

                    case Selections.AddCourier:
                        Console.WriteLine("Implement adding a courier ...");
                        break;

                    case Selections.AllClients:
                        //Console.WriteLine("Implement clients view ...");
                        Console.WriteLine(this.ShowAllClients());
                        break;

                    case Selections.AllOrders:
                        //Console.WriteLine("Implement orders view ...");
                        Console.WriteLine(this.ShowAllOrders());
                        break;

                    case Selections.AllLocations:
                        Console.WriteLine("Implement locations view ...");
                        break;

                    case Selections.Invalid:
                        Console.WriteLine("Invalid option selected! Please select a valid option!");
                        break;
                }

            }
            while (true);
        }


        private string RegisterClient(string firstName, string lastName, string email, string phoneNumber,
            int years, Address address, GenderType gender)
        {
            var user = this.factory.CreateClient(firstName, lastName, email, phoneNumber, years, address, gender);

            return string.Format(Constants.RegisteredClient);
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