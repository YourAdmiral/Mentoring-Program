using ADOLibrary;
using ADOLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADOTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod()
        {
            //Product product = new Product()
            //{
            //    Id = 3,
            //    Name = "Phone",
            //    Description = "info",
            //    Weight = 6,
            //    Height = 8,
            //    Width = 8,
            //    Length = 8
            //};

            //var productService = new ProductService();
            //productService.DeleteByName("Carrot");

            //var dbContext = new MainDbContext();
            //var orderService = new OrderService(dbContext);
            //var productService = new ProductService(dbContext);

            //productService.Insert(product);
            //orderService.Insert(order);

            //var receivedProducts = productService.GetAll();
            //var receivedOrder = orderService.GetById(2);

            //orderService.Delete(2);
            //productService.Delete(3);
        }

        [TestMethod]
        public void GetAllProducts_ReturnsExpectedProducts()
        {
            var productService = new ProductService();

            var product1 = new Product()
            {
                Id = 1,
                Name = "Key",
                Description = "some...",
                Weight = 4,
                Height = 5,
                Width = 6,
                Length = 7
            };

            var expectedProducts = new List<Product>()
            {
                product1
            };

            var receivedProducts = productService.GetAll();

            CollectionAssert.AreEqual(
                expectedProducts.Select(p => p.Id).ToList(),
                receivedProducts.Select(p => p.Id).ToList());
        }

        [TestMethod]
        public void GetByIdOrder_ReturnsExpectedOrderWithId2()
        {
            //var dbContext = new MainDbContext();
            //var orderService = new OrderService(dbContext);

            //var expectedOrder = new Order()
            //{
            //    Id = 2,
            //    Status = OrderStatus.InProgress,
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = DateTime.Now,
            //    ProductId = 3
            //};

            //var receivedOrder = orderService.GetById(expectedOrder.Id);

            //Assert.AreEqual(
            //    expectedOrder.Id,
            //    receivedOrder.Id);
        }

        [TestMethod]
        public void GetAllByStatusOrders_ReturnsExpectedOrdersWithStatus2()
        {
            //var dbContext = new MainDbContext();
            //var orderService = new OrderService(dbContext);

            //var expectedOrder = new Order()
            //{
            //    Id = 2,
            //    Status = OrderStatus.InProgress,
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = DateTime.Now,
            //    ProductId = 3
            //};

            //var expectedOrders = new List<Order>()
            //{
            //    expectedOrder
            //};

            //var receivedOrders = orderService.GetAllByStatus(expectedOrder.Status);

            //CollectionAssert.AreEqual(
            //    expectedOrders.Select(o => o.Status).ToList(),
            //    receivedOrders.Select(o => o.Status).ToList());
        }

        [TestMethod]
        public void GetByIdOrder_ReturnsExpectedOrderWithId2_UsingDapper()
        {
            //var orderService = new ORMDapper.Services.OrderService();

            //var expectedOrder = new Order()
            //{
            //    Id = 5,
            //    Status = OrderStatus.InProgress,
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = DateTime.Now,
            //    ProductId = 3
            //};

            //var receivedOrder = orderService.GetById(expectedOrder.Id);

            //var ord = orderService.GetAll();

            //Assert.AreEqual(
            //  expectedOrder.Id,
            //   receivedOrder.Id);
        }

        [TestMethod]
        public void GetAllOrders_ReturnsExpectedOrdersWithId5And10_UsingDapper()
        {
            var orderService = new OrderService();

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
