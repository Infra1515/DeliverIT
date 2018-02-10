using System;
using DeliverIT.Models;
using DeliverIT.Models.Countries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Models
{
    [TestClass]
    public class AddressTest
    {
        [TestMethod]
        public void ThrowWhenCountryIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Address(null, "Bulgaria", "81", "Lovech"));
        }

        [TestMethod]
        public void ThrowWhenStreetNameIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Address(new Bulgaria(), null, "81", "Lovech"));
        }

        [TestMethod]
        public void ThrowWhenStreetNumberIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Address(new Bulgaria(), "Bulgaria", null, "Lovech"));
        }

        [TestMethod]
        public void ThrowWhenCityIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Address(new Bulgaria(), "Bulgaria", "81", null));
        }
    }
}
