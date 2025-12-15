using Ilary.Application.DTOs;
using Ilary.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ilary.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class JobApplicationController : Controller
{
    private readonly JobApplicationService _service;
    
    public JobApplicationController(JobApplicationService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateJobApplication([FromBody] CreateJobApplicationDto dto)
    {
        await _service.CreateJobApplicationAsync(dto);
        return Ok(new { message = "Job application creada correctamente" });
    }

}