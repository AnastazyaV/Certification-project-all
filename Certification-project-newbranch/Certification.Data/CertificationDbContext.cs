
using Certification.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Certification.Data
{
    public partial class CertificationDbContext : IdentityDbContext <Certification.Core.Models.User>
    {
        public CertificationDbContext(DbContextOptions<CertificationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Certifications> CertificationsOld { get; set; }
        public virtual DbSet<Certifications2> Certifications { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Teaching> Teaching { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CertificationProject;Trusted_Connection=True;");
            }
        }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certifications2>(entity =>
            {
                entity.HasKey(e => e.IdCertif)
                    .HasName("PK__certific__11E22EF34B33367F");

                entity.ToTable("certifications");

                entity.Property(e => e.IdCertif).HasColumnName("id_certif");

                entity.Property(e => e.CMonth).HasColumnName("c_month");

                entity.Property(e => e.CYear).HasColumnName("c_year");

                entity.Property(e => e.IdSubject).HasColumnName("id_subject");

                entity.Property(e => e.NGroup)
                    .HasColumnName("n_group")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Certifications)
                    .HasForeignKey(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__certifica__id_su__6D0D32F4");

                entity.HasOne(d => d.NGroupNavigation)
                    .WithMany(p => p.Certifications)
                    .HasForeignKey(d => d.NGroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__certifica__n_gro__6C190EBB");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.NGroup)
                    .HasName("PK__groups__3CDC94C5118C9CAE");

                entity.ToTable("groups");

                entity.Property(e => e.NGroup)
                    .HasColumnName("n_group")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Course).HasColumnName("course");

                entity.Property(e => e.Field)
                    .HasColumnName("field")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.HasKey(e => new { e.LoginStudent, e.IdCertif })
                    .HasName("PK__results__160F6226553C9680");

                entity.ToTable("results");

                entity.Property(e => e.LoginStudent)
                    .HasColumnName("login_student")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdCertif).HasColumnName("id_certif");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.HasOne(d => d.IdCertifNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.IdCertif)
                    .HasConstraintName("FK__results__id_cert__70DDC3D8");

                entity.HasOne(d => d.LoginStudentNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.LoginStudent)
                    .HasConstraintName("FK__results__login_s__6FE99F9F");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.LoginStudent)
                    .HasName("PK__students__371140C964726F0B");

                entity.ToTable("students");

                entity.Property(e => e.LoginStudent)
                    .HasColumnName("login_student")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NGroup)
                    .HasColumnName("n_group")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.LoginStudentNavigation)
                    .WithOne(p => p.Students)
                    .HasForeignKey<Students>(d => d.LoginStudent)
                    .HasConstraintName("FK__students__login___628FA481");

                entity.HasOne(d => d.NGroupNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.NGroup)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__students__n_grou__6383C8BA");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.IdSubject)
                    .HasName("PK__subjects__8F848F603DC40219");

                entity.ToTable("subjects");

                entity.Property(e => e.IdSubject).HasColumnName("id_subject");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectType).HasColumnName("subject_type");
            });

            modelBuilder.Entity<Teaching>(entity =>
            {
                entity.HasKey(e => new { e.LoginLecturer, e.IdSubject, e.NGroup })
                    .HasName("PK__teaching__EA22D53C386701F9");

                entity.ToTable("teaching");

                entity.Property(e => e.LoginLecturer)
                    .HasColumnName("login_lecturer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdSubject).HasColumnName("id_subject");

                entity.Property(e => e.NGroup)
                    .HasColumnName("n_group")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Teaching)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("FK__teaching__id_sub__6754599E");

                entity.HasOne(d => d.LoginLecturerNavigation)
                    .WithMany(p => p.Teaching)
                    .HasForeignKey(d => d.LoginLecturer)
                    .HasConstraintName("FK__teaching__login___66603565");

                entity.HasOne(d => d.NGroupNavigation)
                    .WithMany(p => p.Teaching)
                    .HasForeignKey(d => d.NGroup)
                    .HasConstraintName("FK__teaching__n_grou__68487DD7");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("PK__users__7838F273456CA1B3");

                entity.ToTable("users");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Role).HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    */
    }
}