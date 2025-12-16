using Ilary.Domain.Entities;

namespace Ilary.Application.Interfaces;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllAsync();
    Task AddAsync(Company Company);
    Task<Company?> GetByEmailAsync(string email);
    Task<Company?> GetByIdAsync(Guid id);

    Task DeleteAsync(Company id);
}