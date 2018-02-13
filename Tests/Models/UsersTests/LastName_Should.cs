using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliverIT.Data.Models.Users;
using DeliverIT.Data.Models.Countries;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Models;

namespace Tests.Models.UsersTests
{
    [TestClass]
    public class LastName_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenLastNameIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Client("irina", "password", "Irina", null,
                "irina99@abv.bg", 18, "0898899800", new Address(new Bulgaria(), "Bulgaria", "81", "Lovech"), GenderType.Female));
        }
    }
}
