using System.Collections.Generic;
using System.Text;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Commands
{
    public class ShowAllClientsCommand : ICommand
    {
        private readonly ICollection<IUser> users;

        public ShowAllClientsCommand(ICollection<IUser> users)
        {
            this.users = users;
        }

        public void Execute()
        {
            StringBuilder sb = new StringBuilder();
            if (this.users.Count == 0)
            {
                sb.AppendLine("No clients registered!");
            }
            else
            {
                foreach (var client in this.users)
                {
                    sb.AppendLine(client.ToString());
                    sb.AppendLine("-----------------------");
                }
            }

            // todo fix returns 

            //return sb.ToString();
        }
    }
}
