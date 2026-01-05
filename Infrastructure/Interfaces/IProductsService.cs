using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IProductsService
{
    List<Products> GetAllProducts();
    Products GetProductById(int id);
    bool CreateProduct(Products products);
    bool UpdateProduct(Products products);
    bool DeleteProduct(int id);
}