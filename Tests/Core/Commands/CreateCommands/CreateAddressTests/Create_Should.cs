using DeliverIT.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Models.Countries;
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
            var country = new Mock<Country>();
            var city = "Lovech";
            var streetName = "Bulgaria";
            var streetNumber = "81";

            var deliverITFactoryMock = new Mock<IDeliverITFactory>();
            deliverITFactoryMock.Setup(x =>
                x.CreateAddress(It.IsAny<Bulgaria>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            deliverITFactoryMock.Verify(x => x.CreateAddress(country.Object, city, streetName, streetNumber), Times.Once);
        }


        [TestMethod]
        public void ReturnCorrectMessage_WhenInvoked()
        {

        }
    }
}
