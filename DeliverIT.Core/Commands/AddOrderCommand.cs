using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DeliverIT.Common;
using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.Factories;

namespace DeliverIT.Core.Commands
{
    public class AddOrderCommand : ICommand
    {
        private readonly ICollection<IUser> users;
        private readonly ICollection<IOrder> orders;
        private readonly IDeliverITFactory factory;

        public AddOrderCommand(
            ICollection<IUser> users, 
            ICollection<IOrder> orders, 
            IDeliverITFactory factory)
        {
            this.users = users;
            this.orders = orders;
            this.factory = factory;
        }

        public void Execute()
        {
            var couriers = this.users
               .Where(u => u.Role == UserRole.Normal)
               .Cast<ICourier>();

            var clients = this.users
                .Where(u => u.Role == UserRole.Operator)
                .Cast<IClient>();

            this.PrintUser(couriers);

            string inputCourier = Console.ReadLine();

            ICourier selectedCourier = couriers
                .FirstOrDefault(sc => sc.Username.Equals(inputCourier));

            Console.WriteLine("--- Sender ---");
            this.PrintUser(clients);

            string inputSender = Console.ReadLine();

            IClient selectedSender = clients
                .FirstOrDefault(sc => sc.Username.Equals(inputSender));

            Console.WriteLine("--- Receiver ---");
            this.PrintUser(clients);

            string inputReceiver = Console.ReadLine();

            IClient selectedReceiver = clients
               .FirstOrDefault(sc => sc.Username.Equals(inputReceiver));

            Console.WriteLine("---Delivery Type information---");
            Console.Write("Delivery type (Standart/Express): ");

            string type = Console.ReadLine();
            DeliveryType deliveryType = AddDeliveryType(type);

            Console.Write("---Product information---");
            IProduct product = AddProduct();

            Console.Write("Enter date of sending (Day/Month/Year): ");
            DateTime sendDate = DateTime.ParseExact(Console.ReadLine(),
                                "d/M/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Enter due date for delivery(Day/Month/Year): ");
            DateTime dueDate = DateTime.ParseExact(Console.ReadLine(),
                            "d/M/yyyy", CultureInfo.InvariantCulture);

            int postalCode = selectedReceiver.Address.Country.CitysAndZips[selectedReceiver.Address.City];

            var order = this.factory.CreateOrder(selectedCourier, selectedSender, selectedReceiver, deliveryType, sendDate, dueDate, OrderState.InProgress, product, postalCode);

            this.orders.Add(order);

            selectedCourier.OrdersList.Add(order);
            selectedReceiver.OrdersList.Add(order);
            selectedSender.OrdersList.Add(order);
        }

        public DeliveryType AddDeliveryType(string deliveryType)
        {
            DeliveryType type;

            switch ((DeliveryType)Enum.Parse(typeof(DeliveryType), deliveryType))
            {
                case DeliveryType.Express:
                    type = DeliveryType.Express;
                    break;
                case DeliveryType.Standart:
                    type = DeliveryType.Standart;
                    break;
                default:
                    type = DeliveryType.Standart;
                    break;
            }
            return type;
        }

        public IProduct AddProduct()
        {
            Console.Write("Dimensions(X Y Z): ");
            var dimensions = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double x = dimensions[0];
            double y = dimensions[1];
            double z = dimensions[2];

            Console.Write("Is the product fragile? ");
            string isFragileStr = Console.ReadLine().ToLower().Trim();
            bool isFragile = isFragileStr == "yes";

            Console.Write("What is the product weight? ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write($"What is the product type?\r\n" +
                          "Available:  Clothes, Accessories, Electronics, Other: ");
            string productTypeString = Console.ReadLine().ToLower().Trim();
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
            IProduct product = this.factory.CreateProduct(x, y, z, isFragile, weight, productType);
            Console.WriteLine($"Product with ID {product.Id} was added succesfully!");

            return product;
        }

        private void PrintUser<T>(IEnumerable<T> users) where T : IUser
        {
            Console.WriteLine("Please select:");

            foreach (var user in users)
            {
                Console.WriteLine(user.Username);
            }
        }
    }
}
