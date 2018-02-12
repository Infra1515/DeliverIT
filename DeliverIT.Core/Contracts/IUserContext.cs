using DeliverIT.Contracts;
using System.Collections.Generic;

namespace DeliverIT.Core.Contracts
{
    public interface IUserContext
    {
        IUser CurrentUser { get; }

        IList<string> Permissions { get; }
    }
}
