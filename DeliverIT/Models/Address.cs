using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Models
{
    public class Address
    {
        private string city;
        private string streetName;
        private int buildingNumber;
        public Address()
        {

        }
        public string City { get => city; set => city = value; }
    }
}
