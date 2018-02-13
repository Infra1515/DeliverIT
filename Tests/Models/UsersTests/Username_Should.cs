using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliverIT.Data.Models;
using DeliverIT.Data.Models.Users;
using DeliverIT.Data.Models.Countries;
using DeliverIT.Data.Common.Enums;

namespace Tests.Models.UsersTests
{
    [TestClass]
    public class Username_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenUsernameIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Client(null, "password", "Irina", "Hristova",
                "irina99@abv.bg", 18, "0898899800", new Address(new Bulgaria(), "Bulgaria", "81", "Lovech"), GenderType.Female));
        }
    }
}
