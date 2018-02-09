using System;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;
using System.Linq;
using DeliverIT.Common;
using DeliverIT.Core.Exceptions;
using DeliverIT.Contracts;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Common.Enums;
using DeliverIT.Core.MenuUtilities;

namespace DeliverIT.Core.Engine
{
    public class DeliverITEngine : IEngine
    {
        private readonly IDataStore dataStore;
        private readonly IReader reader;
        private readonly ICommandsFactory commandsFactory;
        private readonly IWriter writer;

        private MenuState state = MenuState.Login;
        private IUser loggedUser;

        public DeliverITEngine(IDataStore dataStore, IWriter writer, IReader reader, ICommandsFactory commandsFactory)
        {
            this.loggedUser = null;
            this.dataStore = dataStore;
            this.writer = writer;
            this.reader = reader;
            this.commandsFactory = commandsFactory;
        }

        public void Start()
        {
            do
            {
                Console.ResetColor();
                try
                {
                    switch (state)
                    {
                        case MenuState.Login:

                            this.writer.WriteLine(LookupMenuText.LoginText);

                            int.TryParse(Console.ReadLine(), out int userLoginChoice);
                            bool isValidLoginChoice = Enum.IsDefined(typeof(LoginChoice), userLoginChoice);

                            if (!isValidLoginChoice)
                            {
                                throw new InvalidMenuChoiceException(Constants.InvalidMenuChoiceMessage);
                            }

                            LoginMenu((LoginChoice)userLoginChoice);

                            break;

                        case MenuState.MainMenu:

                            this.writer.WriteLine(LookupMenuText.MainMenuText);

                            int.TryParse(Console.ReadLine(), out int userMainMenuChoice);
                            var isValidMainMenuChoice = Enum.IsDefined(typeof(MainMenuChoice), userMainMenuChoice);

                            if (!isValidMainMenuChoice)
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
                    this.writer.WriteLine(ex.Message);
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
                        this.commandsFactory.GetCommand("addclient");
                        break;

                    case MainMenuChoice.AddCourier:
                        Console.WriteLine("Adding courier ...... ");
                        this.commandsFactory.GetCommand("addcourier");
                        break;

                    case MainMenuChoice.PlaceOrder:
                        Console.WriteLine("Placing order ...... ");
                        this.commandsFactory.GetCommand("addorder");
                        break;

                    case MainMenuChoice.AllClients:
                        Console.WriteLine("Listing clients ...... ");
                        this.commandsFactory.GetCommand("showallclients");
                        break;

                    case MainMenuChoice.AllOrders:

                        Console.WriteLine("Listing orders ...... ");
                        this.commandsFactory.GetCommand("showallorders");

                        break;

                    case MainMenuChoice.AllLocations:
                        Console.WriteLine("Listing locations ...... ");
                        this.commandsFactory.GetCommand("showalllocations");
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
    }
}