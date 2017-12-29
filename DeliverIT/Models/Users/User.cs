﻿using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;

namespace DeliverIT.Models.Users
{
    public abstract class User : IUser
    {
        private string username;
        private string firstName;
        private string lastName;
        private string email;

        protected User(string username, string password, string firstName, string lastName, string email, UserRole userRole)
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
                Validator.ValidateUserInfo(value, Constants.MinNameLength,
                    Constants.MaxNameLength, Constants.InvalidName);

                this.username = value;
            }
        }

        public string Password { get; private set; }

        public string FirstName
        {
            get { return this.firstName; }
            protected set
            {
                Validator.ValidateUserInfo(value, Constants.MinNameLength, 
                    Constants.MaxNameLength, Constants.InvalidName);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            protected set
            {
                Validator.ValidateUserInfo(value, Constants.MinNameLength, 
                    Constants.MaxNameLength, Constants.InvalidName);

                this.lastName = value;
            }
        }

        public string Email
        {

            get { return this.email; }
            protected set
            {

                Validator.ValidateEmail(value);

                this.email = value;
            }
        }

        public UserRole Role { get; private set; }
    }
}
