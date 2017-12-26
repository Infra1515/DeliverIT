using DeliverIT.Common;
using DeliverIT.Models.Countries;
using DeliverIT.Models.Users.Couriers.Abstract;

namespace DeliverIT.Models.Users.Couriers
{
    public class Gosheedy :  Courier
    {
        private const string firstName = "Gosheto";
        private const string lastName = "Goshev";
        private const string email = "Gosheto@DeliveryIT.com";
        private const string phoneNumber = "0895448694";
        private static readonly Address address = new Address(new Bulgaria(), "Bulgaria", "81", "Sofia");
        private const int years = 20;
        private const GenderType gender = GenderType.Male;
        private const double allowedWeight = 500;
        private const double allowedVolume = 40;

        public Gosheedy() : base(firstName, lastName, email, phoneNumber, years, address, gender, allowedWeight, allowedVolume)
        {
        }
    }
}
