using Bytes2you.Validation;

namespace DeliverIT.Data.Models
{
    public struct Dimensions
    {
        private readonly double x;
        private readonly double y;
        private readonly double z;

        public Dimensions(double x, double y, double z)
        {
            Guard.WhenArgument(x, "x is negative").IsLessThanOrEqual(0).Throw();
            this.x = x;

            Guard.WhenArgument(y, "y is negative").IsLessThanOrEqual(0).Throw();
            this.y = y;

            Guard.WhenArgument(z, "z is negative").IsLessThanOrEqual(0).Throw();
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
