using System.Collections.Generic;
using DeliverIT.Data.Contracts;

namespace DeliverIT.Core.Commands.CreateCommands.Contracts
{
    public interface ICreateProduct
    {
        IProduct Create(IList<string> commandParameters);
    }
}
