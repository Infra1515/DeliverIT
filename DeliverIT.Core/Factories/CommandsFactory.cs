using Autofac;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IComponentContext container;

        public CommandsFactory(IComponentContext container)
        {
            this.container = container;
        }

        public ICommand GetCommand(string commandName)
        {
            return this.container.ResolveNamed<ICommand>(commandName);
        }
    }
}
