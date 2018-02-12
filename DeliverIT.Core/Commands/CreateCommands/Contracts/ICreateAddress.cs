using System.Collections.Generic;
using DeliverIT.Contracts;

namespace DeliverIT.Core.Commands
{
    public interface ICreateAddress
    {
        IAddress Create(IList<string> commandParameters);
    }
}