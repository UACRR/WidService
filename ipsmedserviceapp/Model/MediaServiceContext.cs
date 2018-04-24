using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ipsmedserviceapp.Model
{
    public partial class MediaServiceContext : DbContext
    {
        public virtual DbSet<ActivityType> ActivityType { get; set; }
        public virtual DbSet<ActivityTypeTr> ActivityTypeTr { get; set; }
        public virtual DbSet<AgreementStatus> AgreementStatus { get; set; }
        public virtual DbSet<AgreementStatusTr> AgreementStatusTr { get; set; }
        public virtual DbSet<AgrLicenseType> AgrLicenseType { get; set; }
        public virtual DbSet<AgrLicenseTypeTr> AgrLicenseTypeTr { get; set; }
        public virtual DbSet<AnketaStatus> AnketaStatus { get; set; }
        public virtual DbSet<AnketaStatusTr> AnketaStatusTr { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryStatusType> CategoryStatusType { get; set; }
        public virtual DbSet<CategoryStatusTypeTr> CategoryStatusTypeTr { get; set; }
        public virtual DbSet<CategoryTr> CategoryTr { get; set; }
        public virtual DbSet<Continent> Continent { get; set; }
        public virtual DbSet<ContinentTr> ContinentTr { get; set; }
        public virtual DbSet<CopyrightKind> CopyrightKind { get; set; }
        public virtual DbSet<CopyrightKindTr> CopyrightKindTr { get; set; }
        public virtual DbSet<CopyrightType> CopyrightType { get; set; }
        public virtual DbSet<CopyrightTypeTr> CopyrightTypeTr { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CountryTr> CountryTr { get; set; }
        public virtual DbSet<CreativeRoleType> CreativeRoleType { get; set; }
        public virtual DbSet<CreativeRoleTypeTr> CreativeRoleTypeTr { get; set; }
        public virtual DbSet<CrkindGroup> CrkindGroup { get; set; }
        public virtual DbSet<CrkindGroupTr> CrkindGroupTr { get; set; }
        public virtual DbSet<CustomerStatus> CustomerStatus { get; set; }
        public virtual DbSet<CustomerStatusTr> CustomerStatusTr { get; set; }
        public virtual DbSet<CustomerType> CustomerType { get; set; }
        public virtual DbSet<CustomerTypeTr> CustomerTypeTr { get; set; }
        public virtual DbSet<DicCategoryItems> DicCategoryItems { get; set; }
        public virtual DbSet<DictCategory> DictCategory { get; set; }
        public virtual DbSet<DocumentKind> DocumentKind { get; set; }
        public virtual DbSet<DocumentKindTr> DocumentKindTr { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<GenreTr> GenreTr { get; set; }
        public virtual DbSet<KlR030> KlR030 { get; set; }
        public virtual DbSet<KlR030tr> KlR030tr { get; set; }
        public virtual DbSet<LegalBasis> LegalBasis { get; set; }
        public virtual DbSet<LegalBasisTr> LegalBasisTr { get; set; }
        public virtual DbSet<LicenseType> LicenseType { get; set; }
        public virtual DbSet<LicenseTypeTr> LicenseTypeTr { get; set; }
        public virtual DbSet<ObjectStatus> ObjectStatus { get; set; }
        public virtual DbSet<ObjectStatusTr> ObjectStatusTr { get; set; }
        public virtual DbSet<ObjectType> ObjectType { get; set; }
        public virtual DbSet<ObjectTypeTr> ObjectTypeTr { get; set; }
        public virtual DbSet<PaymentKind> PaymentKind { get; set; }
        public virtual DbSet<PaymentKindTr> PaymentKindTr { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }
        public virtual DbSet<PaymentStatusTr> PaymentStatusTr { get; set; }
        public virtual DbSet<PayMethodType> PayMethodType { get; set; }
        public virtual DbSet<PayMethodTypeTr> PayMethodTypeTr { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<PeriodTr> PeriodTr { get; set; }
        public virtual DbSet<PositionType> PositionType { get; set; }
        public virtual DbSet<PositionTypeTr> PositionTypeTr { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<RegionTr> RegionTr { get; set; }
        public virtual DbSet<RegisterStatus> RegisterStatus { get; set; }
        public virtual DbSet<RegisterStatusTr> RegisterStatusTr { get; set; }
        public virtual DbSet<ResidentType> ResidentType { get; set; }
        public virtual DbSet<ResidentTypeTr> ResidentTypeTr { get; set; }
        public virtual DbSet<SexType> SexType { get; set; }
        public virtual DbSet<SexTypeTr> SexTypeTr { get; set; }
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
                entity.HasKey(e => e.CodeI);

                entity.ToTable("ActivityType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ActivityTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("ActivityTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.ActivityTypeTr)
                    .HasForeignKey(d => d.CodeI)
                    .HasConstraintName("FK_ACTIVITY_REFERENCE_ACTIVITY");
            });

            modelBuilder.Entity<AgreementStatus>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("AgreementStatus", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AgreementStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("AgreementStatusTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.AgreementStatusTr)
                    .HasForeignKey(d => d.CodeI)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_AGREEMTR");
            });

            modelBuilder.Entity<AgrLicenseType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("AgrLicenseType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.KindCode).HasColumnName("kindCode");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.KindCodeNavigation)
                    .WithMany(p => p.AgrLicenseType)
                    .HasForeignKey(d => d.KindCode)
                    .HasConstraintName("FK_AGRLICEN_REFERENCE_COPYRIGH");
            });

            modelBuilder.Entity<AgrLicenseTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("AgrLicenseTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.AgrLicenseTypeTr)
                    .HasForeignKey(d => d.CodeI)
                    .HasConstraintName("FK_ARGLICEN_REFERENCE_ARGLICEN");
            });

            modelBuilder.Entity<AnketaStatus>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("AnketaStatus", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AnketaStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("AnketaStatusTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.AnketaStatusTr)
                    .HasForeignKey(d => d.CodeI)
                    .HasConstraintName("FK_ANKETAST_REFERENCE_ANKETAST");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("Category", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TableObj)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_CATEGORY_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<CategoryStatusType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("CategoryStatusType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryStatusTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("CategoryStatusTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.CategoryStatusTypeTr)
                    .HasForeignKey(d => d.CodeI)
                    .HasConstraintName("FK_CATEGORY_REFERENCE_CATSTTR");
            });

            modelBuilder.Entity<CategoryTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("CategoryTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.CategoryTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATEGORY_REF_CATEGORYTR");
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("Continent", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContinentTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("ContinentTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.ContinentTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONTINEN_REFERENCE_CONTINEN");
            });

            modelBuilder.Entity<CopyrightKind>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("CopyrightKind", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.CrGroupCode).HasColumnName("crGroupCode");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.HasOne(d => d.CrGroupCodeNavigation)
                    .WithMany(p => p.CopyrightKind)
                    .HasForeignKey(d => d.CrGroupCode)
                    .HasConstraintName("FK_COPYRIGH_REFERENCE_CRKINDGR");
            });

            modelBuilder.Entity<CopyrightKindTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("CopyrightKindTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.CopyrightKindTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COPYRIGH_REFERENCE_COPYR");
            });

            modelBuilder.Entity<CopyrightType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("CopyrightType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CopyrightTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("CopyrightTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.CopyrightTypeTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COPYRIGH_REFERENCE_COPYRIGH");
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

                entity.HasOne(d => d.ContinentCodeNavigation)
                    .WithMany(p => p.Country)
                    .HasForeignKey(d => d.ContinentCode)
                    .HasConstraintName("FK_COUNTRY_REFERENCE_CONTINEN");
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

            modelBuilder.Entity<CreativeRoleType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("CreativeRoleType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Crtype).HasColumnName("CRType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.CreativeRoleType)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREATIVE_REFERENCE_CATEGORY");

                entity.HasOne(d => d.CrtypeNavigation)
                    .WithMany(p => p.CreativeRoleType)
                    .HasForeignKey(d => d.Crtype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREATIVE_REFERENCE_COPYRIGH");
            });

            modelBuilder.Entity<CreativeRoleTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("CreativeRoleTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.CreativeRoleTypeTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREATIVE_REFERENCE_CREATIVE");
            });

            modelBuilder.Entity<CrkindGroup>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("CRKindGroup", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CrkindGroupTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("CRKindGroupTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.CrkindGroupTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRKINDGR_REFERENCE_CRKINDGR");
            });

            modelBuilder.Entity<CustomerStatus>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("CustomerStatus", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("CustomerStatusTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.CustomerStatusTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMER_REFERENCE_CUSTOMTr");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("CustomerType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("CustomerTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.CustomerTypeTr)
                    .HasForeignKey(d => d.CodeI)
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

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.DicLevel).HasColumnName("dicLevel");

                entity.Property(e => e.DicType)
                    .HasColumnName("dicType")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
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

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DocumentKind>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("DocumentKind", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.DocMaker)
                    .HasColumnName("docMaker")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.DocumentKind)
                    .HasForeignKey(d => d.CategoryCode)
                    .HasConstraintName("FK_DOCUMENT_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<DocumentKindTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("DocumentKindTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.DocumentKindTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCUMENT_REFERENCE_DOCUM");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.Genre)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GENRE_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<GenreTr>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Lang });

                entity.ToTable("GenreTr", "dbo");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.GenreTr)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GENRETR_REFERENCE_GENRE");
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

            modelBuilder.Entity<LegalBasis>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("LegalBasis", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LegalBasisTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("LegalBasisTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.LegalBasisTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LEGALBAS_REFERENCE_LEGALBAS");
            });

            modelBuilder.Entity<LicenseType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("LicenseType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LicenseTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("LicenseTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.LicenseTypeTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICENSET_REFERENCE_LICENSET");
            });

            modelBuilder.Entity<ObjectStatus>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("ObjectStatus", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ObjectStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("ObjectStatusTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.ObjectStatusTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBJECTST_REFERENCE_OBJECTST");
            });

            modelBuilder.Entity<ObjectType>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.CategoryCode });

                entity.ToTable("ObjectType", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.ObjectType)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBJECTTY_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<ObjectTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.CategoryCode, e.Lang });

                entity.ToTable("ObjectTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.ObjectTypeTr)
                    .HasForeignKey(d => new { d.CodeI, d.CategoryCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBJECTTY_REFERENCE_OBJECTTY");
            });

            modelBuilder.Entity<PaymentKind>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("PaymentKind", "dbo");

                entity.HasIndex(e => e.CodeI)
                    .HasName("AK_KEY_1_PAYMENTK")
                    .IsUnique();

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentKindTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("PaymentKindTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.PaymentKindTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMENTK_REFERENCE_PAYMENTK");
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("PaymentStatus", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("PaymentStatusTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.PaymentStatusTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMENTS_REFERENCE_PAYMENTS");
            });

            modelBuilder.Entity<PayMethodType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("PayMethodType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PayMethodTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("PayMethodTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.PayMethodTypeTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMETHO_REFERENCE_PAYMETHO");
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("Period", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PeriodTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("PeriodTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.PeriodTr)
                    .HasForeignKey(d => d.CodeI)
                    .HasConstraintName("FK_PERIODTR_REFERENCE_PERIOD");
            });

            modelBuilder.Entity<PositionType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("PositionType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PositionTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("PositionTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.PositionTypeTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POSITION_REFERENCE_POSITION");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("Region", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegionTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("RegionTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.RegionTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGIONTR_REFERENCE_REGION");
            });

            modelBuilder.Entity<RegisterStatus>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("RegisterStatus", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegisterStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("RegisterStatusTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.RegisterStatusTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGISTER_REFERENCE_REGISTER");
            });

            modelBuilder.Entity<ResidentType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("ResidentType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResidentTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("ResidentTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.ResidentTypeTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESIDENT_REFERENCE_RESIDENT");
            });

            modelBuilder.Entity<SexType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("SexType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SexTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("SexTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.SexTypeTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SEXTYPET_REFERENCE_SEXTYPE");
            });

            modelBuilder.Entity<TypePlace>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("TypePlace", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypePlaceTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("TypePlaceTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.TypePlaceTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEPLAC_REFERENCE_TYPEPLAC");
            });

            modelBuilder.Entity<TypeVat>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("TypeVAT", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeVattr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("TypeVATTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.TypeVattr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEVATT_REFERENCE_TYPEVAT");
            });
        }
    }
}
