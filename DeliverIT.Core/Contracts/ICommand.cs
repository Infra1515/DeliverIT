using System.Collections.Generic;

namespace DeliverIT.Core.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> commandParameters);
    }
}
