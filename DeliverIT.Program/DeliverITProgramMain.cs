using DeliverIT.Core.Engine;
using Autofac;
using DeliverIT.Core.Injection;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Utilities;

namespace DeliverIT.Program
{
    public class DeliverITProgramMain
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacConfig());
            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}

