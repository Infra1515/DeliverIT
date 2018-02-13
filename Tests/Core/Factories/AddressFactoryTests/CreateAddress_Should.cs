using DeliverIT.Core.Factories;
using DeliverIT.Data.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Core.Factories.AddressFactoryTests
{

    [TestClass]
    public class CreateAddress_Should
    {
        [TestMethod]
        public void ReturnValueOfCorrectType()
        {
            var countryStub = new Mock<ICountry>();
            var streetName = "somename";
            var streetNumber = "81";
            var city = "Lovech";

            var sut = new AddressFactory();
            var returned = sut.CreateAddress(countryStub.Object,streetName,streetNumber,city);

            Assert.IsInstanceOfType(returned, typeof(IAddress));
        }
    }
}
