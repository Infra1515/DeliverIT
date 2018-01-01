using DeliverIT.Common;

namespace DeliverIT.Models
{
    public struct Dimensions
    {
        private readonly double x;
        private readonly double y;
        private readonly double z;

        public Dimensions(double x, double y, double z)
        {
            Validator.ValidateNotPositive(x, Constants.NotPositiveNumber);
            this.x = x;

            Validator.ValidateNotPositive(y, Constants.NotPositiveNumber);
            this.y = y;

            Validator.ValidateNotPositive(z, Constants.NotPositiveNumber);
            this.z = z;
        }

        public double X { get { return this.x; } }

        public double Y { get { return this.y; } }

        public double Z { get { return this.z; } }

        //method for calculating volume
        public double CalculateVolume()
        {
            return this.X * this.Y * this.Z;
        }
    }
}
