using System;
using System.Collections.Generic;
using System.Text;
using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;
using DeliverIT.Core.Factories;
using DeliverIT.Models;
using DeliverIT.Models.Contracts;
using System.Linq;

namespace DeliverIT.Core.Engine
{
    public class DeliverITEngine : IEngine
    {
        private static readonly IEngine SingleInstance = new DeliverITEngine();

        private readonly IDeliverITFactory factory;
        private ICollection<IUser> users;
        private ICollection<IOrder> orders;
        private IUser loggedUser;
        private MenuState state = MenuState.Login;

        private DeliverITEngine()
        {
            this.factory = new DeliverITFactory();
            this.users = new List<IUser>();
            this.orders = new List<IOrder>();
            this.loggedUser = null;
        }

        public static IEngine Instance
        {
            get { return SingleInstance; }
        }

        public void Start()
        {
            this.SeedObjects();
            
            do
            {
                switch (state)
                {
                    case MenuState.Login:

                        Console.WriteLine(LookupMenuText.LoginText);

                        int.TryParse(Console.ReadLine(), out int userLoginChoise);
                        var isValidLoginChoise = Enum.IsDefined(typeof(LoginChoise), userLoginChoise);

                        if (!isValidLoginChoise)
                        {
                            Console.WriteLine("You have entered an Invalid Choise!\n");
                            break;
                        }

                        LoginMenu((LoginChoise)userLoginChoise);

                        break;
                        
                    case MenuState.MainMenu:

                        Console.WriteLine(LookupMenuText.MainMenuText);

                        int.TryParse(Console.ReadLine(), out int userMainMenuChoise);
                        var isValidMainMenuChoise = Enum.IsDefined(typeof(MainMenuChoise), userMainMenuChoise);

                        if (!isValidMainMenuChoise)
                        {
                            Console.WriteLine("You have entered an Invalid Choise!\n");
                            break;
                        }

                        MainMenu((MainMenuChoise)userMainMenuChoise);

                        break;

                    default:
                        state = MenuState.Exit;
                        break;
                }
            }
            while (state != MenuState.Exit);
        }

        private void RegisterClient(string username, string firstName, string lastName, string password,string email, string phoneNumber,
            int years, Address address, GenderType gender)
        {
            var user = this.factory.CreateClient(username, firstName, lastName, password, email, phoneNumber, years, address, gender);

            Console.WriteLine(string.Format(Constants.RegisteredClient, firstName)); //todo implement with RETURN NOT CW    
        }

        private string ShowAllClients()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var user in this.users)
            {
                sb.Append(user.ToString()); //must implement TOSTRING method
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

        private void MainMenu(MainMenuChoise userMainMenuChoise)
        {
            switch (userMainMenuChoise)
            {
                case MainMenuChoise.AddClient:
                    Console.WriteLine("Implement creating of a client ...");
                    #region Commented Out
                    //Console.Write("First name: ");
                    //string firstName = Console.ReadLine();

                    //Console.Write("Last name: ");
                    //string lastName = Console.ReadLine();

                    //Console.Write("Email: ");
                    //string email = Console.ReadLine();

                    //Console.Write("Phone number: ");
                    //string phoneNumber = Console.ReadLine();

                    //Console.Write("Years: ");
                    //int years = int.Parse(Console.ReadLine());

                    //Console.Write("Gender: ");
                    //GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), Console.ReadLine());

                    //Console.WriteLine("--- Address ---");

                    //// How to make string country into class Country
                    //// ie user enters Bulgaria = program sets user Country to Bulgaria
                    //Console.Write("Country: ");
                    ////Country country = (Country)Enum.Parse(typeof(Country), Console.ReadLine());

                    //string countryString = Console.ReadLine();

                    //Country country;

                    //switch ((CountryType)Enum.Parse(typeof(CountryType), countryString))
                    //{

                    //    case CountryType.Bulgaria:
                    //        country = new Bulgaria();
                    //        break;

                    //    case CountryType.Germany:
                    //        country = new Germany();
                    //        break;

                    //    case CountryType.Russia:
                    //        country = new Russia(); ;
                    //        break;

                    //    default:
                    //        country = new Bulgaria();
                    //        break;
                    //}

                    //Console.Write("City: ");
                    //string city = Console.ReadLine();

                    //Console.Write("Street name: ");
                    //string streetName = Console.ReadLine();

                    //Console.Write("Street number: ");
                    //string streetNumber = Console.ReadLine();

                    //Address userAddress = new Address(country, streetName, streetNumber, city);
                    //this.RegisterClient(firstName, lastName, email, phoneNumber, years, userAddress, gender);
                    #endregion
                    break;

                case MainMenuChoise.PlaceOrder:
                    Console.WriteLine("Implement placing of an order ...");
                    break;

                case MainMenuChoise.AddCourier:
                    Console.WriteLine("Implement adding a courier ...");
                    break;

                case MainMenuChoise.AllClients:
                    Console.WriteLine("Implement clients view ...");
                    //Console.WriteLine(this.ShowAllClients());
                    break;

                case MainMenuChoise.AllOrders:
                    Console.WriteLine("Implement orders view ...");
                    //Console.WriteLine(this.ShowAllOrders());
                    break;

                case MainMenuChoise.AllLocations:
                    Console.WriteLine("Implement locations view ...");
                    break;

                case MainMenuChoise.Logout:

                    this.loggedUser = null;
                    state = MenuState.Login;

                    break;
            }
        }

        private void LoginMenu(LoginChoise userChoise)
        {
            switch (userChoise)
            {
                case LoginChoise.Login:

                    Console.Write("Username: ");
                    string username = Console.ReadLine();

                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    var isLogged = this.Login(username, password);

                    if (isLogged)
                        state = MenuState.MainMenu;

                    break;

                case LoginChoise.Exit:
                    state = MenuState.Exit;
                    break;
            }
        }

        private void SeedObjects()
        {
            var address = new Address()
            {
                City = "Sofia",
                StreetName = "basi ulicata",
                StreetNumber = "1234"
            };

            var adminUser = this.factory.CreateAdmin("root", "ivan", "gargov", "1234", "iv.gargov@haha.bg", "1234", 18, address, GenderType.Male);

            this.users.Add(adminUser);
        }

        private bool Login(string username, string password)
        {
            if (this.loggedUser != null)
                return true;

            var user = this.users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());

            if (user != null && user.Password == password)
            {
                this.loggedUser = user;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}