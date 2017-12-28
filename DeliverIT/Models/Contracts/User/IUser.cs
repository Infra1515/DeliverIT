using DeliverIT.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Models.Contracts
{
    public interface IUser
    {
        string UserName { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        string PhoneNumber { get; }
        int Years { get; }
        Address Address { get; }
        Address ShowCurrentAddress();
    }
}
