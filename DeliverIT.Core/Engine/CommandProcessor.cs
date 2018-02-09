//using DeliverIT.Common;
//using DeliverIT.Common.Enums;
//using DeliverIT.Contracts;
//using DeliverIT.Core.Factories;
//using DeliverIT.Models;
//using DeliverIT.Models.Countries;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;

//namespace DeliverIT.Core.Engine
//{
//    public class CommandProcessor
//    {
//        public IDeliverITFactory Factory { get; }

//        public ICollection<IUser> Users { get; }

//        public ICollection<IOrder> Orders { get; }

//        public CommandProcessor()
//        {
//            this.Users = new List<IUser>();
//            this.Orders = new List<IOrder>();
//            this.Factory = new DeliverITFactory();
//        }

//        public void AddClient()
//        {
//            Console.Write("Username: ");
//            string username = Console.ReadLine();

//            Console.Write("Password: ");
//            string password = Console.ReadLine();

//            Console.Write("First name: ");
//            string firstName = Console.ReadLine();

//            Console.Write("Last name: ");
//            string lastName = Console.ReadLine();

//            Console.Write("Email: ");
//            string email = Console.ReadLine();

//            Console.Write("Phone number: ");
//            string phoneNumber = Console.ReadLine();

//            Console.Write("Age: ");
//            int age = int.Parse(Console.ReadLine());

//            Console.Write("Gender: ");
//            GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), Console.ReadLine());

//            Console.WriteLine("--- Address ---");
//            Console.Write("Country: ");
//            string countryString = Console.ReadLine();

//            Country country;

//            switch ((CountryType)Enum.Parse(typeof(CountryType), countryString))
//            {
//                case CountryType.Bulgaria:
//                    country = new Bulgaria();
//                    break;

//                case CountryType.Serbia:
//                    country = new Serbia();
//                    break;

//                case CountryType.Russia:
//                    country = new Russia();
//                    break;

//                default:
//                    throw new ArgumentException("We don't ship to this country yet!");
//            }

//            Console.Write("City: ");
//            string city = Console.ReadLine();

//            Console.ForegroundColor = ConsoleColor.Red;
//            Validator.ValidateCityInCountry(city, country, Constants.NoSuchCity);
//            Console.ResetColor();

//            Console.Write("Street name: ");
//            string streetName = Console.ReadLine();

//            Console.Write("Street number: ");
//            string streetNumber = Console.ReadLine();

//            Address userAddress = new Address(country, streetName, streetNumber, city);

//            var isUserPresent = this.Users
//                .FirstOrDefault(u => u.Username.Equals(username));

//            if (isUserPresent != null)
//                throw new ArgumentException(string.Format(
//                       Constants.UserAlreadyExists, isUserPresent.GetType().Name, isUserPresent.Username));


//            var client = this.Factory.CreateClient(username, password, firstName, lastName, email, age, phoneNumber, userAddress, gender);

//            this.Users.Add(client);

//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine(Constants.RegisteredClient, client.Username);
//            Console.ResetColor();
//        }

//        public void AddCourier()
//        {
//            Console.Write("Username: ");
//            string username = Console.ReadLine();

//            Console.Write("Password: ");
//            string password = Console.ReadLine();

//            Console.Write("First name: ");
//            string firstName = Console.ReadLine();

//            Console.Write("Last name: ");
//            string lastName = Console.ReadLine();

//            Console.Write("Email: ");
//            string email = Console.ReadLine();

//            Console.Write("Phone number: ");
//            string phoneNumber = Console.ReadLine();

//            Console.Write("Age: ");
//            int age = int.Parse(Console.ReadLine());

//            Console.Write("Gender: ");
//            GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), Console.ReadLine());

//            Console.WriteLine("--- Address ---");
//            Console.Write("Country: ");
//            string countryString = Console.ReadLine();

//            Country country;

//            switch ((CountryType)Enum.Parse(typeof(CountryType), countryString))
//            {
//                case CountryType.Bulgaria:
//                    country = new Bulgaria();
//                    break;

//                case CountryType.Serbia:
//                    country = new Serbia();
//                    break;

//                case CountryType.Russia:
//                    country = new Russia();
//                    break;

//                default:
//                    throw new ArgumentException("We don't ship to this country yet!");
//            }

//            Console.Write("City: ");
//            string city = Console.ReadLine();

//            Console.ForegroundColor = ConsoleColor.Red;
//            Validator.ValidateCityInCountry(city, country, Constants.NoSuchCity);
//            Console.ResetColor();

//            Console.Write("Street name: ");
//            string streetName = Console.ReadLine();

//            Console.Write("Street number: ");
//            string streetNumber = Console.ReadLine();

//            Console.Write("Enter maximum allowed weight that the courier can carry: ");
//            double allowedWeight = double.Parse(Console.ReadLine());

//            Console.Write("Enter maximum allowed volume that the courier can carry: ");
//            double allowedVolume = double.Parse(Console.ReadLine());

//            Address userAddress = new Address(country, streetName, streetNumber, city);

//            var isUserPresent = this.Users
//                .FirstOrDefault(u => u.Username.Equals(username));

//            if (isUserPresent != null)
//                throw new ArgumentException(string.Format(
//                       Constants.UserAlreadyExists, isUserPresent.GetType().Name, isUserPresent.Username));


//            var courier = this.Factory.CreateCourier(username, password, firstName, lastName, email, age, phoneNumber, userAddress, gender, allowedWeight, allowedVolume);

//            this.Users.Add(courier);

//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine(Constants.RegisteredCourier, courier.Username);
//            Console.ResetColor();
//        }

