namespace Ilary.Application.DTOs;

public class CreateJobDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public string Location { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
}
