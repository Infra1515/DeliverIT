using System.Collections.Generic;
using DeliverIT.Core.Commands;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Data;
using DeliverIT.Data.Common;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Core.Commands.AddCommands.AddCourierCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnCorrectMessage_WhenCalledWithValidData()
        {
            // Arrange
            var factoryMock = new Mock<IUserFactory>();
            var dataStoreMock = new Mock<IDataStore>();
            var createAddressMock = new Mock<ICreateAddress>();
            var commandParserMock = new Mock<ICommandParser>();
            var courierMock = new Mock<ICourier>();
            var courierMockTwo = new Mock<ICourier>();

            var userParamsStub = new List<string>
            {
                "usernametest",
                "123456",
                "John",
                "Malkovich",
                "malkovich@gmail.com",
                "0884483838",
                "50",
                "Male",
                "100",
                "50"
            };

            var addressParamsStub = new List<string>
            {
                "Bulgaria",
                "Sofia",
                "TsarOsvoboditelBlvd",
                "150"
            };

            courierMock.Setup(x => x.Username).Returns(userParamsStub[0]);
            courierMockTwo.Setup(x => x.Username).Returns("notsamename");

            dataStoreMock.Setup(x => x.Users)
                .Returns(new List<IUser> { courierMockTwo.Object });

            factoryMock.Setup(x => x.CreateCourier(It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()
                , It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(),
                It.IsAny<IAddress>(), It.IsAny<GenderType>(),
                It.IsAny<double>(), It.IsAny<double>()))
                .Returns(courierMock.Object);

            commandParserMock.Setup(x => x.CourierInfoParseCommandParameters())
                .Returns(userParamsStub);
            commandParserMock.Setup(x => x.AddressInfoParseCommandParameters())
                .Returns(addressParamsStub);

            // Act
            var sut = new AddCourierCommand(dataStoreMock.Object,
                factoryMock.Object, createAddressMock.Object,
                commandParserMock.Object);

            var expectedResult = string.Format(Constants.RegisteredCourier,
                userParamsStub[0]);
            var actualResult = sut.Execute();

            // Assert
            StringAssert.Equals(expectedResult, actualResult);
        }
    }
}
