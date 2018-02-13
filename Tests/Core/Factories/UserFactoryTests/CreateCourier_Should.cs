using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Core.Factories.UserFactoryTests
{
    [TestClass]
    public class CreateCourier_Should
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
            var allowedWeight = 500;
            var allowedVolume = 10;

            var sut = new UserFactory();
            var returned = sut.CreateCourier(username, password, firstName, lastName, email, age, phoneNumber, addressStub.Object, genderType, allowedWeight, allowedVolume);

            Assert.IsInstanceOfType(returned, typeof(ICourier));
        }
    }
}
