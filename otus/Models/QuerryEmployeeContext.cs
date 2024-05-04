using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace otus.Models;

public partial class QuerryEmployeeContext : DbContext
{
    public QuerryEmployeeContext()
    {
    }

    public QuerryEmployeeContext(DbContextOptions<QuerryEmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<ProjectDetail> ProjectDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DBKTTOV\\SQLEXPRESS;Integrated Security=True;Database=QuerryEmployee;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF177F0149E");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.JoiningDate).HasColumnType("date");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ProjectDetail>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__ProjectD__761ABED0363D6817");

            entity.Property(e => e.ProjectId)
                .ValueGeneratedNever()
                .HasColumnName("ProjectID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ProjectName).HasMaxLength(100);

            entity.HasOne(d => d.Employee).WithMany(p => p.ProjectDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__ProjectDe__Emplo__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
