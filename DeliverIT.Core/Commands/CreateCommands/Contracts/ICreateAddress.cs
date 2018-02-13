using System.Collections.Generic;
using DeliverIT.Data.Contracts;

namespace DeliverIT.Core.Commands.CreateCommands.Contracts
{
    public interface ICreateAddress
    {
        IAddress Create(IList<string> commandParameters);
    }
}