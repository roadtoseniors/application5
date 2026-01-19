using System;
using System.Collections.Generic;
using AvaloniaApplication5.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication5.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupVisit> GroupVisits { get; set; }

    public virtual DbSet<IndividualVisit> IndividualVisits { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffCode> StaffCodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=applicationfive;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("department_pk");

            entity.ToTable("department");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Department1).HasColumnName("department");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("division_pk");

            entity.ToTable("division");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Division1).HasColumnName("division");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("group_pk");

            entity.ToTable("group");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Group1).HasColumnName("group");
        });

        modelBuilder.Entity<GroupVisit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("group_visit_pk");

            entity.ToTable("group_visit");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DateOfBirthday).HasColumnName("date_of_birthday");
            entity.Property(e => e.DatePurpose).HasColumnName("date_purpose");
            entity.Property(e => e.EMail).HasColumnName("E-mail");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Passport).HasColumnName("passport");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupVisits)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("group_visit_group_id_fk");

            entity.HasOne(d => d.Staff).WithMany(p => p.GroupVisits)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("group_visit_staff_code_id_fk");
        });

        modelBuilder.Entity<IndividualVisit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("individual_visit_pk");

            entity.ToTable("individual_visit");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DateOfBirthday).HasColumnName("date_of_birthday");
            entity.Property(e => e.DatePurpose).HasColumnName("date_purpose");
            entity.Property(e => e.EMail).HasColumnName("E-mail");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Passport).HasColumnName("passport");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");

            entity.HasOne(d => d.Staff).WithMany(p => p.IndividualVisits)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("individual_visit_staff_code_id_fk");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("staff_pk");

            entity.ToTable("staff");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Department).HasColumnName("department");
            entity.Property(e => e.Division).HasColumnName("division");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");

            entity.HasOne(d => d.DepartmentNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Department)
                .HasConstraintName("staff_department_id_fk");

            entity.HasOne(d => d.DivisionNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Division)
                .HasConstraintName("staff_division_id_fk");
        });

        modelBuilder.Entity<StaffCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("staff_code_pk");

            entity.ToTable("staff_code");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
