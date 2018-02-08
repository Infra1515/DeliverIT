namespace DeliverIT.Core.IOUtilities.Contracts
{
    public interface IWriter
    {
        void WriteLine(string str);

        void Write(string str);
    }
}
