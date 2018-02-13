using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Contracts;
using DeliverIT.Data.Models.Users;

namespace DeliverIT.Core.Factories
{
    public class UserFactory : IUserFactory
    {
        public IClient CreateClient(string username, string password, string firstName, string lastName, string email,
            int age, string phoneNumber, IAddress address, GenderType gender)
        {
            return new Client(username, password, firstName, lastName, email, age, phoneNumber, address, gender);
        }

        public ICourier CreateCourier(string username, string password, string firstName, string lastName, string email,
            int age, string phoneNumber, IAddress address, GenderType gender, double allowedWeight, double allowedVolume)
        {
            return new Courier(username, password, firstName, lastName, email, age, phoneNumber, address,
                gender, allowedWeight, allowedVolume);
        }

        public IUser CreateAdmin(string username, string password, string firstName, string lastName, string email)
        {
            return new Administrator(username, password, firstName, lastName, email);
        }
    }
}
