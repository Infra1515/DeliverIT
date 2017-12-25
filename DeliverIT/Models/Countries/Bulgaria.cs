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
        }
    }
}
