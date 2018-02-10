using System.Text;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.IOUtilities.Contracts;

namespace DeliverIT.Core.Commands
{
    public class ShowAllClientsCommand : ICommand
    {
        private readonly IDataStore dataStore;
        private readonly IWriter writer;

        public ShowAllClientsCommand(
            IDataStore dataStore, 
            IWriter writer)
        {
            this.dataStore = dataStore;
            this.writer = writer;
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

            this.writer.Write(sb.ToString());
        }
    }
}
