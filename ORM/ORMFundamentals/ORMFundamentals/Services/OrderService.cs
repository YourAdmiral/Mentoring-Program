using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public OrderService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            Order order = _dbContext.Orders.Find(id);

            if (order != null)
                _dbContext.Orders.Remove(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders;
        }

        public IEnumerable<Order> GetAllByMonth(int month)
        {
            return _dbContext.Orders.Where(order => order.CreatedDate.Month == month);
        }

        public IEnumerable<Order> GetAllByYear(int year)
        {
            return _dbContext.Orders.Where(order => order.CreatedDate.Year == year);
        }

        public IEnumerable<Order> GetAllByStatus(OrderStatus status)
        {
            return _dbContext.Orders.Where(order => order.Status == status);
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders.Find(id);
        }

        public void Insert(Order obj)
        {
            _dbContext.Orders.Add(obj);
        }

        public void Update(Order obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
        }
    }
}
