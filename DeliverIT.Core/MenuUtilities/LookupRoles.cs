using DeliverIT.Core.Utilities;
using System.Collections.Generic;

namespace DeliverIT.Core.MenuUtilities
{
    public class LookupRoles
    {
        public static readonly IList<MainMenuChoice> Administrator = new List<MainMenuChoice>()
        {
            MainMenuChoice.AddClient,
            MainMenuChoice.PlaceOrder,
            MainMenuChoice.AddCourier,
            MainMenuChoice.AllClients,
            MainMenuChoice.AllOrders,
            MainMenuChoice.AllLocations,
            MainMenuChoice.Logout
        };

        public static readonly IList<MainMenuChoice> Normal = new List<MainMenuChoice>()
        {
            MainMenuChoice.AllClients,
            MainMenuChoice.AllLocations,
            MainMenuChoice.AllOrders,
            MainMenuChoice.Logout
        };

        public static readonly IList<MainMenuChoice> Operator = new List<MainMenuChoice>()
        {
            MainMenuChoice.PlaceOrder,
            MainMenuChoice.AllClients,
            MainMenuChoice.AllLocations,
            MainMenuChoice.AllOrders,
            MainMenuChoice.Logout
        };
    }
}
