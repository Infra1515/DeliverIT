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
    public interface IDeliverITFactory
    {
        Client CreateClient(string firstName, string lastName, string email, string phoneNumber, int years,
            Address address, GenderType gender, ClientType clientType, string username);

        IOrder CreateOrder(Courier courier, Client sender, Client receiver, DateTime sendDate, DateTime dueDate,
                           OrderState orderState, Address address, Product product, int postalCode);

        Product CreateProduct(double x, double y, double z, bool isFragile, double weight,
            ProductType productType);

        //Courier CreateCourier(string firstName, string lastName, string email, string phoneNumber,
        //    int years, Address address, GenderType gender,double allowedWeight, double allowedVolume);
    }
}
