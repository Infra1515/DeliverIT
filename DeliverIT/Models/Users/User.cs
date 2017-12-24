namespace DeliverIT
{
    using DeliverIT.Common;

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

        protected User(string firstName, string lastName, string email, string phoneNumber, int years, Country address, GenderType genderType)
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
                Validator.ValidateUserInfo(value, Constants.NamePattern, Constants.MinNameLength, 
                    Constants.MaxNameLength, Constants.InvalidName);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            protected set
            {
                Validator.ValidateUserInfo(value, Constants.NamePattern, Constants.MinNameLength, 
                    Constants.MaxNameLength, Constants.InvalidName);

                this.lastName = value;
            }
        }

        public string Email
        {

            get { return this.email; }
            protected set
            {
                Validator.ValidateUserInfo(value, Constants.InvalidEmail, Constants.MinEmailLength, 
                    Constants.MaxEmailLength,  Constants.EmailPattern);

                this.email = value;
            }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            protected set
            {
                Validator.ValidateUserInfo(value, Constants.PhonePattern, Constants.MinPhoneLength, 
                    Constants.MaxPhoneLength, Constants.InvalidPhoneNumber);

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

        public Country Address { get; protected set; }

        public GenderType Gender { get; protected set; }

        public Country ShowCurrentAddress()
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
