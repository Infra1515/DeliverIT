using System;
using DeliverIT.Data.Models;
using DeliverIT.Data.Models.Countries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Models.AddressTests
{
    [TestClass]
    public class Address_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenCityIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Address(new Bulgaria(), "Bulgaria", "81", null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCountryIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Address(null, "Bulgaria", "81", "Lovech"));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenStreetNameIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Address(new Bulgaria(), null, "81", "Lovech"));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenStreetNumberIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Address(new Bulgaria(), "Bulgaria", null, "Lovech"));
        }
    }
}
