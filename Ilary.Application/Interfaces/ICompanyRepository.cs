using Ilary.Domain.Entities;

namespace Ilary.Application.Interfaces;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllAsync();
    Task AddAsync(Company Company);
    Task UpdateAsync(Company Company);
    Task DeleteAsync(Company id);
    Task<Company?> GetByNitAsync(int nit);
}