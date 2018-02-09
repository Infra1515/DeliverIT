using System;
using DeliverIT.Contracts;
using DeliverIT.Models.Countries;

namespace DeliverIT.Common
{ 
    public static class Validator
    {
        public static void ValidateNotNull<T> (T value)
        {
            if(value == null)
            {
                throw new ArgumentNullException(Constants.NullValue);
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
            ValidateNotNull(email);

            var addr = new System.Net.Mail.MailAddress(email);

            if(addr.Address != email)
            {
                throw new ArgumentException(Constants.InvalidEmail);
            }
        }

        public static void ValidatePhoneNumber(string phoneNumber)
        {
            ValidateNotNull(phoneNumber);

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
        public static void ValidateYears(int age, int min, int max, string message)
        {
            if (age < min || age > max)
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
            if (dueDate.Date >= sendDate.Date)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateCityInCountry(string city, ICountry country, string message)
        {
            if (!country.CitysAndZips.ContainsKey(city))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateNotPositive(double number, string message)
        {
            if (number <= 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
