using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiApplication.EF;
using WebApiApplication.Models;
using WebApiApplication.Pagination;

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


        [HttpGet("{productId}/orders")]
        public async Task<IActionResult> Get(
            [FromRoute] int productId, 
            [FromQuery] PaginationParams @params)
        {
            var product = _dbContext.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            var orders = _dbContext.Orders.Where(o => o.ProductId == productId)
                .OrderBy(o => o.Id);

            var paginationMetadata = new PaginationMetadata(orders.Count(), @params.Page, @params.ItemsPerPage);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            var items = await orders.Skip((@params.Page - 1) * @params.ItemsPerPage)
                .Take(@params.ItemsPerPage)
                .ToListAsync();

            return Ok(orders.Select(o=>new OrderModel
            {
                Id = o.Id,
                Status = o.Status,
                CreatedDate = o.CreatedDate,
                UpdatedDate = o.UpdatedDate,
                ProductId = o.ProductId
            }));
        }
    }
}
