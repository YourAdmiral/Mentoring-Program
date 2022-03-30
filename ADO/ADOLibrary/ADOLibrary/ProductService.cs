using ADOLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOLibrary
{
    public class ProductService : IService<Product>
    {
        private string _connectionString = AppConnection.ConnectionString;

        public void Delete(int id)
        {
            string query =
                @"DELETE FROM Products WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void DeleteByName(string name)
        {
            string query =
                @"DELETE FROM Products WHERE Name = @name";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();

            string query =
                    @"SELECT 
                    Id, 
                    Name, 
                    Description, 
                    Weight, 
                    Height,
                    Width,
                    Length
                    FROM Products";

            using(var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var product = new Product();

                        product.Id = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.Description = reader.GetString(2);
                        product.Weight = reader.GetInt32(3);
                        product.Height = reader.GetInt32(4);
                        product.Width = reader.GetInt32(5);
                        product.Length = reader.GetInt32(6);

                        products.Add(product);
                    }

                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return products;
        }

        public Product GetById(int id)
        {
            string query =
                    @"SELECT 
                    Id, 
                    Name, 
                    Description, 
                    Weight, 
                    Height,
                    Width,
                    Length
                    FROM Products
                    WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    var product = new Product();
                    product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.Description = reader.GetString(2);
                    product.Weight = reader.GetInt32(3);
                    product.Height = reader.GetInt32(4);
                    product.Width = reader.GetInt32(5);
                    product.Length = reader.GetInt32(6);

                    reader.Close();
                    connection.Close();

                    return product;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }

        public void Insert(Product obj)
        {
            string query =
                @"INSERT INTO Products 
                (Name, 
                Description, 
                Weight, 
                Height,
                Width,
                Length) 
                VALUES 
                (@Name, 
                @Description, 
                @Weight, 
                @Height,
                @Width,
                @Length);
SELECT          @ID = SCOPE_IDENTITY()";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", obj.Name);
                command.Parameters.AddWithValue("@Description", obj.Description);
                command.Parameters.AddWithValue("@Weight", obj.Weight);
                command.Parameters.AddWithValue("@Height", obj.Height);
                command.Parameters.AddWithValue("@Width", obj.Width);
                command.Parameters.AddWithValue("@Length", obj.Length);
                command.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void Update(Product obj)
        {
            string query =
                @"UPDATE Products SET
                Name = @Name, 
                Description = @Description, 
                Weight = @Weight, 
                Height = @Height,
                Width = @Width,
                Length = @Length 
                WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", obj.Id);
                command.Parameters.AddWithValue("@Name", obj.Name);
                command.Parameters.AddWithValue("@Description", obj.Description);
                command.Parameters.AddWithValue("@Weight", obj.Weight);
                command.Parameters.AddWithValue("@Height", obj.Height);
                command.Parameters.AddWithValue("@Width", obj.Width);
                command.Parameters.AddWithValue("@Length", obj.Length);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
