using Bytes2you.Validation;
using DeliverIT.Data.Common;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Contracts;

namespace DeliverIT.Models.Users.Abstract
{
    public class User : IUser
    {
        private string username;
        private string password;
        private string firstName;
        private string lastName;
        private string email;

        public User(string username, string password, string firstName, string lastName, string email, UserRole userRole)
        {
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Role = userRole;
        }

        public string Username
        {
            get { return this.username; }
            private set
            {
                Guard.WhenArgument(value, "username").IsNull().Throw();
                Guard.WhenArgument(value.Length, "length").IsLessThanOrEqual(Constants.MinNameLength).IsGreaterThanOrEqual(Constants.MaxNameLength).Throw();
                
                this.username = value;
            }
        }

        public string Password
        {
            get { return this.password; }
            private set
            {
                Guard.WhenArgument(value, "password null").IsNull().Throw();

                this.password = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            protected set
            {
                Guard.WhenArgument(value, "firstName").IsNull().Throw();
                Guard.WhenArgument(value.Length, "length").IsLessThanOrEqual(Constants.MinNameLength).IsGreaterThanOrEqual(Constants.MaxNameLength).Throw();

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            protected set
            {
                Guard.WhenArgument(value, "lastName").IsNull().Throw();
                Guard.WhenArgument(value.Length, "length").IsLessThanOrEqual(Constants.MinNameLength).IsGreaterThanOrEqual(Constants.MaxNameLength).Throw();

                this.lastName = value;
            }
        }

        public string Email
        {

            get { return this.email; }
            protected set
            {

                Guard.WhenArgument(value, "email null").IsNull().Throw();

                this.email = value;
            }
        }
        public UserRole Role { get; private set; }

        public override string ToString()
        {
            return $"User Type: {this.GetType().Name}\r\n" +
                $"Username: {this.Username}\r\n" +
                $"First Name: {this.FirstName}\r\n" +
                $"Last Name: {this.LastName}\r\n" +
                $"Email : {this.Email}\r\n";
        }

    }
}
