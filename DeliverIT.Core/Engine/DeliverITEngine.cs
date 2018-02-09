using System;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;
using System.Linq;
using DeliverIT.Common.Enums;
using DeliverIT.Core.MenuUtilities;
using DeliverIT.Models;
using DeliverIT.Models.Countries;
using System.Threading;
using DeliverIT.Common;
using DeliverIT.Core.Exceptions;
using DeliverIT.Contracts;
using DeliverIT.Core.Engine.Event;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Core.Demo;

namespace DeliverIT.Core.Engine
{
    public class DeliverITEngine : IEngine
    {

        public static EventHandler<OrderStateChangedEventArgs> OrderStateChanged;
        private readonly ICommandsFactory factory;
        private readonly IWriter writer;
        private readonly IReader reader;
        private DataStore dataStore;
        //private Seed demo;

        public DeliverITEngine(
            DataStore dataStore, 
            ICommandsFactory factory,
            IWriter writer, 
            IReader reader
            //Seed demo
            )
        {
            this.dataStore = dataStore;
            this.factory = factory;
            this.writer = writer;
            this.reader = reader;
            //this.demo = demo;
        }


        public void Start()
        {

            do
            {
                Console.ResetColor();
                try
                {
                    this.writer.WriteLine(LookupMenuText.MainMenuText);
                    var commandNumber = this.reader.ReadLine();
                    var command = this.factory.GetCommand(commandNumber);
                    command.Execute();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }

            }
            while (true);
        }

        private void ProcessOrders()
        {
            foreach (var order in dataStore.Orders)
            {
                var lastState = order.OrderState;

                if (order.DueDate < DateTime.Now && order.OrderState != OrderState.Delivered)
                {
                    order.OrderState = OrderState.Delivered;
                    OnOrderStateChanged(this, new OrderStateChangedEventArgs(lastState, order.OrderState, order.Id));
                }
            }
        }

       
        protected virtual void OnOrderStateChanged(object source, OrderStateChangedEventArgs args)
        {
            OrderStateChanged?.Invoke(this, args);
        }

        private void DeliverITEngine_OrderStateChanged(object sender, OrderStateChangedEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Order {args.ID} status changed from {args.LAST_STATE} to {args.CURRENT_STATE}");
            Console.ResetColor();
        }
    }
}