using DeliverIT.Common;
using DeliverIT.Models.Contracts;

namespace DeliverIT.Models.Users
{
    public abstract class User : IUser
    {
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string phoneNumber;
        private int age;

        protected User(string firstName, string lastName, string password, string email, string phoneNumber, int age, 
            Address address, GenderType genderType)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Age = age;
            this.Address = address;
            this.Gender = genderType;
        }

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

        public string Password
        {
            get { return this.password; }
            protected set
            {
                this.password = value;
            }
        }

        public string Email
        {

            get { return this.email; }
            protected set
            {
                Validator.ValidateUserInfo(value,  Constants.MinEmailLength, Constants.MaxEmailLength, Constants.InvalidEmail);

                this.email = value;
            }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            protected set
            {
               // Validator.ValidateUserInfo(value, Constants.MinPhoneLength, 
                   // Constants.MaxPhoneLength, Constants.InvalidPhoneNumber);

                this.phoneNumber = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            protected set
            {
                Validator.ValidateAge(value, Constants.MinAge, Constants.MaxAge, Constants.InvalidAge);

                this.age = value;
            }
        }

        public Address Address { get; protected set; }

        public GenderType Gender { get; protected set; }

        public Address ShowCurrentAddress()
        {
            //method showing curr address
            return this.Address;
        }

        public virtual void ShowInfo()
        {
            //method for showing information about curr person
        }
    }
}
