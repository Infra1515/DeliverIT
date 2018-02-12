using System;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.IOUtilities
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public void Write(string str)
        {
            Console.Write(str);
        }
    }
}
