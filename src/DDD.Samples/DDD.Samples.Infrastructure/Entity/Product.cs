using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Samples.Infrastructure.Entity
{
    public class Product
    {
        public Product(string description, decimal price)
        {
            Description = description;
            UnitPrice = price;
        }

        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
