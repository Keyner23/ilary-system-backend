using Ilary.Application.DTOs;
using Ilary.Application.Interfaces;
using Ilary.Domain.Entities;


namespace Ilary.Application.Services;

public class CoderService
{
    private readonly ICoderRepository _repository;
 
    
    public CoderService(ICoderRepository repository)
    {
        _repository = repository;
    }
    
    public Task<IEnumerable<Coder>> GetCustomersAsync() => _repository.GetAllAsync();
    
    public async Task AddCustomerAsync(CreateCoderDto dto)
    {
        var coder = new Coder
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Document = dto.Document,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow
        };

        // Rol por defecto (solo ID, ya existe en BD)
        coder.Roles.Add(new Roles
        {
            Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")
        });

        await _repository.AddAsync(coder);
    }


}