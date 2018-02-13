using DeliverIT.Core.Contracts;
using DeliverIT.Utilities.MenuUtilities;

namespace DeliverIT.Core.Factories.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(MainMenuChoice mainMenuChoice);
    }
}
