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
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Engine
{
    public class DeliverITEngine : IEngine
    {
        //private static readonly IEngine SingleInstance = new DeliverITEngine();
        private static Timer actionTimer;
        private readonly IDataStore dataStore;
        private readonly IReader reader;
        private readonly IWriter writer;
        public static event EventHandler<OrderStateChangedEventArgs> OrderStateChanged;
        


        private MenuState state = MenuState.Login;
        private IUser loggedUser;
        //private readonly CommandProcessor commandProcessor;

        public DeliverITEngine(IDataStore dataStore, IWriter writer, IReader reader)
        {
            //this.commandProcessor = new CommandProcessor();
            this.loggedUser = null;
            this.dataStore = dataStore;
            this.writer = writer;
            this.reader = reader;
        }

        //public static IEngine Instance
        //{
        //    get { return SingleInstance; }
        //}

        public void Start()
        {
            //this.SeedObjects();

            OrderStateChanged += DeliverITEngine_OrderStateChanged;

            actionTimer = new Timer((state) =>
            {
                if (this.dataStore.Orders.Any())
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

                            //this.writer.WriteLine(LookupMenuText.LoginText);

                            //int.TryParse(Console.ReadLine(), out int userLoginChoice);
                            //bool isValidLoginChoice = Enum.IsDefined(typeof(LoginChoice), userLoginChoice);

                            //if (!isValidLoginChoice)
                            //{
                            //    throw new InvalidMenuChoiceException(Constants.InvalidMenuChoiceMessage);
                            //}

                            //LoginMenu((LoginChoice)userLoginChoice);

                            break;

                        case MenuState.MainMenu:

                            this.writer.WriteLine(LookupMenuText.MainMenuText);

                            int.TryParse(Console.ReadLine(), out int userMainMenuChoice);
                            var isValidMainMenuChoice = Enum.IsDefined(typeof(MainMenuChoice), userMainMenuChoice);

                            if (!isValidMainMenuChoice)
                            {
                                throw new InvalidCredentialsException(Constants.InvalidCredentialsMessage);
                            }

                            //MainMenu((MainMenuChoice)userMainMenuChoice);

                            break;

                        default:
                            state = MenuState.Exit;
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    this.writer.WriteLine(ex.Message);
                }
               
            }
            while (state != MenuState.Exit); 
        }

        //private void MainMenu(MainMenuChoice mainMenuChoice)
        //{
        //    //bool isPermitted = this.CheckRoleAccess(loggedUser.Role, mainMenuChoice);

        //    if (isPermitted)
        //    {
        //        switch (mainMenuChoice)
        //        {
        //            case MainMenuChoice.AddClient:
        //                Console.WriteLine("Adding client ...... ");
        //                this.commandProcessor.AddClient();
        //                break;

        //            case MainMenuChoice.AddCourier:
        //                Console.WriteLine("Adding courier ...... ");
        //                this.commandProcessor.AddCourier();
        //                break;

        //            case MainMenuChoice.PlaceOrder:
        //                Console.WriteLine("Placing order ...... ");
        //                this.commandProcessor.AddOrder();
        //                break;

        //            case MainMenuChoice.AllClients:
        //                Console.WriteLine("Listing clients ...... ");
        //                Console.WriteLine(this.commandProcessor.ShowAllClients());
        //                break;

        //            case MainMenuChoice.AllOrders:

        //                Console.WriteLine("Listing orders ...... ");
        //                Console.WriteLine(this.commandProcessor.ShowAllOrders());

        //                break;

        //            case MainMenuChoice.AllLocations:
        //                Console.WriteLine("Listing locations ...... ");
        //                Console.WriteLine(this.commandProcessor.ShowAllLocations());
        //                break;

        //            case MainMenuChoice.Logout:

        //                this.loggedUser = null;
        //                state = MenuState.Login;

        //                break;
        //        }
        //    }
        //    else
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("You have no permission to accesss this operation!\n");
        //        Console.ResetColor();
        //    }
        //}

        

        private void ProcessOrders()
        {
            foreach (var order in this.dataStore.Orders)
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

            var user = this.dataStore.Users.FirstOrDefault(x => string.Equals(x.Username, username,
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