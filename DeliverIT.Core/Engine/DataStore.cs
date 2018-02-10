using System.Collections.Generic;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Engine
{
    public class DataStore : IDataStore
    {
        private readonly ICollection<IUser> users;
        private readonly ICollection<IOrder> orders;

        public DataStore()
        {
            this.users = new List<IUser>();
            this.orders = new List<IOrder>();
        }

        public ICollection<IUser> Users => new List<IUser>(this.users);

        public ICollection<IOrder> Orders => new List<IOrder>(this.orders);

        public void AddUser(IUser user)
        {
            // todo validations ? 
            this.users.Add(user);
        }

        public void AddOrder(IOrder order)
        {
            // todo validations ?
            this.orders.Add(order);
        }
    }
}
