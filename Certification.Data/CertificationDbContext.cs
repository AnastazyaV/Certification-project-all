using System;
using Certification.Core;
using Certification.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Certification.Data
{
    public partial class CertificationDbContext : IdentityDbContext<User>
    {
        public CertificationDbContext(DbContextOptions<CertificationDbContext> options)
            : base(options)
        {
        }

       // public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
       // public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
       // public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
       // public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
       // public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
       // public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
       // public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Certifications> Certifications { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Teaching> Teaching { get; set; }
        public virtual DbSet<Users> Users { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Certifications>(entity =>
            {
                entity.HasKey(e => e.IdCertif)
                    .HasName("PK__certific__11E22EF3EA3805AB");

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
                    .HasConstraintName("FK__certifica__id_su__719CDDE7");

                entity.HasOne(d => d.NGroupNavigation)
                    .WithMany(p => p.Certifications)
                    .HasForeignKey(d => d.NGroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__certifica__n_gro__70A8B9AE");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.NGroup)
                    .HasName("PK__groups__3CDC94C511FCD865");

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
                    .HasName("PK__results__160F6226FF08450C");

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
                    .HasConstraintName("FK__results__id_cert__756D6ECB");

                entity.HasOne(d => d.LoginStudentNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.LoginStudent)
                    .HasConstraintName("FK__results__login_s__74794A92");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.LoginStudent)
                    .HasName("PK__students__371140C97E1851FA");

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
                    .HasConstraintName("FK__students__login___681373AD");

                entity.HasOne(d => d.NGroupNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.NGroup)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__students__n_grou__690797E6");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.IdSubject)
                    .HasName("PK__subjects__8F848F600019D150");

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
                    .HasName("PK__teaching__EA22D53C37E50782");

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
                    .HasConstraintName("FK__teaching__id_sub__6CD828CA");

                entity.HasOne(d => d.LoginLecturerNavigation)
                    .WithMany(p => p.Teaching)
                    .HasForeignKey(d => d.LoginLecturer)
                    .HasConstraintName("FK__teaching__login___6BE40491");

                entity.HasOne(d => d.NGroupNavigation)
                    .WithMany(p => p.Teaching)
                    .HasForeignKey(d => d.NGroup)
                    .HasConstraintName("FK__teaching__n_grou__6DCC4D03");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("PK__users__7838F2731AE2F9EF");

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

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
