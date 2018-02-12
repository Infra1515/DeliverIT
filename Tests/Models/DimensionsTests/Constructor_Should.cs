using System;
using DeliverIT.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
