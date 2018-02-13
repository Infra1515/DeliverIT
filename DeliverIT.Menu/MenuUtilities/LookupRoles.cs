using System.Collections.Generic;

namespace DeliverIT.Utilities.MenuUtilities
{
    public static class LookupRoles
    {
        public static readonly IList<MainMenuChoice> Administrator = new List<MainMenuChoice>()
        {
            MainMenuChoice.AddClient,
            MainMenuChoice.AddOrder,
            MainMenuChoice.AddCourier,
            MainMenuChoice.ShowAllClients,
            MainMenuChoice.ShowAllOrders,
            MainMenuChoice.ShowAllLocations,
            MainMenuChoice.Logout
        };

        public static readonly IList<MainMenuChoice> Normal = new List<MainMenuChoice>()
        {
            MainMenuChoice.ShowAllClients,
            MainMenuChoice.ShowAllLocations,
            MainMenuChoice.ShowAllOrders,
            MainMenuChoice.Logout
        };

        public static readonly IList<MainMenuChoice> Operator = new List<MainMenuChoice>()
        {
            MainMenuChoice.AddOrder,
            MainMenuChoice.ShowAllClients,
            MainMenuChoice.ShowAllLocations,
            MainMenuChoice.ShowAllOrders,
            MainMenuChoice.Logout
        };
    }
}
