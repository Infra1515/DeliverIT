using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Commands
{
    public class AddOrderCommand : ICommand
    {
        private readonly IDataStore dataStore;
        private readonly IOrderFactory orderFactory;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ICreateProduct createCommand;

        public AddOrderCommand(
            IDataStore dataStore,
            IOrderFactory orderFactory, 
            IWriter writer, 
            IReader reader, 
            ICreateProduct createCommand)
        {
            this.dataStore = dataStore;
            this.orderFactory = orderFactory;
            this.writer = writer;
            this.reader = reader;
            this.createCommand = createCommand;
        }

        public string Execute()
        {
            var couriers = this.dataStore.Users
               .Where(u => u.Role == UserRole.Normal)
               .Cast<ICourier>();

            var clients = this.dataStore.Users
                .Where(u => u.Role == UserRole.Operator)
                .Cast<IClient>();

            this.PrintUser(couriers);

            string inputCourier = this.reader.ReadLine();

            ICourier selectedCourier = couriers
                .FirstOrDefault(sc => sc.Username.Equals(inputCourier));

            this.writer.WriteLine("--- Sender ---");
            this.PrintUser(clients);

            string inputSender = this.reader.ReadLine();

            IClient selectedSender = clients
                .FirstOrDefault(sc => sc.Username.Equals(inputSender));

            this.writer.WriteLine("--- Receiver ---");
            this.PrintUser(clients);

            string inputReceiver = this.reader.ReadLine();

            IClient selectedReceiver = clients
               .FirstOrDefault(sc => sc.Username.Equals(inputReceiver));

            this.writer.WriteLine("---Delivery Type information---");
            this.writer.Write("Delivery type (Standart/Express): ");

            string type = this.reader.ReadLine();
            DeliveryType deliveryType = AddDeliveryType(type);

            this.writer.Write("---Product information---");
            var product = createCommand.Create();

            this.writer.Write("Enter date of sending (Day/Month/Year): ");
            DateTime sendDate = DateTime.ParseExact(this.reader.ReadLine(),
                                "d/M/yyyy", CultureInfo.InvariantCulture);

            this.writer.Write("Enter due date for delivery(Day/Month/Year): ");
            DateTime dueDate = DateTime.ParseExact(this.reader.ReadLine(),
                            "d/M/yyyy", CultureInfo.InvariantCulture);

            int postalCode = selectedReceiver.Address.Country.CitysAndZips[selectedReceiver.Address.City];

            var order = this.orderFactory.CreateOrder(selectedCourier, selectedSender, selectedReceiver, deliveryType, sendDate, dueDate, OrderState.InProgress, product, postalCode);

            this.dataStore.Orders.Add(order);

            selectedCourier.OrdersList.Add(order);
            selectedReceiver.OrdersList.Add(order);
            selectedSender.OrdersList.Add(order);

            Console.ForegroundColor = ConsoleColor.Green;
            return $"Successfully added order with delivery type {order.DeliveryType}.";
        }

        private DeliveryType AddDeliveryType(string deliveryType)
        {
            DeliveryType type;

            switch ((DeliveryType)Enum.Parse(typeof(DeliveryType), deliveryType))
            {
                case DeliveryType.Express:
                    type = DeliveryType.Express;
                    break;
                case DeliveryType.Standart:
                    type = DeliveryType.Standart;
                    break;
                default:
                    type = DeliveryType.Standart;
                    break;
            }
            return type;
        }

        private void PrintUser<T>(IEnumerable<T> users) where T : IUser
        {
            this.writer.WriteLine("Please select:");

            foreach (var user in users)
            {
                this.writer.WriteLine(user.Username);
            }
        }
    }
}
