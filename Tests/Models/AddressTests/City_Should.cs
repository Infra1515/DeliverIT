using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliverIT.Data.Models;
using DeliverIT.Data.Models.Countries;

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
