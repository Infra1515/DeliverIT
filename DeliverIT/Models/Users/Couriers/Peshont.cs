using DeliverIT.Common;
using DeliverIT.Models.Countries;
using DeliverIT.Models.Users.Couriers.Abstract;

namespace DeliverIT.Models.Users.Couriers
{
    public class Peshont : Courier
    {
        private const string firstName = "Peshont";
        private const string lastName = "Peshontov";
        private const string email = "Peshkata@DeliveryIT.com";
        private const string phoneNumber = "0885236652";
        private static readonly Address address = new Address(new Bulgaria(), "Bulgaria", "81", "Sofia");
        private const int years = 20;
        private const GenderType gender = GenderType.Male;
        private const double allowedWeight = 500;
        private const double allowedVolume = 40;

        public Peshont() : base(firstName, lastName, email, phoneNumber, years, address, gender, allowedWeight, allowedVolume)
        {
        }
    }
}
