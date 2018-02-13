using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliverIT.Data.Models;

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
