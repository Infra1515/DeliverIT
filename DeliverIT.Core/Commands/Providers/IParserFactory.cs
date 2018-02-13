namespace DeliverIT.Core.Commands.Providers
{
    public interface IParserFactory
    {
        ICommandParser GetParser(string parserOption);
    }
}
