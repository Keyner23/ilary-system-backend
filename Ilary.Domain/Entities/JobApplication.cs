namespace Ilary.Domain.Entities;

public class JobApplication
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    
    public Guid CoderId { get; set; }
    public Coder Coder { get; set; }

    public Guid JobId { get; set; }
    public Job Job { get; set; }

    public Guid StatusId { get; set; }
    public ApplicationStatus Status { get; set; }
    
}