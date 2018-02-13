using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tests.Mocks;

namespace Tests.Core.Factories.OrderFactoryTests
{
    [TestClass]
    public class CreateOrder_Should
    {
        [TestMethod]
        public void ReturnValueOfCorrectType()
        {
            var courierStub = new Mock<ICourier>();
            var senderStub = new Mock<IClient>();
            var receiver = new Mock<IClient>();
            var deliveryType = DeliveryType.Express;
            var sendTimeStub = new DateTimeProvider();
            var dueDateStub = new DateTimeProvider();
            var orderState = OrderState.Damaged;
            var product = new Mock<IProduct>();
            var postalCode = 5500;

            var sut = new OrderFactory();
            var returned = sut.CreateOrder(courierStub.Object, senderStub.Object, receiver.Object, deliveryType,
                sendTimeStub.Now, dueDateStub.Now, orderState, product.Object, postalCode);

            Assert.IsInstanceOfType(returned, typeof(IOrder));
        }
    }
}
