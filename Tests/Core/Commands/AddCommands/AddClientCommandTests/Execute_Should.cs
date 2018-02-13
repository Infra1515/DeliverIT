//using DeliverIT.Common.Enums;
//using DeliverIT.Contracts;
//using DeliverIT.Core.Factories;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;

//namespace Tests.Core.Commands.AddCommands.AddClientCommandTests
//{
//    [TestClass]
//    public class Execute_Should
//    {
//        [TestMethod]
//        public void CallUserFactory_WithProperParameters()
//        {
//            // Arrange
//            var userFactoryMock = new Mock<IUserFactory>();
//            var addressStub = new Mock<IAddress>();

//            userFactoryMock.Setup(a => a.CreateClient(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<IAddress>(), It.IsAny<GenderType>())).Verifiable();
            
//            // Act
//            userFactoryMock.Object
//                .CreateClient("client123", "1234", "DummyFirst", "DummyLast", "dummy@dummy.com", 18, "12345678", addressStub.Object, GenderType.Male);

//            // Assert
//            userFactoryMock.Verify(b => b.CreateClient("client123", "1234", "DummyFirst", "DummyLast", "dummy@dummy.com", 18, "12345678", addressStub.Object, GenderType.Male), Times.Once);
//        }
//    }
//}
