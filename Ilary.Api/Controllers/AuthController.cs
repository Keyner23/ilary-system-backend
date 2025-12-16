using Ilary.Application.DTOs.Auth;
using Ilary.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ilary.Api.Controllers;

public class AuthController : Controller
{
    private readonly AuthService _authService;
    
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCoderDto dto)
    {
        try
        {
            var coder = await _authService.LoginAsync(dto);

            return Ok(new
            {
                coder.Id,
                coder.Name,
                coder.Email
            });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
    
    [HttpPost("login/company")]
    public async Task<IActionResult> LoginCompany([FromQuery] int nit)
    {
        var company = await _authService.LoginCompanyAsync(nit);

        return Ok(new
        {
            company.Id,
            company.Name,
            company.NIT
        });
    }



}