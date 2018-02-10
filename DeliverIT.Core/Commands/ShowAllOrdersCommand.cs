using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Commands
{
    public class ShowAllOrdersCommand : ICommand
    {
        private readonly IDataStore dataStore;
        private readonly IWriter writer;

        public ShowAllOrdersCommand(
            IDataStore dataStore, 
            IWriter writer)
        {
            this.dataStore = dataStore;
            this.writer = writer;
        }

        public void Execute()
        {
            var sb = new StringBuilder();
            if (this.dataStore.Orders.Any())
            {
                foreach (var order in this.dataStore.Orders)
                {
                    sb.AppendLine(order.ToString());
                }
            }
            else
            {
                sb.AppendLine("No orders placed yet!");
            }

            this.writer.WriteLine(sb.ToString());
        }
    }
}
