using System;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Providers;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Utilities.MenuUtilities;
using DeliverIT.Utilities.IOUtilities.Contracts;

namespace DeliverIT.Core
{
    public class DeliverITEngine : IEngine
    {
        private readonly IReader reader;
        private readonly ICommandsFactory commandsFactory;
        private readonly IWriter writer;
        private readonly IUserContext userController;
        private AuthProvider authentication;

        public DeliverITEngine(
            IWriter writer,
            IReader reader,
            ICommandsFactory commandsFactory,
            AuthProvider authentication,
            IUserContext userController)
        {
            this.writer = writer;
            this.reader = reader;
            this.commandsFactory = commandsFactory;
            this.authentication = authentication;
            this.userController = userController;
        }

        public void Start()
        {
            while(true)
            {
                if (this.userController.CurrentUser == null)
                {
                    this.writer.WriteLine(LookupMenuText.LoginText);

                    int.TryParse(this.reader.ReadLine(), out int userLoginChoice);
                    bool isValidLoginChoice = Enum.IsDefined(typeof(LoginChoice), userLoginChoice);

                    if (isValidLoginChoice)
                    {
                        if ((LoginChoice)userLoginChoice == LoginChoice.Exit)
                            break;

                        this.writer.WriteLine("Username: ");
                        string username = this.reader.ReadLine();

                        this.writer.WriteLine("Password: ");
                        string password = this.reader.ReadLine();

                        this.authentication.Login(username, password);
                    }
                }
                else
                {
                    this.writer.WriteLine(LookupMenuText.MainMenuText);

                    int.TryParse(this.reader.ReadLine(), out int userMainMenuChoice);
                    bool isValidMainMenuChoice = Enum.IsDefined(typeof(MainMenuChoice), userMainMenuChoice);

                    if (isValidMainMenuChoice)
                    {
                        if ((MainMenuChoice)userMainMenuChoice == MainMenuChoice.Logout)
                        {
                            this.authentication.Logout();
                            continue;
                        }

                        try
                        {
                            var command = this.commandsFactory.GetCommand((MainMenuChoice)userMainMenuChoice);
                            var result = command.Execute();

                            this.writer.WriteLine(result);
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            this.writer.WriteLine(ex.Message);
                        }
                        
                    }
                }
            }
        }
    }
}