using DeliverIT.Models.Countries;

namespace DeliverIT.Contracts
{
    public interface IAddress
    {
        ICountry Country { get; set; }
        string StreetName { get; set; }
        string StreetNumber { get; set; }
        string City { get; set; }
    }
}
