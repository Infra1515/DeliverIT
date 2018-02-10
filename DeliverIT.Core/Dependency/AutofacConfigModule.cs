using Autofac;
using DeliverIT.Core.Commands;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Core.Configuration;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Engine;
using DeliverIT.Core.Factories;
using DeliverIT.Core.IOUtilities;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Core.Providers;
using DeliverIT.Core.Utilities;

namespace DeliverIT.Core.Dependency
{
    public class AutofacConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddClientCommand>().Keyed<ICommand>(MainMenuChoice.AddClient);
            builder.RegisterType<AddCourierCommand>().Keyed<ICommand>(MainMenuChoice.AddCourier);
            builder.RegisterType<AddOrderCommand>().Keyed<ICommand>(MainMenuChoice.AddOrder);
            builder.RegisterType<ShowAllClientsCommand>().Keyed<ICommand>(MainMenuChoice.ShowAllClients);
            builder.RegisterType<ShowAllLocationsCommand>().Keyed<ICommand>(MainMenuChoice.ShowAllLocations);
            builder.RegisterType<ShowAllOrdersCommand>().Keyed<ICommand>(MainMenuChoice.ShowAllOrders);
            builder.RegisterType<CreateAddress>().As<ICreateAddress>();
            builder.RegisterType<CreateProduct>().As<ICreateProduct>();
            builder.RegisterType<CountryFactory>().AsSelf();

            builder.RegisterType<DataStore>().As<IDataStore>().SingleInstance();
            builder.RegisterType<DeliverITEngine>().As<IEngine>().SingleInstance();
            builder.RegisterType<CommandsFactory>().As<ICommandsFactory>().SingleInstance();
            builder.RegisterType<UserFactory>().As<IUserFactory>().SingleInstance();
            builder.RegisterType<DeliverITFactory>().As<IDeliverITFactory>().SingleInstance();
            builder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            builder.RegisterType<AuthProvider>().AsSelf();
            builder.RegisterType<SeedDataStore>().AsSelf().SingleInstance();
        }
    }
}
