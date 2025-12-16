using Ilary.Application.DTOs.Auth;
using Ilary.Application.Interfaces;
using Ilary.Domain.Entities;

namespace Ilary.Application.Services;

public class AuthService
{
    private readonly ICoderRepository _coderRepository;
    private readonly ICompanyRepository _companyRepository;
    public AuthService(ICoderRepository coderRepository)
    {
        _coderRepository = coderRepository;
    }
    
    public async Task<Coder> LoginAsync(LoginCoderDto dto)
    {
        var coder = await _coderRepository
            .GetByEmailAndDocumentAsync(dto.Email, dto.Document);

        if (coder == null)
            throw new Exception("Credenciales inválidas");

        return coder;
    }
    
    public async Task<Company> LoginCompanyAsync(int nit)
    {
        var company = await _companyRepository.GetByNitAsync(nit);

        if (company == null)
            throw new Exception("Empresa no encontrada");

        return company;
    }




}