//        public IProduct AddProduct()
//        {
//            Console.Write("Dimensions(X Y Z): ");
//            var dimensions = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
//            double x = dimensions[0];
//            double y = dimensions[1];
//            double z = dimensions[2];

//            Console.Write("Is the product fragile? ");
//            string isFragileStr = Console.ReadLine().ToLower().Trim();
//            bool isFragile = isFragileStr == "yes";

//            Console.Write("What is the product weight? ");
//            double weight = double.Parse(Console.ReadLine());

//            Console.Write($"What is the product type?\r\n" +
//                "Available:  Clothes, Accessories, Electronics, Other: ");
//            string productTypeString = Console.ReadLine().ToLower().Trim();
//            ProductType productType;
//            switch (productTypeString)
//            {
//                case "clothes":
//                    productType = ProductType.Clothes;
//                    break;
//                case "accessories":
//                    productType = ProductType.Clothes;
//                    break;
//                case "electronics":
//                    productType = ProductType.Electronics;
//                    break;
//                case "other":
//                    productType = ProductType.Other;
//                    break;
//                default:
//                    productType = ProductType.Other;
//                    break;
//            }
//            IProduct product = this.Factory.CreateProduct(x, y, z, isFragile, weight, productType);
//            Console.WriteLine($"Product with ID {product.Id} was added succesfully!");

//            return product;
//        }

//        public void AddOrder()
//        {
//            var couriers = this.Users
//                .Where(u => u.Role == UserRole.Normal)
//                .Cast<ICourier>();

//            var clients = this.Users
//                .Where(u => u.Role == UserRole.Operator)
//                .Cast<IClient>();

//            this.PrintUser(couriers);

//            string inputCourier = Console.ReadLine();

//            ICourier selectedCourier = couriers
//                .FirstOrDefault(sc => sc.Username.Equals(inputCourier));

//            Console.WriteLine("--- Sender ---");
//            this.PrintUser(clients);

//            string inputSender = Console.ReadLine();

//            IClient selectedSender = clients
//                .FirstOrDefault(sc => sc.Username.Equals(inputSender));

//            Console.WriteLine("--- Receiver ---");
//            this.PrintUser(clients);

//            string inputReceiver = Console.ReadLine();

//            IClient selectedReceiver = clients
//               .FirstOrDefault(sc => sc.Username.Equals(inputReceiver));

//            Console.WriteLine("---Delivery Type information---");
//            Console.Write("Delivery type (Standart/Express): ");

//            string type = Console.ReadLine();
//            DeliveryType deliveryType = AddDeliveryType(type);

//            Console.Write("---Product information---");
//            IProduct product = AddProduct();

//            Console.Write("Enter date of sending (Day/Month/Year): ");
//            DateTime sendDate = DateTime.ParseExact(Console.ReadLine(),
//                                "d/M/yyyy", CultureInfo.InvariantCulture);

//            Console.Write("Enter due date for delivery(Day/Month/Year): ");
//            DateTime dueDate = DateTime.ParseExact(Console.ReadLine(),
//                            "d/M/yyyy", CultureInfo.InvariantCulture);

//            int postalCode = selectedReceiver.Address.Country.CitysAndZips[selectedReceiver.Address.City];

//            var order = this.Factory.CreateOrder(selectedCourier, selectedSender, selectedReceiver, deliveryType, sendDate, dueDate, OrderState.InProgress, product, postalCode);

//            this.Orders.Add(order);

//            selectedCourier.OrdersList.Add(order);
//            selectedReceiver.OrdersList.Add(order);
//            selectedSender.OrdersList.Add(order);
//        }

//        private void PrintUser<T>(IEnumerable<T> users) where T : IUser
//        {
//            Console.WriteLine("Please select:");

//            foreach (var user in users)
//            {
//                Console.WriteLine(user.Username);
//            }
//        }

//        public DeliveryType AddDeliveryType(string deliveryType)
//        {
//            DeliveryType type;

//            switch ((DeliveryType)Enum.Parse(typeof(DeliveryType), deliveryType))
//            {
//                case DeliveryType.Express:
//                    type = DeliveryType.Express;
//                    break;
//                case DeliveryType.Standart:
//                    type = DeliveryType.Standart;
//                    break;
//                default:
//                    type = DeliveryType.Standart;
//                    break;
//            }
//            return type;
//        }

//        public string ShowAllClients()
//        {
//            StringBuilder sb = new StringBuilder();
//            if (this.Users.Count == 0)
//            {
//                sb.AppendLine("No clients registered!");
//            }
//            else
//            {
//                foreach (var client in this.Users)
//                {
//                    sb.AppendLine(client.ToString());
//                    sb.AppendLine("-----------------------");
//                }
//            }
//            return sb.ToString();
//        }

//        public string ShowAllOrders()
//        {
//            var sb = new StringBuilder();
//            if (this.Orders.Any())
//            {
//                foreach (var order in Orders)
//                {
//                    sb.AppendLine(order.ToString());
//                }
//            }
//            else
//            {
//                sb.AppendLine("No orders placed yet!");
//            }

//            return sb.ToString();
//        }

//        public string ShowAllLocations()
//        {
//            StringBuilder strBuilder = new StringBuilder();
//            strBuilder.AppendLine("--- Delivery locations ---");
//            strBuilder.AppendLine(" -- " + CountryType.Bulgaria);
//            strBuilder.AppendLine(" -- " + CountryType.Russia);
//            strBuilder.AppendLine(" -- " + CountryType.Serbia);
//            return strBuilder.ToString();
//        }
//    }
//}
