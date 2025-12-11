namespace Ilary.Domain.Entities;

public class JobApplication
{
    public int Id { get; set; }
    public ICollection<Company> Company { get; set; } = new List<Company>();
    public ICollection<Coder> Coder { get; set; } = new List<Coder>();
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    
}