using Ilary.Application.DTOs;
using Ilary.Application.Interfaces;
using Ilary.Domain.Entities;

namespace Ilary.Application.Services;

public class CompanyService
{
    private readonly ICompanyRepository _repository;
    
    public CompanyService(ICompanyRepository repository)
    {
        _repository = repository;
    }
    
    public Task<IEnumerable<Company>> GetCompanyAsync() => _repository.GetAllAsync();
    
    public async Task AddCompanyAsync(CreateCompanyDto dto)
    {
        var company = new Company
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            NIT= dto.NIT,
            Description = dto.Description,
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow
        };
        await _repository.AddAsync(company);
    }
    
    public async Task<Company> LoginCompanyAsync(int nit)
    {
        var company = await _repository.GetByNitAsync(nit);

        if (company == null)
            throw new Exception("Company no encontrada");

        return company;
    }
}