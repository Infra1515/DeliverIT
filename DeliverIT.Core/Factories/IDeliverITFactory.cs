using Microsoft.Win32;
   using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;

namespace DeliverIT.Core.Factories
{
    public interface IDeliverITFactory
    {
        Client CreateClient(string firstName, string lastName, string email, string phoneNumber, int years, Country address,
            GenderType gender);

        Order PlaceOrder();

        ICountry CreateCountry(string name, decimal tax);
    }
}
