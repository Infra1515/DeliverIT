using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Models.Contracts;

namespace DeliverIT.Models.Users.Abstract
{

    public abstract class User : IUser
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private int years;
        private Address address;
        private GenderType gender;

        protected User(string firstName, string lastName, string email, string phoneNumber, int years, 
            Address address, GenderType genderType)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Years = years;
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

        public string Email
        {

            get { return this.email; }
            protected set
            {

                Validator.ValidateEmail(value);

                this.email = value;
            }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            protected set
            {

                Validator.ValidatePhoneNumber(value);
                this.phoneNumber = value;
            }
        }

        public int Years
        {
            get { return this.years; }
            protected set
            {
                Validator.ValidateYears(value, Constants.MinYears, Constants.MaxYears, Constants.InvalidYears);

                this.years = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.Gender;
            }
            protected set
            {
                Validator.ValidateNotNull(value);
                this.gender = value;
            }
        }

        public Address Address
        {
            get
            {
                return this.address;
            }
            protected set
            {
                Validator.ValidateNotNull(value);
                this.address = value;
            }
        }

        public Address ShowCurrentAddress()
        {
            //method showing curr address
            return this.Address;
        }

        public override string ToString()
        {
            return $"First Name: {this.FirstName} -- Last Name: {this.LastName}\r\n" +
                $"Email : {this.Email} -- Telephone: {this.PhoneNumber}\r\n" +
                $"Address: {this.Address.ToString()}\r\n" +
                $"Age : {this.Years} -- Sex: {this.Gender}";
        }


    }
}
