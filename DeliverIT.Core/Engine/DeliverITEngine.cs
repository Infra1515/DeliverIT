using System;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;
using DeliverIT.Core.Demo;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Engine
{
    public class DeliverITEngine : IEngine
    {
        private readonly ICommandsFactory factory;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IDataStore dataStore;
        private readonly Seed demo;

        public DeliverITEngine(
            IDataStore dataStore,
            ICommandsFactory factory,
            IWriter writer,
            IReader reader,
            Seed demo
            )
        {
            this.dataStore = dataStore;
            this.factory = factory;
            this.writer = writer;
            this.reader = reader;
            this.demo = demo;
        }

        public void Start()
        {
            string commandNumber = "0";
            this.demo.SeedObjects();
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
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }

            }
            while (commandNumber != "7");
        }
    }
}