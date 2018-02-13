using System;
using DeliverIT.Utilities.IOUtilities.Contracts;

namespace DeliverIT.Utilities.IOUtilities
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
