using Domain.Entities;
using Infrastructure.Interfaces;
using Npgsql;

namespace Infrastructure.Services;

public class SellersService : ISellersService
{
    private readonly string a =
        "Server=localhost;Port=5432;Database=ShopNet;UserName=postgres;Password=12345;";
    #region GetAllSellers
    public List<Sellers> GetAllSellers()
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = @"SELECT * FROM Sellers;";
        var command = new NpgsqlCommand(query, connection);
        var reader = command.ExecuteReader();
        var sellers = new List<Sellers>();
        while (reader.Read())
        {
            var seller = new Sellers
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                LastName = reader.GetString(reader.GetOrdinal("last_name")),
                Shop_Name = reader.GetString(reader.GetOrdinal("shop_name")),
                Email = reader.GetString(reader.GetOrdinal("email"))
            };
            sellers.Add(seller);
        }
        connection.Close();
        return sellers;
    }
    #endregion

    #region GetSellerById
    public Sellers GetSellerById(int id)
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = @"Select * FROM  Sellers;";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var seller = new Sellers()
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                LastName = reader.GetString(reader.GetOrdinal("last_name")),
                Shop_Name = reader.GetString(reader.GetOrdinal("shop_name")),
                Email = reader.GetString(reader.GetOrdinal("email"))
            };
            return seller;
        }
        connection.Close();
        return null;
    }
    #endregion
    
    #region CreateSeller
    public bool CreateSeller(Sellers seller)
    {
        var connection = new  NpgsqlConnection(a);
        connection.Open();
        const string query = @"INSERT INTO Sellers (Id, FirstName, LastName, Shop_Name, Email)
                                    VALUES (@id, @firstname, @lastname, @shopname, @email);";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", seller.Id);
        command.Parameters.AddWithValue("@firstname", seller.FirstName);
        command.Parameters.AddWithValue("@lastname", seller.LastName);
        command.Parameters.AddWithValue("@shopname", seller.Shop_Name);
        command.Parameters.AddWithValue("@email", seller.Email);
        var res = command.ExecuteNonQuery();
        connection.Close();
        return res > 0;
    }
    #endregion

    #region UpdateSeller
    public bool UpdateSeller(Sellers seller)
    {
         var connection = new NpgsqlConnection(a);
         connection.Open();
         const string query = 
            @"UPDATE Sellers SET FirstName = @firstname, LastName = @lastname, Shop_Name = @shopname, Email = @email  where Id = @id"; 
         var command = new NpgsqlCommand(query, connection);
         command.Parameters.AddWithValue("@id", seller.Id);
         command.Parameters.AddWithValue("@firstname", seller.FirstName);
         command.Parameters.AddWithValue("@lastname", seller.LastName);
         command.Parameters.AddWithValue("@shopname", seller.Shop_Name);
         command.Parameters.AddWithValue("@email", seller.Email);
         var res = command.ExecuteNonQuery();
         connection.Close();
         return res > 0;
    }
    #endregion

    #region DeleteSeller
    public bool DeleteSeller(Sellers seller)
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = @"DELETE FROM Sellers WHERE Id = @id";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", seller.Id);
        var res = command.ExecuteNonQuery();
        connection.Close();
        return res > 0;
    }
    #endregion
}