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
    public class OrderService : IService<Order>
    {
        private string _connectionString = AppConnection.ConnectionString;

        public IEnumerable<Order> GetAllByMonth(int month)
        {
            var orders = GetAll();

            return orders.Where(order => order.CreatedDate.Month == month);
        }

        public IEnumerable<Order> GetAllByYear(int year)
        {
            var orders = GetAll();

            return orders.Where(order => order.CreatedDate.Year == year);
        }

        public IEnumerable<Order> GetAllByStatus(OrderStatus status)
        {
            var orders = GetAll();

            return orders.Where(order => order.Status == status);
        }

        public void Delete(int id)
        {
            string query =
                @"DELETE FROM Orders WHERE Id = @Id";

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
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = new List<Order>();

            string query =
                    @"SELECT 
                    Id, 
                    Status, 
                    CreatedDate, 
                    UpdatedDate, 
                    ProductId
                    FROM Orders";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var order = new Order();

                        Enum.TryParse(reader.GetInt32(1).ToString(), out OrderStatus status);
                        order.Id = reader.GetInt32(0);
                        order.Status = status;
                        order.CreatedDate = reader.GetDateTime(2);
                        order.UpdatedDate = reader.GetDateTime(3);
                        order.ProductId = reader.GetInt32(4);

                        orders.Add(order);
                    }

                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
            }

            return orders;
        }

        public Order GetById(int id)
        {
            string query =
                    @"SELECT 
                    Id, 
                    Status, 
                    CreatedDate, 
                    UpdatedDate, 
                    ProductId
                    FROM Orders
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
                    var order = new Order();
                    Enum.TryParse(reader.GetInt32(1).ToString(), out OrderStatus status);
                    order.Id = reader.GetInt32(0);
                    order.Status = status;
                    order.CreatedDate = reader.GetDateTime(2);
                    order.UpdatedDate = reader.GetDateTime(3);
                    order.ProductId = reader.GetInt32(4);

                    reader.Close();
                    connection.Close();

                    return order;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }

        public void Insert(Order obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            string query =
                @"INSERT INTO Orders 
                (Status, 
                CreatedDate, 
                UpdatedDate, 
                ProductId) 
                VALUES 
                (@Status, 
                @CreatedDate, 
                @UpdatedDate, 
                @ProductId);
                SELECT          @ID = SCOPE_IDENTITY()";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Status", obj.Status);
                command.Parameters.AddWithValue("@CreatedDate", obj.CreatedDate);
                command.Parameters.AddWithValue("@UpdatedDate", obj.UpdatedDate);
                command.Parameters.AddWithValue("@ProductId", obj.ProductId);
                command.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }

        public void Update(Order obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            string query =
                @"UPDATE Orders SET
                Status = @Status, 
                CreatedDate = @CreatedDate, 
                UpdatedDate = @UpdatedDate, 
                ProductId = @ProductId
                WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Status", obj.Status);
                command.Parameters.AddWithValue("@CreatedDate", obj.CreatedDate);
                command.Parameters.AddWithValue("@UpdatedDate", obj.UpdatedDate);
                command.Parameters.AddWithValue("@ProductId", obj.ProductId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }
    }
}
