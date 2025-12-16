using Ilary.Domain.Entities;

namespace Ilary.Application.Interfaces;

public interface IRoleRepository
{
    Task<Roles?> GetByNameAsync(string name);
    Task AddAsync(Roles role);
}
