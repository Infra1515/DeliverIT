﻿using Autofac;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;

namespace DeliverIT.Core.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IComponentContext container;

        public CommandsFactory(IComponentContext container)
        {
            this.container = container;
        }

        public ICommand GetCommand(MainMenuChoice mainMenuChoice)
        {
            return this.container.ResolveKeyed<ICommand>(mainMenuChoice);
        }
    }
}
