using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Factories.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(MainMenuChoice mainMenuChoice);
    }
}
