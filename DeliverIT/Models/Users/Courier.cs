namespace DeliverIT
{
    using DeliverIT.Common;
    using System;
    using System.Collections.Generic;

    public class Courier : User
    {
        private List<Order> deliveries;
        private static int id;
        private double allowedVolume;
        private double allowedWeight;

        public List<Order> Deliveries { get => deliveries; set => deliveries = value; }
        public double AllowedVolume { get => allowedVolume; set => allowedVolume = value; }
        public double AllowedWeight { get => allowedWeight; set => allowedWeight = value; }

        public Courier(string firstName, string lastName, string email, string phoneNumber,
                        int years, Country country, GenderType gender,
                        double allowedWeight, double allowedVolume) 
            : base(firstName, lastName, email, phoneNumber, years, country, gender)
        {
            this.AllowedVolume = allowedVolume;
            this.AllowedWeight = allowedWeight;
        }


        public bool CanCarry()
        {
            throw new NotImplementedException();
        }
    }
}
