using DDD.Samples.Infrastructure.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace DDD.Samples.Infrastructure.Repository
{
    public class OrderRepositoryFake: IOrderRepository
    {
        private List<Order> _theOrders = new List<Order>();
        public Order GetOrder(int orderNumber)
        {
            foreach (var o in _theOrders)
            {
                if (o.OrderNumber == orderNumber)
                    return o;
            }
            return null;
        }
        public void AddOrder(Order order)
        {
            int theNumberOfOrdersBefore = _theOrders.Count + 1;
            _theOrders.Add(order);
            //TODO Add here...
            Trace.Assert(theNumberOfOrdersBefore > 0);
        }
        public IList GetOrders(Customer customer)
        {
            IList theResult = new ArrayList();
            foreach (Order o in _theOrders)
            {
                if (o.Customer.Equals(customer))
                {
                    theResult.Add(o);
                }
            }
            return theResult;
        }

       
    }
}
