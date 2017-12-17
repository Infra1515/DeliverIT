using System.Text.RegularExpressions;

namespace DeliverIT.Common
{ 
    using System;
    //TODO: simplify code!!!
    public class Validator
    {
        public static void ValidateUserInfo(string input, string pattern, int min, int max, string message)
        {
            if (string.IsNullOrEmpty(input) || input.Length < min || input.Length > max)
            {
                throw new ArgumentException(message);
            }

            if (!new Regex(pattern).IsMatch(input))
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

        public static void ValidateSendAndDueDate(DateTime date, string message)
        {
            if (DateTime.Now > date)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
