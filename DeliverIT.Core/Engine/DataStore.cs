using System.Collections.Generic;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Engine
{
    public class DataStore : IDataStore
    {
        // todo --- > should contain both users and orders or not

        private readonly ICollection<IUser> users;

        private readonly ICollection<IOrder> orders;

        public DataStore()
        {
            this.users = new List<IUser>();
            this.orders = new List<IOrder>();
        }

        public ICollection<IUser> Users => this.users;

        public ICollection<IOrder> Orders => this.orders;

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
