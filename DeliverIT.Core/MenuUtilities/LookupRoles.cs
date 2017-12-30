using DeliverIT.Core.Utilities;
using System.Collections.Generic;

namespace DeliverIT.Core.MenuUtilities
{
    public class LookupRoles
    {
        public static readonly IList<MainMenuChoise> Administrator = new List<MainMenuChoise>()
        {
            MainMenuChoise.AddClient,
            MainMenuChoise.PlaceOrder,
            MainMenuChoise.AddCourier,
            MainMenuChoise.AllClients,
            MainMenuChoise.AllOrders,
            MainMenuChoise.AllLocations,
            MainMenuChoise.Logout
        };

        public static readonly IList<MainMenuChoise> Normal = new List<MainMenuChoise>()
        {
            MainMenuChoise.AllClients,
            MainMenuChoise.AllLocations,
            MainMenuChoise.AllOrders,
            MainMenuChoise.Logout
        };

        public static readonly IList<MainMenuChoise> Operator = new List<MainMenuChoise>()
        {
            MainMenuChoise.PlaceOrder,
            MainMenuChoise.AllClients,
            MainMenuChoise.AllLocations,
            MainMenuChoise.AllOrders,
            MainMenuChoise.Logout
        };
    }
}
