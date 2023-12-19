using Microsoft.EntityFrameworkCore;
using TektonLabs.Core.Entities;
using TektonLabs.Infrastracture.Data.Configurations;

namespace TektonLabs.Infrastracture.Data;

public partial class TektonLabsContext : DbContext
{
    public TektonLabsContext()
    {
    }

    public TektonLabsContext(DbContextOptions<TektonLabsContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Product> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
