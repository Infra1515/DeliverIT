using System.Text.RegularExpressions;

namespace DeliverIT.Common
{ 
    using System;

    public class Validator
    {
        public static void ValidateUserInfo(string input, int min, int max, string message)
        {
            if (string.IsNullOrEmpty(input) || input.Length < min || input.Length > max)
            {
                throw new ArgumentException(message);
            }

            //if (!new Regex(pattern).IsMatch(input))
            //{
            //    throw new ArgumentException(message);
            //}
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
