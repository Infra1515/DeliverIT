using System.Collections.Generic;
using DeliverIT.Common;
using DeliverIT.Models.Users.Abstract;
using DeliverIT.Models.Contracts.User;

namespace DeliverIT.Models.Users.Couriers.Abstract
{
    public abstract class Courier : User, ICourier
    {
        private IList<Order> deliveries;
        private static int id = 0;
        private double allowedVolume;
        private double allowedWeight;

        public IList<Order> Deliveries { get => deliveries; set => deliveries = value; }
        public double AllowedVolume { get => allowedVolume; set => allowedVolume = value; }
        public double AllowedWeight { get => allowedWeight; set => allowedWeight = value; }
        public int Id { get => id; }

        public Courier(string firstName, string lastName, string email, string phoneNumber,
                        int years, Address address, GenderType gender,
                        double allowedWeight, double allowedVolume)
            : base(firstName, lastName, email, phoneNumber, years, address, gender)
        {
            id++;
            this.AllowedVolume = allowedVolume;
            this.AllowedWeight = allowedWeight;
            this.Deliveries = new List<Order>();
        }

        //method used for allowed volume and weight orders
        public virtual bool CanCarry()
        {
            bool canCarry = false;

            foreach (var delivery in Deliveries)
            {
                if (delivery.Product.Weight <= this.AllowedWeight &&
                    delivery.Product.Volume <= this.AllowedVolume)
                {
                    this.AllowedWeight -= delivery.Product.Weight;
                    this.AllowedVolume -= delivery.Product.Volume;
                    canCarry = true;
                }
            }

            return canCarry;
        }

        public override string ToString()
        {
            return $"- {this.FirstName} {this.LastName} {this.Email} {this.PhoneNumber} { this.Years} {this.Address} {this.Gender}";
        }
    }
}
