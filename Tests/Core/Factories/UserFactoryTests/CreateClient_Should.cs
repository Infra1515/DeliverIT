using DeliverIT.Core.Factories;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Core.Factories.UserFactoryTests
{
    [TestClass]
    public class CreateClient_Should
    {
        [TestMethod]
        public void ReturnValueOfCorrectType()
        {
            var username = "username";
            var password = "password";
            var firstName = "nameee";
            var lastName = "lastnamee";
            var email = "someemail@email.com";
            var age = 18;
            var phoneNumber = "0987654321";
            var addressStub = new Mock<IAddress>();
            var genderType = GenderType.Female;

            var sut = new UserFactory();
            var returned = sut.CreateClient(username, password, firstName,lastName,email,age, phoneNumber, addressStub.Object,genderType);

            Assert.IsInstanceOfType(returned, typeof(IClient));
        }
    }
}
