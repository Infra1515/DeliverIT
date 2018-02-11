using System.Collections.Generic;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Engine.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public CommandParser(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public virtual IList<string> ParseCommandParameters()
        {
            var commandParameters = new List<string>();

            this.writer.Write("Username: ");
            commandParameters.Add(this.reader.ReadLine());

            this.writer.Write("Password: ");
            commandParameters.Add(this.reader.ReadLine());

            this.writer.Write("First name: ");
            commandParameters.Add(this.reader.ReadLine());

            this.writer.Write("Last name: ");
            commandParameters.Add(this.reader.ReadLine());

            this.writer.Write("Email: ");
            commandParameters.Add(this.reader.ReadLine());

            this.writer.Write("Phone number: ");
            commandParameters.Add(this.reader.ReadLine());

            this.writer.Write("Age: ");
            commandParameters.Add(this.reader.ReadLine());

            return commandParameters;
        }
    }
}
