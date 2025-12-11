using Ilary.Application.Services;
using Ilary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ilary.Api.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class CoderController : Controller
{
    private readonly CoderService _service;
    
    public CoderController(CoderService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCustomer()
    {
        var customer = await _service.GetCustomersAsync();
        return Ok(customer);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] Coder coder)
    {
        await _service.AddCustomerAsync(coder);
        return Ok(new { message = "Cliente creado correctamente" });
    }
}