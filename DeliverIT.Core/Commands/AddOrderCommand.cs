using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Core.Commands.Providers;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Data;

namespace DeliverIT.Core.Commands
{
    public class AddOrderCommand : ICommand
    {
        private readonly IDataStore dataStore;
        private readonly IOrderFactory orderFactory;
        private readonly ICreateProduct createCommand;
        private readonly ICommandParser productInfoCommandParser;

        public AddOrderCommand(
            IDataStore dataStore,
            IOrderFactory orderFactory, 
            ICreateProduct createCommand,
            ICommandParser productInfoCommandParser)
        {
            this.dataStore = dataStore;
            this.orderFactory = orderFactory;
            this.createCommand = createCommand;
            this.productInfoCommandParser = productInfoCommandParser;
        }

        public string Execute(IList<string> commandParameters)
        {
            string courier = commandParameters[0];
            string sender = commandParameters[1];
            string receiver = commandParameters[2];
            string deliveryTypeStr = commandParameters[3];
            string sendDateParam = commandParameters[4];
            string dueDateParam = commandParameters[5];

            DateTime sendDate = DateTime.ParseExact(sendDateParam,
                                    "d/M/yyyy", CultureInfo.InvariantCulture);

            DateTime dueDate = DateTime.ParseExact(dueDateParam,
                                    "d/M/yyyy", CultureInfo.InvariantCulture);

            DeliveryType deliveryType = AddDeliveryType(deliveryTypeStr);

            ICourier selectedCourier = (ICourier)this.dataStore.Users
                .FirstOrDefault(sc => sc.Username.Equals(courier));

            IClient selectedSender = (IClient)this.dataStore.Users
                .FirstOrDefault(sc => sc.Username.Equals(sender));

            IClient selectedReceiver = (IClient)this.dataStore.Users
               .FirstOrDefault(sc => sc.Username.Equals(receiver));

            int postalCode = selectedReceiver.Address.Country.CitysAndZips[selectedReceiver.Address.City];

            var productInfo = this.productInfoCommandParser.Parse();
            var product = this.createCommand.Create(productInfo);

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
        }
    }
