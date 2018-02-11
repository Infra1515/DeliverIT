using System;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;
using DeliverIT.Core.Demo;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Core.Factories.Contracts;

namespace DeliverIT.Core.Engine
{
    public class DeliverITEngine : IEngine
    {
        private readonly ICommandsFactory commandsFactory;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ICountryFactory countryFactory;
        private readonly IAddressFactory addressFactory;
        private readonly IOrderFactory orderFactory;
        private readonly IUserFactory userFactory;
        private readonly IProductFactory productFactory;
        private readonly IDataStore dataStore;

        public DeliverITEngine(
            IDataStore dataStore,
            ICommandsFactory commandsFactory,
            IUserFactory userFactory,
            IProductFactory productFactory,
            ICountryFactory countryFactory,
            IAddressFactory addressFactory,
            IOrderFactory orderFactory,
            IWriter writer,
            IReader reader
            )
        {
            this.dataStore = dataStore;
            this.writer = writer;
            this.reader = reader;
            this.commandsFactory = commandsFactory;
            this.countryFactory = countryFactory;
            this.addressFactory = addressFactory;
            this.orderFactory = orderFactory;
            this.userFactory = userFactory;
            this.productFactory = productFactory;
        }

        public void Start()
        {
            string commandNumber = "0";
            //var userFactory = new UserFactory();
            //var deliverITFactory = new ProductFactory();
            var seed = new Seed(this.dataStore, this.userFactory, this.productFactory, this.orderFactory,this.countryFactory, this.addressFactory);
            seed.SeedObjects();
                
            do
            {
                Console.ResetColor();
                try
                {
                    this.writer.WriteLine(LookupMenuText.MainMenuText);
                    commandNumber = this.reader.ReadLine();
                    var command = this.commandsFactory.GetCommand(commandNumber);
                    this.writer.WriteLine(command.Execute());
                    
                }
                catch (Autofac.Core.Registration.ComponentNotRegisteredException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    this.writer.WriteLine("Invalid command entered!");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    this.writer.WriteLine(ex.Message);
                }

                Console.ResetColor();
            }
            while (commandNumber != "7");
        }
    }
}