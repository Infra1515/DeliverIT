using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using System.Collections.Generic;

namespace DeliverIT.Models.Contracts
{
    public interface IClient : IUser
    {

        IList<IOrder> OrdersList { get; }

        ClientType ClientType { get; }

        int Id { get; }


        void DisplayOrderList();

        void ShowAllOrders(IList<IOrder> orders);

        void ShowReceivedOrders(IList<IOrder> orders);


        void ShowSentOrders(IList<IOrder> orders);

        void ShowExpectedSendOrders(IList<IOrder> orders);


        void ShowExpectedReceiveOrders(IList<IOrder> orders);

    }
}
