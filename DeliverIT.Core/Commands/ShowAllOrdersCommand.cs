using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Commands
{
    public class ShowAllOrdersCommand : ICommand
    {
        private readonly ICollection<IOrder> orders;

        public ShowAllOrdersCommand(ICollection<IOrder> orders)
        {
            this.orders = orders;
        }

        public void Execute()
        {
            var sb = new StringBuilder();
            if (this.orders.Any())
            {
                foreach (var order in orders)
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
