using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Samples.Infrastructure.Entity
{
    public class OrderLine
    {
        public OrderLine(Product product)
        {
            Product = product;
            Price = product.UnitPrice;
        }
        public decimal Price = 0;
        public Product Product { get; set; }
        public decimal TotalAmount
        {
            get { return Price * NumberOfUnits; }
        }
        public int NumberOfUnits { get; set; } = 0;



    }
}
