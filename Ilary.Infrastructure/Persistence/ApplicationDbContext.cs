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
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<JobApplication> JobApplications => Set<JobApplication>();
    public DbSet<ApplicationStatus> ApplicationStatuses => Set<ApplicationStatus>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Coder>()
            .HasMany(c => c.Roles)
            .WithMany(r => r.Coders)
            .UsingEntity(j => j.ToTable("CoderRoles"));

        modelBuilder.Entity<Company>()
            .HasMany(c => c.Roles)
            .WithMany(r => r.Company)
            .UsingEntity(j => j.ToTable("CompanyRoles"));

        modelBuilder.Entity<Company>()
            .HasMany(c => c.Jobs)
            .WithOne(j => j.Company)
            .HasForeignKey(j => j.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<JobApplication>()
            .HasOne(j => j.Coder)
            .WithMany() // Un Coder puede tener muchas Aplicaciones de Trabajo
            .HasForeignKey(j => j.CoderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<JobApplication>()
            .HasOne(j => j.Job)
            .WithMany(j => j.Applications)
            .HasForeignKey(j => j.JobId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<JobApplication>()
            .HasOne(j => j.Status)
            .WithMany()
            .HasForeignKey(j => j.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed initial statuses
        var statuses = new[]
        {
            new ApplicationStatus { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Enviada", Description = "Postulación enviada", Color = "info", Order = 1, Created = DateTime.UtcNow },
            new ApplicationStatus { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "En Revisión", Description = "La empresa está revisando tu perfil", Color = "warning", Order = 2, Created = DateTime.UtcNow },
            new ApplicationStatus { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Entrevista", Description = "Programado para entrevista", Color = "primary", Order = 3, Created = DateTime.UtcNow },
            new ApplicationStatus { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Aceptada", Description = "¡Felicitaciones! Fuiste seleccionado", Color = "success", Order = 4, Created = DateTime.UtcNow },
            new ApplicationStatus { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Rechazada", Description = "No fuiste seleccionado en esta ocasión", Color = "danger", Order = 5, Created = DateTime.UtcNow }
        };

        modelBuilder.Entity<ApplicationStatus>().HasData(statuses);
    }
    
    

}