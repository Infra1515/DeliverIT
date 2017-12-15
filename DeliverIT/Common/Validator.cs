using System.Text.RegularExpressions;

namespace DeliverIT.Common
{ 
    using System;
    //TODO: simplify code!!!
    public class Validator
    {
        public static void ValidateEmail(string email, string emailPattern, string message, int min, int max)
        {
            if (email == null || email.Length < min || email.Length > max)
            {
                throw new ArgumentException(message);
            }
            
            if (!new Regex(emailPattern).IsMatch(email))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateName(string name, string namePattern, string message, int min, int max)
        {
            if (name == null || name.Length < min || name.Length > max)
            {
                throw new ArgumentException(message);
            }

            if (!new Regex(namePattern).IsMatch(name))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidatePhoneNumber(string phoneNumber, string phonePattern, string message)
        {
            if (phoneNumber == null)
            {
                throw new ArgumentException(message);
            }

            if (!new Regex(phonePattern).IsMatch(phoneNumber))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateYears(int years, int min, int max, string message)
        {
            if (years < min || years > max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
