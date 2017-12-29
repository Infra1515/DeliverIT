using System.CodeDom;

namespace DeliverIT.Models.Countries
{
    public class Serbia : Country
    {
        private const string name = "Serbia";
        private const decimal tax = 0.25m;
        public Serbia() : base(name, tax)
        {
            this.CitysAndZips.Add("Belgrade", 11000);
            this.CitysAndZips.Add("Nis", 18000);
        }
    }
}
