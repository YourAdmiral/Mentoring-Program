﻿using ORMFundamentals.Context;
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
        }

        public void DeleteByName(string name)
        {
            List<Product> products = _dbContext.Products.Where(product => product.Name == name).ToList();

            if (products != null)
            {
                foreach (var product in products)
                {
                    _dbContext.Products.Remove(product);
                }
            }
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
            _dbContext.Products.Add(obj);
        }

        public void Update(Product obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
        }
    }
}
