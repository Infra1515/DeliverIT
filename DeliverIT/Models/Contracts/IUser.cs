using DeliverIT.Common;

namespace DeliverIT.Models.Contracts
{
    public interface IUser
    {
        string FirstName { get; }
        string LastName { get; }
        string Password { get; }
        int Age { get; }
        string Email { get; }
        string PhoneNumber { get; }
        Address Address { get; }
        GenderType Gender { get; }
        Address ShowCurrentAddress();
        void ShowInfo();
    }
}
