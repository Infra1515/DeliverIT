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
        public Product(double x, double y, double z, bool isFragile, double weight, ProductType productType)
        {
            this.Dimensions = new Dimensions(x, y, z);
            this.Volume = this.Dimensions.CalculateVolume();
            this.IsFragile = isFragile;
            this.Weight = weight;
            this.ProductType = productType;
        }

        public bool IsFragile { get; }

        public double Weight { get; }

        public Dimensions Dimensions { get; set; }

        private ProductType ProductType { get; set; }

        public double Volume { get; set; }


        //todo override tostring 
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
