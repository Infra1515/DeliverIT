using DeliverIT.Core.Utilities;
using System;
using System.Text;

namespace DeliverIT.Core.Engine
{
    public sealed class InteractiveMenu
    {
        private static readonly InteractiveMenu instance = new InteractiveMenu();
        private static readonly StringBuilder sb = new StringBuilder();

        private InteractiveMenu()
        { }

        public static InteractiveMenu Interactive
        {
            get
            {
                return instance;
            }
        }

        public void Start()
        {
            Console.WriteLine(MenuText()); 

            do
            {
                int userChoise;
                int.TryParse(Console.ReadLine(), out userChoise);

                var isValidChoise = Enum.IsDefined(typeof(Selections), userChoise);

                if (!isValidChoise)
                    userChoise = (int)Selections.Invalid;

                if (userChoise == (int)Selections.Exit)
                    break;

                switch ((Selections)userChoise)
                {
                    case Selections.AddClient:
                        Console.WriteLine("Implement creating of a client ...");
                        break;

                    case Selections.PlaceOrder:
                        Console.WriteLine("Implement placing of an order ...");
                        break;

                    case Selections.AddCourier:
                        Console.WriteLine("Implement adding a courier ...");
                        break;

                    case Selections.AllClients:
                        Console.WriteLine("Implement clients view ...");
                        break;

                    case Selections.AllOrders:
                        Console.WriteLine("Implement orders view ...");
                        break;

                    case Selections.AllLocations:
                        Console.WriteLine("Implement locations view ...");
                        break;
                        
                    case Selections.Invalid:
                        Console.WriteLine("Invalid option selected! Please select a valid option!");
                        break;
                }

            } while (true);
        }

        private string MenuText()
        {
            sb.AppendLine("DeliverIT Menu Options\n");
            sb.AppendLine("----- Control Options -----\n");
            sb.AppendLine("1. Add new clients.");
            sb.AppendLine("2. Place orders for client.");
            sb.AppendLine("3. Add couriers.\n");
            sb.AppendLine("----- List Options -----\n");
            sb.AppendLine("4. List all clients.");
            sb.AppendLine("5. List all orders.");
            sb.AppendLine("6. List delivery locations.\n");
            sb.AppendLine("7. Exit menu.");

            return sb.ToString();
        }
    }
}
