using System;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            return $"Thank you for using our app!";
        }
    }
}
