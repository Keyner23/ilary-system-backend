using Ilary.Domain.Entities;

namespace Ilary.Application.Interfaces;

public interface IJobApplicationRepository
{
    Task<IEnumerable<JobApplication>> GetAllAsync();
    Task AddAsync(JobApplication JobApplication);
}