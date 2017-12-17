namespace DeliverIT
{
    using System;

    public class Dimensions
    {
        private double x;
        private double y;
        private double z;

        public double X {
            get { return this.x; }
            set { this.x = value; } 
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        //props needed
    }
}
