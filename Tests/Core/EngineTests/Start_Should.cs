using DeliverIT.Core.Contracts;
using DeliverIT.Core.Demo;
using DeliverIT.Core.Engine;
using DeliverIT.Core.Factories;
using DeliverIT.Core.IOUtilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Core.EngineTests
{
    [TestClass]
    public class Start_Should
    {
        [TestMethod]
        public void CallCreateCommandFactory_WithCorrectCommandName()
        {
            var commandName = "6";

            var dataStoreStub = new Mock<IDataStore>();
            var commandsFactoryMock = new Mock<ICommandsFactory>();
            var writerStub = new Mock<IWriter>();
            var readerStub = new Mock<IReader>();

            var factoryMock = new Mock<ICommandsFactory>();

            var sut = new DeliverITEngine(dataStoreStub.Object, commandsFactoryMock.Object, writerStub.Object, readerStub.Object);
            sut.Start();

            factoryMock.Verify(x => x.GetCommand(commandName), Times.Once);
        }

    }
}
