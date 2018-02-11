using DeliverIT.Contracts;
using System.Collections.Generic;

namespace DeliverIT.Core.Contracts
{
    public interface IUserController
    {
        IUser CurrentUser { get; set; }

        IList<string> Permissions { get; set; }
    }
}
