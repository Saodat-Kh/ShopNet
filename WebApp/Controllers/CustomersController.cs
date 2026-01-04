using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public  class CustomersController(ICustomerService service) : ControllerBase
{
    
    [HttpPost]
    public  IActionResult CreateCustomer(Customer customer)
    {
        var res = service.CreateCustomer(customer);
        return Ok(res);
    }

    [HttpPut]
    public IActionResult UpdateCustomer(Customer customer)
    {
        var res = service.UpdateCustomer(customer);
        return Ok(res);
    }

    [HttpDelete]
    public IActionResult DeleteCustomer(int customerId)
    {
        var res = service.DeleteCustomer(customerId);
        return Ok(res);
    }

    [HttpGet("customers{id}")]
    public IActionResult GetCustomerById(int id)
    {
        var res = service.GetCustomerById(id);
        return Ok(res);
    }
    
    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        var res = service.GetAllCustomers();
        return Ok(res);
    }
    
}