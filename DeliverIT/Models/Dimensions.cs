namespace DeliverIT
{
    using System;

    public struct Dimensions
    {
        private double x;
        private double y;
        private double z;

        public Dimensions(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double X { get { return this.x; } set { this.x = value; } }

        public double Y { get { return this.y; } set { this.y = value; } }

        public double Z { get { return this.z; } set { this.z = value; } }

        //method for calculating volume
        public double CalculateVolume()
        {
            return this.X * this.Y * this.Z;
        }
    }
}
