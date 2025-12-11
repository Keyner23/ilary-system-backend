namespace Ilary.Domain.Entities;

public class Roles
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Coder> Coder { get; set; } = new List<Coder>();
    public ICollection<Company> Company { get; set; } = new List<Company>();
    
    public Roles() { }
    
    public Roles(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}