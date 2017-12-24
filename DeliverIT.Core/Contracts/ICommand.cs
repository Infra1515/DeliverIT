using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Core.Contracts
{
    public interface ICommand
    {
        string CommandName { get; }

        List<string> Parameters { get; }

        //void ExecuteCommand(string input);
    }
}
