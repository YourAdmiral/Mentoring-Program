using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMFundamentals.Context;
using ORMFundamentals.Models;

namespace ORMFundamentals.Services
{
    public class OrderService : IService<Order>
    {
        private MainDbContext _dbContext;

        public OrderService(MainDbContext context)
        {
            _dbContext = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Get()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}
