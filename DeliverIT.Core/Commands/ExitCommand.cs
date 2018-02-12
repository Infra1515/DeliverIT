using System;
using System.Collections.Generic;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(IList<string> commandParameters)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            return $"Thank you for using our app!";
        }
    }
}
