using DeliverIT.Common.Enums;
using DeliverIT.Core.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Core.Commands.CreateCommands.CreateProductTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public void CallFactory_WithValidParametersOnlyOnce()
        {
            // Arrange
            var factoryMock = new Mock<IProductFactory>();
            factoryMock.Setup(a => a.CreateProduct(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(),
                It.IsAny<bool>(), It.IsAny<double>(), It.IsAny<ProductType>())).Verifiable();

            double x = 0.5;
            double y = 0.5;
            double z = 0.5;
            bool isFragile = true;
            double weight = 0.125;
            ProductType type = ProductType.Accessories;

            // Act
            factoryMock.Object
                .CreateProduct(x, y, z, isFragile, weight, type);

            // Assert
            factoryMock.Verify(b => b.CreateProduct(x, y, z, isFragile, weight, type));
        }
    }
}
