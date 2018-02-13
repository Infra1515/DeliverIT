using System.Collections.Generic;
using System.Linq;
using DeliverIT.Core.Commands.Providers;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Commands.Parsers
{
    public class ProductInfoCommandParser : ICommandParser
    {
        private readonly ICommandProcessor commandProcessor;
        private readonly IReader reader;
        private readonly IWriter writer;

        public ProductInfoCommandParser(
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
            this.writer.Write("---Product information---");
            this.writer.Write("Dimensions(X Y Z): ");
            var dimensions = this.reader.ReadLine().Split(' ').ToArray();

            this.commandProcessor.ParametersToProcess.Add(dimensions[0]);
            this.commandProcessor.ParametersToProcess.Add(dimensions[1]);
            this.commandProcessor.ParametersToProcess.Add(dimensions[2]);

            this.writer.Write("Is the product fragile?");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine().ToLower().Trim());

            this.writer.Write("What is the product weight? ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write($"What is the product type?\r\n" +
                              "Available:  Clothes, Accessories, Electronics, Other:");
            this.commandProcessor.ParametersToProcess.Add(reader.ReadLine());

            return this.commandProcessor.ParametersToProcess;
        }
    }
}
