using System;

namespace DeliverIT.Core.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string message)
            : base(message)
        {
        }
    }
}
