using Ilary.Application.Interfaces;
using Ilary.Domain.Entities;
using Ilary.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ilary.Infrastructure.Repository;

public class CompanyRepository:ICompanyRepository
{
    private readonly ApplicationDbContext _context;
    
    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Company>> GetAllAsync() =>
        await _context.Companies.Include(c => c.Roles).ToListAsync();

    
    public async Task AddAsync(Company Company)
    {
        foreach (var role in Company.Roles)
        {
            _context.Attach(role);
        }
        _context.Companies.Add(Company);
        await _context.SaveChangesAsync();
    }

    public async Task<Company?> GetByEmailAsync(string email) =>
        await _context.Companies.Include(c => c.Roles).FirstOrDefaultAsync(c => c.Email == email);

    public Task UpdateAsync(Company Company)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Company id)
    {
        throw new NotImplementedException();
    }
}