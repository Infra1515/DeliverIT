using System;
using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Models;
using DeliverIT.Models.Users.Clients;
using DeliverIT.Models.Users.Clients.Abstract;
using DeliverIT.Models.Users.Couriers.Abstract;
using DeliverIT.Common.Enums;

namespace DeliverIT.Core.Factories
{
    public class DeliverITFactory : IDeliverITFactory
    {
        public Client CreateClient(string firstName, string lastName, string email, string phoneNumber, int years,
            Address address, GenderType gender)
        {
            return new Client(firstName, lastName, email, phoneNumber, years, address, gender);
        }

        public IOrder CreateOrder(Courier courier, Sender sender, Receiver receiver, DateTime sendDate,
            DateTime dueDate, OrderState orderState, Address address, Product product)
        {
            return new Order(courier, sender, receiver, sendDate, dueDate, orderState, address, product);
        }

        //public Courier CreateCourier(string firstName, string lastName, string email, string phoneNumber, int years, Address address,
        //    GenderType gender, double allowedWeight, double allowedVolume)
        //{
        //    return new 
        //}

        public Product CreateProduct(double x, double y, double z, bool isFragile, double weight,
            ProductType productType)
        {
            return new Product(x, y, z, isFragile, weight, productType);
        }
    }
}
