﻿using System;
using DeliverIT.Core.Commands.Providers;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Core.Providers;
using DeliverIT.Core.Utilities;
using DeliverIT.Data;

namespace DeliverIT.Core
{
    public class DeliverITEngine : IEngine
    {
        private readonly IDataStore dataStore;
        private readonly IReader reader;
        private readonly ICommandsFactory commandsFactory;
        private readonly IWriter writer;
        private readonly IUserContext userController;
        private readonly ICommandProcessor commandProcessor;
        private readonly ICommandParser commandParser;
        private AuthProvider authentication;

        public DeliverITEngine(
            IDataStore dataStore,
            IWriter writer,
            IReader reader,
            ICommandsFactory commandsFactory,
            AuthProvider authentication,
            IUserContext userController,
            ICommandProcessor commandProcessor, 
            ICommandParser commandParser)
        {
            this.dataStore = dataStore;
            this.writer = writer;
            this.reader = reader;
            this.commandsFactory = commandsFactory;
            this.authentication = authentication;
            this.userController = userController;
            this.commandProcessor = commandProcessor;
            this.commandParser = commandParser;
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

                        // parse command
                        //usermainchoice int -> resolve with it
                        //var parser = 
                        var command = this.commandsFactory.GetCommand((MainMenuChoice)userMainMenuChoice);
                        command.Execute(this.commandProcessor.ParametersToProcess);
                    }
                }
            }
        }
    }
}