using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SQLI.Models;

public partial class JarvisContext : DbContext
{
    public JarvisContext()
    {
    }

    public JarvisContext(DbContextOptions<JarvisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Test> Tests { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Test>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Test");

            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
