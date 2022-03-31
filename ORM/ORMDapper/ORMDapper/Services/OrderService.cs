using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ORMDapper.Models;

namespace ORMDapper.Services
{
    public class OrderService : IService<Order>
    {
        private IDbConnection db = new SqlConnection(AppConnection.ConnectionString);

        public void Delete(int id)
        {
            db.Open();

            db.Execute(
                $@"DELETE FROM Orders WHERE Id = {id}",
                commandType: CommandType.Text);

            db.Close();
        }

        public IEnumerable<Order> GetAll()
        {
            db.Open();

            var orders = db.Query<Order>(
                @"SELECT 
                    Id, 
                    Status, 
                    CreatedDate, 
                    UpdatedDate, 
                    ProductId 
                    FROM Orders",
                commandType: CommandType.Text);

            db.Close();

            return orders;
        }

        public IEnumerable<Order> GetAllByStatus(OrderStatus status)
        {
            db.Open();

            var orders = db.Query<Order>(
                $@"SELECT 
                    Id, 
                    Status, 
                    CreatedDate, 
                    UpdatedDate, 
                    ProductId 
                    FROM Orders 
                    WHERE Status = {status}",
                commandType: CommandType.Text);

            db.Close();

            return orders;
        }

        public Order GetById(int id)
        {
            db.Open();

            Order order = db.Query<Order>(
                $@"SELECT 
                    Id, 
                    Status, 
                    CreatedDate, 
                    UpdatedDate, 
                    ProductId 
                    FROM Orders 
                    WHERE Id = {id}",
                commandType: CommandType.Text).FirstOrDefault();

            db.Close();

            return order;
        }

        public void Insert(Order obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            db.Open();

            db.Execute(
                $@"INSERT INTO Orders 
                (Id, 
                Status, 
                CreatedDate, 
                UpdatedDate, 
                ProductId) 
                VALUES 
                ({obj.Id}, 
                {obj.Status}, 
                {obj.CreatedDate}, 
                {obj.UpdatedDate}, 
                {obj.ProductId})",
                commandType: CommandType.Text);

            db.Close();
        }

        public void Update(Order obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            db.Open();

            db.Execute(
                $@"UPDATE Orders 
                SET
                Id = {obj.Id},
                Status = {obj.Status}, 
                CreatedDate = {obj.CreatedDate},  
                UpdatedDate = {obj.UpdatedDate}, 
                ProductId = {obj.ProductId})
                WHERE Id = {obj.Id}", 
                commandType: CommandType.Text);

            db.Close();
        }
    }
}
