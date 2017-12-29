using DeliverIT.Common;
using DeliverIT.Common.Enums;

namespace DeliverIT.Models.Contracts
{
    public interface IUser
    {
        string Username { get; }
        string FirstName { get; }
        string LastName { get; }
        string Password { get; }
        UserRole Role { get; }
        int Age { get; }
        string Email { get; }
        string PhoneNumber { get; }
        Address Address { get; }
        GenderType Gender { get; }
        Address ShowCurrentAddress();
        void ShowInfo();
    }
}
