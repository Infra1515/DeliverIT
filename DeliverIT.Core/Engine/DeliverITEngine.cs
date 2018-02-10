using System;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;
using DeliverIT.Common;
using DeliverIT.Core.Exceptions;
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

        public DeliverITEngine(IDataStore dataStore, IWriter writer, IReader reader, ICommandsFactory commandsFactory, 
            AuthProvider authentication, SeedDataStore seedDataStore)
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

            do
            {
                if (!this.authentication.IsLogged)
                {
                    this.writer.WriteLine(LookupMenuText.LoginText);

                    int.TryParse(Console.ReadLine(), out int userLoginChoice);
                    bool isValidLoginChoice = Enum.IsDefined(typeof(LoginChoice), userLoginChoice);

                    if (!isValidLoginChoice)
                    {
                        throw new InvalidCredentialsException(Constants.InvalidCredentialsMessage);
                    }

                    this.writer.WriteLine("Username: ");
                    string username = this.reader.ReadLine();

                    this.writer.WriteLine("Password: ");
                    string password = this.reader.ReadLine();

                    this.authentication.Login(username, password);
                }
                else
                {
                    this.writer.WriteLine(LookupMenuText.MainMenuText);

                    int.TryParse(Console.ReadLine(), out int userMainMenuChoice);
                    var isValidMainMenuChoice = Enum.IsDefined(typeof(MainMenuChoice), userMainMenuChoice);

                    if (!isValidMainMenuChoice)
                    {
                        throw new InvalidMenuChoiceException(Constants.InvalidMenuChoiceMessage);
                    }

                    var command = this.commandsFactory.GetCommand((MainMenuChoice)userMainMenuChoice);
                    command.Execute();
                }
            }
            while (true); 
        }
    }
}