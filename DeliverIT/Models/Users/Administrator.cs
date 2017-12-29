using DeliverIT.Common.Enums;

namespace DeliverIT.Models.Users
{
    public class Administrator : User
    {
        public Administrator(string username, string password, string firstName, string lastName, string email)
            : base(username, password, firstName, lastName, email, UserRole.Administrator)
        { }
    }
}
