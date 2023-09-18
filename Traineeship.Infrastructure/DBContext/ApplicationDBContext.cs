using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Traineeship.Domain.Models;

namespace Traineeship.Infrastructure.DBContext
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Courseassignement> Courseassignements { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<Instructor> Instructors { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Traineeship;Username=postgres;Password=Febraury14;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>(entity =>
            {
                entity.HasKey(e => e.Serial)
                    .HasName("clubs_pkey");

                entity.ToTable("clubs");

                entity.Property(e => e.Serial)
                    .HasMaxLength(450)
                    .HasColumnName("serial");

                entity.Property(e => e.Entitle)
                    .HasMaxLength(450)
                    .HasColumnName("entitle");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(e => e.Courseid)
                    .ValueGeneratedNever()
                    .HasColumnName("courseid");

                entity.Property(e => e.Credits).HasColumnName("credits");

                entity.Property(e => e.Facultyid).HasColumnName("facultyid");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Facultyid)
                    .HasConstraintName("facultyid");
            });

            modelBuilder.Entity<Courseassignement>(entity =>
            {
                entity.HasKey(e => new { e.Instructorid, e.Courseid })
                    .HasName("courseassignements_pkey");

                entity.ToTable("courseassignements");

                entity.Property(e => e.Instructorid).HasColumnName("instructorid");

                entity.Property(e => e.Courseid).HasColumnName("courseid");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.Id })
                    .HasName("enrollments_pkey");

                entity.ToTable("enrollments");

                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Marks).HasColumnName("marks");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(e => e.Facultiesid)
                    .HasName("faculties_pkey");

                entity.ToTable("faculties");

                entity.Property(e => e.Facultiesid).HasColumnName("facultiesid");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Supervisorid).HasColumnName("supervisorid");

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.Supervisorid)
                    .HasConstraintName("supervisorid");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.ToTable("instructors");

                entity.Property(e => e.Instructorid).HasColumnName("instructorid");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.Property(e => e.Clubid)
                    .HasMaxLength(100)
                    .HasColumnName("clubid");

                entity.Property(e => e.Enrollmentdate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("enrollmentdate");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Clubid)
                    .HasConstraintName("students_clubid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
