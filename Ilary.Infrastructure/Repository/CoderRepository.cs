using Ilary.Application.Interfaces;
using Ilary.Domain.Entities;
using Ilary.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ilary.Infrastructure.Repository;

public class CoderRepository :ICoderRepository
{
    private readonly ApplicationDbContext _context;
    
    public CoderRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<IEnumerable<Coder>> GetAllAsync() =>
        await _context.Coder.ToListAsync();

    
    public async Task AddAsync(Coder coder)
    {
        foreach (var role in coder.Roles)
        {
            _context.Attach(role); 
        }

        _context.Coder.Add(coder);
        await _context.SaveChangesAsync();
    }
    public async Task<Coder?> GetByEmailAndDocumentAsync(string email, string document)
    {
        return await _context.Coder
            .FirstOrDefaultAsync(c =>
                c.Email == email &&
                c.Document == document);
    }



    public Task UpdateAsync(Coder coder)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}