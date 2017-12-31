using System;
using System.Collections.Generic;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;
using System.Linq;
using System.Text;
using DeliverIT.Core.Factories;
using DeliverIT.Common.Enums;
using DeliverIT.Core.MenuUtilities;
using DeliverIT.Models;
using DeliverIT.Models.Countries;
using System.Threading;
using System.Globalization;
using DeliverIT.Models.Users;
using DeliverIT.Common;

namespace DeliverIT.Core.Engine
{
    public class DeliverITEngine : IEngine
    {
        private static readonly IEngine SingleInstance = new DeliverITEngine();
        private static Timer actionTimer;
        public static event EventHandler<OrderStateChangedEventArgs> OrderStateChanged;

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

            OrderStateChanged += DeliverITEngine_OrderStateChanged;

            actionTimer = new Timer((state) =>
            {
                if (this.orders.Any())
                {
                    this.ProcessOrders();
                }

                actionTimer.Change(5000, Timeout.Infinite);
            }, null, 5000, Timeout.Infinite);

            do
            {
                try
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
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }
            while (state != MenuState.Exit);
        }

        private void MainMenu(MainMenuChoise mainMenuChoise)
        {
            bool isPermitted = this.CheckRoleAccess(loggedUser.Role, mainMenuChoise);

            if (isPermitted)
            {
                switch (mainMenuChoise)
                {
                    case MainMenuChoise.AddClient:
                        //Console.WriteLine("Adding client ...... ");
                        AddUser("Client");
                        break;

                    case MainMenuChoise.PlaceOrder:
                        //Console.WriteLine("Placing order ...... ");
                        AddOrder();
                        break;

                    case MainMenuChoise.AddCourier:
                        //Console.WriteLine("Adding courier ...... ");
                        AddUser("Courier");
                        break;

                    case MainMenuChoise.AllClients:
                        //Console.WriteLine("Listing clients ...... ");
                        Console.WriteLine(this.ShowAllClients());
                        break;

                    case MainMenuChoise.AllOrders:

                        Console.WriteLine("Listing orders ...... ");
                        this.ShowAllOrders();

                        break;

                    case MainMenuChoise.AllLocations:
                        Console.WriteLine("Listing locations ...... ");
                        this.ShowAllLocations();
                        break;

                    case MainMenuChoise.Logout:

                        this.loggedUser = null;
                        state = MenuState.Login;

                        break;
                }
            }
            else
            {
                Console.WriteLine("You have no permission to accesss this operation!\n");
            }
        }

        private bool CheckRoleAccess(UserRole role, MainMenuChoise mainMenuChoise)
        {
            bool isPresent = false;

            switch (role)
            {
                case UserRole.Administrator:

                    isPresent = LookupRoles.Administrator.Contains(mainMenuChoise);
                    break;

                case UserRole.Operator:

                    isPresent = LookupRoles.Operator.Contains(mainMenuChoise);
                    break;

                case UserRole.Normal:

                    isPresent = LookupRoles.Normal.Contains(mainMenuChoise);
                    break;
            }

            return isPresent;
        }

        private IUser AddUser(string type)
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
                    country = new Serbia();
                    break;

                case CountryType.Russia:
                    country = new Russia();
                    break;

