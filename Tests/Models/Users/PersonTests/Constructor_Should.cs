using System;
using DeliverIT.Models.Users.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DeliverIT.Data.Common.Enums;
using DeliverIT.Data.Contracts;

namespace Tests.Models.Users.PersonTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumenNullException_WhenAddressIsNull()
        {
            //protected Person(string username, string password, string firstName, string lastName, string email, int age, string phoneNumber, IAddress address,
            //    GenderType gender, UserRole role)
            //    : base(username, password, firstName, lastName, email, role)
            //{

            var username = "username";
            var password = "password";
            var firstName = "nameee";
            var lastName = "lastnamee";
            var email = "someemail@email.com";
            var age = 18;
            var phoneNumber = "0987654321";
            IAddress address = null;
            var genderType = GenderType.Female;
            var role = UserRole.Administrator;

            Assert.ThrowsException<ArgumentNullException>(() => new Person(username, password, firstName, lastName,
                email, age, phoneNumber, address, genderType, role));
        }

        [TestMethod]
        public void ThrowArgumenOutOfRangeException_WhenYearsAreLessThan18()
        {
            //protected Person(string username, string password, string firstName, string lastName, string email, int age, string phoneNumber, IAddress address,
            //    GenderType gender, UserRole role)
            //    : base(username, password, firstName, lastName, email, role)
            //{

            var username = "username";
            var password = "password";
            var firstName = "nameee";
            var lastName = "lastnamee";
            var email = "someemail@email.com";
            var age = 17;
            var phoneNumber = "0987654321";
            var addressStub = new Mock<IAddress>();
            var genderType = GenderType.Female;
            var role = UserRole.Administrator;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Person(username, password, firstName, lastName,
                email, age, phoneNumber, addressStub.Object, genderType, role));
        }

        [TestMethod]
        public void ThrowArgumenOutOfRangeException_WhenYearsAreGreaterThan100()
        {
            //protected Person(string username, string password, string firstName, string lastName, string email, int age, string phoneNumber, IAddress address,
            //    GenderType gender, UserRole role)
            //    : base(username, password, firstName, lastName, email, role)
            //{

            var username = "username";
            var password = "password";
            var firstName = "nameee";
            var lastName = "lastnamee";
            var email = "someemail@email.com";
            var age = 101;
            var phoneNumber = "0987654321";
            var addressStub = new Mock<IAddress>();
            var genderType = GenderType.Female;
            var role = UserRole.Administrator;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Person(username, password, firstName, lastName,
                email, age, phoneNumber, addressStub.Object, genderType, role));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenPhoneNumberIsNull()
        {
            //protected Person(string username, string password, string firstName, string lastName, string email, int age, string phoneNumber, IAddress address,
            //    GenderType gender, UserRole role)
            //    : base(username, password, firstName, lastName, email, role)
            //{

            var username = "username";
            var password = "password";
            var firstName = "nameee";
            var lastName = "lastnamee";
            var email = "someemail@email.com";
            var age = 19;
            string phoneNumber = null;
            var addressStub = new Mock<IAddress>();
            var genderType = GenderType.Female;
            var role = UserRole.Administrator;

            Assert.ThrowsException<ArgumentNullException>(() => new Person(username, password, firstName, lastName,
                email, age, phoneNumber, addressStub.Object, genderType, role));
        }
    }
}
