using Ilary.Application.DTOs;
using Ilary.Application.Services;
using Ilary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ilary.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class JobController : Controller
{
    private readonly JobService _jobService;
    private readonly CompanyService _companyService;

    public JobController(JobService jobService, CompanyService companyService)
    {
        _jobService = jobService;
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var jobs = await _jobService.GetAllJobsAsync();
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var job = await _jobService.GetJobByIdAsync(id);
        if (job == null) return NotFound();
        return Ok(job);
    }

    [HttpGet("company/{companyId}")]
    public async Task<IActionResult> GetByCompany(Guid companyId)
    {
        var jobs = await _jobService.GetJobsByCompanyAsync(companyId);
        return Ok(jobs);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateJobDto dto)
    {
        try
        {
            var company = await _companyService.GetCompanyByIdAsync(dto.CompanyId);
            if (company == null)
            {
                return BadRequest(new { message = $"La empresa con ID {dto.CompanyId} no existe." });
            }

            var job = new Job
            {
                Title = dto.Title,
                Description = dto.Description,
                Salary = dto.Salary,
                Location = dto.Location,
                CompanyId = dto.CompanyId
            };

            await _jobService.CreateJobAsync(job);
            return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.ToString() });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateJobDto dto)
    {
        var job = await _jobService.GetJobByIdAsync(id);
        if (job == null) return NotFound();

        job.Title = dto.Title;
        job.Description = dto.Description;
        job.Salary = dto.Salary;
        job.Location = dto.Location;
        // CompanyId usually shouldn't change, but if needed: job.CompanyId = dto.CompanyId;

        await _jobService.UpdateJobAsync(job);
        return Ok(job);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _jobService.DeleteJobAsync(id);
        return NoContent();
    }
}
