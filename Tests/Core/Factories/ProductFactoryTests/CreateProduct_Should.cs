using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core.Factories.ProductFactory
{
    [TestClass]
    public class CreateProduct_Should
    {
        [TestMethod]
        public void ReturnValueOfCorrectType()
        {
            double x = 1;
            double y = 1;
            double z = 1;
            bool isFragile = true;
            double weight = 15;
            var productType = ProductType.Accessories;

            var sut = new DeliverIT.Core.Factories.ProductFactory();
            var returned = sut.CreateProduct(x,y,z,isFragile,weight,productType);

            Assert.IsInstanceOfType(returned, typeof(IProduct));
        }
    }
}
