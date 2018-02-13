using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliverIT.Data.Models;

namespace Tests.Models
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenXIsNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Dimensions(-1.5, 4.5, 4.5));
        }

        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenYIsNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Dimensions(1.5, -4.5, 4.5));
        }

        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenZIsNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Dimensions(1.5, 4.5, -4.5));
        }
    }
}
