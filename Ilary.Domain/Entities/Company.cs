namespace Ilary.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int NIT { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
    public ICollection<Roles> Roles { get; set; } = new List<Roles>();
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    
    
}