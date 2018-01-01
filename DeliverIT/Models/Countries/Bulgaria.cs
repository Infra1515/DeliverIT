namespace DeliverIT.Models.Countries
{
    public class Bulgaria : Country
    {
        private const string name = "Bulgaria";
        private const decimal tax = 0.15m;

        public Bulgaria() : base(name, tax)
        {
            this.CitysAndZips.Add("Sofia", 1000);
            this.CitysAndZips.Add("Varna", 9000);
            this.CitysAndZips.Add("Veliko Turnovo", 5000);
            this.CitysAndZips.Add("Lovech", 5500);
        }
    }
}
