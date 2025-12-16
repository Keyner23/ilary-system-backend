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
    private readonly AuthService _authService;

    public CompanyController(CompanyService service,
        AuthService authService)
    {
        _service = service;
        _authService = authService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomer()
    {
        var company = await _service.GetCompanyAsync();
        return Ok(company);
    }

    [HttpPost("login/company")]
    public async Task<IActionResult> LoginCompany([FromQuery] int nit)
    {
        var result = await _authService.LoginCompanyAsync(nit);
        return Ok(result);
    }

}