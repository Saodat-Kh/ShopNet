using Domain.Entities;
using Infrastructure.Interfaces;
using Npgsql;

namespace Infrastructure.Services;

public class CategoriesService : ICategoriesService
{
    private readonly string a =
        "Server=localhost;Port=5432;Database=ShopNet;UserName=postgres;Password=12345;";
    #region GetAllCategories
    public List<Categories> GetAllCategories()
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = @"SELECT * FROM categories;";
        var command = new NpgsqlCommand(query, connection);
        var reader = command.ExecuteReader();
        var categories = new List<Categories>();
        while (reader.Read())
        {
            var category = new Categories
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Description = reader.GetString(reader.GetOrdinal("description"))
            };
            categories.Add(category);
        }
        connection.Close();
        return categories;
    }
    #endregion

    #region GetCategoriesById
    public Categories GetCategoriesById(int id)
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = @"SELECT * FROM categories WHERE id = @id";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var category = new Categories
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Description = reader.GetString(reader.GetOrdinal("description"))
            };
            return category;
        }
        connection.Close();
        return null;
    }
    #endregion

    #region CreateCategories
    public bool CreateCategories(Categories categories)
    {
        var connection = new  NpgsqlConnection(a);
        connection.Open();
        const string query = @"INSERT INTO categories (id, name, description) 
                                    VALUES (@id ,@name, @description);";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", categories.Id);
        command.Parameters.AddWithValue("@name", categories.Name);
        command.Parameters.AddWithValue("@description", categories.Description);
        var res = command.ExecuteNonQuery();
        connection.Close();
        return res > 0;
    }
    #endregion

    #region UpdateCategories
    public bool UpdateCategories(Categories categories)
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = 
            "UPDATE categories SET name=@name, description=@description WHERE id=@id";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", categories.Id);
        command.Parameters.AddWithValue("@name", categories.Name);
        command.Parameters.AddWithValue("@description", categories.Description);
        var res = command.ExecuteNonQuery();
        connection.Close();
        return res > 0;
    }
    #endregion

    #region DeleteCategories
    public bool DeleteCategories(int id)
    {
         var connection = new NpgsqlConnection(a);
         connection.Open();
         const string query = @"DELETE FROM Categories WHERE id= @id";
         var command = new NpgsqlCommand(query, connection);
         command.Parameters.AddWithValue("@id", id);
         var res = command.ExecuteNonQuery();
         connection.Close();
         return res > 0;
    }
    #endregion
}