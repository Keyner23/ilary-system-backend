using Ilary.Application.Interfaces;
using Ilary.Domain.Entities;
using Ilary.Infrastructure.Persistence;

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
}