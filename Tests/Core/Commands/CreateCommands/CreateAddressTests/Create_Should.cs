//using DeliverIT.Contracts;
//using DeliverIT.Core.Factories;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;

//namespace Tests.Core.Commands.CreateCommands.CreateAddressTests
//{
//    [TestClass]
//    public class CreateAddress_Should
//    {
//        [TestMethod]
//        public void CallDeliverITFactory_OnlyOnce()
//        {

//            // Arrange
//            var country = new Mock<ICountry>();
//            var city = "Lovech";
//            var streetName = "Bulgaria";
//            var streetNumber = "81";

//            var deliverITFactoryMock = new Mock<IDeliverITFactory>();
//            deliverITFactoryMock.Setup(x =>
//                x.CreateAddress(It.IsAny<ICountry>(), It.IsAny<string>(), It.IsAny<string>(),
//                It.IsAny<string>())).Verifiable();

//            // Act
//            deliverITFactoryMock.Object.CreateAddress(country.Object, streetName,
//                streetNumber, city);

//            // Assert
//            deliverITFactoryMock.Verify(x => x.CreateAddress(country.Object,
//                streetName, streetNumber, city), Times.Once);
//        }


//        [TestMethod]
//        public void ReturnCorrectAddress_WhenInvokedWithValidArguments()
//        {
//            // Arrange
//            var deliverITFactoryMock = new Mock<IDeliverITFactory>();

//        }
//    }
//}
