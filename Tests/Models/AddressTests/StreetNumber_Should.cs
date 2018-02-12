using System;
using DeliverIT.Models;
using DeliverIT.Models.Countries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Models.AddressTests
{
    [TestClass]
    public class StreetNumber_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenStreetNumberIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Address(new Bulgaria(), "Bulgaria", null, "Lovech"));
        }
    }
}
