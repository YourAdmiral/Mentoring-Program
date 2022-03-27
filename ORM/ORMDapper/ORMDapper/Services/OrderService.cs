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
            OpenConnection();

            db.Execute(
                $@"DELETE FROM Orders WHERE Id = {id}",
                commandType: CommandType.Text);
        }

        public IEnumerable<Order> GetAll()
        {
            OpenConnection();

            return db.Query<Order>(
                @"SELECT 
                    Id, 
                    Status, 
                    CreatedDate, 
                    UpdatedDate, 
                    ProductId 
                    FROM Orders",
                commandType: CommandType.Text);
        }

        public IEnumerable<Order> GetAllByStatus(OrderStatus status)
        {
            OpenConnection();

            return db.Query<Order>(
                $@"SELECT 
                    Id, 
                    Status, 
                    CreatedDate, 
                    UpdatedDate, 
                    ProductId 
                    FROM Orders 
                    WHERE Status = {status}",
                commandType: CommandType.Text);
        }

        public Order GetById(int id)
        {
            OpenConnection();

            return db.Query<Order>(
                $@"SELECT 
                    Id, 
                    Status, 
                    CreatedDate, 
                    UpdatedDate, 
                    ProductId 
                    FROM Orders 
                    WHERE Id = {id}",
                commandType: CommandType.Text).FirstOrDefault();
        }

        public void Insert(Order obj)
        {
            OpenConnection();

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
        }

        public void Update(Order obj)
        {
            OpenConnection();

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
        }

        private void OpenConnection()
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
        }
    }
}
