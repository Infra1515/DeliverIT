using System.Collections.Generic;
using DeliverIT.Contracts;

namespace DeliverIT.Core.Contracts
{
    public interface IDataStore
    {
        ICollection<IUser> Users { get; }

        ICollection<IOrder> Orders { get; }
    }
}
