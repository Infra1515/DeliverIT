using DeliverIT.Common.Enums;
using DeliverIT.Contracts;
using DeliverIT.Models.Users.Abstract;

namespace DeliverIT.Models.Users
{
    public class Courier : Person, ICourier
    {
        private static int id = 0;
        
        private double allowedVolume;
        private double allowedWeight;

        public Courier
            ( 
                string username, 
                string password, 
                string firstName, 
                string lastName, 
                string email, 
                int age,
                string phoneNumber, 
                IAddress address, 
                GenderType gender, 
                double allowedWeight, 
                double allowedVolume
            )
                : base(username, password, firstName, lastName, email, age, phoneNumber, address, gender, UserRole.Normal)
        {
            this.Id = ++id;
            this.AllowedVolume = allowedVolume;
            this.AllowedWeight = allowedWeight;
        }

        public int Id { get; protected set; }

        public double AllowedVolume { get => allowedVolume; set => allowedVolume = value; }

        public double AllowedWeight { get => allowedWeight; set => allowedWeight = value; }

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

        public override string ToString()
        {
            return $"ID: {this.Id}\n" +
                base.ToString() +
                $"Allowed Weight: {this.AllowedWeight}\n" +
                $"Allowed Volume: {this.AllowedVolume}";
        }
    }
}
