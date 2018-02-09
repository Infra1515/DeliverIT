using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliverIT.Common;
using DeliverIT.Core.Exceptions;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Core.Utilities;

namespace DeliverIT.Core.Engine.Commands
{
    public class LoginCommand
    {
        private IWriter writer;
        private IReader reader;

        public LoginCommand(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Login()
        {
            this.writer.WriteLine(LookupMenuText.LoginText);

            int.TryParse(Console.ReadLine(), out int userLoginChoice);
            bool isValidLoginChoice = Enum.IsDefined(typeof(LoginChoice), userLoginChoice);

            if (!isValidLoginChoice)
            {
                throw new InvalidMenuChoiceException(Constants.InvalidMenuChoiceMessage);
            }
        }
    }
}
