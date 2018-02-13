using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliverIT.Data.Models;
using DeliverIT.Data.Models.Countries;

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
