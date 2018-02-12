using System.Collections.Generic;
using System.Linq;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Commands.CreateCommands.Contracts;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;

namespace DeliverIT.Core.Commands.CreateCommands
{
    public class CreateProduct : ICreateProduct
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IProductFactory productFactory;

        public CreateProduct(
            IWriter writer,
            IReader reader,
            IProductFactory productFactory)
        {
            this.writer = writer;
            this.reader = reader;
            this.productFactory = productFactory;
        }

        public IProduct Create(IList<string> commandParameters)
        {
            var dimensionsX = double.Parse(commandParameters[0]);
            var dimensionsY = double.Parse(commandParameters[1]);
            var dimensionsZ = double.Parse(commandParameters[2]);
            var isFragileStr = commandParameters[3];
            bool isFragile = isFragileStr == "yes";
            var weight = double.Parse(commandParameters[4]);
            var productTypeString = commandParameters[5];
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

            IProduct product = this.productFactory.CreateProduct(dimensionsX,
            dimensionsY, dimensionsZ, isFragile, weight, productType);
            this.writer.WriteLine($"Product with ID {product.Id} was added succesfully!");
            return product;
            //this.writer.Write("Dimensions(X Y Z): ");
            //var dimensions = this.reader.ReadLine().Split(' ').Select(double.Parse).ToArray();
            //double x = dimensions[0];
            //double y = dimensions[1];
            //double z = dimensions[2];

            //this.writer.Write("Is the product fragile? ");
            //string isFragileStr = this.reader.ReadLine().ToLower().Trim();
            //bool isFragile = isFragileStr == "yes";

            //this.writer.Write("What is the product weight? ");
            //double weight = double.Parse(this.reader.ReadLine());

            //this.writer.Write($"What is the product type?\r\n" +
            //                  "Available:  Clothes, Accessories, Electronics, Other: ");
            //string productTypeString = this.reader.ReadLine().ToLower().Trim();
            //ProductType productType;
            //switch (productTypeString)
            //{
            //    case "clothes":
            //        productType = ProductType.Clothes;
            //        break;
            //    case "accessories":
            //        productType = ProductType.Clothes;
            //        break;
            //    case "electronics":
            //        productType = ProductType.Electronics;
            //        break;
            //    case "other":
            //        productType = ProductType.Other;
            //        break;
            //    default:
            //        productType = ProductType.Other;
            //        break;
            //}
        }
    }
}
