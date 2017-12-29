using DeliverIT.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Models.Contracts.User
{
    public interface ICourier : IUser
    {

        int Id { get; }
        double AllowedVolume { get; set; }
        double AllowedWeight { get; set; }

        bool CanCarry();
    }
}
