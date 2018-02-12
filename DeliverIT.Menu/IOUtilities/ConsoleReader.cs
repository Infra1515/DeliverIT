using System;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.IOUtilities
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
