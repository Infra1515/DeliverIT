using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliverIT.Data.Models;
using DeliverIT.Data.Models.Countries;

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
