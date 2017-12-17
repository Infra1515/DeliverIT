using DeliverIT.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Models
{
    public class Product
    {
        public Product(double x, double y, double z)
        {
            this.Dimensions.X = x;
            this.Dimensions.Y = y;
            this.Dimensions.Z = z;

        }
        public bool IsFragile { get; }

        public double Weight { get; }

        public Dimensions Dimensions  { get; set; }

        private ProductType productType;

        public double CalculateDimensions()
        {
            return this.Dimensions.X * this.Dimensions.Y * this.Dimensions.Z;
        }

        //todo override tostring 
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
