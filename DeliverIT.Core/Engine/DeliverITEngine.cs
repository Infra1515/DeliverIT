using System;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Core.Providers;
using DeliverIT.Core.Configuration;

namespace DeliverIT.Core.Engine
{
    public class DeliverITEngine : IEngine
    {
        private readonly IDataStore dataStore;
        private readonly IReader reader;
        private readonly ICommandsFactory commandsFactory;
        private readonly IWriter writer;
        private readonly SeedDataStore seedDataStore;
        private AuthProvider authentication;

        public DeliverITEngine(
            IDataStore dataStore, 
            IWriter writer, 
            IReader reader, 
            ICommandsFactory commandsFactory, 
            AuthProvider authentication, 
            SeedDataStore seedDataStore)
        {
            this.dataStore = dataStore;
            this.writer = writer;
            this.reader = reader;
            this.commandsFactory = commandsFactory;
            this.authentication = authentication;
            this.seedDataStore = seedDataStore;
        }

        public void Start()
        {
            this.seedDataStore.SeedObjects();

            while(true)
            {
                if (!this.authentication.IsUserLogged)
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

                        var command = this.commandsFactory.GetCommand((MainMenuChoice)userMainMenuChoice);
                        command.Execute();
                    }
                }
            }
        }
    }
}