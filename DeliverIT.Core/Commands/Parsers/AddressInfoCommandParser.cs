using System.Collections.Generic;
using DeliverIT.Core.Commands.Providers;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Commands.Parsers
{
    public class AddressInfoCommandParser : ICommandParser
    {
        private readonly ICommandProcessor commandProcessor;
        private readonly IReader reader;
        private readonly IWriter writer;

        public AddressInfoCommandParser(
            ICommandProcessor commandProcessor,
            IReader reader,
            IWriter writer)
        {
            this.commandProcessor = commandProcessor;
            this.reader = reader;
            this.writer = writer;
        }

        public IList<string> Parse()
        {
            this.writer.WriteLine("--- Address ---");

            this.writer.Write("Country: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write("City: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write("Street name: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write("Street number: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            return this.commandProcessor.ParametersToProcess;

        }
    }
}
