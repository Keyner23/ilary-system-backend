namespace Ilary.Domain.Entities;

public class Roles
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public Roles() { }
    
    public Roles(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}