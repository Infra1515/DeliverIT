using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;

namespace DeliverIT.Core.Factories.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(MainMenuChoice mainMenuChoice);
    }
}
