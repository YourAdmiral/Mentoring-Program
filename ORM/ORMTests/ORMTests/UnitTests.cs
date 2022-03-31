using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ORMDapper;
using ORMFundamentals.Context;
using ORMFundamentals.Models;
using ORMFundamentals.Services;

namespace ORMTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GetAllProducts_ReturnsExpectedProducts()
        {
            var dbContext = new MainDbContext();
            var productService = new ProductService(dbContext);

            var product1 = new Product()
            {
                Id = 3,
                Name = "Milk",
                Description = "Some information",
                Weight = 5,
                Height = 20,
                Width = 10,
                Length = 15
            };

            var product2 = new Product()
            {
                Id = 4,
                Name = "Carrot",
                Description = "Some information",
                Weight = 2,
                Height = 3,
                Width = 2,
                Length = 4
            };

            var expectedProducts = new List<Product>()
            {
                product1,
                product2
            };

            var receivedProducts = productService.GetAll();

            CollectionAssert.AreEqual(
                expectedProducts.Select(p => p.Id).ToList(),
                receivedProducts.Select(p => p.Id).ToList());
        }

        [TestMethod]
        public void GetByIdOrder_ReturnsExpectedOrderWithId2()
        {
            var dbContext = new MainDbContext();
            var orderService = new OrderService(dbContext);

            var expectedOrder = new Order()
            {
                Id = 2,
                Status = OrderStatus.InProgress,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = 3
            };

            var receivedOrder = orderService.GetById(expectedOrder.Id);

            Assert.AreEqual(
                expectedOrder.Id,
                receivedOrder.Id);
        }

        [TestMethod]
        public void GetAllByStatusOrders_ReturnsExpectedOrdersWithStatus2()
        {
            var dbContext = new MainDbContext();
            var orderService = new OrderService(dbContext);

            var expectedOrder = new Order()
            {
                Id = 2,
                Status = OrderStatus.InProgress,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = 3
            };

            var expectedOrders = new List<Order>()
            {
                expectedOrder
            };

            var receivedOrders = orderService.GetAllByStatus(expectedOrder.Status);

            CollectionAssert.AreEqual(
                expectedOrders.Select(o => o.Status).ToList(),
                receivedOrders.Select(o => o.Status).ToList());
        }

        [TestMethod]
        public void GetByIdOrder_ReturnsExpectedOrderWithId2_UsingDapper()
        {
            var orderService = new ORMDapper.Services.OrderService();

            var expectedOrder = new Order()
            {
                Id = 5,
                Status = OrderStatus.InProgress,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = 3
            };

            var receivedOrder = orderService.GetById(expectedOrder.Id);

            var ord = orderService.GetAll();

            Assert.AreEqual(
              expectedOrder.Id,
               receivedOrder.Id);
        }

        [TestMethod]
        public void GetAllOrders_ReturnsExpectedOrdersWithId5And10_UsingDapper()
        {
            var orderService = new ORMDapper.Services.OrderService();

            var expectedOrder1 = new Order()
            {
                Id = 5,
                Status = OrderStatus.InProgress,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = 1
            };

            var expectedOrder2 = new Order()
            {
                Id = 10,
                Status = OrderStatus.Done,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = 1
            };

            var expectedOrders = new List<Order>()
            {
                expectedOrder1,
                expectedOrder2
            };

            var receivedOrders = orderService.GetAll();

            CollectionAssert.AreEqual(
                expectedOrders.Select(o => o.Id).ToList(),
                receivedOrders.Select(o => o.Id).ToList());
        }
    }
}
