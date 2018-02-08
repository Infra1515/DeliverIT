using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Commands
{
    public class ShowAllOrdersCommand : ICommand
    {
        private readonly IDataStore dataStore;

        public ShowAllOrdersCommand(IDataStore dataStore)
        {
            this.dataStore = dataStore;
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

            // todo fix returns
            //return sb.ToString();
        }
    }
}
