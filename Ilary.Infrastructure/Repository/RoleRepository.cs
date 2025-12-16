using Ilary.Application.Interfaces;
using Ilary.Domain.Entities;
using Ilary.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ilary.Infrastructure.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Roles?> GetByNameAsync(string name)
    {
        return await _context.Roles.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
    }

    public async Task AddAsync(Roles role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
    }
}