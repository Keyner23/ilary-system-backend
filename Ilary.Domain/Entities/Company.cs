namespace Ilary.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int NIT { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public ICollection<Roles> Role { get; set; } = new List<Roles>();
}