namespace Ilary.Domain.Entities;

public class Coder
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<Roles> Roles { get; set; } = new List<Roles>();
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    
    
}