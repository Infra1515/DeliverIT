using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Providers;
using System;
using System.Collections.Generic;

namespace DeliverIT.Core.Providers
{
    public class UserContext : IUserContext
    {
        private readonly AuthProvider authProvider;

        public UserContext(AuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        public IUser CurrentUser { get => this.authProvider.GetCurrentUser(); }

        public IList<string> Permissions
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
