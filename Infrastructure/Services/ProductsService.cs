using Domain.Entities;
using Infrastructure.Interfaces;
using Npgsql;

namespace Infrastructure.Services;

public class ProductsService : IProductsService
{
    private readonly string a =
        "Server=localhost;Port=5432;Database=ShopNet;UserName=postgres;Password=12345;";
    #region GetAllProducts
    public List<Products> GetAllProducts()
     {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = @"SELECT * FROM Products;";
        var command = new NpgsqlCommand(query, connection);
        var reader = command.ExecuteReader();
        var products = new List<Products>();
        while (reader.Read())
        {
            var product = new Products 
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Price = reader.GetInt32(reader.GetOrdinal("price")),
                Quantity  = reader.GetInt32(reader.GetOrdinal("quantity")),
                Category_id = reader.GetInt32(reader.GetOrdinal("category_id")),
                Seller_id = reader.GetInt32(reader.GetOrdinal("seller_id"))
            };
            products.Add(product);
        }
        connection.Close();
        return products;
     }
     #endregion

     #region GetProductById
    public Products GetProductById(int id)
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = @"SELECT * FROM Products WHERE id = @id;";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var product = new Products()
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Price = reader.GetInt32(reader.GetOrdinal("price")),
                Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                Category_id = reader.GetInt32(reader.GetOrdinal("category_id")),
                Seller_id = reader.GetInt32(reader.GetOrdinal("seller_id"))
            };
            return product;
        }
        connection.Close();
        return null;
    }
    #endregion

    #region CreateProduct
    public bool CreateProduct(Products products)
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = @"INSERT INTO Products (Id, Name, Price, Quantity, Category_id, Seller_id)
                                    VALUES (@id, @name, @price, @quantity, @category_id, @seller_id)";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", products.Id);
        command.Parameters.AddWithValue("@name", products.Name);
        command.Parameters.AddWithValue("@price", products.Price);
        command.Parameters.AddWithValue("@quantity", products.Quantity);
        command.Parameters.AddWithValue("@category_id", products.Category_id);
        command.Parameters.AddWithValue("@seller_id", products.Seller_id);
        var res = command.ExecuteNonQuery();
        connection.Close();
        return res > 0;
    }
    #endregion

    #region UpdateProduct
    public bool UpdateProduct(Products products)
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query =
            @"UPDATE Products SET Name = @name, Price = @price, Quantity = @quantity, Category_id = @category_id WHERE Id = @id;";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", products.Id);
        command.Parameters.AddWithValue("@name", products.Name);
        command.Parameters.AddWithValue("@price", products.Price);
        command.Parameters.AddWithValue("@quantity", products.Quantity);
        command.Parameters.AddWithValue("@category_id", products.Category_id);
        command.Parameters.AddWithValue("@seller_id", products.Seller_id);
        var res = command.ExecuteNonQuery();
        connection.Close();
        return res > 0;
    }
    #endregion

    #region DeleteProduct
    public bool DeleteProduct(int id)
    {
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = @"DELETE FROM Products WHERE Id = @id;";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        var res = command.ExecuteNonQuery();
        connection.Close();
        return res > 0;
    }
    #endregion

    #region SearchProducts
    public List<Products> SearchProducts(string name)
    { 
        var connection = new NpgsqlConnection(a);
        connection.Open();
        const string query = 
            @"SELECT * FROM Products WHERE name LIKE '%' || @name || '%';";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@name", name);
        var res = command.ExecuteReader();
        List<Products> products = new List<Products>();
        while (res.Read())
        {
            var product = new Products()
            {
                Id = res.GetInt32(res.GetOrdinal("id")),
                Name = res.GetString(res.GetOrdinal("name")),
                Price = res.GetInt32(res.GetOrdinal("price")),
                Quantity = res.GetInt32(res.GetOrdinal("quantity")),
                Category_id = res.GetInt32(res.GetOrdinal("category_id")),
                Seller_id = res.GetInt32(res.GetOrdinal("seller_id"))
            };
            products.Add(product);
        }
        res.Close();
        return products;
    }
    #endregion

    #region GetProductByCategoryId
    public Products GetProductByCategoryId(int categoryId)
    {
        var connection  = new NpgsqlConnection(a);
        connection.Open();
        const string query = @"SELECT * FROM Products WHERE Category_id = @category_id;";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@category_id", categoryId);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var product = new Products()
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Price = reader.GetInt32(reader.GetOrdinal("price")),
                Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                Category_id = reader.GetInt32(reader.GetOrdinal("category_id")),
                Seller_id = reader.GetInt32(reader.GetOrdinal("seller_id"))
            };
            return product;
        }
        connection.Close();
        return null;
    }
    #endregion

    #region GetProductBySellerId
    public Products GetProductBySellerId(int sellerId)
    {
        var connection = new  NpgsqlConnection(a);
        connection.Open();
        const string query = @"SELECT * FROM Products WHERE seller_id = @seller_id;";
        var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@seller_id", sellerId);
        var reader =  command.ExecuteReader();
        if (reader.Read())
        {
            var product = new Products()
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Price = reader.GetInt32(reader.GetOrdinal("price")),
                Category_id = reader.GetInt32(reader.GetOrdinal("category_id")),
                Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                Seller_id = reader.GetInt32(reader.GetOrdinal("seller_id"))
            };
            return product;
        }
        connection.Close();
        return null;
    }
    #endregion
}

