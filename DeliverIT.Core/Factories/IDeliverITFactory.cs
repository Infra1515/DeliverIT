using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Models;

namespace DeliverIT.Core.Factories
{
    public interface IDeliverITFactory
    {
        Client CreateClient(string firstName, string lastName, string email, string phoneNumber, int years,
            Address address, GenderType gender);

        Order PlaceOrder();
    }
}
