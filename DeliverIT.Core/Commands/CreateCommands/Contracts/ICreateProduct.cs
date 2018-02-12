using System.Collections.Generic;
using DeliverIT.Contracts;

namespace DeliverIT.Core.Commands.CreateCommands.Contracts
{
    public interface ICreateProduct
    {
        IProduct Create(IList<string> commandParameters);
    }
}
