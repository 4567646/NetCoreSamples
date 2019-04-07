using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Samples.Infrastructure.Entity
{
    public class Customer
    {
        public int CustomerNumber
        {
            get { return _customerNumber; }
        }
        public Customer() { }
        public string Name { get; set; }

        private int _customerNumber;


        public CustomerSnapshot TakeSnashot()
        {
            return new CustomerSnapshot()
            {
                Name = this.Name
            };
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (this.GetType().Equals(obj.GetType()) == false)
            {
                return false;
            }
            Customer temp = null;
            temp = (Customer)obj;
            return this.CustomerNumber.Equals(temp.CustomerNumber);
        }
        //重写GetHashCode方法（重写Equals方法必须重写GetHashCode方法，否则发生警告

        public override int GetHashCode()
        {
            return this.CustomerNumber.GetHashCode();
        }
    }
}
