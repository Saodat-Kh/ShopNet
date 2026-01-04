using Domain.Entities;
using Infrastructure.Interfaces;
using Npgsql;

namespace Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly string a =
        "Server=localhost;Port=5432;Database=ShopNet;UserName=postgres;Password=12345;";
    #region CreateCustomer
    public bool CreateCustomer(Customer customer)
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = "INSERT INTO Customers (id,firstname, lastname, email, phone) " +
                                   "VALUES (@id,@FirstName, @LastName, @Email, @Phone);";
        using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", customer.Id);
        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
        command.Parameters.AddWithValue("@LastName", customer.LastName);
        command.Parameters.AddWithValue("@Email", customer.Email);
        command.Parameters.AddWithValue("@Phone", customer.Phone);
        var res = command.ExecuteNonQuery();
        connection.Close();
        return res > 0;
    }
    #endregion
    
    #region UpdateCustomer
    public bool UpdateCustomer(Customer customer)
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query =
            @"UPDATE Customers set firstname = @FirstName, lastname = @LastName, email = @Email, phone = @Phone where id = @id";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", customer.Id);
        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
        command.Parameters.AddWithValue("@LastName", customer.LastName);
        command.Parameters.AddWithValue("@Email", customer.Email);
        command.Parameters.AddWithValue("@Phone", customer.Phone);
        var res = command.ExecuteNonQuery();
        connection.Close();
        return res > 0;
    }
    #endregion

    #region DeleteCustomer
    public bool DeleteCustomer(int customerId)
    {
      var connection = new NpgsqlConnection(a);
      connection.Open();
      const string query = @"DELETE FROM Customers WHERE id = @id";
      var command = new NpgsqlCommand(query, connection);
      command.Parameters.AddWithValue("@id", customerId);
      var res = command.ExecuteNonQuery();
      connection.Close();
      return res > 0;
    }
    #endregion

    #region GetCustomerById
    public Customer GetCustomerById(int customerId)
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = @"SELECT * FROM Customers WHERE id = @id";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", customerId);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var customer = new Customer()
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                LastName = reader.GetString(reader.GetOrdinal("lastname")),
                Email = reader.GetString(reader.GetOrdinal("email")),
                Phone = reader.GetString(reader.GetOrdinal("phone"))
            };
            return customer;
        }
        connection.Close();
        return null;
    }
    #endregion

    #region GetAllCustomers
    public List<Customer> GetAllCustomers()
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = @"SELECT * FROM Customers";
        var command = new NpgsqlCommand(query, connection);
        var reader = command.ExecuteReader();
        var customers = new List<Customer>();
        while (reader.Read())
        {
            var customer = new Customer
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                LastName = reader.GetString(reader.GetOrdinal("lastname")),
                Email = reader.GetString(reader.GetOrdinal("email")),
                Phone = reader.GetString(reader.GetOrdinal("phone"))
            };
            customers.Add(customer);
        }
        connection.Close();
        return customers;
    }
    #endregion
}