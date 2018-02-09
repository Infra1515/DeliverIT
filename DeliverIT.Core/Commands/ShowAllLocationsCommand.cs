using System.Text;
using System;
using DeliverIT.Common.Enums;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Commands
{
    public class ShowAllLocationsCommand : ICommand
    {
        public void Execute()
        {
            //StringBuilder strBuilder = new StringBuilder();
            //strBuilder.AppendLine("--- Delivery locations ---");
            //strBuilder.AppendLine(" -- " + CountryType.Bulgaria);
            //strBuilder.AppendLine(" -- " + CountryType.Russia);
            //strBuilder.AppendLine(" -- " + CountryType.Serbia);

            Console.WriteLine("-- - Delivery locations-- - ");

            // todo fix returns
            //return strBuilder.ToString();
        }
    }
}
