using DeliverIT.Common.Enums;
using DeliverIT.Models;
using System.Collections.Generic;

namespace DeliverIT.Contracts
{
    public interface IPerson : IUser
    {
        int Age { get; }
        string PhoneNumber { get; }
        IAddress Address { get; }
        GenderType Gender { get; }
        IList<IOrder> OrdersList { get; }

        void AddOrder(IOrder order);
        void RemoveOrder(IOrder order);
    }
}
