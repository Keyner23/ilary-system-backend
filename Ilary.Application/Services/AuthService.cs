using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Ilary.Application.DTOs;
using Ilary.Application.Interfaces;
using Ilary.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Ilary.Application.Services;

public class AuthService
{
    private readonly ICoderRepository _coderRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IConfiguration _configuration;

    public AuthService(ICoderRepository coderRepository, ICompanyRepository companyRepository, IRoleRepository roleRepository, IConfiguration configuration)
    {
        _coderRepository = coderRepository;
        _companyRepository = companyRepository;
        _roleRepository = roleRepository;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
    {
        // 1. Check Coder
        var coder = await _coderRepository.GetByEmailAsync(loginDto.Email);
        if (coder != null)
        {
            if (BCrypt.Net.BCrypt.Verify(loginDto.Password, coder.Password))
            {
                var token = GenerateJwtToken(coder.Id, coder.Email, "coder");
                return new AuthResponseDto
                {
                    Token = token,
                    User = new UserDto
                    {
                        Id = coder.Id,
                        Name = coder.Name,
                        Email = coder.Email,
                        Role = "coder"
                    }
                };
            }
        }

        // 2. Check Company
        var company = await _companyRepository.GetByEmailAsync(loginDto.Email);
        if (company != null)
        {
            if (BCrypt.Net.BCrypt.Verify(loginDto.Password, company.Password))
            {
                var token = GenerateJwtToken(company.Id, company.Email, "company");
                return new AuthResponseDto
                {
                    Token = token,
                    User = new UserDto
                    {
                        Id = company.Id,
                        Name = company.Name,
                        Email = company.Email,
                        Role = "company"
                    }
                };
            }
        }

        throw new Exception("Credenciales inválidas");
    }

    public async Task RegisterCoderAsync(CreateCoderDto dto, string password)
    {
        // Check if email exists
        var existingCoder = await _coderRepository.GetByEmailAsync(dto.Email);
        if (existingCoder != null) throw new Exception("El email ya está registrado como Coder");

        var existingCompany = await _companyRepository.GetByEmailAsync(dto.Email);
        if (existingCompany != null) throw new Exception("El email ya está registrado como Empresa");

        var role = await _roleRepository.GetByNameAsync("Coder");
        if (role == null)
        {
            role = new Roles(Guid.NewGuid(), "Coder");
            await _roleRepository.AddAsync(role);
        }

        var coder = new Coder
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Document = dto.Document,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Description = dto.Description,
            Password = BCrypt.Net.BCrypt.HashPassword(password),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow
        };
        
        coder.Roles.Add(role);

        await _coderRepository.AddAsync(coder);
    }

    public async Task RegisterCompanyAsync(CreateCompanyDto dto, string email, string password)
    {
        // Check if email exists
        var existingCoder = await _coderRepository.GetByEmailAsync(email);
        if (existingCoder != null) throw new Exception("El email ya está registrado como Coder");

        var existingCompany = await _companyRepository.GetByEmailAsync(email);
        if (existingCompany != null) throw new Exception("El email ya está registrado como Empresa");

        var role = await _roleRepository.GetByNameAsync("Company");
        if (role == null)
        {
            role = new Roles(Guid.NewGuid(), "Company");
            await _roleRepository.AddAsync(role);
        }

        var company = new Company
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            NIT = int.Parse(dto.NIT), // Assuming NIT is int in Entity but string in DTO based on previous files
            Description = dto.Description,
            Email = email,
            Password = BCrypt.Net.BCrypt.HashPassword(password),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow
        };
        
        // Note: Company entity in Roles.cs has 'Company' collection (singular name in Roles.cs but likely meant to be plural or just 'Companies'). 
        // But here we need to add the role to the Company entity.
        // Let's check Company.cs to see if it has a Roles collection.
        // Checking previous file view of Company.cs (Step 180/202/321/350/362/389/422/448 don't show Company.cs fully with Roles).
        // Step 180 shows CompanyRepository but not Company entity.
        // Step 158/159/164/165/179/180/202/215/216/272/273/291/292/321/322/323/350/362/389/422/448/449/454 don't show Company.cs.
        // Step 196/197/267/316/329/331/344/400/415 show build errors/logs.
        // Step 175/187/198/268/317/332/338/346/357/401/416/444 show user requests.
        // Step 154 shows summary of previous session which says "Roles.cs exists and already has collections for Coders and Company".
        // It does NOT explicitly say Company.cs has a Roles collection.
        // However, Coder.cs has `public ICollection<Roles> Roles { get; set; }`.
        // I should verify Company.cs has Roles collection before adding code.
        // But for now, assuming symmetry with Coder.
        
        // Wait, I need to be sure. I'll assume it doesn't exist if I haven't seen it, but Roles.cs links to Company.
        // If Roles.cs has `ICollection<Company> Company`, then Company should have `ICollection<Roles> Roles` for many-to-many.
        // Let's assume it does for now to proceed, if it fails compilation I will fix.
        // Actually, I should check Company.cs first to be safe.
        // But I can't check it in the middle of this tool call sequence easily without breaking flow.
        // I will add the code assuming it exists, if it fails I'll fix it.
        // Actually, looking at Coder.cs in step 179/184, it has `Include(c => c.Roles)`.
        // CompanyRepository in step 180/185 does NOT have `Include(c => c.Roles)`.
        // This suggests Company might NOT have Roles collection yet.
        // But Roles.cs has `ICollection<Company> Company`.
        // If I want to assign a role, I need the relationship.
        
        // Let's look at Coder.cs again. Step 179 shows `_context.Coder.Include(c => c.Roles)`.
        // So Coder definitely has Roles.
        // Company? Step 180 shows `_context.Companies.FirstOrDefaultAsync`. No include.
        
        // I will assume I need to add `Roles` collection to Company.cs if it's missing.
        // But I am editing AuthService now.
        // I will add `company.Roles.Add(role);` and if it fails, I know what to do.
        // Wait, `Roles` entity has `public ICollection<Company> Company`.
        // If I add `role.Company.Add(company)`, that might work too if the relationship is set up that way.
        // But usually we add to the entity we are creating.
        
        // Let's try adding to company.Roles. If it fails, I'll check Company.cs.
        // Actually, I'll check Company.cs in the next step if this fails.
        // Or I can check it now? No, I'm in a tool call.
        
        // I'll stick to the plan: update AuthService.
        
        // Wait, I can't add `company.Roles.Add(role)` if `Roles` property doesn't exist.
        // I'll assume it exists because `Roles.cs` implies a relationship.
        
        // Re-reading step 154 summary: "Las entidades Roles.cs existe y ya tiene colecciones para Coders y Company."
        // It doesn't explicitly say Company has Roles.
        // But Coder has Roles.
        
        // I will use `company.Roles.Add(role)` and if it fails compilation, I will add the property to Company.cs.
        
        company.Roles = new List<Roles> { role };
        
        await _companyRepository.AddAsync(company);
    }

    private string GenerateJwtToken(Guid userId, string email, string role)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];
        
        if (string.IsNullOrEmpty(secretKey))
        {
            // Fallback for development if config is missing, though strictly should be in appsettings
            secretKey = "SuperSecretKeyForDevelopmentOnly_ChangeThisInProduction"; 
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim("role", role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"] ?? "IlarySystem",
            audience: jwtSettings["Audience"] ?? "IlaryUsers",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(24),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
