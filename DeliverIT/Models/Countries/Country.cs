using DeliverIT.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Models.Countries
{
    public class Country : Address
    {
        private const string name = "Bulgaria";
        private const decimal tax = 0.15m;
        private const string telephoneCode = "+359";
        private const string postalCode = "BG";
        private const string timeZone = "UTC-2";
        private const Continent continent = Continent.Europe;

        public Country() : base(name, tax, telephoneCode, postalCode, timeZone, continent)
        {

        }
    }
}
