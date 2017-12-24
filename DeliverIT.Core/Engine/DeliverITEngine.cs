using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Core.Utilities;

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
                        Console.WriteLine("Implement creating of a client ...");

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

                        //Console.Write("Address: ");
                        //string countryName = Console.ReadLine();
                        //var country = this.RegisterCountry(name, tax, telephoneCode, postalCode, timeZone, continent);
                        //this.RegisterClient(firstName, lastName, email, phoneNumber, years, country, gender);
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

        private ICountry RegisterCountry(string name, decimal tax, string telephoneCode, string postalCode,
            string timeZone, Continent continent)
        {
            var country = this.factory.CreateCountry(name, tax, telephoneCode, postalCode, timeZone, continent);
            return new Country(name, tax, telephoneCode, postalCode, timeZone, continent);
        }

        private string RegisterClient(string firstName, string lastName, string email, string phoneNumber,
            int years, Country address, GenderType gender)
        {
           // var user = this.factory.CreateClient(firstName, lastName, email, phoneNumber, years, country, gender);

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
