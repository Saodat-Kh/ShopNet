using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SellersController(ISellersService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllSellers()
    {
        var res = service.GetAllSellers();
        return Ok(res);
    }

    [HttpGet("id")]
    public IActionResult GetSellerById(int id)
    {
        var res = service.GetSellerById(id);
        return Ok(res);
    }

    [HttpPost]
    public IActionResult CreateSeller(Sellers seller)
    {
        var res = service.CreateSeller(seller);
        return Ok(res);
    }

    [HttpPut]
    public IActionResult UpdateSeller(Sellers seller)
    {
        var res = service.UpdateSeller(seller);
        return Ok(res);
    }

    [HttpDelete]
    public IActionResult DeleteSeller(Sellers seller)
    {
        var res = service.DeleteSeller(seller);
        return Ok(res);
    }
}