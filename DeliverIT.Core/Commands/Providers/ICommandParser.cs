﻿using System.Collections.Generic;

namespace DeliverIT.Core.Commands.Providers
{
    public interface ICommandParser
    {
        IList<string> Parse();
    }
}
