using DDD.Samples.Infrastructure.Entity;
using DDD.Samples.Infrastructure.Helper;
using DDD.Samples.Infrastructure.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tests
{
    public class OrderTest
    {
        private OrderRepositoryFake _repository;
        [SetUp]
        public void Setup()
        {
            _repository = new OrderRepositoryFake();
        }

        [Test]
        public void CanCreateOrder()
        {
            Order order = new Order(new Customer());
            Assert.IsNotNull(order);
        }
        [Test]
        public void CanCreateOrderWithCustomer()
        {
            Order order = new Order(new Customer());
            Assert.IsNotNull(order.Customer);
        }

        [Test]
        public void OrderDateIsCurrentAfterCreation()
        {
            DateTime theTimeBefore = DateTime.Now.AddMinutes(-1);
            Order order = new Order(new Customer());
            Assert.IsTrue(order.OrderDate > theTimeBefore);
            Assert.IsTrue(order.OrderDate < DateTime.Now.AddMinutes(1));
        }
        [Test]
        public void OrderNumberIsZeroAfterCretion()
        {
            Order order = new Order(new Customer());
            Assert.AreEqual(0, order.OrderNumber);
        }
        [Test]
        //[Ignore("ignore a test")]//忽略此测试（当测试的方法不确定活不想运行的时候使用此特性）
        public void OrderNumberCantBeZeroAfterReconstitution()
        {
            int theOrderNumber = 42;
            _FakeAnOrder(theOrderNumber);
            Order order = _repository.GetOrder(theOrderNumber);
            Assert.IsTrue(order.OrderNumber != 0);
        }

        [Test]
        public void CanAddOrder()
        {
            _repository.AddOrder(new Order(new Customer()));
        }

        [Test]
        public void CanFindOrdersViaCustomer()
        {
            Customer customer = _FakeAnCustomer(7);
            _FakeAnOrder(42, customer, _repository);
            _FakeAnOrder(12, _FakeAnCustomer(1), _repository);
            _FakeAnOrder(3, customer, _repository);
            _FakeAnOrder(21, customer, _repository);
            _FakeAnOrder(1, _FakeAnCustomer(2), _repository);
            Assert.AreEqual(3, _repository.GetOrders(customer).Count);
        }

        [Test]
        public void EmptyOrderHasZeroForTotalAmount()
        {
            Order order = new Order(new Customer());
            Assert.AreEqual(0, order.TotalAmount);

        }
        [Test]
        //[Ignore("OrderWithLinesHasTotalAmount")]
        public void OrderWithLinesHasTotalAmount()
        {
            Order order = new Order(new Customer());
            OrderLine ol = new OrderLine(new Product("Chair", 52.00m));
            ol.NumberOfUnits = 2;
            order.AddOrderLine(ol);

            OrderLine ol2 = new OrderLine(new Product("Desk", 115.00m));
            ol2.NumberOfUnits = 3;
            order.AddOrderLine(ol2);
            Assert.AreEqual(104.00m + 345m, order.TotalAmount);
        }

        [Test]
        public void OrderLineGetsDefaultPrice()
        {
            Product p = new Product("Chair", 52.00m);
            OrderLine ol = new OrderLine(p);
            Assert.AreEqual(52.00, ol.Price);
        }

        [Test]
        public void OrderLineHasTotalAmount()
        {
            OrderLine ol = new OrderLine(new Product("Chair", 52.00m));
            ol.NumberOfUnits = 2;
            Assert.AreEqual(104.00m, ol.TotalAmount);
        }
        [Test]
        public void CanAddOrderLine()
        {
            Order order = new Order(new Customer());
            OrderLine orderLine = new OrderLine(new Product("Chair", 52.00m));
            order.AddOrderLine(orderLine);
            Assert.AreEqual(1, order.OrderLines.Count);

        }

        [Test]
        public void OrderHasSnapshotOfRealCustomer() {
            Customer customer = new Customer();
            customer.Name = "Volvo";
            Order order = new Order(customer);
            customer.Name = "Saab";
            Assert.AreEqual("Saab",customer.Name);
            Assert.AreEqual("Volvo",order.Customer.Name);

        }

        #region private
        private void _FakeAnOrder(int orderNumber, Customer customer, OrderRepositoryFake repository)
        {
            Order order = new Order(customer);
            RepositoryHelper.SetFieldWhenReconstitutingFromPersistence(order, "_orderNumber", orderNumber);
            _repository.AddOrder(order);
        }
        private Customer _FakeAnCustomer(int customerNumber)
        {
            Customer customer = new Customer();
            RepositoryHelper.SetFieldWhenReconstitutingFromPersistence(customer, "_customerNumber", customerNumber);
            return customer;
        }
        private void _FakeAnOrder(int orderNumber)
        {
            Order order = new Order(new Customer());
            RepositoryHelper.SetFieldWhenReconstitutingFromPersistence(order, "_orderNumber", orderNumber);
            _repository.AddOrder(order);
        }
        #endregion
    }
}