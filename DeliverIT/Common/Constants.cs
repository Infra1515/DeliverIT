namespace DeliverIT.Common
{
    public class Constants
    {
        //messages
        public const string InvalidName = "Invalid name!";
        public const string InvalidEmail = "Invalid email!";
        public const string InvalidPhoneNumber = "Invalid phone number entered! Enter valid phone number!";
        public const string InvalidYears = "Age must be between 18 and 100";
        public const string InvalidSendDate = "Send date must be >= today.";
        public const string InvalidDueDate = "Due date must be > send date.";
        public const string InvalidNullValue = "Value cannot be null!";
        public const string UserAlreadyExists = "{0} {1} already exists!";
        public const string InvalidMenuChoiceMessage = "You have entered an Invalid Choice!";
        public const string InvalidCredentialsMessage = "Wrong username or password!";
        public const string NoSuchUser = "No such user!";
        public const string NoSuchCity = "We don't ship to this city yet!";
        public const string NullValue = "Value cannot be null or empty!";
        public const string NotPositiveNumber = "Number must be positive!";

        public const string RegisteredCourier = "Courier {0} registered succesfully!";
        public const string RegisteredClient = "Client {0} registered successfully!";
        public const string ChoosenSender = "Sender {0} choosen successfully!";
        public const string ChoosenReceiver = "Receiver {0} choosen successfully!";


        //min and max constants
        public const int MinNameLength = 2;
        public const int MaxNameLength = 15;
        public const int MinEmailLength = 10;
        public const int MaxEmailLength = 30;
        public const int MinPhoneLength = 6;
        public const int MaxPhoneLength = 10;
        public const int MinAge = 18;
        public const int MaxAge = 100;

        public const decimal Price = 4.5m;
        public const decimal PriceForKg = 0.5m;
        public const decimal FragileCoefficient = 2;
    }
}
