namespace Ilary.Application.DTOs;

public class CreateCompanyDto
{
    public string Name { get; set; } = string.Empty;
    public int NIT { get; set; } 
    public string Description { get; set; } = string.Empty;
}