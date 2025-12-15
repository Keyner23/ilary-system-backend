using Ilary.Application.DTOs;
using Ilary.Application.Interfaces;
using Ilary.Domain.Entities;

namespace Ilary.Application.Services;

public class JobApplicationService
{
    private readonly IJobApplicationRepository _repository;

    public JobApplicationService(IJobApplicationRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateJobApplicationAsync(CreateJobApplicationDto dto)
    {
        var jobApplication = new JobApplication
        {
            CoderId = dto.CoderId,
            CompanyId = dto.CompanyId,
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow
        };

        await _repository.AddAsync(jobApplication);
    }
}