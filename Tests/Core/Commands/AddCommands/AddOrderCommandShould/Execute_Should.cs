using System;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Core.Commands.AddCommands.AddOrderCommandShould
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallDeliverITFactory_WithProperParameters()
        {
            // Arrange
            var deliverITFactoryMock = new Mock<IDeliverITFactory>();
            var senderStub = new Mock<IClient>();
            var receiverStub = new Mock<IClient>();
            var productStub = new Mock<IProduct>();
            var courierStub = new Mock<ICourier>();
            var type = DeliverIT.Common.DeliveryType.Express;
            var sendDate = System.DateTime.Today;
            var dueDate = System.DateTime.Today;
            var orderState = OrderState.Damaged;
            var postalCode = 5555;

            deliverITFactoryMock.Setup(a => a.CreateOrder(It.IsAny<ICourier>(), It.IsAny<IClient>(), It.IsAny<IClient>(), It.IsAny<DeliveryType>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<OrderState>(), It.IsAny<IProduct>(), It.IsAny<int>())).Verifiable();
            
            // Act
            deliverITFactoryMock.Object
                .CreateOrder(courierStub.Object, senderStub.Object, receiverStub.Object, type, sendDate, dueDate, orderState, productStub.Object, postalCode);

            // Assert
            deliverITFactoryMock.Verify(b => b.CreateOrder(courierStub.Object, senderStub.Object, receiverStub.Object, type, sendDate, dueDate, orderState, productStub.Object, postalCode), Times.Once);
        }
    }
}
