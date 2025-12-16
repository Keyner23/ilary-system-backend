using Ilary.Application.Interfaces;
using Ilary.Domain.Entities;

namespace Ilary.Application.Services;

public class JobService
{
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<IEnumerable<Job>> GetAllJobsAsync()
    {
        return await _jobRepository.GetAllAsync();
    }

    public async Task<Job?> GetJobByIdAsync(Guid id)
    {
        return await _jobRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Job>> GetJobsByCompanyAsync(Guid companyId)
    {
        return await _jobRepository.GetByCompanyIdAsync(companyId);
    }

    public async Task CreateJobAsync(Job job)
    {
        job.Id = Guid.NewGuid();
        job.Created = DateTime.UtcNow;
        job.Updated = DateTime.UtcNow;
        await _jobRepository.AddAsync(job);
    }

    public async Task UpdateJobAsync(Job job)
    {
        job.Updated = DateTime.UtcNow;
        await _jobRepository.UpdateAsync(job);
    }

    public async Task DeleteJobAsync(Guid id)
    {
        await _jobRepository.DeleteAsync(id);
    }
}
