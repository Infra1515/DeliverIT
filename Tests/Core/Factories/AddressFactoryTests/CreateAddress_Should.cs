using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tests.Mocks;

namespace Tests.Core.Factories.AddressFactoryTests
{
//    public IAddress CreateAddress(ICountry country, string streetName, string streetNumber, string city)
//    {
//    return new Address(country, streetName, streetNumber, city);
//}

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
