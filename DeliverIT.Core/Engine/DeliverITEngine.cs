using System;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;
using DeliverIT.Core.Demo;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Core.Factories;

namespace DeliverIT.Core.Engine
{
    public class DeliverITEngine : IEngine
    {
        private readonly ICommandsFactory factory;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IDataStore dataStore;

        public DeliverITEngine(
            IDataStore dataStore,
            ICommandsFactory factory,
            IWriter writer,
            IReader reader
            )
        {
            this.dataStore = dataStore;
            this.factory = factory;
            this.writer = writer;
            this.reader = reader;
        }

        public void Start()
        {
            string commandNumber = "0";
            var userFactory = new UserFactory();
            var deliverITFactory = new DeliverITFactory();
            var seed = new Seed(this.dataStore, userFactory, deliverITFactory);
            seed.SeedObjects();
                
            do
            {
                Console.ResetColor();
                try
                {
                    this.writer.WriteLine(LookupMenuText.MainMenuText);
                    commandNumber = this.reader.ReadLine();
                    var command = this.factory.GetCommand(commandNumber);
                    command.Execute();
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

            }
            while (commandNumber != "7");
        }
    }
}