using DeliverIT.Contracts;
using DeliverIT.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Tests.Models
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void Order_Type_Should_Implement_IOrder_Interface()
        {
            var type = typeof(Order);
            var isAssignable = typeof(IOrder).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Order class does not implement IOrder interface!");
        }
    }
}
