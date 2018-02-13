using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Data.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Core.Commands.CreateCommands.CreateAddressTests
{
    [TestClass]
    public class CreateAddress_Should
    {
        [TestMethod]
        public void CallDeliverITFactory_OnlyOnce()
        {
            // Arrange
            var country = new Mock<ICountry>();
            var city = "Lovech";
            var streetName = "Bulgaria";
            var streetNumber = "81";

            var deliverITFactoryMock = new Mock<IAddressFactory>();
            deliverITFactoryMock.Setup(x =>
                x.CreateAddress(It.IsAny<ICountry>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>())).Verifiable();

            // Act
            deliverITFactoryMock.Object.CreateAddress(country.Object, streetName,
                streetNumber, city);

            // Assert
            deliverITFactoryMock.Verify(x => x.CreateAddress(country.Object,
                streetName, streetNumber, city), Times.Once);
        }
    }
}
