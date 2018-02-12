using System.Text;
using DeliverIT.Core.Contracts;
using DeliverIT.Data;

namespace DeliverIT.Core.Commands
{
    public class ShowAllClientsCommand : ICommand
    {
        private readonly IDataStore dataStore;

        public ShowAllClientsCommand(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public void Execute()
        {
            StringBuilder sb = new StringBuilder();
            if (this.dataStore.Users.Count == 0)
            {
                sb.AppendLine("No clients registered!");
            }
            else
            {
                foreach (var client in this.dataStore.Users)
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
