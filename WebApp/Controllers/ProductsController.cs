using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductsService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var res = service.GetAllProducts();
        return Ok(res);
    }

    [HttpGet("id")]
    public IActionResult GetProductById(int id)
    {
        var res = service.GetProductById(id);
        return Ok(res);
    }

    [HttpPost]
    public IActionResult CreateProduct(Products products)
    {
        var res = service.CreateProduct(products);
        return Ok(res);
    }

    [HttpPut]
    public IActionResult UpdateProduct(Products products)
    {
        var res = service.UpdateProduct(products);
        return Ok(res);
    }

    [HttpDelete]
    public IActionResult DeleteProduct(int id)
    {
        var res = service.DeleteProduct(id);
        return Ok(res);
    }
    
}