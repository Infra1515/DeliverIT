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
        public void ThrowArgumentNullException_WhenCityIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Address(new Bulgaria(), "Bulgaria", "81", null));
        }
    }
}
