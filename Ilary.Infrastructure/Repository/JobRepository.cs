using Ilary.Application.Interfaces;
using Ilary.Domain.Entities;
using Ilary.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ilary.Infrastructure.Repository;

public class JobRepository : IJobRepository
{
    private readonly ApplicationDbContext _context;

    public JobRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Job>> GetAllAsync()
    {
        return await _context.Jobs
            .Include(j => j.Company)
            .OrderByDescending(j => j.Created)
            .ToListAsync();
    }

    public async Task<Job?> GetByIdAsync(Guid id)
    {
        return await _context.Jobs
            .Include(j => j.Company)
            .Include(j => j.Applications)
            .FirstOrDefaultAsync(j => j.Id == id);
    }

    public async Task<IEnumerable<Job>> GetByCompanyIdAsync(Guid companyId)
    {
        return await _context.Jobs
            .Where(j => j.CompanyId == companyId)
            .OrderByDescending(j => j.Created)
            .ToListAsync();
    }

    public async Task AddAsync(Job job)
    {
        await _context.Jobs.AddAsync(job);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Job job)
    {
        _context.Jobs.Update(job);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job != null)
        {
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
        }
    }
}
