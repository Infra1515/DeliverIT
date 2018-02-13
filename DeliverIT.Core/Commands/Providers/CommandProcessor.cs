using System.Collections.Generic;

namespace DeliverIT.Core.Commands.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private IList<string> parameterToParse;

        public CommandProcessor()
        {
            this.parameterToParse = new List<string>();
        }

        public IList<string> ParametersToProcess
        {
            get { return this.parameterToParse; }
            set { this.parameterToParse = value; }
        }
    }
}
