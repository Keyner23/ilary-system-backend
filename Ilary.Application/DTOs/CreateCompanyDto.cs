namespace Ilary.Application.DTOs;

public class CreateCompanyDto
{
    public string Name { get; set; } = string.Empty;
    public string NIT { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}