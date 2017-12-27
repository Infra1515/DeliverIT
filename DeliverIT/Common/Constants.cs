namespace DeliverIT.Common
{
    using System;
    using System.Text.RegularExpressions;

    public class Constants
    {
        //public const string NamePattern = @"^[\w']+\s?,\s?[\w']+$";
       // public const string EmailPattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        //public const string PhonePattern = @"^(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+))?$";


        public const int MinNameLength = 3;
        public const int MaxNameLength = 15;
        public const int MinEmailLength = 10;
        public const int MaxEmailLength = 30;
        public const int MinPhoneLength = 6;
        public const int MaxPhoneLength = 10;
        public const int MinYears = 18;
        public const int MaxYears = 100;

        public const string InvalidName = "Invalid name!";
        public const string InvalidEmail = "Invalid email!";
        public const string InvalidPhoneNumber = "Invalid phone number entered! Enter valid phone number!";
        public const string InvalidYears = "Age must be between 18 and 100";
        public const string InvalidSendDate = "Send date must be >= today.";
        public const string InvalidDueDate = "Due date must be > send date.";

        public const decimal Price = 4.5m;
        public const decimal PriceForKg = 0.5m;
        public const decimal FragileCoefficient = 2;

        public const string RegisteredClient = "Client {0} registered successfully!";
        public const string ChoosenSender = "Sender {0} choosen successfully!";
        public const string ChoosenReceiver = "Receiver {0} choosen successfully!";
    }
}
