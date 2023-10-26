using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CG.ProgDec.PL;

public partial class ProgDecEntities : DbContext
{
    public ProgDecEntities()
    {
    }

    public ProgDecEntities(DbContextOptions<ProgDecEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<tblDeclaration> tblDeclarations { get; set; }

    public virtual DbSet<tblDegreeType> tblDegreeTypes { get; set; }

    public virtual DbSet<tblProgram> tblPrograms { get; set; }

    public virtual DbSet<tblStudent> tblStudents { get; set; }

    public virtual DbSet<tblUser> tblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CG.ProgDec.DB;Integrated Security=True");
        optionsBuilder.UseSqlServer("Data Source=server-21296-300083002.database.windows.net;Initial Catalog=progdecdb;User ID=300083002db;Password=Test123!;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblDeclaration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblDecla__3214EC07AF646F9D");

            entity.ToTable("tblDeclaration");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ChangeDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<tblDegreeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblDegre__3214EC07112FFF58");

            entity.ToTable("tblDegreeType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblProgram>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblProgr__3214EC0716FAD970");

            entity.ToTable("tblProgram");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblStude__3214EC074C2CC296");

            entity.ToTable("tblStudent");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC075BF9DDF5");

            entity.ToTable("tblUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
