using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tests.Mocks;
using DeliverIT.Data.Contracts;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Models;

namespace Tests.Models.OrderTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenSenderIsNull()
        {
            var courierStub = new Mock<ICourier>();
            IClient sender = null;
            var receiverStub = new Mock<IClient>();
            var sendDate = new DateTimeProvider().Now;
            var deliveryType = DeliveryType.Standart;
            var dueDate = new DateTimeProvider().Now;
            var orderState = OrderState.Damaged;
            var productStub = new Mock<IProduct>();
            var code = 5500;

            Assert.ThrowsException<ArgumentNullException>(() => new Order(courierStub.Object, sender,
                receiverStub.Object, deliveryType, sendDate, dueDate, orderState, productStub.Object, code));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCourierIsNull()
        {
            ICourier courier = null;
            var senderStub = new Mock<IClient>();
            var receiverStub = new Mock<IClient>();
            var sendDate = new DateTimeProvider().Now;
            var deliveryType = DeliveryType.Standart;
            var dueDate = new DateTimeProvider().Now;
            var orderState = OrderState.Damaged;
            var productStub = new Mock<IProduct>();
            var code = 5500;

            Assert.ThrowsException<ArgumentNullException>(() => new Order(courier, senderStub.Object,
                receiverStub.Object, deliveryType, sendDate, dueDate, orderState, productStub.Object, code));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenReceiverIsNull()
        {
            var courierStub = new Mock<ICourier>();
            var senderStub = new Mock<IClient>();
            IClient receiver = null;
            var sendDate = new DateTimeProvider().Now;
            var deliveryType = DeliveryType.Standart;
            var dueDate = new DateTimeProvider().Now;
            var orderState = OrderState.Damaged;
            var productStub = new Mock<IProduct>();
            var code = 5500;

            Assert.ThrowsException<ArgumentNullException>(() => new Order(courierStub.Object, senderStub.Object,
                receiver, deliveryType, sendDate, dueDate, orderState, productStub.Object, code));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenProductIsNull()
        {
            var courierStub = new Mock<ICourier>();
            var senderStub = new Mock<IClient>();
            var receiverStub = new Mock<IClient>();
            var sendDate = new DateTimeProvider().Now;
            var deliveryType = DeliveryType.Standart;
            var dueDate = new DateTimeProvider().Now;
            var orderState = OrderState.Damaged;
            IProduct product = null;
            var code = 5500;

            Assert.ThrowsException<ArgumentNullException>(() => new Order(courierStub.Object, senderStub.Object,
                receiverStub.Object, deliveryType, sendDate, dueDate, orderState, product, code));
        }
    }
}