                default:
                    throw new ArgumentException("We don't ship to this country yet!");
            }

            // TODO: Implement validation for city: If its not in Country dict with cities
            // throw exception();
            Console.Write("City: ");
            string city = Console.ReadLine();

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

            foreach(IUser user in this.users)
            {
                if(user.Username == username)
                {
                    throw new ArgumentException(string.Format(
                        Constants.UserAlreadyExists, user.GetType().Name, user.Username));
                }
            }
            if(type == "Client")
            {
                IClient client = this.factory.CreateClient(username, password, firstName, lastName, email,
                        years, phoneNumber, userAddress, gender);
                this.users.Add(client);
                Console.WriteLine(string.Format(userTypeInfo, client.Username));
                return client;
            }
            else
            {
                Console.Write("Enter maximum allowed weight that the courier can carry: ");
                double allowedWeight = double.Parse(Console.ReadLine());
                Console.Write("Enter maximum allowed volume that the courier can carry: ");
                double allowedVolume = double.Parse(Console.ReadLine());
                ICourier courier = this.factory.CreateCourier(username, password, firstName, lastName,
                    email, years, phoneNumber, userAddress, gender, allowedWeight, allowedVolume);
                return courier;
            }

            
        }

        private IProduct AddProduct()
        {

            Console.Write("Dimensions(X Y Z): ");
            var dimensions = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double x = dimensions[0];
            double y = dimensions[1];
            double z = dimensions[2];

            Console.Write("Is the product fragile? ");
            string isFragileStr = Console.ReadLine().ToLower().Trim(); // possible null - needs validation!!
            bool isFragile;
            isFragile = isFragileStr == "yes";

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
            IProduct product = this.factory.CreateProduct(x, y, z, isFragile, weight, productType);
            Console.WriteLine($"Product with ID {product.Id} was added succesfully!");

            return product;

        }

        private IOrder AddOrder()
        {
            string choice;
            ICourier courier = (ICourier)this.users.FirstOrDefault(x => x.Role == UserRole.Normal);

            if (this.loggedUser.Role == UserRole.Administrator)
            {
                Console.WriteLine("--- Courier Information ---");
                Console.WriteLine(@"To choose already registered Courier press 'C' and type his username");
                Console.WriteLine("Or press 'R' to register a new Courier");
                choice = Console.ReadLine();
                if (choice == "C")
                {
                    Console.WriteLine("Type username: ");
                    string username = Console.ReadLine();
                    // how to avoid type casting?
                    foreach (var user in this.users)
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
                sender = (IClient)this.users.FirstOrDefault(x => x.Username == username);
                if (sender == null)
                {

                    throw new ArgumentNullException("No such user!");
                }
                else
                {
                    sender.ClientType = ClientType.Sender;
                    Console.WriteLine($"Sender {sender.FirstName} {sender.LastName} choosen successfully!");

                }
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
                receiver = (Client)this.users.FirstOrDefault(x => x.Username == username);
                if (receiver == null)
                {
                    throw new ArgumentNullException("No such user!");
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
                                "d/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Enter due date for delivery(Day/Month/Year): ");
            DateTime dueDate = DateTime.ParseExact(Console.ReadLine(),
                            "d/M/yyyy", CultureInfo.InvariantCulture);

            int postalCode = receiver.Address.Country.CitysAndZips[receiver.Address.City];

            IOrder order = this.factory.CreateOrder(courier, sender, receiver, sendDate, dueDate,
                OrderState.NotDelivered, product, postalCode);
            Console.WriteLine($"Order with ID {order.Id} created!");

            this.orders.Add(order);

            receiver.AddOrder(order);

            sender.AddOrder(order);

            courier.AddOrder(order);

            return order;
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
                    else
                        Console.WriteLine("Wrong username or password!\n");

                    break;

                case LoginChoise.Exit:
                    state = MenuState.Exit;
                    break;
            }
        }

        private void ProcessOrders()
        {
            foreach (var order in this.orders)
            {
                var lastState = order.OrderState;

                if (order.DueDate < DateTime.Now && order.OrderState != OrderState.Delivered)
                {
                    order.OrderState = OrderState.Delivered;
                    OnOrderStateChanged(this, new OrderStateChangedEventArgs(lastState, order.OrderState, order.Id));
                }
            }
        }

        private string ShowAllClients()
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

        private bool Login(string username, string password)
        {
            if (this.loggedUser != null)
                return true;

            var user = this.users.FirstOrDefault(x => string.Equals(x.Username, username, StringComparison.CurrentCultureIgnoreCase));

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

        private void ShowAllOrders()
        {
            if (this.orders.Any())
            {
                foreach (var order in orders)
                {
                    Console.WriteLine(order.ToString());
                }
            }    
        }

        private string ShowAllLocations()
        {
            var counter = 1;
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("--- Delivery locations ---");
            strBuilder.AppendLine(counter.ToString() + ". " + CountryType.Bulgaria.ToString());
            counter++;
            strBuilder.AppendLine(counter.ToString() + ". " + CountryType.Russia.ToString());
            counter++;
            strBuilder.AppendLine(counter.ToString() + ". " + CountryType.Germany.ToString());
            return strBuilder.ToString();
        }

        private void SeedObjects()
        {
            var adminUser = this.factory.CreateAdmin("root", "123456", "Ivan", "Gargov", "basi@qkoto.adminsum");

            var country = new Bulgaria();
            var address = new Address(country, "Dummy", "100", "Sofia");
                
            var dummyClient = this.factory.CreateClient("client123", "1234", "DummyFirst", "DummyLast", "dummy@dummy.com", 18, "12345678", address, GenderType.Male);
            var dummyClientCool = this.factory.CreateClient("coolClient", "1234", "DummyCool", "DummyLastCool", "dummycool@dummy.com", 18, "12345678", address, GenderType.Male);

            // Beloved ones resurrected :))
            var dummyCourierGosheedy = this.factory.CreateCourier("gosheedy", "1234", "Gosheto", "Goshev", "Gosheto@DeliveryIT.com", 20, "0895448694", address, GenderType.Male, 500, 40);
            var dummyCourierPeshont = this.factory.CreateCourier("peshont", "1234", "Peshont", "Peshontov", "Peshkata@DeliveryIT.com", 20, "0885236652", address, GenderType.Male, 500, 40);

            var product = this.factory.CreateProduct(10, 10, 10, false, 50, ProductType.Accessories);
            var order = this.factory.CreateOrder(dummyCourierGosheedy, dummyClient, dummyClientCool, DateTime.Now, DateTime.Now.AddSeconds(30), OrderState.InProgress, product, 10);

            this.users.Add(adminUser);
            this.users.Add(dummyClient);
            this.users.Add(dummyCourierGosheedy);
            this.users.Add(dummyCourierPeshont);
            this.orders.Add(order);
        }

        protected virtual void OnOrderStateChanged(object source, OrderStateChangedEventArgs args)
        {
            OrderStateChanged?.Invoke(this, args);
        }

        private void DeliverITEngine_OrderStateChanged(object sender, OrderStateChangedEventArgs args)
        {
            Console.WriteLine($"Order {args.ID} status changed from {args.LAST_STATE} to {args.CURRENT_STATE}");
        }
    }
}