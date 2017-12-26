using System.Collections.Generic;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Engine
{
    /// <summary>
    /// Class for implementation of different commands
    /// </summary>

    public class DeliverITCommand : ICommand
    {
        private const char SplitCommandSymbol = ' ';

        private string commandName;
        private List<string> parameters;


        public DeliverITCommand(string currLine)
        {
            
        }

        public string CommandName
        {
            get { return this.commandName; }
            private set
            {
                //validation needed
                this.commandName = value;
            }
            
        }
        
        public List<string> Parameters 
        {
            get { return this.parameters; }
            private set
            {
                //validation
                this.parameters = value;
            }
        }
    }
}
