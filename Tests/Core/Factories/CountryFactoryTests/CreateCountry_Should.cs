using System;
using DeliverIT.Core.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliverIT.Data.Models.Countries;
using DeliverIT.Data.Contracts;

namespace Tests.Core.Factories.CountryFactoryTests
{
    [TestClass]
    public class CreateCountry_Should
    {
        [TestMethod]
        public void ReturnValueOfCorrectType()
        {
            var country = "Bulgaria";

            var sut = new CountryFactory();
            var returned = sut.CreateCountry(country);

            Assert.IsInstanceOfType(returned, typeof(ICountry));
        }

        [TestMethod]
        public void ReturnBulgaria_WhenInvokedWithCorrectString()
        {
            var country = "Bulgaria";

            var sut = new CountryFactory();
            var returned = sut.CreateCountry(country);

            Assert.IsInstanceOfType(returned, typeof(Bulgaria));
        }

        [TestMethod]
        public void ReturnSerbia_WhenInvokedWithCorrectString()
        {
            var country = "Serbia";

            var sut = new CountryFactory();
            var returned = sut.CreateCountry(country);

            Assert.IsInstanceOfType(returned, typeof(Serbia));
        }

        [TestMethod]
        public void ReturnRussia_WhenInvokedWithCorrectString()
        {
            var country = "Russia";

            var sut = new CountryFactory();
            var returned = sut.CreateCountry(country);

            Assert.IsInstanceOfType(returned, typeof(Russia));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenIncorrectStringPassed()
        {
            var country = "noooocountry";

            var sut = new CountryFactory();

            Assert.ThrowsException<ArgumentException>(() => sut.CreateCountry(country));
        }
    }
}
