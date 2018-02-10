using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Core.Controllers
{
    public class UserController
    {
        public UserRole UserRole { get; set; }

        public IUser CurrentUser { get; set; }
    }
}
