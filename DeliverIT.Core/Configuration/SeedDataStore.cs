using System;
using DeliverIT.Core.Factories;
using DeliverIT.Core.Factories.Contracts;
using DeliverIT.Data;
using DeliverIT.Data.Common.Enums;

namespace DeliverIT.Core.Configuration
{
    public class SeedDataStore
    {
        private readonly IDataStore dataStore;
        private readonly IUserFactory userFactory;
        private readonly ICountryFactory countryFactory;
        private readonly IAddressFactory addressFactory;
        private readonly IProductFactory productFactory;
        private readonly IOrderFactory orderFactory;

        public SeedDataStore(IDataStore dataStore, IUserFactory userFactory,
            ICountryFactory countryFactory, IAddressFactory addressFactory,
            IProductFactory productFactory, IOrderFactory orderFactory)
        {
            this.dataStore = dataStore;
            this.userFactory = userFactory;
            this.countryFactory = countryFactory;
            this.addressFactory = addressFactory;
            this.productFactory = productFactory;
            this.orderFactory = orderFactory;

        }
        public void SeedObjects()
        {
            var adminUser = this.userFactory.CreateAdmin("root", "123456", "Ivan", "Gargov", "basi@qkoto.adminsum");

            var country = this.countryFactory.CreateCountry("Bulgaria");
            var address = this.addressFactory.CreateAddress(country, "Dummy", "100", "Sofia");

            var dummyClient = this.userFactory.CreateClient("client123", "1234", "DummyFirst", "DummyLast", "dummy@dummy.com", 18, "12345678", address, GenderType.Male);
            var dummyClientCool = this.userFactory.CreateClient("coolClient", "1234", "DummyCool", "DummyLastCool", "dummycool@dummy.com", 18, "12345678", address, GenderType.Male);

            // Beloved ones resurrected :))
            var dummyCourierGosheedy = this.userFactory.CreateCourier("gosheedy", "1234", "Gosheto", "Goshev", "Gosheto@DeliveryIT.com", 20, "0895448694", address, GenderType.Male, 500, 40);
            var dummyCourierPeshont = this.userFactory.CreateCourier("peshont", "1234", "Peshont", "Peshontov", "Peshkata@DeliveryIT.com", 20, "0885236652", address, GenderType.Male, 500, 40);

            var product = this.productFactory.CreateProduct(10, 10, 10, false, 50, ProductType.Accessories);
            var order = this.orderFactory.CreateOrder(dummyCourierGosheedy, dummyClient, dummyClientCool, DeliveryType.Express, DateTime.Now, DateTime.Now.AddSeconds(30), OrderState.InProgress, product, 10);

            this.dataStore.AddUser(adminUser);
            this.dataStore.AddUser(dummyClient);
            this.dataStore.AddUser(dummyClientCool);
            this.dataStore.AddUser(dummyCourierGosheedy);
            this.dataStore.AddUser(dummyCourierPeshont);
            this.dataStore.Orders.Add(order);
        }

    }
}
