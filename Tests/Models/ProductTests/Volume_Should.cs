using System;
using DeliverIT.Common.Enums;
using DeliverIT.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Models.ProductTests
{
    [TestClass]
    public class Volume_Should
    {
        [TestMethod]
        public void ThrowArgumenOutOfRangeException_WhenVolumeIsNegative()
        {
            double x = 1;
            double y = 1;
            double z = 1;
            bool isFragile = false;
            double weight = 1;
            ProductType productType = ProductType.Accessories;

            var sut = new Product(x,y,z,isFragile,weight,productType);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                sut.Volume = -1);
        }
    }
}
