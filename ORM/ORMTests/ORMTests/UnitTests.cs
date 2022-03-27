﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ORMFundamentals.Context;
using ORMFundamentals.Models;
using ORMFundamentals.Services;

namespace ORMTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod()
        {
            Product product = new Product()
            {
                Id = 1,
                Name = "Carrot",
                Description = "Some information",
                Weight = 2,
                Height = 3,
                Width = 2,
                Length = 4
            };

            Order order = new Order()
            {
                Id = 1,
                Status = OrderStatus.Done,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = product.Id,
                Product = product
            };

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
    }
}
