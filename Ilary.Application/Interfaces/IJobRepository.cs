using Ilary.Domain.Entities;

namespace Ilary.Application.Interfaces;

public interface IJobRepository
{
    Task<IEnumerable<Job>> GetAllAsync();
    Task<Job?> GetByIdAsync(Guid id);
    Task<IEnumerable<Job>> GetByCompanyIdAsync(Guid companyId);
    Task AddAsync(Job job);
    Task UpdateAsync(Job job);
    Task DeleteAsync(Guid id);
}
