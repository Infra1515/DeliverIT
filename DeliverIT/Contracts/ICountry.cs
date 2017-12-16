﻿using DeliverIT.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Contracts
{
    public interface ICountry
    {
        string Name { get; set; }
        string TelephoneCode { get; set; }
        string PostalCode { get; set; }
        string TimeZone { get; set; }
        Continent Continent { get; set; }
        Dictionary<string, int> CitysAndZips { get; set; }

        void AddCityWithZip(string city, int zip);
        void RemoveCityWithZip(string city, int zip);
    }
}
