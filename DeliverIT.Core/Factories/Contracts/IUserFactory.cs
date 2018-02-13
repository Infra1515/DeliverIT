using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Contracts;
using DeliverIT.Data.Models.Users;

namespace DeliverIT.Core.Factories
{
    public interface IUserFactory
    {
        IClient CreateClient(string username, string password, string firstName, string lastName, string email,
            int age, string phoneNumber, IAddress address, GenderType gender);

        Courier CreateCourier(string username, string password, string firstName, string lastName, string email,
            int age, string phoneNumber, IAddress address, GenderType gender, double allowedWeight,
            double allowedVolume);

        IUser CreateAdmin(string username, string password, string firstName, string lastName, string email);
    }
}