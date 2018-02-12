using System;
using DeliverIT.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Models.AddressTests
{
    [TestClass]
    public class Country_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenCountryIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Address(null, "Bulgaria", "81", "Lovech"));
        }
    }
}
