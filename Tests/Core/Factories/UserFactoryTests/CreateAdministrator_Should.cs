﻿using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Factories;
using DeliverIT.Models.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Core.Factories.UserFactoryTests
{
    [TestClass]
    public class CreateAdministrator_Should
    {
        [TestMethod]
        public void ReturnValueOfCorrectType()
        {
            var username = "username";
            var password = "password";
            var firstName = "nameee";
            var lastName = "lastnamee";
            var email = "someemail@email.com";

            var sut = new UserFactory();
            var returned = sut.CreateAdmin(username, password, firstName, lastName, email);

            Assert.IsInstanceOfType(returned, typeof(Administrator));
        }
    }
}
