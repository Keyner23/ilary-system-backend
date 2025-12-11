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
    
    public async Task AddCustomerAsync(Coder coder)
    {
        
        // var existingEmail = await _repository.GetByEmailAsync(customer.Email);
        // if (existingEmail != null)
        //     throw new Exception("El email ya está registrado.");
        //
        //
        // var existingDocument = await _repository.GetByDocumentAsync(customer.Document);
        // if (existingDocument != null)
        //     throw new Exception("El documento ya está registrado.");
        
        await _repository.AddAsync(coder);
    }
}