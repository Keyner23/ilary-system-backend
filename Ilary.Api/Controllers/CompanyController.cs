using Ilary.Application.DTOs;
using Ilary.Application.Services;
using Ilary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ilary.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CompanyController : Controller
{
    private readonly CompanyService _service;
    
    public CompanyController(CompanyService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCustomer()
    {
        var company = await _service.GetCompanyAsync();
        return Ok(company);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto dto)
    {
        await _service.AddCompanyAsync(dto);
        return Ok(new { message = "Compañia creada correctamente" });
    }
}