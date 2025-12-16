using Ilary.Domain.Entities;

namespace Ilary.Application.Interfaces;

public interface IJobApplicationRepository
{
    Task<IEnumerable<JobApplication>> GetAllAsync();
    Task AddAsync(JobApplication jobApplication);
    Task<IEnumerable<JobApplication>> GetByJobIdAsync(Guid jobId);
    Task<IEnumerable<JobApplication>> GetByCoderIdAsync(Guid coderId);
}