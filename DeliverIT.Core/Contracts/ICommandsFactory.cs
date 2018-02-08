namespace DeliverIT.Core.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(string commandName);
    }
}
