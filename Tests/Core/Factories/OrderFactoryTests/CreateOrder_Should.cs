using DeliverIT.Common;
using DeliverIT.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Core.Factories.OrderFactoryTests
{
    [TestClass]
    public class CreateOrder_Should
    {
        [TestMethod]
        public void ReturnValueOfCorrectType()
        {
            //public IOrder CreateOrder(ICourier courier, IClient sender, IClient receiver, DeliveryType deliveryType, DateTime sendDate, DateTime dueDate,
            //    OrderState orderState, IProduct product, int postalCode)
            //{
            //    return new Order(courier, sender, receiver, deliveryType, sendDate, dueDate, orderState, product, postalCode);
            //}

            var courierStub = new Mock<ICourier>();
            var senderStub = new Mock<IClient>();
            var receiver = new Mock<IClient>();
            var deliveryType = DeliveryType.Express;
            //var dateTimeStub
        }
    }
}
