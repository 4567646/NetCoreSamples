using DDD.Samples.Infrastructure.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DDD.Samples.Infrastructure.Entity
{
    public class Order
    {
        public Order(Customer customer)
        {
            Customer = customer.TakeSnashot();
            _orderDate = DateTime.Now;
            _orderNumber = 0;
        }

        public CustomerSnapshot Customer;

        public int OrderNumber
        {
            get { return _orderNumber; }
        }
        public DateTime OrderDate
        {
            get { return _orderDate; }
        }
        public decimal TotalAmount
        {
            get
            {
                decimal theSum = 0;
                foreach (OrderLine ol in _orderLines)
                {
                    theSum += ol.TotalAmount;
                }
                return theSum;
            }
        }
        public IList OrderLines
        {
            get { return _orderLines; }
        }
        private int _totalAmount = 0;
        private int _orderNumber;
        private DateTime _orderDate;
        private IList _orderLines { get; set; } = new ArrayList();

        public void AddOrderLine(OrderLine orderLine)
        {
            _orderLines.Add(orderLine);
        }

    }
}
