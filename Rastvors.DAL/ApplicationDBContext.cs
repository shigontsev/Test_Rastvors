using Microsoft.EntityFrameworkCore;
using Rastvors.Common.Entities;

namespace Rastvors.DAL;

public partial class ApplicationDBContext : DbContext
{
    public ApplicationDBContext()
    {
    }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<Rastvor> Rastvors { get; set; }

    public virtual DbSet<Structure> Structures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.
                UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MudDBTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Component>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Rastvor>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Structure>(entity =>
        {
            entity.Property(e => e.ComponentId).HasColumnName("Component_Id");
            entity.Property(e => e.RastvorId).HasColumnName("Rastvor_Id");

            entity.HasOne(d => d.Component).WithMany(p => p.Structures)
                .HasForeignKey(d => d.ComponentId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Structures_Components");

            entity.HasOne(d => d.Rastvor).WithMany(p => p.Structures)
                .HasForeignKey(d => d.RastvorId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Structures_Rastvors");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
