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

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(ProductModel productModel)
        {
            if (productModel == null)
            {
                return BadRequest("No Product specified");
            }

            var product = new Product();
            product.Name = productModel.Name;
            product.Description = productModel.Description;
            product.Weight = productModel.Weight;
            product.Height = productModel.Height;
            product.Width = productModel.Width;
            product.Length = productModel.Length;

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return Ok(product);
        }

        [Route("Update")]
        [HttpPut]
        public IActionResult Update(ProductModel productModel)
        {
            if (productModel.Id <= 0)
            {
                return BadRequest("No Id specified");
            }

            var product = _dbContext.Products.Find(productModel.Id);

            if (product is null)
            {
                return BadRequest("Product not found");
            }

            product.Name = productModel.Name;
            product.Description = productModel.Description;
            product.Weight = productModel.Weight;
            product.Height = productModel.Height;
            product.Width = productModel.Width;
            product.Length = productModel.Length;

            _dbContext.Products.Attach(product);
            _dbContext.SaveChanges();

            return Ok(product);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Products.Find(id);

            if (product is null)
            {
                return BadRequest("No Data was found");
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();

            return Ok(product);
        }
    }
}
