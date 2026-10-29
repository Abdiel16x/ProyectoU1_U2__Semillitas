using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Semillitas_Api.Models.Entities;

namespace Semillitas_Api.Models.Data;

public partial class SemillitasdbContext : DbContext
{
    public SemillitasdbContext()
    {
    }

    public SemillitasdbContext(DbContextOptions<SemillitasdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumnos> Alumnos { get; set; }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Cuentas> Cuentas { get; set; }

    public virtual DbSet<HorariosTaller> HorariosTaller { get; set; }

    public virtual DbSet<Inscripciones> Inscripciones { get; set; }

    public virtual DbSet<Instructores> Instructores { get; set; }

    public virtual DbSet<Periodos> Periodos { get; set; }

    public virtual DbSet<Talleres> Talleres { get; set; }

    public virtual DbSet<Tutores> Tutores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySql("server=localhost;database=semillitasdb;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.46-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alumnos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("alumnos");

            entity.HasIndex(e => e.IdTutor, "IdTutor");

            entity.Property(e => e.Nombre).HasMaxLength(45);

            entity.HasOne(d => d.IdTutorNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdTutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alumnos_ibfk_1");
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categorias");

            entity.HasIndex(e => e.Nombre, "Nombre").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(45);
        });

        modelBuilder.Entity<Cuentas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cuentas");

            entity.HasIndex(e => new { e.IdAlumno, e.IdPeriodo }, "IdAlumno").IsUnique();

            entity.HasIndex(e => e.IdPeriodo, "IdPeriodo");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.Cuentas)
                .HasForeignKey(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cuentas_ibfk_1");

            entity.HasOne(d => d.IdPeriodoNavigation).WithMany(p => p.Cuentas)
                .HasForeignKey(d => d.IdPeriodo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cuentas_ibfk_2");
        });

        modelBuilder.Entity<HorariosTaller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("horarios_taller");

            entity.HasIndex(e => new { e.IdTaller, e.DiaSemana, e.HoraInicio }, "IdTaller").IsUnique();

            entity.Property(e => e.HoraFin).HasColumnType("time");
            entity.Property(e => e.HoraInicio).HasColumnType("time");

            entity.HasOne(d => d.IdTallerNavigation).WithMany(p => p.HorariosTaller)
                .HasForeignKey(d => d.IdTaller)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("horarios_taller_ibfk_1");
        });

        modelBuilder.Entity<Inscripciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inscripciones");

            entity.HasIndex(e => new { e.IdCuenta, e.IdTaller }, "IdCuenta").IsUnique();

            entity.HasIndex(e => e.IdTaller, "IdTaller");

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inscripciones_ibfk_1");

            entity.HasOne(d => d.IdTallerNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.IdTaller)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inscripciones_ibfk_2");
        });

        modelBuilder.Entity<Instructores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("instructores");

            entity.Property(e => e.Nombre).HasMaxLength(45);
        });

        modelBuilder.Entity<Periodos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("periodos");

            entity.HasIndex(e => e.Nombre, "Nombre").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(45);
        });

        modelBuilder.Entity<Talleres>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("talleres");

            entity.HasIndex(e => e.IdCategoria, "IdCategoria");

            entity.HasIndex(e => e.IdInstructor, "IdInstructor");

            entity.Property(e => e.CostoMensual).HasPrecision(10, 2);
            entity.Property(e => e.Nombre).HasMaxLength(45);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Talleres)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("talleres_ibfk_2");

            entity.HasOne(d => d.IdInstructorNavigation).WithMany(p => p.Talleres)
                .HasForeignKey(d => d.IdInstructor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("talleres_ibfk_1");
        });

        modelBuilder.Entity<Tutores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tutores");

            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Telefono).HasMaxLength(18);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
