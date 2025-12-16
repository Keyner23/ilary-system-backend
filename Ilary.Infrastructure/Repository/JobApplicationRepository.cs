using Ilary.Application.Interfaces;
using Ilary.Domain.Entities;
using Ilary.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ilary.Infrastructure.Repository;

public class JobApplicationRepository:IJobApplicationRepository
{
    private readonly ApplicationDbContext _context;

    public JobApplicationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<JobApplication>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(JobApplication jobApplication)
    {
        await _context.JobApplications.AddAsync(jobApplication);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<JobApplication>> GetByJobIdAsync(Guid jobId)
    {
        return await _context.JobApplications
            .Include(ja => ja.Coder)
            .Include(ja => ja.Status)
            .Where(ja => ja.JobId == jobId)
            .ToListAsync();
    }

    public async Task<IEnumerable<JobApplication>> GetByCoderIdAsync(Guid coderId)
    {
        return await _context.JobApplications
            .Include(ja => ja.Job)
            .ThenInclude(j => j.Company)
            .Include(ja => ja.Status)
            .Where(ja => ja.CoderId == coderId)
            .ToListAsync();
    }
}