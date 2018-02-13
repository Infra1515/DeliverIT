namespace DeliverIT.Data.Contracts
{
    public interface IAddress
    {
        ICountry Country { get; set; }
        string StreetName { get; set; }
        string StreetNumber { get; set; }
        string City { get; set; }
    }
}
