namespace DeliverIT.Contracts
{
    public interface ICourier : IUser
    {
        int Id { get; }
        double AllowedVolume { get; set; }
        double AllowedWeight { get; set; }
       
        bool CanCarry();
    }
}
