using System.Text.RegularExpressions;

namespace DeliverIT.Common
{ 
    using System;

    public class Validator
    {

        public static void ValidateNotNull<T> (T value)
        {
            if(value == null)
            {
                throw new ArgumentNullException();
            }
        }
        public static void ValidateUserInfo(string input, int min, int max, string message)
        {
            if (string.IsNullOrEmpty(input) || input.Length < min || input.Length > max)
            {
                throw new ArgumentException(message);
            }

        }

        public static void ValidateEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException();
            }

            var addr = new System.Net.Mail.MailAddress(email);
            if(addr.Address != email)
            {
                throw new ArgumentException(Constants.InvalidEmail);
            }

        }

        public static void ValidatePhoneNumber(string phoneNumber)
        {
            if(string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentNullException();
            }

            if(phoneNumber.Length < 6 || phoneNumber.Length > 20)
            {
                throw new ArgumentException(Constants.InvalidPhoneNumber);
            }

            foreach(char digit in phoneNumber)
            {
                if(!char.IsDigit(digit))
                {
                    throw new ArgumentException(Constants.InvalidPhoneNumber);
                }
            }
        }
        public static void ValidateYears(int years, int min, int max, string message)
        {
            if (years < min || years > max)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateSendDate(DateTime sendDate, string message)
        {
            if (sendDate.Date < DateTime.Today.Date)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateDueDate(DateTime sendDate, DateTime dueDate, string message)
        {
            if(dueDate.Date >= sendDate.Date)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
