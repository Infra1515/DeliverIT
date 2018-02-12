using System.Collections.Generic;
using DeliverIT.Core.Commands.Providers;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Data;

namespace DeliverIT.Core.Commands.Parsers
{
    public class CourierInfoCommandParser : ICommandParser
    {
        private readonly ICommandProcessor commandProcessor;
        private readonly IReader reader;
        private readonly IWriter writer;

        public CourierInfoCommandParser(
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

            this.writer.Write("Enter maximum allowed weight that the courier can carry: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write("Enter maximum allowed volume that the courier can carry: ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            return this.commandProcessor.ParametersToProcess;
        }
    }
}
