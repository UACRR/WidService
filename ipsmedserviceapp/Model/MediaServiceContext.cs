using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ipsmedserviceapp.Model
{
    public partial class MediaServiceContext : DbContext
    {
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryTr> CategoryTr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Data Source=192.168.1.252,60675;Initial Catalog=MediaService;User ID=robot;Password=robot11235813");
                optionsBuilder.UseSqlServer(@"Data Source=62.216.38.178,60674;Initial Catalog=MediaService;User ID=robot;Password=robot11235813");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "db_owner");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryCode);

                entity.ToTable("Category", "dbo");

                entity.Property(e => e.CategoryCode)
                    .HasColumnName("categoryCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .HasColumnName("categoryName")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryStatus).HasColumnName("categoryStatus");

                entity.Property(e => e.TableObj)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryTr>(entity =>
            {
                entity.HasKey(e => new { e.CategoryCode, e.Lang });

                entity.ToTable("CategoryTr", "dbo");

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("categoryName")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.CategoryTr)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATEGtr_REFERENCE_CATEGORY");
            });
        }
    }
}
