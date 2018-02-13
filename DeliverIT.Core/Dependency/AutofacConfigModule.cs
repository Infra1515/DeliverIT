﻿using Autofac;
using DeliverIT.Core.Commands;
using DeliverIT.Core.Commands.CreateCommands;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Core.Configuration;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Core.Providers;
using DeliverIT.Data;
using DeliverIT.Utilities.IOUtilities;
using DeliverIT.Utilities.IOUtilities.Contracts;
using DeliverIT.Utilities.MenuUtilities;
using System.Reflection;

namespace DeliverIT.Core.Dependency
{
    public class AutofacConfigModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Commands
            builder.RegisterType<AddClientCommand>().Keyed<ICommand>(MainMenuChoice.AddClient);
            builder.RegisterType<AddCourierCommand>().Keyed<ICommand>(MainMenuChoice.AddCourier);
            builder.RegisterType<AddOrderCommand>().Keyed<ICommand>(MainMenuChoice.AddOrder);
            builder.RegisterType<ShowAllClientsCommand>().Keyed<ICommand>(MainMenuChoice.ShowAllClients);
            builder.RegisterType<ShowAllLocationsCommand>().Keyed<ICommand>(MainMenuChoice.ShowAllLocations);
            builder.RegisterType<ShowAllOrdersCommand>().Keyed<ICommand>(MainMenuChoice.ShowAllOrders);
            builder.RegisterType<CreateAddress>().As<ICreateAddress>();
            builder.RegisterType<CreateProduct>().As<ICreateProduct>();

            builder.RegisterType<DataStore>().As<IDataStore>().SingleInstance();
            builder.RegisterType<DeliverITEngine>().As<IEngine>().SingleInstance();
            builder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            builder.RegisterType<AuthProvider>().AsSelf().SingleInstance();
            builder.RegisterType<SeedDataStore>().AsSelf().SingleInstance();
            builder.RegisterType<UserContext>().As<IUserContext>().SingleInstance();
            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();

            //Factories
            var a = builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
                .Where(x => x.Namespace.Contains("Factories"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<CountryFactory>().AsSelf();
            builder.RegisterType<CommandsFactory>().As<ICommandsFactory>().SingleInstance();
        }
    }
}
