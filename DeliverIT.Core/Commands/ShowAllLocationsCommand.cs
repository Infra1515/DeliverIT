using System.Text;
using DeliverIT.Common.Enums;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Commands
{
    public class ShowAllLocationsCommand : ICommand
    {
        private readonly IWriter writer;

        public ShowAllLocationsCommand(IWriter writer)
        {
            this.writer = writer;
        }

        public void Execute()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("--- Delivery locations ---");
            strBuilder.AppendLine(" -- " + CountryType.Bulgaria);
            strBuilder.AppendLine(" -- " + CountryType.Russia);
            strBuilder.AppendLine(" -- " + CountryType.Serbia);
            
            this.writer.WriteLine(strBuilder.ToString());
        }
    }
}
