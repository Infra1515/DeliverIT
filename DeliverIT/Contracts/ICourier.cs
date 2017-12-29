namespace DeliverIT.Contracts
{
    public interface ICourier
    {
        int Id { get; }
        double AllowedVolume { get; set; }
        double AllowedWeight { get; set; }
       
        bool CanCarry();
    }
}
