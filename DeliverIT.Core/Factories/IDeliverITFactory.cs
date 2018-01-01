using System;
using DeliverIT.Common;
using DeliverIT.Contracts;
using DeliverIT.Models;
using DeliverIT.Common.Enums;
using DeliverIT.Models.Users;
using DeliverIT.Common;

namespace DeliverIT.Core.Factories
{
    public interface IDeliverITFactory
    {
        Client CreateClient(string username, string password, string firstName, string lastName, string email,
            int age, string phoneNumber, Address address, GenderType gender);

        Courier CreateCourier(string username, string password, string firstName, string lastName, string email,
            int age, string phoneNumber, Address address, GenderType gender, double allowedWeight, double allowedVolume);

        IUser CreateAdmin(string username, string password, string firstName, string lastName, string email);

        IOrder CreateOrder(ICourier courier, IClient sender, IClient receiver, DeliveryType deliveryType, DateTime sendDate, DateTime dueDate,
                           OrderState orderState, IProduct product, int postalCode);

        IProduct CreateProduct(double x, double y, double z, bool isFragile, double weight,
            ProductType productType);
    }
}
