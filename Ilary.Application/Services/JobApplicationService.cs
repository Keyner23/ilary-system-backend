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
            JobId = dto.JobId,
            StatusId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // "Enviada" status
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow
        };

        await _repository.AddAsync(jobApplication);
    }

    public async Task<IEnumerable<JobApplication>> GetJobApplicationsByJobIdAsync(Guid jobId)
    {
        return await _repository.GetByJobIdAsync(jobId);
    }

    public async Task<IEnumerable<JobApplication>> GetJobApplicationsByCoderIdAsync(Guid coderId)
    {
        return await _repository.GetByCoderIdAsync(coderId);
    }
}