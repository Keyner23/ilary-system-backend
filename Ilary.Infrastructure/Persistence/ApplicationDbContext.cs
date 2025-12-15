using Ilary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ilary.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
    
    public DbSet<Roles> Roles => Set<Roles>();
    public DbSet<Coder> Coder => Set<Coder>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<JobApplication> JobApplications => Set<JobApplication>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Coder>()
            .HasMany(c => c.JobApplication)
            .WithMany()
            .UsingEntity(j => j.ToTable("CoderRoles"));
    }
}