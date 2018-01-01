using System;
using DeliverIT.Common;
using DeliverIT.Models.Users;
using DeliverIT.Contracts;
using DeliverIT.Models;
using DeliverIT.Common.Enums;

namespace DeliverIT.Core.Factories
{
    public class DeliverITFactory : IDeliverITFactory
    {
        public Client CreateClient(string username, string password, string firstName, string lastName, string email,
            int age, string phoneNumber, Address address, GenderType gender)
        {
            return new Client(username, password, firstName, lastName, email, age, phoneNumber, address, gender);
        }

        public Courier CreateCourier(string username, string password, string firstName, string lastName, string email,
            int age, string phoneNumber, Address address, GenderType gender, double allowedWeight, double allowedVolume)
        {
            return new Courier(username, password, firstName, lastName, email, age, phoneNumber, address,
                gender, allowedWeight, allowedVolume);
        }

        public IUser CreateAdmin(string username, string password, string firstName, string lastName, string email)
        {
            return new Administrator(username, password, firstName, lastName, email);
        }

        public IOrder CreateOrder(ICourier courier, IClient sender, IClient receiver, DeliveryType deliveryType, DateTime sendDate, DateTime dueDate,
                           OrderState orderState, IProduct product, int postalCode)
        {
            return new Order(courier, sender, receiver, deliveryType, sendDate, dueDate, orderState, product, postalCode);
        }

        public IProduct CreateProduct(double x, double y, double z, bool isFragile, double weight, ProductType productType)
        {
            return new Product(x, y, z, isFragile, weight, productType);
        }
    }
}
