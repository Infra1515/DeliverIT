using Autofac;

namespace DeliverIT.Core.Commands.Providers
{
    public class ParserFactory : IParserFactory
    {
        private readonly IComponentContext container;

        public ParserFactory(IComponentContext container)
        {
            this.container = container;
        }

        public ICommandParser GetParser(string parserOption)
        {
            return this.container.ResolveNamed<ICommandParser>(parserOption);
        }
    }
}
