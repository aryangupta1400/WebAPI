using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model.DBModels;

public partial class OrganizationContext : DbContext
{
    public OrganizationContext()
    {
    }

    public OrganizationContext(DbContextOptions<OrganizationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BRD-3917L13-L\\SQLEXPRESS;Database=Organization;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Employee");

            entity.Property(e => e.CurrentProject).HasColumnName("Current Project");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee ID");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .HasColumnName("Employee Name");
            entity.Property(e => e.JoiningDate)
                .HasMaxLength(50)
                .HasColumnName("Joining Date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
