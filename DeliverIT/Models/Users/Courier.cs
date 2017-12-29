using DeliverIT.Common;
using DeliverIT.Common.Enums;
using System.Collections.Generic;
using DeliverIT.Common;
using DeliverIT.Models.Users.Abstract;
using DeliverIT.Models.Contracts.User;
using DeliverIT.Contracts;

namespace DeliverIT.Models.Users.Couriers.Abstract
{
    public abstract class Courier : User, ICourier
    {
        private static int id = 0;
        private double allowedVolume;
        private double allowedWeight;



        public Courier(string firstName, string lastName, string email, string phoneNumber,
                        int years, Address address, GenderType gender,
                        double allowedWeight, double allowedVolume, string userName)
            : base(firstName, lastName, email, phoneNumber, years, address, gender, userName)
        {
            id++;
            this.AllowedVolume = allowedVolume;
            this.AllowedWeight = allowedWeight;
        }

        public double AllowedVolume { get => allowedVolume; set => allowedVolume = value; }
        public double AllowedWeight { get => allowedWeight; set => allowedWeight = value; }
        public int Id { get => id; }

        //method used for allowed volume and weight orders
        public virtual bool CanCarry()
        {
            bool canCarry = false;

            foreach (var order in this.OrdersList)
            {
                
                if (order.Product.Weight <= this.AllowedWeight &&
                    order.Product.Volume <= this.AllowedVolume)
                {
                    this.AllowedWeight -= order.Product.Weight;
                    this.AllowedVolume -= order.Product.Volume;
                    canCarry = true;
                }
            }

            return canCarry;
        }

        public void DisplayAllOrders()
        {

        }

        public override string ToString()
        {
            return $"- {this.FirstName} {this.LastName} {this.Email} {this.PhoneNumber} { this.Years} {this.Address} {this.Gender}";
        }
    }
}
