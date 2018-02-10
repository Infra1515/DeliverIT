using DeliverIT.Core.Utilities;

namespace DeliverIT.Core.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(MainMenuChoice mainMenuChoice);
    }
}
