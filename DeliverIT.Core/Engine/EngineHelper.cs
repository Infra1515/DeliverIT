//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DeliverIT.Common;
//using DeliverIT.Common.Enums;
//using DeliverIT.Core.Exceptions;
//using DeliverIT.Core.IOUtilities.Contracts;
//using DeliverIT.Core.MenuUtilities;
//using DeliverIT.Core.Utilities;

//namespace DeliverIT.Core.Engine
//{
//    public class EngineHelper
//    {
//        private IWriter writer;

//        public EngineHelper(IWriter writer)
//        {
//            this.writer = writer;
//        }

//        public void Login()
//        {
//            this.writer.WriteLine(LookupMenuText.LoginText);

//            int.TryParse(Console.ReadLine(), out int userLoginChoice);
//            bool isValidLoginChoice = Enum.IsDefined(typeof(LoginChoice), userLoginChoice);

//            if (!isValidLoginChoice)
//            {
//                throw new InvalidMenuChoiceException(Constants.InvalidMenuChoiceMessage);
//            }
//        }
//        private void LoginMenu(LoginChoice userChoice)
//        {
//            switch (userChoice)
//            {
//                case LoginChoice.Login:

//                    Console.Write("Username: ");
//                    string username = Console.ReadLine();

//                    Console.Write("Password: ");
//                    string password = Console.ReadLine();

//                    var isLogged = this.Login(username, password);

//                    if (!isLogged)
//                    {
//                        throw new InvalidCredentialsException(Constants.InvalidCredentialsMessage);
//                    }

//                    state = MenuState.MainMenu;
//                    break;

//                case LoginChoice.Exit:
//                    state = MenuState.Exit;
//                    break;
//            }
//        }

//        private bool CheckRoleAccess(UserRole role, MainMenuChoice mainMenuChoice)
//        {
//            bool isPresent = false;

//            switch (role)
//            {
//                case UserRole.Administrator:

//                    isPresent = LookupRoles.Administrator.Contains(mainMenuChoice);
//                    break;

//                case UserRole.Operator:

//                    isPresent = LookupRoles.Operator.Contains(mainMenuChoice);
//                    break;

//                case UserRole.Normal:

//                    isPresent = LookupRoles.Normal.Contains(mainMenuChoice);
//                    break;
//            }

//            return isPresent;
//        }
//    }
//}



