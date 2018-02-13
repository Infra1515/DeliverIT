using System.Collections.Generic;

namespace DeliverIT.Core.Commands.Providers
{
    public interface ICommandProcessor
    {
        IList<string> ParametersToProcess { get; set; }
    }
}
