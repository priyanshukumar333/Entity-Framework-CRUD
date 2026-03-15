using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrame.Models;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07C345B0A6");

            entity.ToTable("Student");

            entity.Property(e => e.StuBook).HasMaxLength(100);
            entity.Property(e => e.StuDob).HasMaxLength(20);
            entity.Property(e => e.StuGender).HasMaxLength(20);
            entity.Property(e => e.StuName).HasMaxLength(100);
            entity.Property(e => e.StuPhone).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
