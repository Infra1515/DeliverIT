using System.Collections.Generic;
using Bytes2you.Validation;
using DeliverIT.Contracts;

namespace DeliverIT.Data
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
            Guard.WhenArgument(user, "add user null").IsNull().Throw();
            this.users.Add(user);
        }

        public void AddOrder(IOrder order)
        {
            Guard.WhenArgument(order, "add order null").IsNull().Throw();
            this.orders.Add(order);
        }
    }
}
