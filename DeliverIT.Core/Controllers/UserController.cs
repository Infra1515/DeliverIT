using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Core.Controllers
{
    public class UserController : IUserController
    {
        public IUser CurrentUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IList<string> Permissions
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
