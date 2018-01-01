using DeliverIT.Common.Enums;
using System.Collections.Generic;

namespace DeliverIT.Contracts
{
    public interface IClient : IPerson
    {
        ClientType ClientType { get; set; }

        int Id { get; }

        void ShowAllNotPendingOrders(IList<IOrder> orders);

        void ShowReceivedOrders(IList<IOrder> orders);

        void ShowSentOrders(IList<IOrder> orders);

        void ShowExpectedSendOrders(IList<IOrder> orders);

        void ShowExpectedReceiveOrders(IList<IOrder> orders);
    }
}
