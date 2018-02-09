using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Models.Users;

namespace DeliverIT.Core.Contracts
{
    public interface IUserFactory
    {
        Client CreateClient(string username, string password, string firstName, string lastName, string email,
            int age, string phoneNumber, IAddress address, GenderType gender);

        Courier CreateCourier(string username, string password, string firstName, string lastName, string email,
            int age, string phoneNumber, IAddress address, GenderType gender, double allowedWeight,
            double allowedVolume);

        IUser CreateAdmin(string username, string password, string firstName, string lastName, string email);
    }
}