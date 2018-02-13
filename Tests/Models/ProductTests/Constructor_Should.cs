﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Models;

namespace Tests.Models.ProductTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenWeightIsNegative()
        {
            double x = 1;
            double y = 1;
            double z = 1;
            bool isFragile = false;
            double weight = -1;
            ProductType productType = ProductType.Accessories;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new Product(x, y, z, isFragile, weight, productType));
        }
    }
}
