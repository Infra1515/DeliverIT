using DeliverIT.Common;
using DeliverIT.Models;
using DeliverIT.Models.Users;

namespace DeliverIT.Core.Factories
{
    public interface IDeliverITFactory
    {
        Client CreateClient(string firstName, string lastName, string password, string email, string phoneNumber, int years,
            Address address, GenderType gender);

        Order PlaceOrder();
    }
}
