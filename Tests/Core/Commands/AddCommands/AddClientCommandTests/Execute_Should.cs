using System.Collections.Generic;
using System.Linq;
using DeliverIT.Core.Commands;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Data;
using DeliverIT.Data.Common;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Contracts;
using DeliverIT.Data.Models.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Core.Commands.AddCommands.AddClientCommandTests
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
            var clientMock = new Mock<IClient>();
            var clientMockTwo = new Mock<IClient>();

            var userParamsStub = new List<string>
            {
                "usernametest",
                "123456",
                "John",
                "Malkovich",
                "malkovich@gmail.com",
                "0884483838",
                "50",
                "Male"
            };

            var addressParamsStub = new List<string>
            {
                "Bulgaria",
                "Sofia",
                "TsarOsvoboditelBlvd",
                "150"
            };

            clientMock.Setup(x => x.Username).Returns(userParamsStub[0]);
            clientMockTwo.Setup(x => x.Username).Returns("notsamename");

            // cant mock extensions(static) methods
            //dataStoreMock.Setup(x => x.Users.FirstOrDefault(
            //    u => u.Username.Equals(It.IsAny<string>())))
            //    .Returns<IUser>(null);

            dataStoreMock.Setup(x => x.Users)
                .Returns(new List<IUser> { clientMockTwo.Object });

            factoryMock.Setup(x => x.CreateClient(It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()
                , It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(),
                It.IsAny<IAddress>(), It.IsAny<GenderType>()))
                .Returns(clientMock.Object);

            commandParserMock.Setup(x => x.UserInfoParseCommandParameters())
                .Returns(userParamsStub);
            commandParserMock.Setup(x => x.AddressInfoParseCommandParameters())
                .Returns(addressParamsStub);

            // Act
            var sut = new AddClientCommand(dataStoreMock.Object,
                factoryMock.Object, createAddressMock.Object,
                commandParserMock.Object);
            
            var expectedResult = string.Format(Constants.RegisteredClient,
                userParamsStub[0]);
            var actualResult = sut.Execute();

            // Assert
            StringAssert.Equals(expectedResult, actualResult);
        }
    }
}
