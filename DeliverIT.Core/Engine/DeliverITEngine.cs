using System;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;
using System.Linq;
using DeliverIT.Common.Enums;
using DeliverIT.Core.MenuUtilities;
using DeliverIT.Models;
using DeliverIT.Models.Countries;
using System.Threading;
using DeliverIT.Common;
using DeliverIT.Core.Exceptions;
using DeliverIT.Contracts;
using DeliverIT.Core.Engine.Event;

namespace DeliverIT.Core.Engine
{
    public class DeliverITEngine : IEngine
    {
        private static readonly IEngine SingleInstance = new DeliverITEngine();
        private static Timer actionTimer;
        public static event EventHandler<OrderStateChangedEventArgs> OrderStateChanged;

        private MenuState state = MenuState.Login;
        private IUser loggedUser;
        private readonly CommandProcessor commandProcessor;

        private DeliverITEngine()
        {
            this.commandProcessor = new CommandProcessor();
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
                if (this.commandProcessor.Orders.Any())
                {
                    this.ProcessOrders();
                }

                actionTimer.Change(5000, Timeout.Infinite);
            }, null, 5000, Timeout.Infinite);

            do
            {
                Console.ResetColor();
                try
                {
                    switch (state)
                    {
                        case MenuState.Login:

                            Console.WriteLine(LookupMenuText.LoginText);

                            int.TryParse(Console.ReadLine(), out int userLoginChoice);
                            bool isValidLoginChoice = Enum.IsDefined(typeof(LoginChoice), userLoginChoice);

                            if (!isValidLoginChoice)
                            {
                                throw new InvalidMenuChoiceException(Constants.InvalidMenuChoiceMessage);
                            }

                            LoginMenu((LoginChoice)userLoginChoice);

                            break;

                        case MenuState.MainMenu:

                            Console.WriteLine(LookupMenuText.MainMenuText);

                            int.TryParse(Console.ReadLine(), out int userMainMenuChoice);
                            var isValidMainMenuChoise = Enum.IsDefined(typeof(MainMenuChoice), userMainMenuChoice);

                            if (!isValidMainMenuChoise)
                            {
                                throw new InvalidCredentialsException(Constants.InvalidCredentialsMessage);
                            }

                            MainMenu((MainMenuChoice)userMainMenuChoice);

                            break;

                        default:
                            state = MenuState.Exit;
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
               
            }
            while (state != MenuState.Exit);
        }

        private void MainMenu(MainMenuChoice mainMenuChoice)
        {
            bool isPermitted = this.CheckRoleAccess(loggedUser.Role, mainMenuChoice);

            if (isPermitted)
            {
                switch (mainMenuChoice)
                {
                    case MainMenuChoice.AddClient:
                        Console.WriteLine("Adding client ...... ");
                        this.commandProcessor.AddClient();
                        break;

                    case MainMenuChoice.AddCourier:
                        Console.WriteLine("Adding courier ...... ");
                        this.commandProcessor.AddCourier();
                        break;

                    case MainMenuChoice.PlaceOrder:
                        Console.WriteLine("Placing order ...... ");
                        this.commandProcessor.AddOrder();
                        break;

                    case MainMenuChoice.AllClients:
                        Console.WriteLine("Listing clients ...... ");
                        Console.WriteLine(this.commandProcessor.ShowAllClients());
                        break;

                    case MainMenuChoice.AllOrders:

                        Console.WriteLine("Listing orders ...... ");
                        Console.WriteLine(this.commandProcessor.ShowAllOrders());

                        break;

                    case MainMenuChoice.AllLocations:
                        Console.WriteLine("Listing locations ...... ");
                        Console.WriteLine(this.commandProcessor.ShowAllLocations());
                        break;

                    case MainMenuChoice.Logout:

                        this.loggedUser = null;
                        state = MenuState.Login;

                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have no permission to accesss this operation!\n");
                Console.ResetColor();
            }
        }

        private bool CheckRoleAccess(UserRole role, MainMenuChoice mainMenuChoice)
        {
            bool isPresent = false;

            switch (role)
            {
                case UserRole.Administrator:

                    isPresent = LookupRoles.Administrator.Contains(mainMenuChoice);
                    break;

                case UserRole.Operator:

                    isPresent = LookupRoles.Operator.Contains(mainMenuChoice);
                    break;

                case UserRole.Normal:

                    isPresent = LookupRoles.Normal.Contains(mainMenuChoice);
                    break;
            }

            return isPresent;
        }

        private void LoginMenu(LoginChoice userChoice)
        {
            switch (userChoice)
            {
                case LoginChoice.Login:

                    Console.Write("Username: ");
                    string username = Console.ReadLine();

                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    var isLogged = this.Login(username, password);

                    if (!isLogged)
                    {
                        throw new InvalidCredentialsException(Constants.InvalidCredentialsMessage);
                    }

                    state = MenuState.MainMenu;
                    break;

                case LoginChoice.Exit:
                    state = MenuState.Exit;
                    break;
            }
        }

        private void ProcessOrders()
        {
            foreach (var order in this.commandProcessor.Orders)
            {
                var lastState = order.OrderState;

                if (order.DueDate < DateTime.Now && order.OrderState != OrderState.Delivered)
                {
                    order.OrderState = OrderState.Delivered;
                    OnOrderStateChanged(this, new OrderStateChangedEventArgs(lastState, order.OrderState, order.Id));
                }
            }
        }

        private bool Login(string username, string password)
        {
            if (this.loggedUser != null)
                return true;

            var user = this.commandProcessor.Users.FirstOrDefault(x => string.Equals(x.Username, username,
                StringComparison.CurrentCultureIgnoreCase));

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

        private void SeedObjects()
        {
            var adminUser = this.commandProcessor.Factory.CreateAdmin("root", "123456", "Ivan", "Gargov", "basi@qkoto.adminsum");

            var country = new Bulgaria();
            var address = new Address(country, "Dummy", "100", "Sofia");
                
            var dummyClient = this.commandProcessor.Factory.CreateClient("client123", "1234", "DummyFirst", "DummyLast", "dummy@dummy.com", 18, "12345678", address, GenderType.Male);
            var dummyClientCool = this.commandProcessor.Factory.CreateClient("coolClient", "1234", "DummyCool", "DummyLastCool", "dummycool@dummy.com", 18, "12345678", address, GenderType.Male);

            // Beloved ones resurrected :))
            var dummyCourierGosheedy = this.commandProcessor.Factory.CreateCourier("gosheedy", "1234", "Gosheto", "Goshev", "Gosheto@DeliveryIT.com", 20, "0895448694", address, GenderType.Male, 500, 40);
            var dummyCourierPeshont = this.commandProcessor.Factory.CreateCourier("peshont", "1234", "Peshont", "Peshontov", "Peshkata@DeliveryIT.com", 20, "0885236652", address, GenderType.Male, 500, 40);

            var product = this.commandProcessor.Factory.CreateProduct(10, 10, 10, false, 50, ProductType.Accessories);
            var order = this.commandProcessor.Factory.CreateOrder(dummyCourierGosheedy, dummyClient, dummyClientCool, DeliveryType.Express, DateTime.Now, DateTime.Now.AddSeconds(30), OrderState.InProgress, product, 10);

            this.commandProcessor.Users.Add(adminUser);
            this.commandProcessor.Users.Add(dummyClient);
            this.commandProcessor.Users.Add(dummyClientCool);
            this.commandProcessor.Users.Add(dummyCourierGosheedy);
            this.commandProcessor.Users.Add(dummyCourierPeshont);
            this.commandProcessor.Orders.Add(order);
        }

        protected virtual void OnOrderStateChanged(object source, OrderStateChangedEventArgs args)
        {
            OrderStateChanged?.Invoke(this, args);
        }

        private void DeliverITEngine_OrderStateChanged(object sender, OrderStateChangedEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Order {args.ID} status changed from {args.LAST_STATE} to {args.CURRENT_STATE}");
            Console.ResetColor();
        }
    }
}