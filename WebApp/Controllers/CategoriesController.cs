using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoriesService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllCategories()
    {
        var categories = service.GetAllCategories();
        return Ok(categories);
    }

    [HttpGet("id")]
    public IActionResult GetCategoryById(int id)
    {
        var res = service.GetCategoriesById(id);
        return Ok(res);
    }

    [HttpPost]
    public IActionResult CreateCategory(Categories categories)
    {
        var res = service.CreateCategories(categories);
        return Ok(res);
    }

    [HttpPut]
    public IActionResult UpdateCategory(Categories categories)
    {
        var res = service.UpdateCategories(categories);
        return Ok(res);
    }

    [HttpDelete]
    public IActionResult DeleteCategory(int id)
    {
        var res = service.DeleteCategories(id);
        return Ok(res);
    }
}