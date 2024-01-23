using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbFirst.Models;

public partial class EmpContext : DbContext
{
    public EmpContext()
    {
    }

    public EmpContext(DbContextOptions<EmpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07353FE42E");

            entity.ToTable("Employee");

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.State).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
