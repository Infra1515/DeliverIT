using System;
using System.Collections.Generic;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;
using System.Linq;
using DeliverIT.Core.Factories;
using DeliverIT.Common.Enums;
using DeliverIT.Core.MenuUtilities;
using DeliverIT.Models;
using DeliverIT.Models.Countries;

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

        private void MainMenu(MainMenuChoise mainMenuChoise)
        {
            bool isPermitted = this.CheckRoleAccess(loggedUser.Role, mainMenuChoise);

            if (isPermitted)
            {
                switch (mainMenuChoise)
                {
                    case MainMenuChoise.AddClient:
                        Console.WriteLine("Adding client ...... ");
                        //AddClient("Client");
                        break;

                    case MainMenuChoise.PlaceOrder:
                        Console.WriteLine("Placing order ...... ");
                        //AddOrder();
                        break;

                    case MainMenuChoise.AddCourier: //optional?
                        Console.WriteLine("Adding courier ...... ");
                        //Console.WriteLine("Implement adding a courier ...");
                        break;

                    case MainMenuChoise.AllClients:
                        Console.WriteLine("Listing clients ...... ");
                        //Console.WriteLine(this.ShowAllClients());
                        break;

                    case MainMenuChoise.AllOrders:
                        Console.WriteLine("Listing orders ...... ");
                        //Console.WriteLine(this.ShowAllOrders());
                        break;

                    case MainMenuChoise.AllLocations:
                        Console.WriteLine("Listing locations ...... ");
                        //Console.WriteLine(ShowAllLocations());
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

        //private Client AddClient(string type)
        //{
        //    Console.Write("Username: ");
        //    string username = Console.ReadLine();

        //    Console.Write("First name: ");
        //    string firstName = Console.ReadLine();

        //    Console.Write("Phone number: ");
        //    string phoneNumber = Console.ReadLine();

        //    Console.Write("Years: ");
        //    int years = int.Parse(Console.ReadLine());

        //    Console.Write("Gender: ");
        //    GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), Console.ReadLine());

        //    Console.WriteLine("--- Address ---");
        //    Console.Write("Country: ");
        //    string countryString = Console.ReadLine();

        //    Country country;

        //    switch ((CountryType)Enum.Parse(typeof(CountryType), countryString))
        //    {

        //        case CountryType.Bulgaria:
        //            country = new Bulgaria();
        //            break;

        //        case CountryType.Germany:
        //            country = new Serbia();
        //            break;

        //        case CountryType.Russia:
        //            country = new Russia();
        //            break;

        //        default:
        //            throw new ArgumentException("We don't ship to this country yet!");
        //    }

        //    // TODO: Implement validation for city: If its not in Country dict with cities
        //    // throw exception();
        //    Console.Write("City: ");
        //    string city = Console.ReadLine();

        //    Console.Write("Street name: ");
        //    string streetName = Console.ReadLine();

        //    Console.Write("Street number: ");
        //    string streetNumber = Console.ReadLine();

        //    //Address userAddress = new Address(country, streetName, streetNumber, city);

        //    string clientTypeInfo;
        //    switch (type)
        //    {
        //        case "Client":
        //            clientTypeInfo = Constants.RegisteredClient;
        //            break;
        //        case "Sender":
        //            clientTypeInfo = Constants.ChoosenSender;
        //            break;
        //        case "Receiver":
        //            clientTypeInfo = Constants.ChoosenReceiver;
        //            break;
        //        default:
        //            throw new ArgumentException("No such client type!");
        //    }

        //    if (this.users.Any(user => user.UserName == username))
        //    {
        //        throw new ArgumentException("User already exists!");
        //    }
        //    else
        //    {

        //        Client client = this.factory.CreateClient(firstName, lastName, email, phoneNumber,
        //            years, userAddress, gender, (ClientType)Enum.Parse(typeof(ClientType), type), username);
        //        this.clients.Add(client);
        //        Console.WriteLine(string.Format(clientTypeInfo, client.UserName));
        //        return client;
        //    }
        //}
        //private Product AddProduct()
        //{

        //    Console.Write("Dimensions(X Y Z): ");
        //    var dimensions = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        //    double x = dimensions[0];
        //    double y = dimensions[1];
        //    double z = dimensions[2];

        //    Console.Write("Is the product fragile? ");
        //    string isFragileStr = Console.ReadLine().ToLower().Trim();
        //    bool isFragile;
        //    if (isFragileStr == "yes")
        //    {
        //        isFragile = true;
        //    }
        //    else
        //    {
        //        isFragile = false;
        //    }

        //    Console.Write("What is the product weight? ");
        //    double weight = double.Parse(Console.ReadLine());

        //    Console.Write($"What is the product type?\r\n" +
        //        "Available:  Clothes, Accessories, Electronics, Other: ");
        //    string productTypeString = Console.ReadLine().ToLower().Trim();
        //    ProductType productType;
        //    switch (productTypeString)
        //    {
        //        case "clothes":
        //            productType = ProductType.Clothes;
        //            break;
        //        case "accessories":
        //            productType = ProductType.Clothes;
        //            break;
        //        case "electronics":
        //            productType = ProductType.Electronics;
        //            break;
        //        case "other":
        //            productType = ProductType.Other;
        //            break;
        //        default:
        //            productType = ProductType.Other;
        //            break;
        //    }
        //    Product product = this.factory.CreateProduct(x, y, z, isFragile, weight, productType);
        //    Console.WriteLine($"Product with ID {product.Id} was added succesfully!");

        //    return product;

        //}

        //private IOrder AddOrder()
        //{
        //    Console.WriteLine("Choose a courier: ");
        //    Console.WriteLine("8." + new Gosheedy().ToString());
        //    Console.WriteLine("9." + new Peshont().ToString());
        //    Courier courier = CreateCourier(int.Parse(Console.ReadLine()));

        //    Console.WriteLine("--- Sender information ---");
        //    Console.WriteLine(@"To choose already registered user press 'C' and type his username");
        //    Console.WriteLine("Or press 'R' to register a new user");
        //    Client sender;
        //    string choice = Console.ReadLine();
        //    if (choice == "C")
        //    {
        //        Console.WriteLine("Type username: ");
        //        string username = Console.ReadLine();
        //        sender = this.users.FirstOrDefault(x => x.UserName == username);

        //        if (sender == null)
        //        {
        //            throw new ArgumentNullException("No such user!");
        //        }
        //        else
        //        {
        //            sender.ClientType = ClientType.Sender;
        //            Console.WriteLine($"Sender {sender.FirstName} {sender.LastName} choosen successfully!");

        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Register the new user: ");
        //        sender = AddClient("Sender");

        //        Console.WriteLine("--- Receiver information ---");
        //        Console.WriteLine(@"To choose already registered user press 'C' and type his username");
        //        Console.WriteLine("Or press 'R' to register a new user");
        //        Client receiver;
        //        choice = Console.ReadLine();
        //        if (choice == "C")
        //        {
        //            Console.WriteLine("Type username: ");
        //            string username = Console.ReadLine();
        //            receiver = this.clients.FirstOrDefault(x => x.UserName == username);
        //            if (receiver == null)
        //            {
        //                throw new ArgumentNullException("No such user!");
        //            }
        //            else
        //            {
        //                receiver.ClientType = ClientType.Receiver;
        //                Console.WriteLine($"Reciver {receiver.FirstName} {receiver.LastName} choosen successfully!");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Register the new user: ");
        //            receiver = AddClient("Receiver");
        //        }

        //        Console.Write("---Product information---");
        //        Product product = AddProduct();

        //        Console.Write("Enter date of sending (Day/Month/Year): ");
        //        DateTime sendDate = DateTime.ParseExact(Console.ReadLine(),
        //                            "d/MM/yyyy", CultureInfo.InvariantCulture);
        //        Console.Write("Enter due date for delivery(Day/Month/Year): ");
        //        DateTime dueDate = DateTime.ParseExact(Console.ReadLine(),
        //                       "d/M/yyyy", CultureInfo.InvariantCulture);

        //        int postalCode = receiver.Address.Country.CitysAndZips[receiver.Address.City];

        //        IOrder order = this.factory.CreateOrder(courier, sender, receiver, sendDate, dueDate,
        //            OrderState.NotDelivered, receiver.Address, product, postalCode);
        //        Console.WriteLine($"Order with ID {order.Id} created!");

        //        this.orders.Add(order);

        //        receiver.AddOrder(order);

        //        sender.AddOrder(order);

        //        courier.AddOrder(order);

        //        return order;
        //    }
        //}

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

        //private string ShowAllClients()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    if (this.users.Count == 0)
        //    {
        //        sb.AppendLine("No clients registered!");
        //    }
        //    else
        //    {
        //        foreach (var client in this.users)
        //        {
        //            sb.AppendLine(client.ToString()); //must implement TOSTRING method
        //            sb.AppendLine("-----------------------");
        //        }
        //    }
        //}

        private void SeedObjects()
        {
            var adminUser = this.factory.CreateAdmin("root", "123456", "Ivan", "Gargov", "basi@qkoto.adminsum");

            var country = new Bulgaria();
            var address = new Address(country, "Dummy", "100", "Sofia");

            var dummyClient = this.factory.CreateClient("client123", "1234", "DummyFirst", "DummyLast", "dummy@dummy.com", 18, "12345678", address, GenderType.Male);

            // Beloved ones resurrected :))
            var dummyCourierGosheedy = this.factory.CreateCourier("gosheedy", "1234", "Gosheto", "Goshev", "Gosheto@DeliveryIT.com", 20, "0895448694", address, GenderType.Male, 500, 40);
            var dummyCourierPeshont = this.factory.CreateCourier("peshont", "1234", "Peshont", "Peshontov", "Peshkata@DeliveryIT.com", 20, "0885236652", address, GenderType.Male, 500, 40);

            this.users.Add(adminUser);
            this.users.Add(dummyClient);
            this.users.Add(dummyCourierGosheedy);
            this.users.Add(dummyCourierPeshont);
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

        //private string ShowAllOrders()
        //{
        //    if (this.orders.Count == 0)
        //    {
        //        sb.AppendLine("No orders registered!");
        //    }
        //    else
        //    {
        //        foreach (var order in this.orders)
        //        {
        //            sb.Append(order.ToString());
        //        }
        //    }

        //    return sb.ToString();
        //}

        //private string ShowAllLocations()
        //{
        //    var counter = 1;
        //    StringBuilder strBuilder = new StringBuilder();
        //    strBuilder.AppendLine("--- Delivery locations ---");
        //    strBuilder.AppendLine(counter.ToString() + ". " + CountryType.Bulgaria.ToString());
        //    counter++;
        //    strBuilder.AppendLine(counter.ToString() + ". " + CountryType.Russia.ToString());
        //    counter++;
        //    strBuilder.AppendLine(counter.ToString() + ". " + CountryType.Germany.ToString());
        //    return strBuilder.ToString();
        //}
    }
}