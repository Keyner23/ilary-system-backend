namespace Ilary.Domain.Entities;

public class ApplicationStatus
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty; // Para UI: primary, success, warning, danger, etc.
    public int Order { get; set; } // Para ordenar los estados
    public DateTime Created { get; set; } = DateTime.UtcNow;
}
