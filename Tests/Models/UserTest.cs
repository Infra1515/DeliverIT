using System;
using DeliverIT.Common.Enums;
using DeliverIT.Models;
using DeliverIT.Models.Countries;
using DeliverIT.Models.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Models
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void ThrowWhenUsernameIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() => new Client(null, "password", "Irina", "Hristova",
                "irina99@abv.bg", 18, "0898899800", new Address(new Bulgaria(), "Bulgaria", "81", "Lovech"), GenderType.Female));
        }

        [TestMethod]
        public void ThrowWhenPasswordIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Client("irina", null, "Irina", "Hristova",
                "irina99@abv.bg", 18, "0898899800", new Address(new Bulgaria(), "Bulgaria", "81", "Lovech"), GenderType.Female));
        }

        [TestMethod]
        public void ThrowWhenFirstNameIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() => new Client("irina", "password", null, "Hristova",
                "irina99@abv.bg", 18, "0898899800", new Address(new Bulgaria(), "Bulgaria", "81", "Lovech"), GenderType.Female));
        }

        [TestMethod]
        public void ThrowWhenLastNameIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() => new Client("irina", "password", "Irina", null,
                "irina99@abv.bg", 18, "0898899800", new Address(new Bulgaria(), "Bulgaria", "81", "Lovech"), GenderType.Female));
        }

        [TestMethod]
        public void ThrowWhenEmailIsInvalid()
        {
            Assert.ThrowsException<FormatException>(() => new Client("irina", "password", "Irina", "Hristova",
                "irina99@.bg", 18, "0898899800", new Address(new Bulgaria(), "Bulgaria", "81", "Lovech"), GenderType.Female));
        }
    }
}
