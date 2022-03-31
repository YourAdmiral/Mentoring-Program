using Dapper;
using ORMDapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMDapper.Services
{
    internal class ProductService : IService<Product>
    {
        private IDbConnection db = new SqlConnection(AppConnection.ConnectionString);

        public void Delete(int id)
        {
            db.Open();

            db.Execute(
                $@"DELETE FROM Products WHERE Id = {id}",
                commandType: CommandType.Text);

            db.Close();
        }

        public IEnumerable<Product> GetAll()
        {
            db.Open();

            var orders = db.Query<Product>(
                @"SELECT 
                    Id, 
                    Name, 
                    Description, 
                    Weight, 
                    Height,
                    Width,
                    Length
                    FROM Products",
                commandType: CommandType.Text);

            db.Close();

            return orders;
        }

        public Product GetById(int id)
        {
            db.Open();

            Product order = db.Query<Product>(
                $@"SELECT 
                    Id, 
                    Name, 
                    Description, 
                    Weight, 
                    Height,
                    Width,
                    Length
                    FROM Products 
                    WHERE Id = {id}",
                commandType: CommandType.Text).FirstOrDefault();

            db.Close();

            return order;
        }

        public void Insert(Product obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            db.Open();

            db.Execute(
                $@"INSERT INTO Products 
                (Id, 
                Name, 
                Description, 
                Weight, 
                Height,
                Width,
                Length) 
                VALUES 
                ({obj.Id}, 
                {obj.Name}, 
                {obj.Description}, 
                {obj.Weight}, 
                {obj.Height},
                {obj.Width},
                {obj.Length})",
                commandType: CommandType.Text);

            db.Close();
        }

        public void Update(Product obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            db.Open();

            db.Execute(
                $@"UPDATE Products 
                SET
                Id = {obj.Id},
                Name = {obj.Name}, 
                Description = {obj.Description},  
                Weight = {obj.Weight}, 
                Height = {obj.Height},
                Width = {obj.Width},
                Length = {obj.Length})
                WHERE Id = {obj.Id}",
                commandType: CommandType.Text);

            db.Close();
        }
    }
}
