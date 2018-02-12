using System.Collections.Generic;
using System;
using DeliverIT.Core.IOUtilities.Contracts;
using System.Linq;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Engine.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IDataStore dataStore;

        public CommandParser(IWriter writer, IReader reader, IDataStore dataStore)
        {
            this.writer = writer;
            this.reader = reader;
            this.dataStore = dataStore;
        }

        public IList<string> AddressInfoParseCommandParameters()
        {
            var commandParameters = new List<string>();
            

            writer.WriteLine("--- Address ---");

            writer.Write("Country: ");
            commandParameters.Add(this.reader.ReadLine());

            writer.Write("City: ");
            commandParameters.Add(this.reader.ReadLine());

            writer.Write("Street name: ");
            commandParameters.Add(this.reader.ReadLine());

            writer.Write("Street number: ");
            commandParameters.Add(this.reader.ReadLine());

            return commandParameters;

        }

        public IList<string> OrderInfoCommandParameters()
        {
            var commandParameters = new List<string>();
            var couriers = this.dataStore.Users
                            .Where(u => u.Role == UserRole.Normal)
                            .Cast<ICourier>();

            var clients = this.dataStore.Users
                .Where(u => u.Role == UserRole.Operator)
                .Cast<IClient>();

            this.PrintUser(couriers);
            commandParameters.Add(this.reader.ReadLine());


            this.writer.WriteLine("--- Sender ---");
            this.PrintUser(clients);

            string inputSender = this.reader.ReadLine();
            commandParameters.Add(this.reader.ReadLine());


            this.writer.WriteLine("--- Receiver ---");
            this.PrintUser(clients);

            commandParameters.Add(this.reader.ReadLine());

            this.writer.WriteLine("---Delivery Type information---");
            this.writer.Write("Delivery type (Standart/Express): ");

            commandParameters.Add(this.reader.ReadLine());

            this.writer.Write("Enter date of sending (Day/Month/Year): ");
            commandParameters.Add(this.reader.ReadLine());

            this.writer.Write("Enter due date for delivery(Day/Month/Year): ");
            commandParameters.Add(this.reader.ReadLine());

            return commandParameters;
        }

        public IList<string> ProductInfoCommandParameters()
        {
            var commandParameters = new List<string>();

            this.writer.Write("---Product information---");
            this.writer.Write("Dimensions(X Y Z): ");
            var dimensions = this.reader.ReadLine().Split(' ').ToArray();

            commandParameters.Add(dimensions[0]);
            commandParameters.Add(dimensions[1]);
            commandParameters.Add(dimensions[2]);
            //double x = dimensions[0];
            //double y = dimensions[1];
            //double z = dimensions[2];

            this.writer.Write("Is the product fragile?");
            commandParameters.Add(this.reader.ReadLine().ToLower().Trim());

            this.writer.Write("What is the product weight? ");
            commandParameters.Add(this.reader.ReadLine());

            this.writer.Write($"What is the product type?\r\n" +
                              "Available:  Clothes, Accessories, Electronics, Other:");
            commandParameters.Add(reader.ReadLine());

            return commandParameters;
            
        }

        public IList<string> CourierInfoParseCommandParameters()
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

            this.writer.Write("Enter maximum allowed weight that the courier can carry: ");
            commandParameters.Add(this.reader.ReadLine());

            this.writer.Write("Enter maximum allowed volume that the courier can carry: ");
            commandParameters.Add(this.reader.ReadLine());

            return commandParameters;
        }

        public virtual IList<string> UserInfoParseCommandParameters()
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
