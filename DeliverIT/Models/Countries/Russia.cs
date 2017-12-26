namespace DeliverIT.Models.Countries
{
    public class Russia : Country
    {
        private const string name = "Russia";
        private const decimal tax = 0.08m;
        public Russia() : base(name, tax)
        {
            
        }
    }
}
