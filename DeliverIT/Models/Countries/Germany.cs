using System.CodeDom;

namespace DeliverIT.Models.Countries
{
    public class Germany : Country
    {
        private const string name = "Germany";
        private const decimal tax = 0.25m;
        public Germany() : base(name, tax)
        {
            
        }
    }
}
