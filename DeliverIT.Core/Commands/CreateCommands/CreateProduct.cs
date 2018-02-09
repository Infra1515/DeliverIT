using System.Linq;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Core.Contracts;

namespace DeliverIT.Core.Commands
{
    public class CreateProduct : ICreateProduct
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IDeliverITFactory deliverItFactory;

        public CreateProduct(
            IWriter writer,
            IReader reader,
            IDeliverITFactory deliverItFactory)
        {
            this.writer = writer;
            this.reader = reader;
            this.deliverItFactory = deliverItFactory;
        }

        public IProduct Create()
        {
            this.writer.Write("Dimensions(X Y Z): ");
            var dimensions = this.reader.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double x = dimensions[0];
            double y = dimensions[1];
            double z = dimensions[2];

            this.writer.Write("Is the product fragile? ");
            string isFragileStr = this.reader.ReadLine().ToLower().Trim();
            bool isFragile = isFragileStr == "yes";

            this.writer.Write("What is the product weight? ");
            double weight = double.Parse(this.reader.ReadLine());

            this.writer.Write($"What is the product type?\r\n" +
                              "Available:  Clothes, Accessories, Electronics, Other: ");
            string productTypeString = this.reader.ReadLine().ToLower().Trim();
            ProductType productType;
            switch (productTypeString)
            {
                case "clothes":
                    productType = ProductType.Clothes;
                    break;
                case "accessories":
                    productType = ProductType.Clothes;
                    break;
                case "electronics":
                    productType = ProductType.Electronics;
                    break;
                case "other":
                    productType = ProductType.Other;
                    break;
                default:
                    productType = ProductType.Other;
                    break;
            }
            IProduct product = this.deliverItFactory.CreateProduct(x, y, z, isFragile, weight, productType);
            this.writer.WriteLine($"Product with ID {product.Id} was added succesfully!");

            return product;
        }
    }
}
