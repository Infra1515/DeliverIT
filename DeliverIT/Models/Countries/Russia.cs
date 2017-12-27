namespace DeliverIT.Models.Countries
{
    public class Russia : Country
    {
        private const string name = "Russia";
        private const decimal tax = 0.08m;
        public Russia() : base(name, tax)
        {
            this.CitysAndZips.Add("Saint-Petersburg", 190000);
            this.CitysAndZips.Add("Moscow", 101000);

        }
    }
}
