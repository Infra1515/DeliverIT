using System;
using System.Globalization;
using System.Linq;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Data;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Contracts;

namespace DeliverIT.Core.Commands
{
    public class AddOrderCommand : ICommand
    {
        private readonly IDataStore dataStore;
        private readonly IOrderFactory orderFactory;
        private readonly ICreateProduct createCommand;
        private readonly ICommandParser commandParser;

        public AddOrderCommand(
            IDataStore dataStore,
            IOrderFactory orderFactory, 
            ICreateProduct createCommand,
            ICommandParser commandParser)
        {
            this.dataStore = dataStore;
            this.orderFactory = orderFactory;
            this.createCommand = createCommand;
            this.commandParser = commandParser;
        }

        public string Execute()
        {
            var orderParams = this.commandParser.OrderInfoCommandParameters();

            string courier = orderParams[0];
            string sender = orderParams[1];
            string receiver = orderParams[2];
            string deliveryTypeStr = orderParams[3];
            string sendDateParam = orderParams[4];
            string dueDateParam = orderParams[5];

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

            var productInfo = this.commandParser.ProductInfoCommandParameters();
            var product = this.createCommand.Create(productInfo);

            var order = this.orderFactory.CreateOrder(selectedCourier, selectedSender, selectedReceiver, deliveryType, sendDate, dueDate, OrderState.InProgress, product, postalCode);

            this.dataStore.AddOrder(order);

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
