using DeliverIT.Contracts;
using DeliverIT.Data;
using System.Linq;

namespace DeliverIT.Core.Providers
{
    public class AuthProvider
    {
        private readonly IDataStore dataStore;
        private IUser loggedUser;

        public AuthProvider(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public IUser GetCurrentUser()
        {
            return this.loggedUser;
        }

        public void Login(string username, string password)
        {
            var user = this.dataStore.Users
                .FirstOrDefault(x => x.Username.Equals(username.ToLower()));

            if (user != null && user.Password.Equals(password))
            {
                this.loggedUser = user;
            }
            else
            {
                this.loggedUser = null;
            }
        }

        public void Logout()
        {
            this.loggedUser = null;
        }
    }
}
