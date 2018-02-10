using DeliverIT.Common.Enums;
using DeliverIT.Core.Factories;
using DeliverIT.Core.IOUtilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Core.Commands.CreateCommands.CreateProductTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public void CallDeliverITFactory_WithValidParametersOnlyOnce()
        {
            var writerStub = new Mock<IWriter>();
            var readerStub = new Mock<IReader>();
            var deliverITFactoryStub = new Mock<IDeliverITFactory>();
            deliverITFactoryStub.Setup(x => x.CreateProduct(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(),
                It.IsAny<bool>(), It.IsAny<double>(), It.IsAny<ProductType>())).Verifiable();

            deliverITFactoryStub.Verify();
        }

    }
}
