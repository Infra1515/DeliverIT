using DeliverIT.Common;
using DeliverIT.Common.Enums;

namespace DeliverIT.Models.Users
{
    public class Administrator : User
    {
        public Administrator(string username, string firstName, string lastName, string password, UserRole role, string email, string phoneNumber, int age,
            Address address, GenderType genderType)
            : base(username, firstName, lastName, password, role, email, phoneNumber, age, address, genderType)
        {

        }
    }
}
