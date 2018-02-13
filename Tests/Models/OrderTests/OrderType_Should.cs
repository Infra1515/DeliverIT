using DeliverIT.Data.Contracts;
using DeliverIT.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Models.OrderTests
{
    [TestClass]
    public class OrderType_Should
    {
        [TestMethod]
        public void ImplementIOrderInterface()
        {
            var type = typeof(Order);
            var isAssignable = typeof(IOrder).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Order class does not implement IOrder interface!");
        }
    }
}
