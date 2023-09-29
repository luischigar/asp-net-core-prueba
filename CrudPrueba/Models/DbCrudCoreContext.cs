using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudPrueba.Models;

public partial class DbCrudCoreContext : DbContext
{
    public DbCrudCoreContext()
    {
    }

    public DbCrudCoreContext(DbContextOptions<DbCrudCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=(local)\\DESKTOP-SO3VJHO,1433;Initial Catalog=DB_CRUD_CORE;Persist Security Info=False;User ID=sa;Password=luis456chi;Encrypt=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo);

            entity.ToTable("CARGO");

            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado);

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.Correo).HasMaxLength(60);
            entity.Property(e => e.NombreCompleto).HasMaxLength(60);
            entity.Property(e => e.Telefono).HasMaxLength(60);

            entity.HasOne(d => d.objCargo).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EMPLEADO_CARGO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
