using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using System;
using System.Linq;

namespace DeliverIT.Core.Providers
{
    public class AuthProvider
    {
        private readonly IDataStore dataStore;
        private bool isUserLogged;

        public AuthProvider(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public bool IsUserLogged
        {
            get { return this.isUserLogged; }
            private set { }
        }

        public void Login(string username, string password)
        {
            var user = this.dataStore.Users
                .FirstOrDefault(x => x.Username.Equals(username.ToLower()));

            if (user != null && user.Password.Equals(password))
            {
                this.isUserLogged = true;
            }
            else
            {
                this.isUserLogged = false;
            }
        }

        public void Logout()
        {
            this.isUserLogged = false;
        }
    }
}
