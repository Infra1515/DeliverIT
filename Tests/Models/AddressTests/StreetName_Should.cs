using System;
using DeliverIT.Models;
using DeliverIT.Models.Countries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Models.AddressTests
{
    [TestClass]
    public class StreetName_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenStreetNameIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Address(new Bulgaria(), null, "81", "Lovech"));
        }
    }
}
