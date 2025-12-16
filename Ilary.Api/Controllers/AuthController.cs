using Ilary.Application.DTOs;
using Ilary.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ilary.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : Controller
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            var response = await _authService.LoginAsync(dto);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost("register/coder")]
    public async Task<IActionResult> RegisterCoder([FromBody] RegisterCoderRequest request)
    {
        try
        {
            var dto = new CreateCoderDto
            {
                Name = request.Name,
                Document = request.Document,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Description = request.Description
            };
            
            await _authService.RegisterCoderAsync(dto, request.Password);
            return Ok(new { message = "Coder registrado exitosamente" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("register/company")]
    public async Task<IActionResult> RegisterCompany([FromBody] RegisterCompanyRequest request)
    {
        try
        {
            var dto = new CreateCompanyDto
            {
                Name = request.Name,
                NIT = request.NIT,
                Description = request.Description
            };

            await _authService.RegisterCompanyAsync(dto, request.Email, request.Password);
            return Ok(new { message = "Empresa registrada exitosamente" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

public class RegisterCoderRequest
{
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class RegisterCompanyRequest
{
    public string Name { get; set; } = string.Empty;
    public string NIT { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
