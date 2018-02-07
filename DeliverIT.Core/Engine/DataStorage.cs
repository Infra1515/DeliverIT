using System.Collections.Generic;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Engine
{
    public class DataStorage : IDataStore
    {
        public ICollection<IUser> Users { get; }

        public ICollection<IOrder> Orders { get; }
    }
}
