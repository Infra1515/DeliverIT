using Autofac;
using DeliverIT.Core.Commands;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Engine;
using DeliverIT.Core.Factories;
using DeliverIT.Core.IOUtilities;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Dependency
{
    public class AutofacConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddClientCommand>().Named<ICommand>("addclient");
            builder.RegisterType<AddCourierCommand>().Named<ICommand>("addcourier");
            builder.RegisterType<AddOrderCommand>().Named<ICommand>("addorder");
            builder.RegisterType<ShowAllClientsCommand>().Named<ICommand>("showallclients");
            builder.RegisterType<ShowAllLocationsCommand>().Named<ICommand>("showalllocations");
            builder.RegisterType<ShowAllOrdersCommand>().Named<ICommand>("showallorders");

            builder.RegisterType<DataStore>().As<IDataStore>().SingleInstance();
            builder.RegisterType<DeliverITEngine>().As<IEngine>().SingleInstance();
            builder.RegisterType<CommandsFactory>().As<ICommandsFactory>().SingleInstance();
            builder.RegisterType<UserFactory>().As<IUserFactory>().SingleInstance();
            builder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
        }
    }
}
