using System;
using DeliverIT.Contracts;
using DeliverIT.Models;
using DeliverIT.Common.Enums;
using DeliverIT.Models.Users;

namespace DeliverIT.Core.Factories
{
    public interface IDeliverITFactory
    {
        IUser CreateClient(string username, string password, string firstName, string lastName, string email,
            int age, string phoneNumber, Address address, GenderType gender);

        IUser CreateCourier(string username, string password, string firstName, string lastName, string email,
            int age, string phoneNumber, Address address, GenderType gender, double allowedWeight, double allowedVolume);

        IUser CreateAdmin(string username, string password, string firstName, string lastName, string email);

        IOrder CreateOrder(Courier courier, Client sender, Client receiver, DateTime sendDate, DateTime dueDate,
                           OrderState orderState, Address address, IProduct product, int postalCode);

        IProduct CreateProduct(double x, double y, double z, bool isFragile, double weight,
            ProductType productType);
    }
}
