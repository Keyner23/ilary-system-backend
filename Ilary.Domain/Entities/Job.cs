using System;
using System.Collections.Generic;

namespace Ilary.Domain.Entities;

public class Job
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;

    public Guid CompanyId { get; set; }
    public Company Company { get; set; }

    public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
}
