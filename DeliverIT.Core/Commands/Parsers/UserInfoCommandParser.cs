using System.Collections.Generic;
using DeliverIT.Core.Commands.Providers;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Commands.Parsers
{
    public class UserInfoCommandParser : ICommandParser
    {
        private readonly ICommandProcessor commandProcessor;
        private readonly IReader reader;
        private readonly IWriter writer;

        public UserInfoCommandParser(
            ICommandProcessor commandProcessor,
            IReader reader,
            IWriter writer)
        {
            this.commandProcessor = commandProcessor;
            this.reader = reader;
            this.writer = writer;
        }

        public virtual IList<string> Parse()
        {
            //var commandParameters = new List<string>();

            this.writer.Write("Username: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write("Password: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write("First name: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write("Last name: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write("Email: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write("Phone number: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write("Age: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            return this.commandProcessor.ParametersToProcess;
        }
    }
}
