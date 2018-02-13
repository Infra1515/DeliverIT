using System.Collections.Generic;
using DeliverIT.Data.Contracts;

namespace DeliverIT.Data
{
    public interface IDataStore
    {
        ICollection<IUser> Users { get; }

        ICollection<IOrder> Orders { get; }

        void AddUser(IUser user);

        void AddOrder(IOrder order);
    }
}
