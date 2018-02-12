using System;
using DeliverIT.Common.Enums;
using DeliverIT.Models;
using DeliverIT.Models.Countries;
using DeliverIT.Models.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Models.UsersTests
{
    [TestClass]
    public class Password_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenPasswordIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Client("irina", null, "Irina", "Hristova",
                "irina99@abv.bg", 18, "0898899800", new Address(new Bulgaria(), "Bulgaria", "81", "Lovech"), GenderType.Female));
        }
    }
}
