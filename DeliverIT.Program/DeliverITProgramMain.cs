using Autofac;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Dependency;

namespace DeliverIT.Program
{
    public class DeliverITProgramMain
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacConfigModule());

            var container = builder.Build();
            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}
