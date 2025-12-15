namespace Ilary.Domain.Entities;

public class JobApplication
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    
    public Guid CoderId { get; set; }
    public Coder Coder { get; set; }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
    
}