using System.Collections.Generic;

namespace DeliverIT.Core.Engine.Providers
{
    public interface ICommandParser
    {
        IList<string> ParseCommandParameters();
    }
}
