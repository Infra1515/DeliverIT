using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Models.Contracts
{
    public interface IAddress
    {

        Country Country { get; set; }
        string StreetName { get; set; }
        string StreetNumber { get; set; }
        string City { get; set; }
    }
}
