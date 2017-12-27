using System;
using DeliverIT.Common;
using DeliverIT.Models.Users;
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
            Address address, GenderType gender, ClientType clientType)
        {
            return new Client(firstName, lastName, email, phoneNumber, years, address, gender, clientType);
        }

        public IOrder CreateOrder(Courier courier, Client sender, Client receiver, DateTime sendDate,
            DateTime dueDate, OrderState orderState, Address address, Product product, int postalCode)
        {
            return new Order(courier, sender, receiver, sendDate, dueDate, orderState, address, product, postalCode);
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
