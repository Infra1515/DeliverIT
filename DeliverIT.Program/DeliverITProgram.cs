using Autofac;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Dependency;
using DeliverIT.Data.Configuration;

namespace DeliverIT.Program
{
    public class DeliverITProgram
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacConfigModule());

            var container = builder.Build();
            var engine = container.Resolve<IEngine>();

            var seed = container.Resolve<SeedDataStore>();
            seed.SeedObjects();
            engine.Start();
        }
    }
}
