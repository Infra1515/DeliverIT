using System;

namespace DeliverIT.Core.Exceptions
{
    public class InvalidMenuChoiceException : Exception
    {
        public InvalidMenuChoiceException(string message)
            : base(message)
        {
        }
    }
}
