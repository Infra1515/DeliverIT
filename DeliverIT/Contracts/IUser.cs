using DeliverIT.Common.Enums;

namespace DeliverIT.Contracts
{
    public interface IUser
    {
        string Username { get; }
        string Password { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        UserRole Role { get; }
    }
}
