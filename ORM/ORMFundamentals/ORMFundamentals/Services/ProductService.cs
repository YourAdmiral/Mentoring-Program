using ORMFundamentals.Context;
using ORMFundamentals.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMFundamentals.Services
{
    public class ProductService : IService<Product>
    {
        private MainDbContext _dbContext;

        public ProductService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            Product product = _dbContext.Products.Find(id);

            if (product != null)
                _dbContext.Products.Remove(product);

            _dbContext.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }

            List<Product> products = _dbContext.Products.Where(product => product.Name == name).ToList();

            if (products != null)
            {
                foreach (var product in products)
                {
                    _dbContext.Products.Remove(product);
                }
            }

            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products;
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public void Insert(Product obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            _dbContext.Products.Add(obj);

            _dbContext.SaveChanges();
        }

        public void Update(Product obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            _dbContext.Entry(obj).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }
    }
}
