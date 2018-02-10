using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using System;
using System.Linq;

namespace DeliverIT.Core.Providers
{
    public class AuthProvider
    {
        private readonly IDataStore dataStore;
        private bool isLogged;

        public AuthProvider(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public bool IsLogged
        {
            get { return this.isLogged; }
            private set { }
        }

        public void Login(string username, string password)
        {
            var user = this.dataStore.Users
                .FirstOrDefault(x => x.Username.Equals(username.ToLower()));

            if (user != null && user.Password.Equals(password))
            {
                this.isLogged = true;
            }
            else
            {
                this.isLogged = false;
            }
        }
    }
}
