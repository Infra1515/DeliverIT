using System;
using DeliverIT.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Models
{
    [TestClass]
    public class DimensionsTest
    {
        [TestMethod]
        public void ThrowWhenXIsNegative()
        {
            Assert.ThrowsException<ArgumentException>(() => new Dimensions(-1.5, 4.5, 4.5));
        }

        [TestMethod]
        public void ThrowWhenYIsNegative()
        {
            Assert.ThrowsException<ArgumentException>(() => new Dimensions(1.5, -4.5, 4.5));
        }

        [TestMethod]
        public void ThrowWhenZIsNegative()
        {
            Assert.ThrowsException<ArgumentException>(() => new Dimensions(1.5, 4.5, -4.5));
        }
    }
}
