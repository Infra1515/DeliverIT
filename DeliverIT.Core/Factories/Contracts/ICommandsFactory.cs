using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Factories.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(string commandName);
    }
}
