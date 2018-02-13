//using System;
//using System.Collections.Generic;
//using DeliverIT.Core.Commands.CreateCommands.Contracts;
//using DeliverIT.Core.Contracts;
//using DeliverIT.Core.Factories.Contracts;
//using DeliverIT.Data;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;

//namespace Tests.Core.Commands.AddCommands.AddOrderCommandShould
//{
//    [TestClass]
//    public class Execute_Should
//    {
//        [TestMethod]
//        public void ReturnCorrectMessage_WhenCalledWithValidData()
//        {
        
//            var dataStorMock = new Mock<IDataStore>();
//            var factoryMock = new Mock<IOrderFactory>();
//            var createProductMock = new Mock<ICreateProduct>();
//            var commandParserMock = new Mock<ICommandParser>();

//            var orderParamsStub = new List<string>
//            {
//                "Gosheedy",
//                "Senderov",
//                "Receivarov",
//                "Express",
//                "5/5/2017",
//                "6/5/2017",

//            };

//            //var orderParams = this.commandParser.OrderInfoCommandParameters();

//            //string courier = orderParams[0];
//            //string sender = orderParams[1];
//            //string receiver = orderParams[2];
//            //string deliveryTypeStr = orderParams[3];
//            //string sendDateParam = orderParams[4];
//            //string dueDateParam = orderParams[5];

//        }
//    }
//}
