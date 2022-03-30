using ADOLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOLibrary
{
    public class OrderService : IService<Order>
    {
        private string _connectionString = AppConnection.ConnectionString;

        public void Delete(int id)
        {
            //Order order = _dbContext.Orders.Find(id);

            //if (order != null)
            //    _dbContext.Orders.Remove(order);
        }

        public IEnumerable<Order> GetAll()
        {
            //return _dbContext.Orders;
            return null;
        }

        public IEnumerable<Order> GetAllByMonth(int month)
        {
            //return _dbContext.Orders.Where(order => order.CreatedDate.Month == month);
            return null;
        }

        public IEnumerable<Order> GetAllByYear(int year)
        {
            //return _dbContext.Orders.Where(order => order.CreatedDate.Year == year);
            return null;
        }

        public IEnumerable<Order> GetAllByStatus(OrderStatus status)
        {
            //return _dbContext.Orders.Where(order => order.Status == status);
            return null;
        }

        public Order GetById(int id)
        {
            //return _dbContext.Orders.Find(id);
            return null;
        }

        public void Insert(Order obj)
        {
            //_dbContext.Orders.Add(obj);
        }

        public void Update(Order obj)
        {
            //_dbContext.Entry(obj).State = EntityState.Modified;
        }
    }
}
