using DeliverIT.Data.Common.Enums;
using System.Collections.Generic;

namespace DeliverIT.Data.Contracts
{
    public interface IClient : IPerson
    {
        ClientType ClientType { get; set; }

        int Id { get; }

        string ShowAllNotPendingOrders(IList<IOrder> orders);

        string ShowReceivedOrders(IList<IOrder> orders);

        string ShowSentOrders(IList<IOrder> orders);

        string ShowExpectedSendOrders(IList<IOrder> orders);

        string ShowExpectedReceiveOrders(IList<IOrder> orders);
    }
}
