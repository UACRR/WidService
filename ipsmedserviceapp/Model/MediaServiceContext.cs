using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ipsmedserviceapp.Model
{
    public partial class MediaServiceContext : DbContext
    {
        public virtual DbSet<ActivityType> ActivityType { get; set; }
        public virtual DbSet<ActivityTypeTr> ActivityTypeTr { get; set; }
        public virtual DbSet<AnketaStatus> AnketaStatus { get; set; }
        public virtual DbSet<AnketaStatusTr> AnketaStatusTr { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryTr> CategoryTr { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CountryTr> CountryTr { get; set; }
        public virtual DbSet<CustomerStatus> CustomerStatus { get; set; }
        public virtual DbSet<CustomerStatusTr> CustomerStatusTr { get; set; }
        public virtual DbSet<CustomerType> CustomerType { get; set; }
        public virtual DbSet<CustomerTypeTr> CustomerTypeTr { get; set; }
        public virtual DbSet<DicCategoryItems> DicCategoryItems { get; set; }
        public virtual DbSet<DictCategory> DictCategory { get; set; }
        public virtual DbSet<KlR030> KlR030 { get; set; }
        public virtual DbSet<KlR030tr> KlR030tr { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<RegionTr> RegionTr { get; set; }
        public virtual DbSet<ResidentType> ResidentType { get; set; }
        public virtual DbSet<ResidentTypeTr> ResidentTypeTr { get; set; }
        public virtual DbSet<SexType> SexType { get; set; }
        public virtual DbSet<SexTypeTr> SexTypeTr { get; set; }
        public virtual DbSet<TypeMethodGet> TypeMethodGet { get; set; }
        public virtual DbSet<TypeMethodGetTr> TypeMethodGetTr { get; set; }
        public virtual DbSet<TypePlace> TypePlace { get; set; }
        public virtual DbSet<TypePlaceTr> TypePlaceTr { get; set; }
        public virtual DbSet<TypeVat> TypeVat { get; set; }
        public virtual DbSet<TypeVattr> TypeVattr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=192.168.1.252,60675;Initial Catalog=MediaService;User ID=robot;Password=robot11235813");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "db_owner");

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.HasKey(e => e.ActivityCode);

                entity.ToTable("ActivityType", "dbo");

                entity.Property(e => e.ActivityCode)
                    .HasColumnName("activityCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityName)
                    .HasColumnName("activityName")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ActivityTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.ActivityCode, e.Lang });

                entity.ToTable("ActivityTypeTr", "dbo");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.ActivityName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActivityCodeNavigation)
                    .WithMany(p => p.ActivityTypeTr)
                    .HasForeignKey(d => d.ActivityCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACTIVITY_REFERENCE_ACTIVITY");
            });

            modelBuilder.Entity<AnketaStatus>(entity =>
            {
                entity.HasKey(e => e.AnkStatus);

                entity.ToTable("AnketaStatus", "dbo");

                entity.Property(e => e.AnkStatus)
                    .HasColumnName("ankStatus")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnkStatusName)
                    .HasColumnName("ankStatusName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AnketaStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.AnkStatus, e.Lang });

                entity.ToTable("AnketaStatusTr", "dbo");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.AnkStatusName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AnkStatusNavigation)
                    .WithMany(p => p.AnketaStatusTr)
                    .HasForeignKey(d => d.AnkStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETAST_REFERENCE_ANKETAST");
            });

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

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryCode);

                entity.ToTable("Country", "dbo");

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasColumnType("char(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.A2)
                    .HasColumnName("a2")
                    .HasColumnType("char(2)");

                entity.Property(e => e.ContinentCode).HasColumnName("continentCode");

                entity.Property(e => e.CountryName)
                    .HasColumnName("countryName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CountryNameShort)
                    .HasColumnName("countryNameShort")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KOdLit)
                    .HasColumnName("kOD_LIT")
                    .HasColumnType("char(3)");

                entity.Property(e => e.OrderBy).HasColumnName("orderBy");

                entity.Property(e => e.ShortChoise).HasColumnName("shortChoise");
            });

            modelBuilder.Entity<CountryTr>(entity =>
            {
                entity.HasKey(e => new { e.CountryCode, e.Lang })
                    .ForSqlServerIsClustered(false);

                entity.ToTable("CountryTr", "dbo");

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasColumnType("char(3)");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.CountryName)
                    .HasColumnName("countryName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CountryNameShort)
                    .HasColumnName("countryNameShort")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.CountryTr)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COUNTRYT_REFERENCE_COUNTRY");
            });

            modelBuilder.Entity<CustomerStatus>(entity =>
            {
                entity.HasKey(e => e.CustStatus);

                entity.ToTable("CustomerStatus", "dbo");

                entity.Property(e => e.CustStatus)
                    .HasColumnName("custStatus")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustStatusName)
                    .HasColumnName("custStatusName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.CustStatus, e.Lang });

                entity.ToTable("CustomerStatusTr", "dbo");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.CustStatusName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustStatusNavigation)
                    .WithMany(p => p.CustomerStatusTr)
                    .HasForeignKey(d => d.CustStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMER_REFERENCE_CUSTOMTr");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasKey(e => e.CustType);

                entity.ToTable("CustomerType", "dbo");

                entity.Property(e => e.CustType)
                    .HasColumnName("custType")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CustType, e.Lang });

                entity.ToTable("CustomerTypeTr", "dbo");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.CustTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustTypeNavigation)
                    .WithMany(p => p.CustomerTypeTr)
                    .HasForeignKey(d => d.CustType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMER_REFERENCE_CUSTTR");
            });

            modelBuilder.Entity<DicCategoryItems>(entity =>
            {
                entity.HasKey(e => e.DicName);

                entity.ToTable("DicCategoryItems", "dbo");

                entity.Property(e => e.DicName)
                    .HasColumnName("dicName")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeNavigation)
                    .WithMany(p => p.DicCategoryItems)
                    .HasForeignKey(d => d.Code)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DICCATEG_REFERENCE_DICTCATE");
            });

            modelBuilder.Entity<DictCategory>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("DictCategory", "dbo");

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KlR030>(entity =>
            {
                entity.HasKey(e => e.R030);

                entity.ToTable("KL_R030", "dbo");

                entity.Property(e => e.R030)
                    .HasColumnName("r030")
                    .HasColumnType("char(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.A3)
                    .HasColumnName("a3")
                    .HasColumnType("char(3)");

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasColumnType("char(3)");

                entity.Property(e => e.NAim)
                    .HasColumnName("nAIM")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NOmin).HasColumnName("nOMIN");

                entity.Property(e => e.PrWork).HasColumnName("pr_work");

                entity.Property(e => e.R030Name)
                    .HasColumnName("r030Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.R031).HasColumnName("r031");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.KlR030)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK_KL_R030_REFERENCE_COUNTRY");
            });

            modelBuilder.Entity<KlR030tr>(entity =>
            {
                entity.HasKey(e => new { e.R030, e.Lang });

                entity.ToTable("KL_R030Tr", "dbo");

                entity.Property(e => e.R030)
                    .HasColumnName("r030")
                    .HasColumnType("char(3)");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.R030Name)
                    .HasColumnName("r030Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.R030Navigation)
                    .WithMany(p => p.KlR030tr)
                    .HasForeignKey(d => d.R030)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_R030TR_REFERENCE_KL_R030");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionCode);

                entity.ToTable("Region", "dbo");

                entity.Property(e => e.RegionCode)
                    .HasColumnName("regionCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasColumnType("char(3)");

                entity.Property(e => e.RegionName)
                    .HasColumnName("regionName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK_REGION_REFERENCE_COUNTRY");
            });

            modelBuilder.Entity<RegionTr>(entity =>
            {
                entity.HasKey(e => new { e.RegionCode, e.Lang });

                entity.ToTable("RegionTr", "dbo");

                entity.Property(e => e.RegionCode).HasColumnName("regionCode");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.RegionName)
                    .HasColumnName("regionName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.RegionCodeNavigation)
                    .WithMany(p => p.RegionTr)
                    .HasForeignKey(d => d.RegionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGIONTR_REFERENCE_REGION");
            });

            modelBuilder.Entity<ResidentType>(entity =>
            {
                entity.HasKey(e => e.ResidentCode);

                entity.ToTable("ResidentType", "dbo");

                entity.Property(e => e.ResidentCode)
                    .HasColumnName("residentCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.ResidentName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResidentTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.ResidentCode, e.Lang });

                entity.ToTable("ResidentTypeTr", "dbo");

                entity.Property(e => e.ResidentCode).HasColumnName("residentCode");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.ResidentName)
                    .HasColumnName("residentName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ResidentCodeNavigation)
                    .WithMany(p => p.ResidentTypeTr)
                    .HasForeignKey(d => d.ResidentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESIDENT_REFERENCE_RESIDENT");
            });

            modelBuilder.Entity<SexType>(entity =>
            {
                entity.HasKey(e => e.SexCode);

                entity.ToTable("SexType", "dbo");

                entity.Property(e => e.SexCode)
                    .HasColumnName("sexCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.SexName)
                    .HasColumnName("sexName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SexTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.SexCode, e.Lang });

                entity.ToTable("SexTypeTr", "dbo");

                entity.Property(e => e.SexCode).HasColumnName("sexCode");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.SexName)
                    .HasColumnName("sexName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.SexCodeNavigation)
                    .WithMany(p => p.SexTypeTr)
                    .HasForeignKey(d => d.SexCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SEXTYPET_REFERENCE_SEXTYPE");
            });

            modelBuilder.Entity<TypeMethodGet>(entity =>
            {
                entity.HasKey(e => e.GetCode);

                entity.ToTable("TypeMethodGet", "dbo");

                entity.Property(e => e.GetCode)
                    .HasColumnName("getCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.GetName)
                    .HasColumnName("getName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeMethodGetTr>(entity =>
            {
                entity.HasKey(e => new { e.Lang, e.GetCode });

                entity.ToTable("TypeMethodGetTr", "dbo");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.GetCode).HasColumnName("getCode");

                entity.Property(e => e.GetName)
                    .HasColumnName("getName")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.GetCodeNavigation)
                    .WithMany(p => p.TypeMethodGetTr)
                    .HasForeignKey(d => d.GetCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEMETH_REFERENCE_TYPEMETH");
            });

            modelBuilder.Entity<TypePlace>(entity =>
            {
                entity.HasKey(e => e.PlCode);

                entity.ToTable("TypePlace", "dbo");

                entity.Property(e => e.PlCode)
                    .HasColumnName("plCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.PlName)
                    .HasColumnName("plName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypePlaceTr>(entity =>
            {
                entity.HasKey(e => new { e.PlCode, e.Lang });

                entity.ToTable("TypePlaceTr", "dbo");

                entity.Property(e => e.PlCode).HasColumnName("plCode");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.PlName)
                    .HasColumnName("plName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PlCodeNavigation)
                    .WithMany(p => p.TypePlaceTr)
                    .HasForeignKey(d => d.PlCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEPLAC_REFERENCE_TYPEPLAC");
            });

            modelBuilder.Entity<TypeVat>(entity =>
            {
                entity.HasKey(e => e.VType);

                entity.ToTable("TypeVAT", "dbo");

                entity.Property(e => e.VType)
                    .HasColumnName("vType")
                    .ValueGeneratedNever();

                entity.Property(e => e.VTypeName)
                    .HasColumnName("vTypeName")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeVattr>(entity =>
            {
                entity.HasKey(e => new { e.VType, e.Lang });

                entity.ToTable("TypeVATTr", "dbo");

                entity.Property(e => e.VType).HasColumnName("vType");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.VTypeName)
                    .HasColumnName("vTypeName")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.VTypeNavigation)
                    .WithMany(p => p.TypeVattr)
                    .HasForeignKey(d => d.VType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEVATT_REFERENCE_TYPEVAT");
            });
        }
    }
}
