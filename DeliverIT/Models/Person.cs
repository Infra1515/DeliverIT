

namespace DeliverIT
{
    using DeliverIT.Common;
    using System;
    using System.Text.RegularExpressions;

    /// <todo>
    /// 1. Implement Person behaviour
    /// 
    /// </todo>
    /// 
    public abstract class Person
    {
        //fields
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private int years;
        private Country country;
        private GenderType gender;

        protected Person(string firstName, string lastName, string email, string phoneNumber, int years, Country country, GenderType genderType)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Years = years;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                Validator.ValidateName(value, Constants.NamePattern, Constants.InvalidName, Constants.MinNameLength, Constants.MaxNameLength);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                Validator.ValidateName(value, Constants.NamePattern, Constants.InvalidName, Constants.MinNameLength, Constants.MaxNameLength);

                this.lastName = value;
            }
        }

        public string Email
        {

            get { return this.email; }
            private set
            {
                Validator.ValidateEmail(value, Constants.InvalidEmail, Constants.EmailPattern, Constants.MinEmailLength, Constants.MaxEmailLength);

                this.email = value;
            }

        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            private set
            {
                Validator.ValidatePhoneNumber(value, Constants.PhonePattern, Constants.InvalidPhoneNumber);

                this.phoneNumber = value;
            }
        }

        public int Years
        {
            get { return this.years; }
            set
            {
                Validator.ValidateYears(value, Constants.MinYears, Constants.MaxYears, Constants.InvalidYears);

                this.years = value;
            }
        }

        void ShowCurrentAddress()
        {
            //method showing curr address
        }

        void ShowInfo()
        {
            //method for showing information about curr person
        }
    }
}
