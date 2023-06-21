using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RMF.School.Entities;

namespace RMF.School.DAL.Models;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-1K29SKO8\\MSSQLSERVER2020;Database=SchoolDB;User Id=sa;Password=admin2020;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.NumeroControl).HasName("PK_Alumnos");

            entity.ToTable("Alumno");

            entity.HasIndex(e => e.ApellidoMaterno, "IDX_ApellidoMaterno");

            entity.HasIndex(e => e.ApellidoPaterno, "IDX_ApellidoPaterno");

            entity.HasIndex(e => e.Nombre, "IDX_Nombre");

            entity.Property(e => e.NumeroControl).ValueGeneratedNever();
            entity.Property(e => e.ApellidoMaterno).HasMaxLength(50);
            entity.Property(e => e.ApellidoPaterno).HasMaxLength(50);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
