using Microsoft.EntityFrameworkCore;
using OrganizationAssetManagement.Domain.Entities;

namespace OrganizationAssetManagement.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Asset> Assets { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }

    public DbSet<AssetAssignment> AssetAssignments { get; set; }

    public DbSet<AssetHistory> AssetHistories { get; set; }

    public DbSet<Document> Documents { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}