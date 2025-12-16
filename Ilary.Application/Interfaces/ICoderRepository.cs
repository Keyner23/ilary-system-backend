using Ilary.Domain.Entities;

namespace Ilary.Application.Interfaces;

public interface ICoderRepository
{
    Task<IEnumerable<Coder>> GetAllAsync();
    Task AddAsync(Coder coder);
    Task UpdateAsync(Coder coder);
    Task<Coder?> GetByEmailAsync(string email);
    Task DeleteAsync(Guid id);
}