using System.Collections.Generic;

namespace DeliverIT.Core.Contracts
{
    public interface ICommandParser
    {
        IList<string> UserInfoParseCommandParameters();
        IList<string> CourierInfoParseCommandParameters();
        IList<string> AddressInfoParseCommandParameters();
        IList<string> ProductInfoCommandParameters();
        IList<string> OrderInfoCommandParameters();
    }
}
