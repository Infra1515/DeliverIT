using DeliverIT.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Models.Contracts
{
    public interface IProduct
    {


        bool IsFragile { get; }

        double Weight { get; }

        Dimensions Dimensions { get; set; }

        ProductType ProductType { get; set; }

        double Volume { get; set; }

        int Id { get; }
    }
}
