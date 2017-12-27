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

        public static void ValidateAge(int age, int min, int max, string message)
        {
            if (age < min || age > max)
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
