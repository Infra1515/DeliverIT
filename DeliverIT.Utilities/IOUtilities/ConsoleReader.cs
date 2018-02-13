using System;
using DeliverIT.Utilities.IOUtilities.Contracts;

namespace DeliverIT.Utilities.IOUtilities
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
