using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApplication.EF;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private WebApiContext _dbContext;

        public OrderController(WebApiContext context)
        {
            _dbContext = context;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _dbContext.Orders.ToList();

            return Ok(orders);
        }

        [Route("Get/{id}")]
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            var order = _dbContext.Orders.Find(id);

            if (order == null)
            {
                return BadRequest("Order was not found");
            }

            return Ok(order);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(OrderModel orderModel)
        {
            if (orderModel == null)
            {
                return BadRequest("No Order specified");
            }

            var order = new Order();
            order.Status = orderModel.Status;
            order.CreatedDate = orderModel.CreatedDate;
            order.UpdatedDate = orderModel.UpdatedDate;
            order.ProductId = orderModel.ProductId;

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            return Ok(order);
        }

        [Route("Update")]
        [HttpPut]
        public IActionResult Update(OrderModel orderModel)
        {
            if (orderModel.Id <= 0)
            {
                return BadRequest("No Id specified");
            }

            var order = _dbContext.Orders.Find(orderModel.Id);

            if (order is null)
            {
                return BadRequest("Product not found");
            }

            order.Status = orderModel.Status;
            order.CreatedDate = orderModel.CreatedDate;
            order.UpdatedDate = orderModel.UpdatedDate;
            order.ProductId = orderModel.ProductId;

            _dbContext.Orders.Attach(order);
            _dbContext.SaveChanges();

            return Ok(order);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var order = _dbContext.Orders.Find(id);

            if (order is null)
            {
                return BadRequest("No Data was found");
            }

            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();

            return Ok(order);
        }
    }
}
