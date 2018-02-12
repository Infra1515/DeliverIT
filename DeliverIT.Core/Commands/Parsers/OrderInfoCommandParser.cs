using System.Collections.Generic;
using System.Linq;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Commands.Providers;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Data;

namespace DeliverIT.Core.Commands.Parsers
{
    public class OrderInfoCommandParser : ICommandParser
    {
        private readonly IDataStore dataStore;
        private readonly ICommandProcessor commandProcessor;
        private readonly IReader reader;
        private readonly IWriter writer;

        public OrderInfoCommandParser(
            IDataStore dataStore, 
            ICommandProcessor commandProcessor,
            IReader reader, 
            IWriter writer)
        {
            this.dataStore = dataStore;
            this.commandProcessor = commandProcessor;
            this.reader = reader;
            this.writer = writer;
        }

        public IList<string> Parse()
        {
            //var commandParameters = new List<string>();
            var couriers = this.dataStore.Users
                .Where(u => u.Role == UserRole.Normal)
                .Cast<ICourier>();

            var clients = this.dataStore.Users
                .Where(u => u.Role == UserRole.Operator)
                .Cast<IClient>();

            this.PrintUser(couriers);
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());


            this.writer.WriteLine("--- Sender ---");
            this.PrintUser(clients);

            string inputSender = this.reader.ReadLine();
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.WriteLine("--- Receiver ---");
            this.PrintUser(clients);

            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.WriteLine("---Delivery Type information---");
            this.writer.Write("Delivery type (Standart/Express): ");

            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write("Enter date of sending (Day/Month/Year): ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            this.writer.Write("Enter due date for delivery(Day/Month/Year): ");
            this.commandProcessor.ParametersToProcess.Add(this.reader.ReadLine());

            return this.commandProcessor.ParametersToProcess;
        }

        private void PrintUser<T>(IEnumerable<T> users) where T : IUser
        {
            this.writer.WriteLine("Please select:");

            foreach (var user in this.dataStore.Users)
            {
                this.writer.WriteLine(user.Username);
            }
        }
    }
}
