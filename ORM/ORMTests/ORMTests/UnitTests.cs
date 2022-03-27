using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public void TestMethod1()
        {
            Product product = new Product()
            {
                Id = 1,
                Name = "Milk",
                Description = "Some information",
                Weight = 5,
                Height = 20,
                Width = 10,
                Length = 15
            };

            Order order = new Order()
            {
                Id = 1,
                Status = OrderStatus.InProgress,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = product.Id,
                Product = product
            };

            var dbContext = new MainDbContext();

            OrderService orderService = new OrderService(dbContext);

            ProductService productService = new ProductService(dbContext);

            //productService.Insert(product);

            //orderService.Insert(order);

            //var receivedProducts = productService.GetAll();

            //var receivedOrder = orderService.GetById(2);

            //orderService.Delete(2);

            //productService.Delete(3);
        }
    }
}
