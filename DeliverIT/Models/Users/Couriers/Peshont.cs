using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliverIT.Common;

namespace DeliverIT.Models.Users.Couriers
{
    public class Peshont : Courier
    {
        private const string firstName = "Peshont";
        private const string lastName = "Peshontov";
        private const string email = "Peshkata@DeliveryIT.com";
        private const string phoneNumber = "0885236652";

        public Peshont(string firstName, string lastName, string email, string phoneNumber, int years,
            Address address, GenderType gender, double allowedWeight, double allowedVolume)
           : base(firstName, lastName, email, phoneNumber, years, address, gender, allowedWeight, allowedVolume)
        {


        }
    }
}
