namespace DeliverIT.Models.Countries
{
    public class Bulgaria : Country
    {
        private const string name = "Bulgaria";
        private const decimal tax = 0.15m;
        //private const string telephoneCode = "+359";
        //private const string postalCode = "BG";
        //private const string timeZone = "UTC-2";
        //private const Continent continent = Continent.Europe;

        public Bulgaria() : base(name, tax)
        {
            this.CitysAndZips.Add("Sofia", 1000);
            this.CitysAndZips.Add("Varna", 9000);
            this.CitysAndZips.Add("Veliko Turnovo", 5000);
            this.CitysAndZips.Add("Lovech", 5500);
        }
    }
}
