using Autofac;
using DeliverIT.Core.Commands;
using DeliverIT.Core.Commands.CreateCommands;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Core.IOUtilities;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Core.Providers;
using DeliverIT.Core.Utilities;
using DeliverIT.Data;
using DeliverIT.Data.Configuration;
using System.Reflection;
using DeliverIT.Core.Commands.Parsers;
using DeliverIT.Core.Commands.Providers;

namespace DeliverIT.Core.Dependency
{
    public class AutofacConfigModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
                .AsImplementedInterfaces();

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
            builder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            builder.RegisterType<AuthProvider>().AsSelf().SingleInstance();
            builder.RegisterType<SeedDataStore>().AsSelf().SingleInstance();
            builder.RegisterType<UserContext>().As<IUserContext>().SingleInstance();

            builder.RegisterType<AddressInfoCommandParser>().As<ICommandParser>();
            builder.RegisterType<CourierInfoCommandParser>().Named<ICommandParser>("2");
            builder.RegisterType<OrderInfoCommandParser>().Named<ICommandParser>("3");
            builder.RegisterType<ProductInfoCommandParser>().As<ICommandParser>();
            builder.RegisterType<UserInfoCommandParser>().Named<ICommandParser>("1");

            builder.RegisterType<ParserFactory>().As<IParserFactory>();
            //builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();

        }
    }
}
