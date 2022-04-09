using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApplication.EF;

namespace WebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private WebApiContext _dbContext;

        public ProductController(WebApiContext context)
        {
            _dbContext = context;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _dbContext.Products.ToList();

            return Ok(products);
        }

        [Route("Get/{id}")]
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            var product = _dbContext.Products.Find(id);

            if (product == null)
            {
                return BadRequest("Product was not found");
            }

            return Ok(product);
        }
    }
}
