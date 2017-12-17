﻿

using DeliverIT.Models;

namespace DeliverIT
{
    using DeliverIT.Common;
    using DeliverIT.Models.Countries;
    using System;
    using System.Text.RegularExpressions;

    /// <todo>
    /// 1. Implement Person behaviour
    /// 
    /// </todo>
    /// 
    public abstract class User
    {
        //fields
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private int years;

        protected User(string firstName, string lastName, string email, string phoneNumber, int years, Address address, GenderType genderType)
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
                Validator.ValidateName(value, Constants.NamePattern, Constants.InvalidName, Constants.MinNameLength, Constants.MaxNameLength);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            protected set
            {
                Validator.ValidateName(value, Constants.NamePattern, Constants.InvalidName, Constants.MinNameLength, Constants.MaxNameLength);

                this.lastName = value;
            }
        }

        public string Email
        {

            get { return this.email; }
            protected set
            {
                Validator.ValidateEmail(value, Constants.InvalidEmail, Constants.EmailPattern, Constants.MinEmailLength, Constants.MaxEmailLength);

                this.email = value;
            }

        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            protected set
            {
                Validator.ValidatePhoneNumber(value, Constants.PhonePattern, Constants.InvalidPhoneNumber);

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

        public Address Address { get; protected set; }

        public GenderType Gender { get; protected set; }

        void ShowCurrentAddress()
        {
            //method showing curr address
        }

        public virtual void ShowInfo()
        {
            //method for showing information about curr person
        }
    }
}
