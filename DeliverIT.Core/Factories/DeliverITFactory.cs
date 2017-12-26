using System;
using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Models;
using DeliverIT.Models.Users.Clients;
using DeliverIT.Models.Users.Clients.Abstract;
using DeliverIT.Models.Users.Couriers.Abstract;

namespace DeliverIT.Core.Factories
{
    public class DeliverITFactory : IDeliverITFactory
    {
        public Client CreateClient(string firstName, string lastName, string email, string phoneNumber, int years,
            Address address, GenderType gender)
        {
            return new Client(firstName, lastName, email, phoneNumber, years, address, gender);
        }

        public IOrder PlaceOrder(Courier courier, Sender sender, Receiver receiver, DateTime sendDate, DateTime dueDate,
            decimal deliveryPrice, bool isDelivered, Country address, Product product)
        {
            return new Order(courier, sender, receiver, sendDate, dueDate, deliveryPrice, isDelivered, address, product);
        }

        //public Courier CreateCourier(string firstName, string lastName, string email, string phoneNumber, int years, Address address,
        //    GenderType gender, double allowedWeight, double allowedVolume)
        //{
        //    return new 
        //}
    }
}
