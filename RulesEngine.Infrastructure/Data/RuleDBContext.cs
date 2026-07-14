//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RuleEngine.Infrastructure.Data
//{
//    internal class RuleDBContext
//    {
//    }
//}
using Microsoft.EntityFrameworkCore;
using RuleEngine.Domain.Entities;

namespace RuleEngine.Infrastructure.Data;

public class RuleDbContext : DbContext
{
    public RuleDbContext(DbContextOptions<RuleDbContext> options) : base(options) { }

    public DbSet<Workflow> Workflows => Set<Workflow>();
    public DbSet<RuleEntity> Rules => Set<RuleEntity>();

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Workflow>().HasMany(w => w.Rules).WithOne().HasForeignKey(r => r.WorkflowId);
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RuleEntity>(entity =>
        {
            entity.HasKey(r => r.Id);

            // Explicitly define the relationship
            entity.HasOne<Workflow>()
                  .WithMany(w => w.Rules)
                  .HasForeignKey(r => r.WorkflowId)
                  .OnDelete(DeleteBehavior.Cascade); // Deleting a workflow deletes its rules
        });

        modelBuilder.Entity<Workflow>(entity =>
        {
            entity.HasKey(w => w.Id);
            entity.Property(w => w.Id).ValueGeneratedOnAdd();
        });
    }
}
