using System.Reflection;
using Autofac;
using DeliverIT.Core.Commands;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Demo;
using DeliverIT.Core.Engine;
using DeliverIT.Core.Factories;
using DeliverIT.Core.Factories.Contracts;

namespace DeliverIT.Core.Injection
{
    public class AutofacConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // register assembly
            var currentAssembly = Assembly.Load("DeliverIT.Core");

            builder.RegisterAssemblyTypes(currentAssembly)
                .AsImplementedInterfaces();

            // register core components
            builder.RegisterType<DeliverITEngine>().As<IEngine>()
                .SingleInstance();
            builder.RegisterType<DataStore>().As<IDataStore>()
                .SingleInstance();
            //builder.RegisterType<Seed>().AsSelf()
            //    .SingleInstance();
     

            // register commands
            builder.RegisterType<AddClientCommand>().Named<ICommand>
                ("1");
            builder.RegisterType<AddCourierCommand>().Named<ICommand>
                ("2");
            builder.RegisterType<AddOrderCommand>().Named<ICommand>
                ("3");
            builder.RegisterType<ShowAllClientsCommand>().Named<ICommand>
                ("4");
            builder.RegisterType<ShowAllOrdersCommand>().Named<ICommand>
                ("5");
            builder.RegisterType<ShowAllLocationsCommand>().Named<ICommand>
               ("6");
            builder.RegisterType<ExitCommand>().Named<ICommand>
                ("7");

            builder.RegisterType<CommandsFactory>().As<ICommandsFactory>()
                .SingleInstance();

        }
    }
}
