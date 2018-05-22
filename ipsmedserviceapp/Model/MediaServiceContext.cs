using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ipsmedserviceapp.Model
{
    public partial class MediaServiceContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountBals> AccountBals { get; set; }
        public virtual DbSet<AccountStatus> AccountStatus { get; set; }
        public virtual DbSet<ActivityType> ActivityType { get; set; }
        public virtual DbSet<ActivityTypeTr> ActivityTypeTr { get; set; }
        public virtual DbSet<AgreementAddPartner> AgreementAddPartner { get; set; }
        public virtual DbSet<AgreementAddRh> AgreementAddRh { get; set; }
        public virtual DbSet<AgreementMaster> AgreementMaster { get; set; }
        public virtual DbSet<AgreementStatus> AgreementStatus { get; set; }
        public virtual DbSet<AgreementStatusTr> AgreementStatusTr { get; set; }
        public virtual DbSet<AgreementType> AgreementType { get; set; }
        public virtual DbSet<AgreementTypeTr> AgreementTypeTr { get; set; }
        public virtual DbSet<AgrLicenseType> AgrLicenseType { get; set; }
        public virtual DbSet<AgrLicenseTypeTr> AgrLicenseTypeTr { get; set; }
        public virtual DbSet<AnketaAddName> AnketaAddName { get; set; }
        public virtual DbSet<AnketaAddNick> AnketaAddNick { get; set; }
        public virtual DbSet<AnketaAddParam> AnketaAddParam { get; set; }
        public virtual DbSet<AnketaCompany> AnketaCompany { get; set; }
        public virtual DbSet<AnketaPerson> AnketaPerson { get; set; }
        public virtual DbSet<AnketaStatus> AnketaStatus { get; set; }
        public virtual DbSet<AnketaStatusTr> AnketaStatusTr { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AtreementStatusTr> AtreementStatusTr { get; set; }
        public virtual DbSet<BankAccount> BankAccount { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryStatusType> CategoryStatusType { get; set; }
        public virtual DbSet<CategoryStatusTypeTr> CategoryStatusTypeTr { get; set; }
        public virtual DbSet<CategoryTr> CategoryTr { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        public virtual DbSet<ClnPlaceHoll> ClnPlaceHoll { get; set; }
        public virtual DbSet<CommentCause> CommentCause { get; set; }
        public virtual DbSet<Community> Community { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Continent> Continent { get; set; }
        public virtual DbSet<ContinentTr> ContinentTr { get; set; }
        public virtual DbSet<CopyRight> CopyRight { get; set; }
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
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<CurrencyCourse> CurrencyCourse { get; set; }
        public virtual DbSet<CustCmRight> CustCmRight { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerStatus> CustomerStatus { get; set; }
        public virtual DbSet<CustomerStatusTr> CustomerStatusTr { get; set; }
        public virtual DbSet<CustomerType> CustomerType { get; set; }
        public virtual DbSet<CustomerTypeTr> CustomerTypeTr { get; set; }
        public virtual DbSet<DicCategoryItems> DicCategoryItems { get; set; }
        public virtual DbSet<DicList> DicList { get; set; }
        public virtual DbSet<DictCategory> DictCategory { get; set; }
        public virtual DbSet<DistribStatus> DistribStatus { get; set; }
        public virtual DbSet<Distribution> Distribution { get; set; }
        public virtual DbSet<DistributionItem> DistributionItem { get; set; }
        public virtual DbSet<DocPreparePay> DocPreparePay { get; set; }
        public virtual DbSet<DocReq> DocReq { get; set; }
        public virtual DbSet<DocTemplate> DocTemplate { get; set; }
        public virtual DbSet<DocText> DocText { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentKind> DocumentKind { get; set; }
        public virtual DbSet<DocumentKindTr> DocumentKindTr { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EpisodeType> EpisodeType { get; set; }
        public virtual DbSet<ExternalPay> ExternalPay { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<GenreTr> GenreTr { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<KindComposition> KindComposition { get; set; }
        public virtual DbSet<KindFilm> KindFilm { get; set; }
        public virtual DbSet<KindSerial> KindSerial { get; set; }
        public virtual DbSet<KlR030> KlR030 { get; set; }
        public virtual DbSet<KlR030tr> KlR030tr { get; set; }
        public virtual DbSet<KlR031> KlR031 { get; set; }
        public virtual DbSet<Lang> Lang { get; set; }
        public virtual DbSet<LangTr> LangTr { get; set; }
        public virtual DbSet<LegalBasis> LegalBasis { get; set; }
        public virtual DbSet<LegalBasisTr> LegalBasisTr { get; set; }
        public virtual DbSet<LicenseAgreement> LicenseAgreement { get; set; }
        public virtual DbSet<LicenseBigR> LicenseBigR { get; set; }
        public virtual DbSet<LicenseType> LicenseType { get; set; }
        public virtual DbSet<LicenseTypeTr> LicenseTypeTr { get; set; }
        public virtual DbSet<LicPlace> LicPlace { get; set; }
        public virtual DbSet<LicPlaceHoll> LicPlaceHoll { get; set; }
        public virtual DbSet<MediaFile> MediaFile { get; set; }
        public virtual DbSet<MediaSearchData> MediaSearchData { get; set; }
        public virtual DbSet<MediaTrack> MediaTrack { get; set; }
        public virtual DbSet<ModifyMusicType> ModifyMusicType { get; set; }
        public virtual DbSet<ModifyTextType> ModifyTextType { get; set; }
        public virtual DbSet<ModifyType> ModifyType { get; set; }
        public virtual DbSet<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public virtual DbSet<MoneyReceived> MoneyReceived { get; set; }
        public virtual DbSet<MoneyType> MoneyType { get; set; }
        public virtual DbSet<MoneyTypeTr> MoneyTypeTr { get; set; }
        public virtual DbSet<MyAnketa> MyAnketa { get; set; }
        public virtual DbSet<MyCategory> MyCategory { get; set; }
        public virtual DbSet<MyCopyRightType> MyCopyRightType { get; set; }
        public virtual DbSet<ObjectRight> ObjectRight { get; set; }
        public virtual DbSet<ObjectStatus> ObjectStatus { get; set; }
        public virtual DbSet<ObjectStatusTr> ObjectStatusTr { get; set; }
        public virtual DbSet<ObjectType> ObjectType { get; set; }
        public virtual DbSet<ObjectTypeTr> ObjectTypeTr { get; set; }
        public virtual DbSet<PaidPeriod> PaidPeriod { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<PaymentCase> PaymentCase { get; set; }
        public virtual DbSet<PaymentKind> PaymentKind { get; set; }
        public virtual DbSet<PaymentKindTr> PaymentKindTr { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }
        public virtual DbSet<PaymentStatusTr> PaymentStatusTr { get; set; }
        public virtual DbSet<PayMethodType> PayMethodType { get; set; }
        public virtual DbSet<PayMethodTypeTr> PayMethodTypeTr { get; set; }
        public virtual DbSet<PayTurn> PayTurn { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<PeriodStatus> PeriodStatus { get; set; }
        public virtual DbSet<PeriodStatusTr> PeriodStatusTr { get; set; }
        public virtual DbSet<PeriodTr> PeriodTr { get; set; }
        public virtual DbSet<PermitType> PermitType { get; set; }
        public virtual DbSet<PermitTypeTr> PermitTypeTr { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PortalObjectRights> PortalObjectRights { get; set; }
        public virtual DbSet<PortalSupportRights> PortalSupportRights { get; set; }
        public virtual DbSet<PositionType> PositionType { get; set; }
        public virtual DbSet<PositionTypeTr> PositionTypeTr { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<RegionTr> RegionTr { get; set; }
        public virtual DbSet<Register> Register { get; set; }
        public virtual DbSet<RegisterCount> RegisterCount { get; set; }
        public virtual DbSet<RegisterItem> RegisterItem { get; set; }
        public virtual DbSet<RegisterStatus> RegisterStatus { get; set; }
        public virtual DbSet<RegisterStatusTr> RegisterStatusTr { get; set; }
        public virtual DbSet<RelAdaptUseArea> RelAdaptUseArea { get; set; }
        public virtual DbSet<RelEmployee> RelEmployee { get; set; }
        public virtual DbSet<RelGenreAdapt> RelGenreAdapt { get; set; }
        public virtual DbSet<RelGenreMovie> RelGenreMovie { get; set; }
        public virtual DbSet<RelGenreSerial> RelGenreSerial { get; set; }
        public virtual DbSet<RelLicCopyR> RelLicCopyR { get; set; }
        public virtual DbSet<RelMovieEpisode> RelMovieEpisode { get; set; }
        public virtual DbSet<RelObjGenre> RelObjGenre { get; set; }
        public virtual DbSet<RelReqMedia> RelReqMedia { get; set; }
        public virtual DbSet<RelReqObj> RelReqObj { get; set; }
        public virtual DbSet<RelSerialEpisode> RelSerialEpisode { get; set; }
        public virtual DbSet<RelTvepisode> RelTvepisode { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<ReqAgreement> ReqAgreement { get; set; }
        public virtual DbSet<ReqAgreementStatus> ReqAgreementStatus { get; set; }
        public virtual DbSet<ReqCustomer> ReqCustomer { get; set; }
        public virtual DbSet<ReqLocationUse> ReqLocationUse { get; set; }
        public virtual DbSet<ReqTrade> ReqTrade { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestAdapt> RequestAdapt { get; set; }
        public virtual DbSet<RequestAdvertising> RequestAdvertising { get; set; }
        public virtual DbSet<RequestAim> RequestAim { get; set; }
        public virtual DbSet<RequestInternet> RequestInternet { get; set; }
        public virtual DbSet<RequestMovie> RequestMovie { get; set; }
        public virtual DbSet<RequestOther> RequestOther { get; set; }
        public virtual DbSet<RequestSerial> RequestSerial { get; set; }
        public virtual DbSet<RequestStatusType> RequestStatusType { get; set; }
        public virtual DbSet<RequestTvradio> RequestTvradio { get; set; }
        public virtual DbSet<RequestType> RequestType { get; set; }
        public virtual DbSet<ResidentType> ResidentType { get; set; }
        public virtual DbSet<ResidentTypeTr> ResidentTypeTr { get; set; }
        public virtual DbSet<RightHolder> RightHolder { get; set; }
        public virtual DbSet<SaldoDay> SaldoDay { get; set; }
        public virtual DbSet<SeekObject> SeekObject { get; set; }
        public virtual DbSet<SeekType> SeekType { get; set; }
        public virtual DbSet<SexType> SexType { get; set; }
        public virtual DbSet<SexTypeTr> SexTypeTr { get; set; }
        public virtual DbSet<TableColumn> TableColumn { get; set; }
        public virtual DbSet<TableColumnTech> TableColumnTech { get; set; }
        public virtual DbSet<TableObject> TableObject { get; set; }
        public virtual DbSet<TableType> TableType { get; set; }
        public virtual DbSet<TermsOfService> TermsOfService { get; set; }
        public virtual DbSet<TermUse> TermUse { get; set; }
        public virtual DbSet<TerritoryExclude> TerritoryExclude { get; set; }
        public virtual DbSet<TerritoryInclude> TerritoryInclude { get; set; }
        public virtual DbSet<TmpTradeLog> TmpTradeLog { get; set; }
        public virtual DbSet<TradeStatus> TradeStatus { get; set; }
        public virtual DbSet<TypeInternetObject> TypeInternetObject { get; set; }
        public virtual DbSet<TypeMethodGet> TypeMethodGet { get; set; }
        public virtual DbSet<TypeMethodGetTr> TypeMethodGetTr { get; set; }
        public virtual DbSet<TypePlace> TypePlace { get; set; }
        public virtual DbSet<TypePlaceTr> TypePlaceTr { get; set; }
        public virtual DbSet<TypeVat> TypeVat { get; set; }
        public virtual DbSet<TypeVattr> TypeVattr { get; set; }
        public virtual DbSet<UseAreaType> UseAreaType { get; set; }
        public virtual DbSet<UseMediaType> UseMediaType { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserRoleType> UserRoleType { get; set; }

        // Unable to generate entity type for table 'dbo.Form1'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.MusicalDesign'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PostTransfer'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SeekTypeTr'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.testshell'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PartnerClient'. Please see the warning messages.

        public MediaServiceContext(DbContextOptions<MediaServiceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "db_owner");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccId);

                entity.ToTable("Account", "dbo");

                entity.HasIndex(e => new { e.R030, e.AccNls, e.AccStatus })
                    .HasName("AccountUI")
                    .IsUnique();

                entity.Property(e => e.AccId).HasColumnName("accId");

                entity.Property(e => e.AccDk).HasColumnName("accDK");

                entity.Property(e => e.AccName)
                    .HasColumnName("accName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AccNls)
                    .HasColumnName("accNls")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AccStatus).HasColumnName("accStatus");

                entity.Property(e => e.BalsCode).HasColumnName("balsCode");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.DateClose)
                    .HasColumnName("dateClose")
                    .HasColumnType("date");

                entity.Property(e => e.DateModify)
                    .HasColumnName("dateModify")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOpen)
                    .HasColumnName("dateOpen")
                    .HasColumnType("date");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.R030)
                    .HasColumnName("r030")
                    .HasColumnType("char(3)");

                entity.HasOne(d => d.BalsCodeNavigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.BalsCode)
                    .HasConstraintName("FK_ACCOUNT_REFERENCE_ACCOUNTB");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_ACCOUNT_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.Obj)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.ObjId)
                    .HasConstraintName("FK_ACCOUNT_REFERENCE_OBJECTRI");

                entity.HasOne(d => d.R030Navigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.R030)
                    .HasConstraintName("FK_ACCOUNT_REFERENCE_CURRENCY");
            });

            modelBuilder.Entity<AccountBals>(entity =>
            {
                entity.HasKey(e => e.BalsCode);

                entity.ToTable("AccountBals", "dbo");

                entity.Property(e => e.BalsCode)
                    .HasColumnName("balsCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.BalsNameEn)
                    .HasColumnName("balsNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BalsNameRu)
                    .HasColumnName("balsNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BalsNameUk)
                    .HasColumnName("balsNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BalsType).HasColumnName("balsType");
            });

            modelBuilder.Entity<AccountStatus>(entity =>
            {
                entity.HasKey(e => e.StatusCode);

                entity.ToTable("AccountStatus", "dbo");

                entity.Property(e => e.StatusCode)
                    .HasColumnName("statusCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.StatusNameEn)
                    .HasColumnName("statusNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusNameRu)
                    .HasColumnName("statusNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusNameUk)
                    .HasColumnName("statusNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

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

            modelBuilder.Entity<AgreementAddPartner>(entity =>
            {
                entity.HasKey(e => e.AgrId);

                entity.ToTable("AgreementAddPartner", "dbo");

                entity.Property(e => e.AgrId)
                    .HasColumnName("agrId")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourtCompRate)
                    .HasColumnName("courtCompRate")
                    .HasColumnType("numeric(10, 5)");

                entity.Property(e => e.CourtRate)
                    .HasColumnName("courtRate")
                    .HasColumnType("numeric(10, 5)");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.NoCourtRate)
                    .HasColumnName("noCourtRate")
                    .HasColumnType("numeric(10, 5)");

                entity.Property(e => e.PfFirstRate)
                    .HasColumnName("pfFirstRate")
                    .HasColumnType("numeric(10, 5)");

                entity.Property(e => e.PfMonthRate)
                    .HasColumnName("pfMonthRate")
                    .HasColumnType("numeric(10, 5)");

                entity.Property(e => e.SrFirstRate)
                    .HasColumnName("srFirstRate")
                    .HasColumnType("numeric(10, 5)");

                entity.Property(e => e.SrMonthRate)
                    .HasColumnName("srMonthRate")
                    .HasColumnType("numeric(10, 5)");

                entity.HasOne(d => d.Agr)
                    .WithOne(p => p.AgreementAddPartner)
                    .HasForeignKey<AgreementAddPartner>(d => d.AgrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_AGREEMEN");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.AgreementAddPartner)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_PARTNER");
            });

            modelBuilder.Entity<AgreementAddRh>(entity =>
            {
                entity.HasKey(e => e.AgrId);

                entity.ToTable("AgreementAddRH", "dbo");

                entity.Property(e => e.AgrId)
                    .HasColumnName("agrId")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.RateCommiss)
                    .HasColumnName("rateCommiss")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.RateCourt)
                    .HasColumnName("rateCourt")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.ResponsUser)
                    .HasColumnName("responsUser")
                    .HasMaxLength(48);

                entity.HasOne(d => d.Agr)
                    .WithOne(p => p.AgreementAddRh)
                    .HasForeignKey<AgreementAddRh>(d => d.AgrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_AGREEM");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.AgreementAddRh)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_RIGHTHOL");

                entity.HasOne(d => d.ResponsUserNavigation)
                    .WithMany(p => p.AgreementAddRh)
                    .HasForeignKey(d => d.ResponsUser)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_ASPNETUS");
            });

            modelBuilder.Entity<AgreementMaster>(entity =>
            {
                entity.HasKey(e => e.AgrId);

                entity.ToTable("AgreementMaster", "dbo");

                entity.Property(e => e.AgrId).HasColumnName("agrId");

                entity.Property(e => e.AgrDate)
                    .HasColumnName("agrDate")
                    .HasColumnType("date");

                entity.Property(e => e.AgrNumber)
                    .HasColumnName("agrNumber")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AgrStatus).HasColumnName("agrStatus");

                entity.Property(e => e.AgrType).HasColumnName("agrType");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.DateBegin)
                    .HasColumnName("dateBegin")
                    .HasColumnType("date");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("dateEnd")
                    .HasColumnType("date");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyLogin)
                    .HasColumnName("modifyLogin")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.ParentAgrId).HasColumnName("parentAgrId");

                entity.HasOne(d => d.AgrStatusNavigation)
                    .WithMany(p => p.AgreementMaster)
                    .HasForeignKey(d => d.AgrStatus)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_STATUS");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.AgreementMaster)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.ParentAgr)
                    .WithMany(p => p.InverseParentAgr)
                    .HasForeignKey(d => d.ParentAgrId)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_AGREEID");
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

            modelBuilder.Entity<AgreementType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("AgreementType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AgreementTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("AgreementTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.AgreementTypeTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AGREEMET_REFERENCE_AGREEMEN");
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

            modelBuilder.Entity<AnketaAddName>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.Lang });

                entity.ToTable("AnketaAddName", "dbo");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.NikName)
                    .HasColumnName("nikName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasColumnName("shortName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.SurName)
                    .HasColumnName("surName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.AnketaAddName)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETAADN_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<AnketaAddNick>(entity =>
            {
                entity.HasKey(e => e.AddId);

                entity.ToTable("AnketaAddNick", "dbo");

                entity.Property(e => e.AddId).HasColumnName("addId");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.NikName)
                    .HasColumnName("nikName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.AnketaAddNick)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETAAD_REFERENCE_RIGHTHOL");
            });

            modelBuilder.Entity<AnketaAddParam>(entity =>
            {
                entity.HasKey(e => new { e.ParamCode, e.LangCode });

                entity.ToTable("AnketaAddParam", "dbo");

                entity.Property(e => e.ParamCode).HasColumnName("paramCode");

                entity.Property(e => e.LangCode)
                    .HasColumnName("langCode")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.ParamName)
                    .IsRequired()
                    .HasColumnName("paramName")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ParamValue)
                    .HasColumnName("paramValue")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.AnketaAddParam)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_ANKETAAD_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<AnketaCompany>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.Version });

                entity.ToTable("AnketaCompany", "dbo");

                entity.HasIndex(e => e.CustId)
                    .HasName("Association26_FK");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.Property(e => e.ActivityCode).HasColumnName("activityCode");

                entity.Property(e => e.BanAccId).HasColumnName("banAccId");

                entity.Property(e => e.FaAddress)
                    .HasColumnName("faAddress")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.FaCity)
                    .HasColumnName("faCity")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FaCountry)
                    .HasColumnName("faCountry")
                    .HasColumnType("char(3)");

                entity.Property(e => e.FaRegion).HasColumnName("faRegion");

                entity.Property(e => e.IsCurrent).HasColumnName("isCurrent");

                entity.Property(e => e.JaAddress)
                    .HasColumnName("jaAddress")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.JaCity)
                    .HasColumnName("jaCity")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JaCountry)
                    .HasColumnName("jaCountry")
                    .HasColumnType("char(3)");

                entity.Property(e => e.JaRegion).HasColumnName("jaRegion");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyLogin)
                    .HasColumnName("modifyLogin")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.NumberVat)
                    .HasColumnName("numberVAT")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Okpo)
                    .HasColumnName("okpo")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrDate)
                    .HasColumnName("registrDate")
                    .HasColumnType("date");

                entity.Property(e => e.RegistrNumber)
                    .HasColumnName("registrNumber")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrWho)
                    .HasColumnName("registrWho")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasColumnName("shortName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TypeVat).HasColumnName("typeVAT");

                entity.HasOne(d => d.ActivityCodeNavigation)
                    .WithMany(p => p.AnketaCompany)
                    .HasForeignKey(d => d.ActivityCode)
                    .HasConstraintName("FK_ANKETACO_REFERENCE_ACTIVITY");

                entity.HasOne(d => d.BanAcc)
                    .WithMany(p => p.AnketaCompany)
                    .HasForeignKey(d => d.BanAccId)
                    .HasConstraintName("FK_ANKETACO_REFERENCE_BANKACCO");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.AnketaCompany)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETACO_ASSOCIATI_COMPANY");

                entity.HasOne(d => d.CustNavigation)
                    .WithMany(p => p.AnketaCompany)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETACO_ASSOCIATI_CUSTOMER");

                entity.HasOne(d => d.FaCountryNavigation)
                    .WithMany(p => p.AnketaCompanyFaCountryNavigation)
                    .HasForeignKey(d => d.FaCountry)
                    .HasConstraintName("FK_ANKETACO_REF_FaCOUNTRY");

                entity.HasOne(d => d.FaRegionNavigation)
                    .WithMany(p => p.AnketaCompanyFaRegionNavigation)
                    .HasForeignKey(d => d.FaRegion)
                    .HasConstraintName("FK_ANKETACO_REFERENCE_REGFA");

                entity.HasOne(d => d.JaCountryNavigation)
                    .WithMany(p => p.AnketaCompanyJaCountryNavigation)
                    .HasForeignKey(d => d.JaCountry)
                    .HasConstraintName("FK_ANKETACO_REF_jaCOUNTRY");

                entity.HasOne(d => d.JaRegionNavigation)
                    .WithMany(p => p.AnketaCompanyJaRegionNavigation)
                    .HasForeignKey(d => d.JaRegion)
                    .HasConstraintName("FK_ANKETACO_REFERENCE_REGJA");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.AnketaCompany)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETACO_REFERENCE_ANKETAST");

                entity.HasOne(d => d.TypeVatNavigation)
                    .WithMany(p => p.AnketaCompany)
                    .HasForeignKey(d => d.TypeVat)
                    .HasConstraintName("FK_ANKETACO_REFERENCE_TYPEVAT");
            });

            modelBuilder.Entity<AnketaPerson>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.Version });

                entity.ToTable("AnketaPerson", "dbo");

                entity.HasIndex(e => e.CustId)
                    .HasName("Association26_FK");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.Property(e => e.BanAccId).HasColumnName("banAccId");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birthDate")
                    .HasColumnType("date");

                entity.Property(e => e.BuisDateRegistration)
                    .HasColumnName("buisDateRegistration")
                    .HasColumnType("date");

                entity.Property(e => e.BuisNumberPayer)
                    .HasColumnName("buisNumberPayer")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.BuisNumberRegistration)
                    .HasColumnName("buisNumberRegistration")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.BuisSertNumberPayer)
                    .HasColumnName("buisSertNumberPayer")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Citizenship)
                    .HasColumnName("citizenship")
                    .HasColumnType("char(3)");

                entity.Property(e => e.EMail)
                    .HasColumnName("eMail")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.FaAddress)
                    .HasColumnName("faAddress")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.FaCity)
                    .HasColumnName("faCity")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FaCountry)
                    .HasColumnName("faCountry")
                    .HasColumnType("char(3)");

                entity.Property(e => e.FaRegion).HasColumnName("faRegion");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Inn)
                    .HasColumnName("inn")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.IsCurrent).HasColumnName("isCurrent");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.LeAddress)
                    .HasColumnName("leAddress")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.LeCity)
                    .HasColumnName("leCity")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LeCountry)
                    .HasColumnName("leCountry")
                    .HasColumnType("char(3)");

                entity.Property(e => e.LePostIndex)
                    .HasColumnName("lePostIndex")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeRegion).HasColumnName("leRegion");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyLogin)
                    .HasColumnName("modifyLogin")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NikName)
                    .HasColumnName("nikName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.PFissuedDate)
                    .HasColumnName("pFIssuedDate")
                    .HasColumnType("date");

                entity.Property(e => e.PFnumber)
                    .HasColumnName("pFNumber")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.PFseries)
                    .HasColumnName("pFSeries")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.PFvalidity)
                    .HasColumnName("pFValidity")
                    .HasColumnType("date");

                entity.Property(e => e.PUissuedWhen)
                    .HasColumnName("pUIssuedWhen")
                    .HasColumnType("date");

                entity.Property(e => e.PUissuedWho)
                    .HasColumnName("pUIssuedWho")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.PUnumber)
                    .HasColumnName("pUNumber")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.PUseries)
                    .HasColumnName("pUSeries")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneHome)
                    .HasColumnName("phoneHome")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneMobileExtra)
                    .HasColumnName("phoneMobileExtra")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneMobileMain)
                    .HasColumnName("phoneMobileMain")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ReAddress)
                    .HasColumnName("reAddress")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ReCity)
                    .HasColumnName("reCity")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReCountry)
                    .HasColumnName("reCountry")
                    .HasColumnType("char(3)");

                entity.Property(e => e.ReRegion).HasColumnName("reRegion");

                entity.Property(e => e.Residency).HasColumnName("residency");

                entity.Property(e => e.Sex).HasColumnName("sex");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SurName)
                    .HasColumnName("surName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.TypeVat).HasColumnName("typeVAT");

                entity.HasOne(d => d.BanAcc)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.BanAccId)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_BANKACCO");

                entity.HasOne(d => d.CitizenshipNavigation)
                    .WithMany(p => p.AnketaPersonCitizenshipNavigation)
                    .HasForeignKey(d => d.Citizenship)
                    .HasConstraintName("FK_ANKETAPE_REF_SitizCOUNTRY");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETAPE_ASSOCIATI_CUSTOMER");

                entity.HasOne(d => d.CustNavigation)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETAPE_ASSOCIATI_PERSON");

                entity.HasOne(d => d.FaCountryNavigation)
                    .WithMany(p => p.AnketaPersonFaCountryNavigation)
                    .HasForeignKey(d => d.FaCountry)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_COUNTRY");

                entity.HasOne(d => d.FaRegionNavigation)
                    .WithMany(p => p.AnketaPersonFaRegionNavigation)
                    .HasForeignKey(d => d.FaRegion)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_REGFa");

                entity.HasOne(d => d.LangNavigation)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.Lang)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_LANG");

                entity.HasOne(d => d.LeRegionNavigation)
                    .WithMany(p => p.AnketaPersonLeRegionNavigation)
                    .HasForeignKey(d => d.LeRegion)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_REGLe");

                entity.HasOne(d => d.ReCountryNavigation)
                    .WithMany(p => p.AnketaPersonReCountryNavigation)
                    .HasForeignKey(d => d.ReCountry)
                    .HasConstraintName("FK_ANKETAPE_REF_RegistCOUNTRY");

                entity.HasOne(d => d.ReRegionNavigation)
                    .WithMany(p => p.AnketaPersonReRegionNavigation)
                    .HasForeignKey(d => d.ReRegion)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_REGRe");

                entity.HasOne(d => d.ResidencyNavigation)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.Residency)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_RESIDENT");

                entity.HasOne(d => d.SexNavigation)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.Sex)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_SEXTYPE");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_ANKETAST");

                entity.HasOne(d => d.TypeVatNavigation)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.TypeVat)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_TYPEVAT");
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

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.ToTable("AspNetRoleClaims", "dbo");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClaimType).HasColumnName("claimType");

                entity.Property(e => e.ClaimValue).HasColumnName("claimValue");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("roleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.ToTable("AspNetRoles", "dbo");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrencyStamp");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedName)
                    .HasColumnName("normalizedName")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.ToTable("AspNetUserClaims", "dbo");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClaimType).HasColumnName("claimType");

                entity.Property(e => e.ClaimValue).HasColumnName("claimValue");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(48);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("AspNetUserLogins", "dbo");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasColumnName("loginProvider");

                entity.Property(e => e.ProviderKey).HasColumnName("providerKey");

                entity.Property(e => e.ProviderDisplayName).HasColumnName("providerDisplayName");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(48);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("AspNetUserRoles", "dbo");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserRoles_UserId");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(48);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.ToTable("AspNetUsers", "dbo");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(48)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessFailedCount).HasColumnName("accessFailedCount");

                entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrencyStamp");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(256);

                entity.Property(e => e.EmailConfirmed).HasColumnName("emailConfirmed");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(256);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(256);

                entity.Property(e => e.LockoutEnabled).HasColumnName("lockoutEnabled");

                entity.Property(e => e.LockoutEnd).HasColumnName("lockoutEnd");

                entity.Property(e => e.NormalizedEmail)
                    .HasColumnName("normalizedEmail")
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName)
                    .HasColumnName("normalizedUserName")
                    .HasMaxLength(256);

                entity.Property(e => e.PasswordHash).HasColumnName("passwordHash");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("phoneNumberConfirmed");

                entity.Property(e => e.SecurityStamp).HasColumnName("securityStamp");

                entity.Property(e => e.SurName)
                    .HasColumnName("surName")
                    .HasMaxLength(256);

                entity.Property(e => e.TwoFactorEnabled).HasColumnName("twoFactorEnabled");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("AspNetUserTokens", "dbo");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.LoginProvider).HasColumnName("loginProvider");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<AtreementStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("AtreementStatusTr", "dbo");

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
                    .WithMany(p => p.AtreementStatusTr)
                    .HasForeignKey(d => d.CodeI)
                    .HasConstraintName("FK_ATREEMEN_REFERENCE_AGREEMEN");
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(e => e.BanAccId);

                entity.ToTable("BankAccount", "dbo");

                entity.Property(e => e.BanAccId).HasColumnName("banAccID");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("accountNumber")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasColumnType("char(3)");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.Mfo).HasColumnName("mfo");

                entity.Property(e => e.MfoName)
                    .HasColumnName("mfoName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.MfoOkpo)
                    .HasColumnName("mfoOkpo")
                    .HasColumnType("char(10)");

                entity.Property(e => e.TransitNumber)
                    .HasColumnName("transitNumber")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.BankAccount)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK_BANKACCO_REFERENCE_KL_R030");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.BankAccount)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_BANKACCO_REFERENCE_CUSTOMER");
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

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("Client", "dbo");

                entity.Property(e => e.CustId)
                    .HasColumnName("custId")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.Client)
                    .HasForeignKey<Client>(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENT_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<ClnBusinessPlace>(entity =>
            {
                entity.HasKey(e => e.PlaceId);

                entity.ToTable("ClnBusinessPlace", "dbo");

                entity.Property(e => e.PlaceId).HasColumnName("placeId");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.FreeEntry).HasColumnName("freeEntry");

                entity.Property(e => e.PlCode).HasColumnName("plCode");

                entity.Property(e => e.PlaceAddress)
                    .HasColumnName("placeAddress")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceCity)
                    .HasColumnName("placeCity")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceCountry)
                    .HasColumnName("placeCountry")
                    .HasColumnType("char(3)");

                entity.Property(e => e.PlaceName)
                    .HasColumnName("placeName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlacePhone)
                    .HasColumnName("placePhone")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceRegion).HasColumnName("placeRegion");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.ClnBusinessPlace)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_CLNBUSIN_REFERENCE_CLIENT");

                entity.HasOne(d => d.PlCodeNavigation)
                    .WithMany(p => p.ClnBusinessPlace)
                    .HasForeignKey(d => d.PlCode)
                    .HasConstraintName("FK_CLNBUSIN_REFERENCE_TYPEPLAC");
            });

            modelBuilder.Entity<ClnPlaceHoll>(entity =>
            {
                entity.HasKey(e => e.HollId);

                entity.ToTable("ClnPlaceHoll", "dbo");

                entity.Property(e => e.HollId).HasColumnName("hollId");

                entity.Property(e => e.HollName)
                    .HasColumnName("hollName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HollNum).HasColumnName("hollNum");

                entity.Property(e => e.PlaceId).HasColumnName("placeId");

                entity.Property(e => e.SqHoll)
                    .HasColumnName("sqHoll")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.СalcNum).HasColumnName("сalcNum");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.ClnPlaceHoll)
                    .HasForeignKey(d => d.PlaceId)
                    .HasConstraintName("FK_CLNPLACE_REFERENCE_CLNBUSIN");
            });

            modelBuilder.Entity<CommentCause>(entity =>
            {
                entity.HasKey(e => e.CauseCode);

                entity.ToTable("CommentCause", "dbo");

                entity.Property(e => e.CauseCode)
                    .HasColumnName("causeCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CauseNameEn)
                    .HasColumnName("causeNameEn")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CauseNameRu)
                    .HasColumnName("causeNameRu")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CauseNameUk)
                    .HasColumnName("causeNameUk")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Community>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("Community", "dbo");

                entity.Property(e => e.CustId)
                    .HasColumnName("custId")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.Community)
                    .HasForeignKey<Community>(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMUNIT_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("Company", "dbo");

                entity.HasIndex(e => e.CustId)
                    .HasName("Association20_FK");

                entity.HasIndex(e => new { e.CustId, e.Version })
                    .HasName("Association25_FK");

                entity.Property(e => e.CustId)
                    .HasColumnName("custId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.Company)
                    .HasForeignKey<Company>(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMPANY_ASSOCIATI_CUSTOMER");
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

            modelBuilder.Entity<CopyRight>(entity =>
            {
                entity.HasKey(e => e.CRightId);

                entity.ToTable("CopyRight", "dbo");

                entity.HasIndex(e => e.CustId)
                    .HasName("Association10_FK");

                entity.Property(e => e.CRightId).HasColumnName("cRightId");

                entity.Property(e => e.BeginDate)
                    .HasColumnName("beginDate")
                    .HasColumnType("date");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.LBasis).HasColumnName("lBasis");

                entity.Property(e => e.LBasisComment)
                    .HasColumnName("lBasisComment")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyLogin)
                    .HasColumnName("modifyLogin")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.ParentId).HasColumnName("parentId");

                entity.Property(e => e.PermCode).HasColumnName("permCode");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.RoleCode).HasColumnName("roleCode");

                entity.Property(e => e.RoleRate)
                    .HasColumnName("roleRate")
                    .HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.RoleCodeNavigation)
                    .WithMany(p => p.CopyRight)
                    .HasForeignKey(d => d.RoleCode)
                    .HasConstraintName("FK_COPYRIGH_REFERENCE_CREATIVE");
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

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.R030);

                entity.ToTable("Currency", "dbo");

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

                entity.Property(e => e.OrderBy).HasColumnName("orderBy");

                entity.Property(e => e.PrNc).HasColumnName("prNC");

                entity.Property(e => e.PrWork).HasColumnName("prWork");

                entity.Property(e => e.R030NameEn)
                    .HasColumnName("r030NameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.R030NameRu)
                    .HasColumnName("r030NameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.R030NameUk)
                    .HasColumnName("r030NameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CurrencyCourse>(entity =>
            {
                entity.HasKey(e => new { e.R030, e.CDate });

                entity.ToTable("CurrencyCourse", "dbo");

                entity.Property(e => e.R030)
                    .HasColumnName("r030")
                    .HasColumnType("char(3)");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasColumnType("date");

                entity.Property(e => e.CAmount)
                    .HasColumnName("cAmount")
                    .HasColumnType("numeric(18, 5)");

                entity.Property(e => e.CAmountNbu)
                    .HasColumnName("cAmountNBU")
                    .HasColumnType("numeric(18, 5)");

                entity.Property(e => e.CUnit).HasColumnName("cUnit");

                entity.HasOne(d => d.R030Navigation)
                    .WithMany(p => p.CurrencyCourse)
                    .HasForeignKey(d => d.R030)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CURRENCY_REFERENCE_KL_R030");
            });

            modelBuilder.Entity<CustCmRight>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.CRkindCode, e.DateBegin, e.CmCustId });

                entity.ToTable("CustCmRight", "dbo");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.CRkindCode).HasColumnName("cRKindCode");

                entity.Property(e => e.DateBegin)
                    .HasColumnName("dateBegin")
                    .HasColumnType("date");

                entity.Property(e => e.CmCustId).HasColumnName("cmCustId");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("dateEnd")
                    .HasColumnType("date");

                entity.HasOne(d => d.CmCust)
                    .WithMany(p => p.CustCmRight)
                    .HasForeignKey(d => d.CmCustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTCMRI_REFERENCE_COMMUNIT");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.CustCmRight)
                    .HasForeignKey(d => new { d.CustId, d.CRkindCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTCMRI_REFERENCE_TERMSOFS");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("Customer", "dbo");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.AnkMy).HasColumnName("ankMy");

                entity.Property(e => e.AnkPublish).HasColumnName("ankPublish");

                entity.Property(e => e.AnkTech).HasColumnName("ankTech");

                entity.Property(e => e.AnkVersion).HasColumnName("ankVersion");

                entity.Property(e => e.CustType).HasColumnName("custType");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.CustTypeNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CustType)
                    .HasConstraintName("FK_CUSTOMER_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMER_REFERENCE_Status");
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

            modelBuilder.Entity<DicList>(entity =>
            {
                entity.HasKey(e => e.DicId);

                entity.ToTable("DicList", "dbo");

                entity.Property(e => e.DicId).HasColumnName("dicId");

                entity.Property(e => e.DCode).HasColumnName("dCode");

                entity.Property(e => e.DKind)
                    .IsRequired()
                    .HasColumnName("dKind")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DNameEn)
                    .HasColumnName("dNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DNameRu)
                    .HasColumnName("dNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DNameUk)
                    .HasColumnName("dNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);
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

            modelBuilder.Entity<DistribStatus>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("DistribStatus", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Distribution>(entity =>
            {
                entity.HasKey(e => e.DistId);

                entity.ToTable("Distribution", "dbo");

                entity.Property(e => e.DistId).HasColumnName("distId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.CRkindCode).HasColumnName("cRKindCode");

                entity.Property(e => e.CourtFee)
                    .HasColumnName("courtFee")
                    .HasColumnType("money");

                entity.Property(e => e.DistribDate)
                    .HasColumnName("distribDate")
                    .HasColumnType("date");

                entity.Property(e => e.IsCourt).HasColumnName("isCourt");

                entity.Property(e => e.PartnerCommiss)
                    .HasColumnName("partnerCommiss")
                    .HasColumnType("money");

                entity.Property(e => e.PartnerId).HasColumnName("partnerId");

                entity.Property(e => e.PeriodId).HasColumnName("periodId");

                entity.Property(e => e.RegId).HasColumnName("regId");

                entity.Property(e => e.RegIdBr).HasColumnName("regIdBr");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.CRkindCodeNavigation)
                    .WithMany(p => p.Distribution)
                    .HasForeignKey(d => d.CRkindCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Distribution)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_PARTNER");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.Distribution)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_PAIDPERI");

                entity.HasOne(d => d.Reg)
                    .WithMany(p => p.Distribution)
                    .HasForeignKey(d => d.RegId)
                    .HasConstraintName("FK_DISTRIB_REF_REGISTER");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Distribution)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_DISTRIBS");
            });

            modelBuilder.Entity<DistributionItem>(entity =>
            {
                entity.HasKey(e => e.DistItemId);

                entity.ToTable("DistributionItem", "dbo");

                entity.Property(e => e.DistItemId).HasColumnName("distItemId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.DistId).HasColumnName("distId");

                entity.Property(e => e.RegId).HasColumnName("regId");

                entity.Property(e => e.RegIdBr).HasColumnName("regIdBr");

                entity.Property(e => e.RegIitemId).HasColumnName("regIItemId");

                entity.Property(e => e.RegItemIdBr).HasColumnName("regItemIdBr");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Dist)
                    .WithMany(p => p.DistributionItem)
                    .HasForeignKey(d => d.DistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_DISTRIBU");
            });

            modelBuilder.Entity<DocPreparePay>(entity =>
            {
                entity.HasKey(e => new { e.DocPayId, e.DateWork });

                entity.ToTable("DocPreparePay", "dbo");

                entity.Property(e => e.DocPayId)
                    .HasColumnName("docPayId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DateWork)
                    .HasColumnName("dateWork")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccCredit)
                    .HasColumnName("accCredit")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AccDebet)
                    .HasColumnName("accDebet")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AccIdCredit).HasColumnName("accIdCredit");

                entity.Property(e => e.AccIdDebet).HasColumnName("accIdDebet");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.AmountCur)
                    .HasColumnName("amountCur")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.DateOper)
                    .HasColumnName("dateOper")
                    .HasColumnType("date");

                entity.Property(e => e.DistId).HasColumnName("distId");

                entity.Property(e => e.ND)
                    .HasColumnName("nD")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NDdate)
                    .HasColumnName("nDDate")
                    .HasColumnType("date");

                entity.Property(e => e.Paidid).HasColumnName("paidid");

                entity.Property(e => e.PayNote)
                    .HasColumnName("payNote")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PayStatus).HasColumnName("payStatus");

                entity.Property(e => e.R030)
                    .HasColumnName("r030")
                    .HasColumnType("char(3)");

                entity.Property(e => e.RegId).HasColumnName("regId");

                entity.HasOne(d => d.PayStatusNavigation)
                    .WithMany(p => p.DocPreparePay)
                    .HasForeignKey(d => d.PayStatus)
                    .HasConstraintName("FK_DOCPREPA_REFERENCE_PAYMENTS");
            });

            modelBuilder.Entity<DocReq>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.ReqId });

                entity.ToTable("DocReq", "dbo");

                entity.Property(e => e.DocId).HasColumnName("docId");

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.DocReq)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCREQ_REFERENCE_DOCUMENT");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.DocReq)
                    .HasForeignKey(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCREQ_REFERENCE_REQUEST");
            });

            modelBuilder.Entity<DocTemplate>(entity =>
            {
                entity.HasKey(e => e.TemplId);

                entity.ToTable("DocTemplate", "dbo");

                entity.Property(e => e.TemplId).HasColumnName("templId");

                entity.Property(e => e.DocTypeCode).HasColumnName("docTypeCode");

                entity.Property(e => e.ReqType).HasColumnName("reqType");

                entity.Property(e => e.TemplName)
                    .HasColumnName("templName")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.TemplPath)
                    .HasColumnName("templPath")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.DocTypeCodeNavigation)
                    .WithMany(p => p.DocTemplate)
                    .HasForeignKey(d => d.DocTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCTEMPL_REFERENCE_DOCUMENT");

                entity.HasOne(d => d.ReqTypeNavigation)
                    .WithMany(p => p.DocTemplate)
                    .HasForeignKey(d => d.ReqType)
                    .HasConstraintName("FK_DOCTEMPL_REFERENCE_REQUESTT");
            });

            modelBuilder.Entity<DocText>(entity =>
            {
                entity.ToTable("DocText", "dbo");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TextEn)
                    .HasColumnName("Text_En")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TextRu)
                    .HasColumnName("Text_Ru")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TextUk)
                    .HasColumnName("Text_Uk")
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("Document", "dbo");

                entity.Property(e => e.DocId).HasColumnName("docId");

                entity.Property(e => e.DocDate)
                    .HasColumnName("docDate")
                    .HasColumnType("date");

                entity.Property(e => e.DocFile)
                    .HasColumnName("docFile")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DocNumber)
                    .IsRequired()
                    .HasColumnName("docNumber")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.DocStatus).HasColumnName("docStatus");

                entity.Property(e => e.DocTypeCode).HasColumnName("docTypeCode");

                entity.HasOne(d => d.DocTypeCodeNavigation)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.DocTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCUMENT_REFERENCE_DOCUMENT");
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

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Emplid);

                entity.ToTable("Employee", "dbo");

                entity.Property(e => e.Emplid).HasColumnName("emplid");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.SurName)
                    .HasColumnName("surName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(48);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_EMPLOYEE_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_EMPLOYEE_REFERENCE_ASPNETUS");
            });

            modelBuilder.Entity<EpisodeType>(entity =>
            {
                entity.HasKey(e => e.EpisodeTypeCode);

                entity.ToTable("EpisodeType", "dbo");

                entity.Property(e => e.EpisodeTypeCode)
                    .HasColumnName("episodeTypeCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.EpisodeTypeNameEn)
                    .HasColumnName("episodeTypeNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EpisodeTypeNameRu)
                    .HasColumnName("episodeTypeNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EpisodeTypeNameUk)
                    .HasColumnName("episodeTypeNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExternalPay>(entity =>
            {
                entity.HasKey(e => e.PaidId);

                entity.ToTable("ExternalPay", "dbo");

                entity.Property(e => e.PaidId).HasColumnName("paidId");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AccountCorr)
                    .HasColumnName("accountCorr")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CodeOper)
                    .HasColumnName("codeOper")
                    .HasColumnType("char(10)");

                entity.Property(e => e.DateOper)
                    .HasColumnName("dateOper")
                    .HasColumnType("date");

                entity.Property(e => e.DocDate)
                    .HasColumnName("docDate")
                    .HasColumnType("date");

                entity.Property(e => e.DocNum)
                    .HasColumnName("docNum")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InputDate)
                    .HasColumnName("inputDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mfo)
                    .HasColumnName("mfo")
                    .HasColumnType("char(10)");

                entity.Property(e => e.MfoCorr)
                    .HasColumnName("mfoCorr")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NameCorr)
                    .HasColumnName("nameCorr")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NameMfoCorr)
                    .HasColumnName("nameMfoCorr")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nplat)
                    .HasColumnName("nplat")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.OkpoCorr)
                    .HasColumnName("okpoCorr")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Okpol)
                    .HasColumnName("okpol")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.R030)
                    .HasColumnName("r030")
                    .HasColumnType("char(3)");

                entity.Property(e => e.SCredit)
                    .HasColumnName("sCredit")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.SDebet)
                    .HasColumnName("sDebet")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.SNcCur)
                    .HasColumnName("sNcCur")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.Status).HasColumnName("status");
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

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("Invoice", "dbo");

                entity.Property(e => e.DocId)
                    .HasColumnName("docId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.PayAnk).HasColumnName("payAnk");

                entity.Property(e => e.PayCustId).HasColumnName("payCustId");

                entity.Property(e => e.Purpose)
                    .HasColumnName("purpose")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.R030)
                    .HasColumnName("r030")
                    .HasColumnType("char(3)");

                entity.Property(e => e.RecAnk).HasColumnName("recAnk");

                entity.Property(e => e.RecBankName)
                    .HasColumnName("recBankName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.RecCustId).HasColumnName("recCustId");

                entity.Property(e => e.RecMfo)
                    .HasColumnName("recMFO")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Doc)
                    .WithOne(p => p.Invoice)
                    .HasForeignKey<Invoice>(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INVOICE_REFERENCE_DOCUMENT");
            });

            modelBuilder.Entity<KindComposition>(entity =>
            {
                entity.HasKey(e => e.KindCompCode);

                entity.ToTable("KindComposition", "dbo");

                entity.Property(e => e.KindCompCode)
                    .HasColumnName("kindCompCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.KindCompNameEn)
                    .HasColumnName("kindCompNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KindCompNameRu)
                    .HasColumnName("kindCompNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KindCompNameUk)
                    .HasColumnName("kindCompNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.KindComposition)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KINDCOMP_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<KindFilm>(entity =>
            {
                entity.HasKey(e => e.KindFilmCode);

                entity.ToTable("KindFilm", "dbo");

                entity.Property(e => e.KindFilmCode)
                    .HasColumnName("kindFilmCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.KindFilmNameEn)
                    .HasColumnName("kindFilmNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KindFilmNameRu)
                    .HasColumnName("kindFilmNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KindFilmNameUk)
                    .HasColumnName("kindFilmNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KindSerial>(entity =>
            {
                entity.HasKey(e => e.KindSerialCode);

                entity.ToTable("KindSerial", "dbo");

                entity.Property(e => e.KindSerialCode)
                    .HasColumnName("kindSerialCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.KindSerialNameEn)
                    .HasColumnName("kindSerialNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KindSerialNameRu)
                    .HasColumnName("kindSerialNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KindSerialNameUk)
                    .HasColumnName("kindSerialNameUk")
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

                entity.HasOne(d => d.R031Navigation)
                    .WithMany(p => p.KlR030)
                    .HasForeignKey(d => d.R031)
                    .HasConstraintName("FK_KL_R030_REFERENCE_KL_R031");
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

            modelBuilder.Entity<KlR031>(entity =>
            {
                entity.HasKey(e => e.R031);

                entity.ToTable("KL_R031", "dbo");

                entity.Property(e => e.R031)
                    .HasColumnName("r031")
                    .ValueGeneratedNever();

                entity.Property(e => e.R031NameEn)
                    .HasColumnName("r031NameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.R031NameRu)
                    .HasColumnName("r031NameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.R031NameUk)
                    .HasColumnName("r031NameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lang>(entity =>
            {
                entity.HasKey(e => e.CodeS);

                entity.ToTable("Lang", "dbo");

                entity.Property(e => e.CodeS)
                    .HasColumnName("codeS")
                    .HasColumnType("char(2)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LangTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeS, e.Lang });

                entity.ToTable("LangTr", "dbo");

                entity.Property(e => e.CodeS)
                    .HasColumnName("codeS")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeSNavigation)
                    .WithMany(p => p.LangTr)
                    .HasForeignKey(d => d.CodeS)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LANGTR_REFERENCE_LANG");
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

            modelBuilder.Entity<LicenseAgreement>(entity =>
            {
                entity.HasKey(e => e.LicId);

                entity.ToTable("LicenseAgreement", "dbo");

                entity.Property(e => e.LicId).HasColumnName("licId");

                entity.Property(e => e.AddRate)
                    .HasColumnName("addRate")
                    .HasColumnType("numeric(10, 5)");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.DateBegin)
                    .HasColumnName("dateBegin")
                    .HasColumnType("date");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("dateEnd")
                    .HasColumnType("date");

                entity.Property(e => e.DayForPay).HasColumnName("dayForPay");

                entity.Property(e => e.IndxInfl)
                    .HasColumnName("indxInfl")
                    .HasColumnType("numeric(10, 5)");

                entity.Property(e => e.IsAutoprolog).HasColumnName("isAutoprolog");

                entity.Property(e => e.LicCode).HasColumnName("licCode");

                entity.Property(e => e.LicDate)
                    .HasColumnName("licDate")
                    .HasColumnType("date");

                entity.Property(e => e.LicNum)
                    .HasColumnName("licNum")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LicStatus).HasColumnName("licStatus");

                entity.Property(e => e.LicType).HasColumnName("licType");

                entity.Property(e => e.MinAmount)
                    .HasColumnName("minAmount")
                    .HasColumnType("money");

                entity.Property(e => e.ParentLicId).HasColumnName("parentLicId");

                entity.Property(e => e.PeriodCode).HasColumnName("periodCode");

                entity.Property(e => e.RateAmount)
                    .HasColumnName("rateAmount")
                    .HasColumnType("numeric(10, 5)");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.LicenseAgreement)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_LICENSEA_REFERENCE_CLIENT");

                entity.HasOne(d => d.LicCodeNavigation)
                    .WithMany(p => p.LicenseAgreement)
                    .HasForeignKey(d => d.LicCode)
                    .HasConstraintName("FK_LICENSEA_REFERENCE_ARGLICEN");

                entity.HasOne(d => d.LicStatusNavigation)
                    .WithMany(p => p.LicenseAgreement)
                    .HasForeignKey(d => d.LicStatus)
                    .HasConstraintName("FK_LICENSEA_REFERENCE_AGREEMEN");

                entity.HasOne(d => d.LicTypeNavigation)
                    .WithMany(p => p.LicenseAgreement)
                    .HasForeignKey(d => d.LicType)
                    .HasConstraintName("FK_LICENSEA_REFERENCE_LICENSET");

                entity.HasOne(d => d.ParentLic)
                    .WithMany(p => p.InverseParentLic)
                    .HasForeignKey(d => d.ParentLicId)
                    .HasConstraintName("FK_LICENSEA_REFERENCE_LICENSEA");

                entity.HasOne(d => d.PeriodCodeNavigation)
                    .WithMany(p => p.LicenseAgreement)
                    .HasForeignKey(d => d.PeriodCode)
                    .HasConstraintName("FK_LICENSEA_REFERENCE_PERIOD");
            });

            modelBuilder.Entity<LicenseBigR>(entity =>
            {
                entity.HasKey(e => e.LicId);

                entity.ToTable("LicenseBigR", "dbo");

                entity.Property(e => e.LicId)
                    .HasColumnName("licId")
                    .ValueGeneratedNever();

                entity.Property(e => e.DatePremiere)
                    .HasColumnName("datePremiere")
                    .HasColumnType("date");

                entity.Property(e => e.FillingRate)
                    .HasColumnName("fillingRate")
                    .HasColumnType("numeric(10, 5)");

                entity.Property(e => e.IsTour).HasColumnName("isTour");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.PerfomNumb).HasColumnName("perfomNumb");

                entity.Property(e => e.TicketPriceNc)
                    .HasColumnName("ticketPriceNC")
                    .HasColumnType("money");

                entity.Property(e => e.TicketPriceUsd)
                    .HasColumnName("ticketPriceUSD")
                    .HasColumnType("money");

                entity.Property(e => e.WhereTour)
                    .HasColumnName("whereTour")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lic)
                    .WithOne(p => p.LicenseBigR)
                    .HasForeignKey<LicenseBigR>(d => d.LicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICENSEB_REFERENCE_LICENSEA");

                entity.HasOne(d => d.Obj)
                    .WithMany(p => p.LicenseBigR)
                    .HasForeignKey(d => d.ObjId)
                    .HasConstraintName("FK_LICENSEB_REFERENCE_OBJECTRI");
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

            modelBuilder.Entity<LicPlace>(entity =>
            {
                entity.HasKey(e => new { e.LicId, e.PlaceId });

                entity.ToTable("licPlace", "dbo");

                entity.Property(e => e.LicId).HasColumnName("licId");

                entity.Property(e => e.PlaceId).HasColumnName("placeId");

                entity.HasOne(d => d.Lic)
                    .WithMany(p => p.LicPlace)
                    .HasForeignKey(d => d.LicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICPLACE_REFERENCE_LICENSEA");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.LicPlace)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICPLACE_REFERENCE_CLNBUSIN");
            });

            modelBuilder.Entity<LicPlaceHoll>(entity =>
            {
                entity.HasKey(e => new { e.LicId, e.PlaceId, e.HollId });

                entity.ToTable("licPlaceHoll", "dbo");

                entity.Property(e => e.LicId).HasColumnName("licId");

                entity.Property(e => e.PlaceId).HasColumnName("placeId");

                entity.Property(e => e.HollId).HasColumnName("hollId");

                entity.HasOne(d => d.Holl)
                    .WithMany(p => p.LicPlaceHoll)
                    .HasForeignKey(d => d.HollId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICPLACE_REFERENCE_CLNPLACE");

                entity.HasOne(d => d.LicPlace)
                    .WithMany(p => p.LicPlaceHoll)
                    .HasForeignKey(d => new { d.LicId, d.PlaceId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICPLACE_REFERENCE_LICPLACE");
            });

            modelBuilder.Entity<MediaFile>(entity =>
            {
                entity.ToTable("MediaFile", "dbo");

                entity.Property(e => e.MediaFileId).HasColumnName("mediaFileId");

                entity.Property(e => e.Compress).HasColumnName("compress");

                entity.Property(e => e.FileType)
                    .HasColumnName("fileType")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.PlayTime).HasColumnName("playTime");

                entity.HasOne(d => d.Obj)
                    .WithMany(p => p.MediaFile)
                    .HasForeignKey(d => d.ObjId)
                    .HasConstraintName("FK_MEDIAFIL_ASSOCIATI_MEDIATRA");
            });

            modelBuilder.Entity<MediaSearchData>(entity =>
            {
                entity.ToTable("MediaSearchData", "dbo");

                entity.HasIndex(e => new { e.TypeData, e.AlterNameNormalize, e.ObjId })
                    .HasName("search_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlterName)
                    .IsRequired()
                    .HasColumnName("alterName")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.AlterNameNormalize)
                    .IsRequired()
                    .HasColumnName("alterNameNormalize")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.TypeData).HasColumnName("typeData");
            });

            modelBuilder.Entity<MediaTrack>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.ToTable("MediaTrack", "dbo");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Album)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Composers)
                    .HasColumnName("composers")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Iswc)
                    .HasColumnName("iswc")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Label)
                    .HasColumnName("label")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Lyrics)
                    .HasColumnName("lyrics")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyLogin)
                    .HasColumnName("modifyLogin")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.NumberInAlbum).HasColumnName("numberInAlbum");

                entity.Property(e => e.Performers)
                    .HasColumnName("performers")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Obj)
                    .WithOne(p => p.MediaTrack)
                    .HasForeignKey<MediaTrack>(d => d.ObjId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEDIATRA_ASSOCIATI_OBJECTRI");
            });

            modelBuilder.Entity<ModifyMusicType>(entity =>
            {
                entity.HasKey(e => e.ModifyMusicTypeCode);

                entity.ToTable("ModifyMusicType", "dbo");

                entity.Property(e => e.ModifyMusicTypeCode)
                    .HasColumnName("modifyMusicTypeCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.KindCompCode).HasColumnName("kindCompCode");

                entity.Property(e => e.ModifyMusicTypeNameEn)
                    .HasColumnName("modifyMusicTypeNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyMusicTypeNameRu)
                    .HasColumnName("modifyMusicTypeNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyMusicTypeNameUk)
                    .HasColumnName("modifyMusicTypeNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.ModifyMusicType)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MODIFYMU_REFERENCE_CATEGORY");

                entity.HasOne(d => d.KindCompCodeNavigation)
                    .WithMany(p => p.ModifyMusicType)
                    .HasForeignKey(d => d.KindCompCode)
                    .HasConstraintName("FK_MODIFYMU_REFERENCE_KINDCOMP");
            });

            modelBuilder.Entity<ModifyTextType>(entity =>
            {
                entity.HasKey(e => e.ModifyTextTypeCode);

                entity.ToTable("ModifyTextType", "dbo");

                entity.Property(e => e.ModifyTextTypeCode)
                    .HasColumnName("modifyTextTypeCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.KindCompCode).HasColumnName("kindCompCode");

                entity.Property(e => e.ModifyTextTypeNameEn)
                    .HasColumnName("modifyTextTypeNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyTextTypeNameRu)
                    .HasColumnName("modifyTextTypeNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyTextTypeNameUk)
                    .HasColumnName("modifyTextTypeNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.ModifyTextType)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MODIFYTE_REFERENCE_CATEGORY");

                entity.HasOne(d => d.KindCompCodeNavigation)
                    .WithMany(p => p.ModifyTextType)
                    .HasForeignKey(d => d.KindCompCode)
                    .HasConstraintName("FK_MODIFYTE_REFERENCE_KINDCOMP");
            });

            modelBuilder.Entity<ModifyType>(entity =>
            {
                entity.HasKey(e => e.ModifyTypeCode);

                entity.ToTable("ModifyType", "dbo");

                entity.Property(e => e.ModifyTypeCode)
                    .HasColumnName("modifyTypeCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.KindCompCode).HasColumnName("kindCompCode");

                entity.Property(e => e.ModifyTypeNameEn)
                    .HasColumnName("modifyTypeNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyTypeNameRu)
                    .HasColumnName("modifyTypeNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyTypeNameUk)
                    .HasColumnName("modifyTypeNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.ModifyType)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MODIFYTY_REFERENCE_CATEGORY");

                entity.HasOne(d => d.KindCompCodeNavigation)
                    .WithMany(p => p.ModifyType)
                    .HasForeignKey(d => d.KindCompCode)
                    .HasConstraintName("FK_MODIFYTY_REFERENCE_KINDCOMP");
            });

            modelBuilder.Entity<MoneyPeriodLink>(entity =>
            {
                entity.HasKey(e => new { e.PaidId, e.PeriodId });

                entity.ToTable("MoneyPeriodLink", "dbo");

                entity.Property(e => e.PaidId).HasColumnName("paidId");

                entity.Property(e => e.PeriodId).HasColumnName("periodId");

                entity.Property(e => e.AgrId).HasColumnName("agrId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.LicId).HasColumnName("licId");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Agr)
                    .WithMany(p => p.MoneyPeriodLink)
                    .HasForeignKey(d => d.AgrId)
                    .HasConstraintName("FK_MONEYPER_REFERENCE_AGREEMEN");

                entity.HasOne(d => d.Lic)
                    .WithMany(p => p.MoneyPeriodLink)
                    .HasForeignKey(d => d.LicId)
                    .HasConstraintName("FK_MONEYPER_REFERENCE_LICENSEA");

                entity.HasOne(d => d.Paid)
                    .WithMany(p => p.MoneyPeriodLink)
                    .HasForeignKey(d => d.PaidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYPER_REFERENCE_MONEYREC");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.MoneyPeriodLink)
                    .HasForeignKey(d => d.PeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYPER_REFERENCE_PAIDPERI");
            });

            modelBuilder.Entity<MoneyReceived>(entity =>
            {
                entity.HasKey(e => e.PaidId);

                entity.ToTable("MoneyReceived", "dbo");

                entity.Property(e => e.PaidId)
                    .HasColumnName("paidId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.DateInvoice)
                    .HasColumnName("dateInvoice")
                    .HasColumnType("date");

                entity.Property(e => e.DestribAmount)
                    .HasColumnName("destribAmount")
                    .HasColumnType("money");

                entity.Property(e => e.GoalInvoice)
                    .IsRequired()
                    .HasColumnName("goalInvoice")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.MoneyType).HasColumnName("moneyType");

                entity.Property(e => e.NumberInvoice)
                    .IsRequired()
                    .HasColumnName("numberInvoice")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.MoneyReceived)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYREC_REFERENCE_CLIENT");

                entity.HasOne(d => d.MoneyTypeNavigation)
                    .WithMany(p => p.MoneyReceived)
                    .HasForeignKey(d => d.MoneyType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYREC_REFERENCE_MONEYTYP");
            });

            modelBuilder.Entity<MoneyType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("MoneyType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MoneyTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeI, e.Lang });

                entity.ToTable("MoneyTypeTr", "dbo");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.MoneyTypeTr)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYTYP_REFERENCE_MONEYTYP");
            });

            modelBuilder.Entity<MyAnketa>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("MyAnketa", "dbo");

                entity.Property(e => e.CustId)
                    .HasColumnName("custId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccCommission)
                    .HasColumnName("accCommission")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AccCompany)
                    .HasColumnName("accCompany")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AccCourt)
                    .HasColumnName("accCourt")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AccInCommission)
                    .HasColumnName("accInCommission")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.MyAnketa)
                    .HasForeignKey<MyAnketa>(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MYANKETA_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<MyCategory>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.CodeI });

                entity.ToTable("MyCategory", "dbo");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.MyCategory)
                    .HasForeignKey(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MYCATEGO_REFERENCE_CATEGORY");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.MyCategory)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MYCATEGO_REFERENCE_MYANKETA");
            });

            modelBuilder.Entity<MyCopyRightType>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.CRtype });

                entity.ToTable("myCopyRightType", "dbo");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.CRtype).HasColumnName("cRType");

                entity.HasOne(d => d.CRtypeNavigation)
                    .WithMany(p => p.MyCopyRightType)
                    .HasForeignKey(d => d.CRtype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MYCOPYRI_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.MyCopyRightType)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MYCOPYRI_REFERENCE_MYANKETA");
            });

            modelBuilder.Entity<ObjectRight>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.ToTable("ObjectRight", "dbo");

                entity.HasIndex(e => e.ReqId)
                    .HasName("Relationship_13_FK");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Loadid).HasColumnName("loadid");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyLogin)
                    .HasColumnName("modifyLogin")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ObjImg)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ObjType).HasColumnName("objType");

                entity.Property(e => e.Performer)
                    .HasColumnName("performer")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.ObjectRight)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_OBJECTRI_REFERENCE_OBJECTST");

                entity.HasOne(d => d.ObjectType)
                    .WithMany(p => p.ObjectRight)
                    .HasForeignKey(d => new { d.ObjType, d.CategoryCode })
                    .HasConstraintName("FK_OBJECTRI_REFERENCE_OBJECTTY");
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

            modelBuilder.Entity<PaidPeriod>(entity =>
            {
                entity.HasKey(e => e.PeriodId);

                entity.ToTable("PaidPeriod", "dbo");

                entity.Property(e => e.PeriodId).HasColumnName("periodId");

                entity.Property(e => e.AgrId).HasColumnName("agrId");

                entity.Property(e => e.AlgType).HasColumnName("algType");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.BeginDate)
                    .HasColumnName("beginDate")
                    .HasColumnType("date");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.Distribamount)
                    .HasColumnName("distribamount")
                    .HasColumnType("money");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.FagFirst).HasColumnName("fagFirst");

                entity.Property(e => e.LicId).HasColumnName("licId");

                entity.Property(e => e.PeriodName)
                    .IsRequired()
                    .HasColumnName("periodName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodType).HasColumnName("periodType");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Undistribamount)
                    .HasColumnName("undistribamount")
                    .HasColumnType("money");

                entity.HasOne(d => d.Agr)
                    .WithMany(p => p.PaidPeriod)
                    .HasForeignKey(d => d.AgrId)
                    .HasConstraintName("FK_PAIDPERI_REFERENCE_AGREEMEN");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.PaidPeriod)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAIDPERI_REFERENCE_CLIENT");

                entity.HasOne(d => d.Lic)
                    .WithMany(p => p.PaidPeriod)
                    .HasForeignKey(d => d.LicId)
                    .HasConstraintName("FK_PAIDPERI_REFERENCE_LICENSEA");

                entity.HasOne(d => d.PeriodTypeNavigation)
                    .WithMany(p => p.PaidPeriod)
                    .HasForeignKey(d => d.PeriodType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAIDPERI_REFERENCE_PERIOD");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.PaidPeriod)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAIDPERI_REFERENCE_PERIODST");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("Partner", "dbo");

                entity.Property(e => e.CustId)
                    .HasColumnName("custId")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.Partner)
                    .HasForeignKey<Partner>(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARTNER_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<PaymentCase>(entity =>
            {
                entity.HasKey(e => e.ReqId);

                entity.ToTable("PaymentCase", "dbo");

                entity.Property(e => e.ReqId)
                    .HasColumnName("reqId")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateForPay)
                    .HasColumnName("dateForPay")
                    .HasColumnType("date");

                entity.Property(e => e.DateInvoce)
                    .HasColumnName("dateInvoce")
                    .HasColumnType("date");

                entity.Property(e => e.DatePay)
                    .HasColumnName("datePay")
                    .HasColumnType("date");

                entity.Property(e => e.DatePayFact)
                    .HasColumnName("datePayFact")
                    .HasColumnType("date");

                entity.Property(e => e.OtherCase)
                    .HasColumnName("otherCase")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.PayKind).HasColumnName("payKind");

                entity.Property(e => e.PayMethod).HasColumnName("payMethod");

                entity.Property(e => e.PayStatus).HasColumnName("payStatus");

                entity.Property(e => e.PtId).HasColumnName("ptId");

                entity.HasOne(d => d.PayKindNavigation)
                    .WithMany(p => p.PaymentCase)
                    .HasForeignKey(d => d.PayKind)
                    .HasConstraintName("FK_PAYMENTC_REFERENCE_PAYMENTK");

                entity.HasOne(d => d.PayMethodNavigation)
                    .WithMany(p => p.PaymentCase)
                    .HasForeignKey(d => d.PayMethod)
                    .HasConstraintName("FK_PAYMENTC_REFERENCE_PAYMETHO");

                entity.HasOne(d => d.Req)
                    .WithOne(p => p.PaymentCase)
                    .HasForeignKey<PaymentCase>(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMENTC_REFERENCE_REQUEST");
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

            modelBuilder.Entity<PayTurn>(entity =>
            {
                entity.HasKey(e => new { e.TurnId, e.DateWork });

                entity.ToTable("PayTurn", "dbo");

                entity.Property(e => e.TurnId).HasColumnName("turnId");

                entity.Property(e => e.DateWork)
                    .HasColumnName("dateWork")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccCredit)
                    .HasColumnName("accCredit")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AccDebet)
                    .HasColumnName("accDebet")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AccIdCredit).HasColumnName("accIdCredit");

                entity.Property(e => e.AccIdDebet).HasColumnName("accIdDebet");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.AmountCur)
                    .HasColumnName("amountCur")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.DateOper)
                    .HasColumnName("dateOper")
                    .HasColumnType("date");

                entity.Property(e => e.DistId).HasColumnName("distId");

                entity.Property(e => e.ND)
                    .HasColumnName("nD")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NDdate)
                    .HasColumnName("nDDate")
                    .HasColumnType("date");

                entity.Property(e => e.PayNote)
                    .HasColumnName("payNote")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.PayStatus).HasColumnName("payStatus");

                entity.Property(e => e.R030)
                    .HasColumnName("r030")
                    .HasColumnType("char(3)");

                entity.Property(e => e.RegId).HasColumnName("regId");

                entity.HasOne(d => d.AccIdDebetNavigation)
                    .WithMany(p => p.PayTurn)
                    .HasForeignKey(d => d.AccIdDebet)
                    .HasConstraintName("FK_PAYTURN_REFERENCE_ACCOUNT");

                entity.HasOne(d => d.PayStatusNavigation)
                    .WithMany(p => p.PayTurn)
                    .HasForeignKey(d => d.PayStatus)
                    .HasConstraintName("FK_PAYTURN_REFERENCE_PAYMENTS");
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

            modelBuilder.Entity<PeriodStatus>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("PeriodStatus", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PeriodStatusTr>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("PeriodStatusTr", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Lang)
                    .IsRequired()
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeINavigation)
                    .WithOne(p => p.PeriodStatusTr)
                    .HasForeignKey<PeriodStatusTr>(d => d.CodeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERIODST_REFERENCE_PERIODST");
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

            modelBuilder.Entity<PermitType>(entity =>
            {
                entity.HasKey(e => e.CodeB);

                entity.ToTable("PermitType", "dbo");

                entity.Property(e => e.CodeB).HasColumnName("codeB");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PermitTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.CodeB, e.Lang });

                entity.ToTable("PermitTypeTr", "dbo");

                entity.Property(e => e.CodeB).HasColumnName("codeB");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeBNavigation)
                    .WithMany(p => p.PermitTypeTr)
                    .HasForeignKey(d => d.CodeB)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERMITTY_REFERENCE_PERMITTY");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("Person", "dbo");

                entity.HasIndex(e => e.CustId)
                    .HasName("Association21_FK");

                entity.HasIndex(e => new { e.CustId, e.Version })
                    .HasName("Association24_FK");

                entity.Property(e => e.CustId)
                    .HasColumnName("custId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERSON_ASSOCIATI_CUSTOMER");
            });

            modelBuilder.Entity<PortalObjectRights>(entity =>
            {
                entity.HasKey(e => new { e.ObjId, e.CRkindCode });

                entity.ToTable("PortalObjectRights", "dbo");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.CRkindCode).HasColumnName("cRKindCode");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.HasOne(d => d.CRkindCodeNavigation)
                    .WithMany(p => p.PortalObjectRights)
                    .HasForeignKey(d => d.CRkindCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PORTALOB_REFERENCE_PORTALSU");

                entity.HasOne(d => d.Obj)
                    .WithMany(p => p.PortalObjectRights)
                    .HasForeignKey(d => d.ObjId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PORTALOB_REFERENCE_OBJECTRI");
            });

            modelBuilder.Entity<PortalSupportRights>(entity =>
            {
                entity.HasKey(e => e.CRkindCode);

                entity.ToTable("PortalSupportRights", "dbo");

                entity.Property(e => e.CRkindCode)
                    .HasColumnName("cRKindCode")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.CRkindCodeNavigation)
                    .WithOne(p => p.PortalSupportRights)
                    .HasForeignKey<PortalSupportRights>(d => d.CRkindCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PORTALOB_REFERENCE_COPYRIGH");
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

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.RegId);

                entity.ToTable("Register", "dbo");

                entity.Property(e => e.RegId).HasColumnName("regId");

                entity.Property(e => e.CountRows).HasColumnName("countRows");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.DurationItems).HasColumnName("durationItems");

                entity.Property(e => e.FileName)
                    .HasColumnName("fileName")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodId).HasColumnName("periodId");

                entity.Property(e => e.RgStatus).HasColumnName("rgStatus");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(48);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Register)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_REGISTER_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.RgStatusNavigation)
                    .WithMany(p => p.Register)
                    .HasForeignKey(d => d.RgStatus)
                    .HasConstraintName("FK_REGISTER_REFERENCE_REGISTER2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Register)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_REGISTER_REFERENCE_ASPNETUS");
            });

            modelBuilder.Entity<RegisterCount>(entity =>
            {
                entity.HasKey(e => e.RegCntId);

                entity.ToTable("RegisterCount", "dbo");

                entity.Property(e => e.RegCntId)
                    .HasColumnName("regCntId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CRkindCode).HasColumnName("cRKindCode");

                entity.Property(e => e.CRtype).HasColumnName("cRType");

                entity.Property(e => e.CmCustId).HasColumnName("cmCustId");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.RateCommiss)
                    .HasColumnName("rateCommiss")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.RegId).HasColumnName("regId");

                entity.Property(e => e.RegIdBr).HasColumnName("regIdBr");

                entity.Property(e => e.RegIitemId).HasColumnName("regIItemId");

                entity.Property(e => e.RegItemIdBr).HasColumnName("regItemIdBr");

                entity.HasOne(d => d.CRkindCodeNavigation)
                    .WithMany(p => p.RegisterCount)
                    .HasForeignKey(d => d.CRkindCode)
                    .HasConstraintName("FK_REGISTER_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.CmCust)
                    .WithMany(p => p.RegisterCount)
                    .HasForeignKey(d => d.CmCustId)
                    .HasConstraintName("FK_REGISTER_REFERENCE_COMMUNIT");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.RegisterCount)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_REGISTER_REFERENCE_RIGHTHOL");

                entity.HasOne(d => d.RegI)
                    .WithMany(p => p.RegisterCount)
                    .HasForeignKey(d => new { d.RegId, d.RegIitemId })
                    .HasConstraintName("FK_REGISTER_REFEREN_REGISTER");
            });

            modelBuilder.Entity<RegisterItem>(entity =>
            {
                entity.HasKey(e => new { e.RegId, e.RegIitemId });

                entity.ToTable("RegisterItem", "dbo");

                entity.Property(e => e.RegId).HasColumnName("regId");

                entity.Property(e => e.RegIitemId).HasColumnName("regIItemId");

                entity.Property(e => e.AuthorMusic)
                    .HasColumnName("authorMusic")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorText)
                    .HasColumnName("authorText")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.CountUse).HasColumnName("countUse");

                entity.Property(e => e.DurationItem).HasColumnName("durationItem");

                entity.Property(e => e.DurationUse).HasColumnName("durationUse");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyLogin)
                    .HasColumnName("modifyLogin")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.Performer)
                    .HasColumnName("performer")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Obj)
                    .WithMany(p => p.RegisterItem)
                    .HasForeignKey(d => d.ObjId)
                    .HasConstraintName("FK_REGISTER_REFERENCE_OBJECTRI");

                entity.HasOne(d => d.Reg)
                    .WithMany(p => p.RegisterItem)
                    .HasForeignKey(d => d.RegId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGISTER_REFERENCE_REGISTERItem");
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

            modelBuilder.Entity<RelAdaptUseArea>(entity =>
            {
                entity.HasKey(e => new { e.ReqId, e.UseAreaTypeCode });

                entity.ToTable("RelAdaptUseArea", "dbo");

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.Property(e => e.UseAreaTypeCode).HasColumnName("useAreaTypeCode");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.RelAdaptUseArea)
                    .HasForeignKey(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELADAPT_REFERENCE_REQUESTA");

                entity.HasOne(d => d.UseAreaTypeCodeNavigation)
                    .WithMany(p => p.RelAdaptUseArea)
                    .HasForeignKey(d => d.UseAreaTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELADAPT_REFERENCE_USEAREAT");
            });

            modelBuilder.Entity<RelEmployee>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.Emplid, e.PositionCode });

                entity.ToTable("RelEmployee", "dbo");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.Emplid).HasColumnName("emplid");

                entity.Property(e => e.PositionCode).HasColumnName("positionCode");

                entity.Property(e => e.RelDocument)
                    .HasColumnName("relDocument")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.RelEmployee)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELEMPLO_ASSOCIATI_COMPANY");

                entity.HasOne(d => d.Empl)
                    .WithMany(p => p.RelEmployee)
                    .HasForeignKey(d => d.Emplid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELEMPLO_ASSOCIATI_EMPLOYEE");

                entity.HasOne(d => d.PositionCodeNavigation)
                    .WithMany(p => p.RelEmployee)
                    .HasForeignKey(d => d.PositionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELEMPLO_REFERENCE_POSITION");
            });

            modelBuilder.Entity<RelGenreAdapt>(entity =>
            {
                entity.HasKey(e => new { e.ReqId, e.GenreId });

                entity.ToTable("RelGenreAdapt", "dbo");

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.Property(e => e.GenreId).HasColumnName("genreId");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.RelGenreAdapt)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENREAD_REF_GENRE");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.RelGenreAdapt)
                    .HasForeignKey(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REFERENCE_REQUESTA");
            });

            modelBuilder.Entity<RelGenreMovie>(entity =>
            {
                entity.HasKey(e => new { e.ReqId, e.GenreId });

                entity.ToTable("RelGenreMovie", "dbo");

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.Property(e => e.GenreId).HasColumnName("genreId");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.RelGenreMovie)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REFERENCE_GENRE");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.RelGenreMovie)
                    .HasForeignKey(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REFERENCE_REQUESTM");
            });

            modelBuilder.Entity<RelGenreSerial>(entity =>
            {
                entity.HasKey(e => new { e.ReqId, e.GenreId });

                entity.ToTable("RelGenreSerial", "dbo");

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.Property(e => e.GenreId).HasColumnName("genreId");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.RelGenreSerial)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REF_GENRESERI");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.RelGenreSerial)
                    .HasForeignKey(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REF_REQUESTSERI");
            });

            modelBuilder.Entity<RelLicCopyR>(entity =>
            {
                entity.HasKey(e => new { e.AgrLlicCode, e.CRkindCode });

                entity.ToTable("relLicCopyR", "dbo");

                entity.Property(e => e.AgrLlicCode).HasColumnName("agrLlicCode");

                entity.Property(e => e.CRkindCode).HasColumnName("cRKindCode");

                entity.HasOne(d => d.AgrLlicCodeNavigation)
                    .WithMany(p => p.RelLicCopyR)
                    .HasForeignKey(d => d.AgrLlicCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELLICCO_REFERENCE_AGRLICEN");

                entity.HasOne(d => d.CRkindCodeNavigation)
                    .WithMany(p => p.RelLicCopyR)
                    .HasForeignKey(d => d.CRkindCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELLICCO_REFERENCE_COPYRIGH");
            });

            modelBuilder.Entity<RelMovieEpisode>(entity =>
            {
                entity.HasKey(e => new { e.EpisodeTypeCode, e.ReqId });

                entity.ToTable("RelMovieEpisode", "dbo");

                entity.Property(e => e.EpisodeTypeCode).HasColumnName("episodeTypeCode");

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.Property(e => e.EpDuration).HasColumnName("epDuration");

                entity.HasOne(d => d.EpisodeTypeCodeNavigation)
                    .WithMany(p => p.RelMovieEpisode)
                    .HasForeignKey(d => d.EpisodeTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELMOVIE_REFERENCE_EPISODET");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.RelMovieEpisode)
                    .HasForeignKey(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELMOVIE_REFERENCE_REQUESTM");
            });

            modelBuilder.Entity<RelObjGenre>(entity =>
            {
                entity.HasKey(e => new { e.ObjId, e.GenreId });

                entity.ToTable("RelObjGenre", "dbo");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.GenreId).HasColumnName("genreId");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.RelObjGenre)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELOBJGE_REFERENCE_GENRE");

                entity.HasOne(d => d.Obj)
                    .WithMany(p => p.RelObjGenre)
                    .HasForeignKey(d => d.ObjId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELOBJGE_REFERENCE_OBJECTRI");
            });

            modelBuilder.Entity<RelReqMedia>(entity =>
            {
                entity.HasKey(e => new { e.UseMediaTypeCode, e.ReqId });

                entity.ToTable("RelReqMedia", "dbo");

                entity.Property(e => e.UseMediaTypeCode).HasColumnName("useMediaTypeCode");

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.RelReqMedia)
                    .HasForeignKey(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELREQME_REFERENCE_REQUEST");

                entity.HasOne(d => d.UseMediaTypeCodeNavigation)
                    .WithMany(p => p.RelReqMedia)
                    .HasForeignKey(d => d.UseMediaTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELREQME_REFERENCE_USEMEDIA");
            });

            modelBuilder.Entity<RelReqObj>(entity =>
            {
                entity.HasKey(e => new { e.CategoryCode, e.ReqType, e.KindGroupId });

                entity.ToTable("RelReqObj", "dbo");

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.ReqType).HasColumnName("reqType");

                entity.Property(e => e.KindGroupId).HasColumnName("kindGroupId");

                entity.Property(e => e.CrkindCode).HasColumnName("CRKindCode");

                entity.HasOne(d => d.ReqTypeNavigation)
                    .WithMany(p => p.RelReqObj)
                    .HasForeignKey(d => d.ReqType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELREQOB_REFERENCE_REQUESTT");
            });

            modelBuilder.Entity<RelSerialEpisode>(entity =>
            {
                entity.HasKey(e => new { e.ReqId, e.EpisodeTypeCode });

                entity.ToTable("RelSerialEpisode", "dbo");

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.Property(e => e.EpisodeTypeCode).HasColumnName("episodeTypeCode");

                entity.Property(e => e.EpDuration).HasColumnName("epDuration");

                entity.HasOne(d => d.EpisodeTypeCodeNavigation)
                    .WithMany(p => p.RelSerialEpisode)
                    .HasForeignKey(d => d.EpisodeTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELSERIAEP_REF_EPISODET");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.RelSerialEpisode)
                    .HasForeignKey(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELSERIAEP_REF_REQSERIAL");
            });

            modelBuilder.Entity<RelTvepisode>(entity =>
            {
                entity.HasKey(e => new { e.ReqId, e.EpisodeTypeCode });

                entity.ToTable("RelTVEpisode", "dbo");

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.Property(e => e.EpisodeTypeCode).HasColumnName("episodeTypeCode");

                entity.Property(e => e.EpDuration).HasColumnName("epDuration");

                entity.HasOne(d => d.EpisodeTypeCodeNavigation)
                    .WithMany(p => p.RelTvepisode)
                    .HasForeignKey(d => d.EpisodeTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELTVEPI_REFERENCE_EPISODET");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.RelTvepisode)
                    .HasForeignKey(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELTVEPI_REFERENCE_REQUESTT");
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.ToTable("Reports", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Repname)
                    .HasColumnName("repname")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReqAgreement>(entity =>
            {
                entity.HasKey(e => e.RAgrId);

                entity.ToTable("ReqAgreement", "dbo");

                entity.HasIndex(e => e.CustId)
                    .HasName("Association16_FK");

                entity.HasIndex(e => e.CustIdRh)
                    .HasName("Association15_FK");

                entity.Property(e => e.RAgrId).HasColumnName("rAgrId");

                entity.Property(e => e.AgrDate)
                    .HasColumnName("agrDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.CostOffer)
                    .HasColumnName("costOffer")
                    .HasColumnType("money");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.CustIdRh).HasColumnName("custIdRh");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.R030)
                    .IsRequired()
                    .HasColumnName("r030")
                    .HasColumnType("char(3)");

                entity.Property(e => e.R030Offer)
                    .HasColumnName("r030Offer")
                    .HasColumnType("char(3)");

                entity.Property(e => e.RAgrComment)
                    .HasColumnName("rAgrComment")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StatusDate)
                    .HasColumnName("statusDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TradeId).HasColumnName("tradeId");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(48);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.ReqAgreement)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQAGREE_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.CustIdRhNavigation)
                    .WithMany(p => p.ReqAgreement)
                    .HasForeignKey(d => d.CustIdRh)
                    .HasConstraintName("FK_REQAGREE_REFERENCE_RIGHTHOL");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.ReqAgreement)
                    .HasForeignKey(d => d.ReqId)
                    .HasConstraintName("FK_REQAGREE_REFERENCE_REQUEST");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.ReqAgreement)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQAGREE_REFERENCE_REQAGREE");
            });

            modelBuilder.Entity<ReqAgreementStatus>(entity =>
            {
                entity.HasKey(e => e.StatusCode);

                entity.ToTable("ReqAgreementStatus", "dbo");

                entity.Property(e => e.StatusCode)
                    .HasColumnName("statusCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.StatusNameEn)
                    .HasColumnName("statusNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusNameRu)
                    .HasColumnName("statusNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusNameUk)
                    .HasColumnName("statusNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReqCustomer>(entity =>
            {
                entity.HasKey(e => e.ReqCustId);

                entity.ToTable("ReqCustomer", "dbo");

                entity.Property(e => e.ReqCustId).HasColumnName("reqCustId");

                entity.Property(e => e.ActivityCode).HasColumnName("activityCode");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasColumnType("char(3)");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasColumnName("nickName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Okpo)
                    .HasColumnName("okpo")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActivityCodeNavigation)
                    .WithMany(p => p.ReqCustomer)
                    .HasForeignKey(d => d.ActivityCode)
                    .HasConstraintName("FK_REQCUSTO_REFERENCE_ACTIVITY");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.ReqCustomer)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK_REQCUSTO_REFERENCE_COUNTRY");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.ReqCustomer)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_REQCUSTO_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<ReqLocationUse>(entity =>
            {
                entity.HasKey(e => e.LocUsId);

                entity.ToTable("ReqLocationUse", "dbo");

                entity.Property(e => e.LocUsId).HasColumnName("locUsId");

                entity.Property(e => e.ContinentCode).HasColumnName("continentCode");

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasColumnType("char(3)");

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.HasOne(d => d.ContinentCodeNavigation)
                    .WithMany(p => p.ReqLocationUse)
                    .HasForeignKey(d => d.ContinentCode)
                    .HasConstraintName("FK_REQLOCAT_REFERENCE_CONTINEN");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.ReqLocationUse)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK_REQLOCAT_REFERENCE_COUNTRY");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.ReqLocationUse)
                    .HasForeignKey(d => d.ReqId)
                    .HasConstraintName("FK_REQLOCAT_REFERENCE_REQUEST");
            });

            modelBuilder.Entity<ReqTrade>(entity =>
            {
                entity.HasKey(e => e.TradeId);

                entity.ToTable("ReqTrade", "dbo");

                entity.Property(e => e.TradeId).HasColumnName("tradeId");

                entity.Property(e => e.CauseCode).HasColumnName("causeCode");

                entity.Property(e => e.CostClient)
                    .HasColumnName("costClient")
                    .HasColumnType("money");

                entity.Property(e => e.CostRholder)
                    .HasColumnName("costRHolder")
                    .HasColumnType("money");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.R030)
                    .IsRequired()
                    .HasColumnName("r030")
                    .HasColumnType("char(3)");

                entity.Property(e => e.RAgrId).HasColumnName("rAgrId");

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StatusDate)
                    .HasColumnName("statusDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TradeComment)
                    .HasColumnName("tradeComment")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.CauseCodeNavigation)
                    .WithMany(p => p.ReqTrade)
                    .HasForeignKey(d => d.CauseCode)
                    .HasConstraintName("FK_REQTRADE_REFERENCE_COMMENTC");

                entity.HasOne(d => d.RAgr)
                    .WithMany(p => p.ReqTrade)
                    .HasForeignKey(d => d.RAgrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQTRADE_REFERENCE_REQAGREE");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.ReqTrade)
                    .HasForeignKey(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQTRADE_REFERENCE_REQUEST");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.ReqTrade)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQTRADE_REFERENCE_TRADESTA");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.ReqId);

                entity.ToTable("Request", "dbo");

                entity.Property(e => e.ReqId).HasColumnName("reqId");

                entity.Property(e => e.BeginDate)
                    .HasColumnName("beginDate")
                    .HasColumnType("date");

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.CountUse).HasColumnName("countUse");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.DurationUse).HasColumnName("durationUse");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.KindCompCode).HasColumnName("kindCompCode");

                entity.Property(e => e.LicCode).HasColumnName("licCode");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyLogin)
                    .HasColumnName("modifyLogin")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.R030)
                    .HasColumnName("r030")
                    .HasColumnType("char(3)");

                entity.Property(e => e.ReqAimCode).HasColumnName("reqAimCode");

                entity.Property(e => e.ReqAmount)
                    .HasColumnName("reqAmount")
                    .HasColumnType("money");

                entity.Property(e => e.ReqComment)
                    .HasColumnName("reqComment")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ReqCustId).HasColumnName("reqCustId");

                entity.Property(e => e.ReqDate)
                    .HasColumnName("reqDate")
                    .HasColumnType("date");

                entity.Property(e => e.ReqType).HasColumnName("reqType");

                entity.Property(e => e.Reqstatus).HasColumnName("reqstatus");

                entity.Property(e => e.TermUseCode).HasColumnName("termUseCode");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(48);

                entity.Property(e => e.WorkName)
                    .HasColumnName("workName")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.CategoryCode)
                    .HasConstraintName("FK_REQUEST_REFERENCE_CATEGORY");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_REQUEST_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.KindCompCodeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.KindCompCode)
                    .HasConstraintName("FK_REQUEST_REFERENCE_KINDCOMP");

                entity.HasOne(d => d.LicCodeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.LicCode)
                    .HasConstraintName("FK_REQUEST_REFERENCE_LICENSET");

                entity.HasOne(d => d.Obj)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.ObjId)
                    .HasConstraintName("FK_REQUEST_REFERENCE_OBJECTRI");

                entity.HasOne(d => d.ReqAimCodeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.ReqAimCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUEST_REFERENCE_REQUESTA");

                entity.HasOne(d => d.ReqCust)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.ReqCustId)
                    .HasConstraintName("FK_REQUEST_REFERENCE_REQCUSTO");

                entity.HasOne(d => d.ReqTypeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.ReqType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUEST_REFERENCE_REQUESTT");

                entity.HasOne(d => d.ReqstatusNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.Reqstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUEST_REFERENCE_REQUESTS");

                entity.HasOne(d => d.TermUseCodeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.TermUseCode)
                    .HasConstraintName("FK_REQUEST_REFERENCE_TERMUSE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_REQUEST_REFERENCE_ASPNETUS");
            });

            modelBuilder.Entity<RequestAdapt>(entity =>
            {
                entity.HasKey(e => e.ReqId);

                entity.ToTable("RequestAdapt", "dbo");

                entity.Property(e => e.ReqId)
                    .HasColumnName("reqId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExecNick)
                    .HasColumnName("execNick")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyMusicType).HasColumnName("modifyMusicType");

                entity.Property(e => e.ModifyMusictComment)
                    .HasColumnName("modifyMusictComment")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyTextComment)
                    .HasColumnName("modifyTextComment")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyTextType).HasColumnName("modifyTextType");

                entity.Property(e => e.ModifyType).HasColumnName("modifyType");

                entity.Property(e => e.UseAreaComment)
                    .HasColumnName("useAreaComment")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.ModifyMusicTypeNavigation)
                    .WithMany(p => p.RequestAdapt)
                    .HasForeignKey(d => d.ModifyMusicType)
                    .HasConstraintName("FK_REQUESTA_REFERENCE_MODIFYMU");

                entity.HasOne(d => d.ModifyTextTypeNavigation)
                    .WithMany(p => p.RequestAdapt)
                    .HasForeignKey(d => d.ModifyTextType)
                    .HasConstraintName("FK_REQUESTA_REFERENCE_MODIFYTE");

                entity.HasOne(d => d.ModifyTypeNavigation)
                    .WithMany(p => p.RequestAdapt)
                    .HasForeignKey(d => d.ModifyType)
                    .HasConstraintName("FK_REQUESTA_REFERENCE_MODIFYTY");

                entity.HasOne(d => d.Req)
                    .WithOne(p => p.RequestAdapt)
                    .HasForeignKey<RequestAdapt>(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTA_REF_REQUESTADA");
            });

            modelBuilder.Entity<RequestAdvertising>(entity =>
            {
                entity.HasKey(e => e.ReqId);

                entity.ToTable("RequestAdvertising", "dbo");

                entity.Property(e => e.ReqId)
                    .HasColumnName("reqId")
                    .ValueGeneratedNever();

                entity.Property(e => e.DurationAll).HasColumnName("durationAll");

                entity.Property(e => e.DurationShort).HasColumnName("durationShort");

                entity.Property(e => e.TradeMark)
                    .HasColumnName("tradeMark")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.Req)
                    .WithOne(p => p.RequestAdvertising)
                    .HasForeignKey<RequestAdvertising>(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTA_REF_REQUESTADV");
            });

            modelBuilder.Entity<RequestAim>(entity =>
            {
                entity.HasKey(e => e.ReqAimCode);

                entity.ToTable("RequestAim", "dbo");

                entity.Property(e => e.ReqAimCode)
                    .HasColumnName("reqAimCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.ReqAimNameEn)
                    .HasColumnName("reqAimNameEn")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReqAimNameRu)
                    .HasColumnName("reqAimNameRu")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReqAimNameUk)
                    .HasColumnName("reqAimNameUk")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReqType).HasColumnName("reqType");

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.RequestAim)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTA_REFERENCE_CATEGORY");

                entity.HasOne(d => d.ReqTypeNavigation)
                    .WithMany(p => p.RequestAim)
                    .HasForeignKey(d => d.ReqType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTA_REFERENCE_REQUESTT");
            });

            modelBuilder.Entity<RequestInternet>(entity =>
            {
                entity.HasKey(e => e.ReqId);

                entity.ToTable("RequestInternet", "dbo");

                entity.Property(e => e.ReqId)
                    .HasColumnName("reqId")
                    .ValueGeneratedNever();

                entity.Property(e => e.TypeInternetObject).HasColumnName("typeInternetObject");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.UseDesc)
                    .HasColumnName("useDesc")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.Req)
                    .WithOne(p => p.RequestInternet)
                    .HasForeignKey<RequestInternet>(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTI_REF_INTERNREQUEST");

                entity.HasOne(d => d.TypeInternetObjectNavigation)
                    .WithMany(p => p.RequestInternet)
                    .HasForeignKey(d => d.TypeInternetObject)
                    .HasConstraintName("FK_REQUESTI_REFERENCE_TYPEINTE");
            });

            modelBuilder.Entity<RequestMovie>(entity =>
            {
                entity.HasKey(e => e.ReqId);

                entity.ToTable("RequestMovie", "dbo");

                entity.Property(e => e.ReqId)
                    .HasColumnName("reqId")
                    .ValueGeneratedNever();

                entity.Property(e => e.EpisodeComment)
                    .HasColumnName("episodeComment")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.KindFilm).HasColumnName("kindFilm");

                entity.HasOne(d => d.KindFilmNavigation)
                    .WithMany(p => p.RequestMovie)
                    .HasForeignKey(d => d.KindFilm)
                    .HasConstraintName("FK_REQUESTM_REFERENCE_KINDFILM");

                entity.HasOne(d => d.Req)
                    .WithOne(p => p.RequestMovie)
                    .HasForeignKey<RequestMovie>(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTM_REFERENCE_REQUEST");
            });

            modelBuilder.Entity<RequestOther>(entity =>
            {
                entity.HasKey(e => e.ReqId);

                entity.ToTable("RequestOther", "dbo");

                entity.Property(e => e.ReqId)
                    .HasColumnName("reqId")
                    .ValueGeneratedNever();

                entity.Property(e => e.UseDesc)
                    .IsRequired()
                    .HasColumnName("useDesc")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.Req)
                    .WithOne(p => p.RequestOther)
                    .HasForeignKey<RequestOther>(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTO_REFERENCE_REQUEST");
            });

            modelBuilder.Entity<RequestSerial>(entity =>
            {
                entity.HasKey(e => e.ReqId);

                entity.ToTable("RequestSerial", "dbo");

                entity.Property(e => e.ReqId)
                    .HasColumnName("reqId")
                    .ValueGeneratedNever();

                entity.Property(e => e.CntSeries).HasColumnName("cntSeries");

                entity.Property(e => e.EpisodeComment)
                    .HasColumnName("episodeComment")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.KindSerial).HasColumnName("kindSerial");

                entity.HasOne(d => d.KindSerialNavigation)
                    .WithMany(p => p.RequestSerial)
                    .HasForeignKey(d => d.KindSerial)
                    .HasConstraintName("FK_REQUESTS_REFERENCE_KINDSERI");

                entity.HasOne(d => d.Req)
                    .WithOne(p => p.RequestSerial)
                    .HasForeignKey<RequestSerial>(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTS_REF_REQUESTS");
            });

            modelBuilder.Entity<RequestStatusType>(entity =>
            {
                entity.HasKey(e => e.ReqStatusCode);

                entity.ToTable("RequestStatusType", "dbo");

                entity.Property(e => e.ReqStatusCode)
                    .HasColumnName("reqStatusCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.ReqStatusNameEn)
                    .HasColumnName("reqStatusNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReqStatusNameRu)
                    .HasColumnName("reqStatusNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReqStatusNameUk)
                    .HasColumnName("reqStatusNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequestTvradio>(entity =>
            {
                entity.HasKey(e => e.ReqId);

                entity.ToTable("RequestTVRadio", "dbo");

                entity.Property(e => e.ReqId)
                    .HasColumnName("reqId")
                    .ValueGeneratedNever();

                entity.Property(e => e.EpisodeComment)
                    .HasColumnName("episodeComment")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.NameTvchanel)
                    .HasColumnName("nameTVChanel")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.ShortTitle)
                    .HasColumnName("shortTitle")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.Req)
                    .WithOne(p => p.RequestTvradio)
                    .HasForeignKey<RequestTvradio>(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTT_REF_TVREQUEST");
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.HasKey(e => e.ReqType);

                entity.ToTable("RequestType", "dbo");

                entity.Property(e => e.ReqType)
                    .HasColumnName("reqType")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.ReqTypeNameEn)
                    .HasColumnName("reqTypeNameEn")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReqTypeNameRu)
                    .HasColumnName("reqTypeNameRu")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReqTypeNameUk)
                    .HasColumnName("reqTypeNameUk")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.RequestType)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTT_REFERENCE_CATEGORY");
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

            modelBuilder.Entity<RightHolder>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("RightHolder", "dbo");

                entity.Property(e => e.CustId)
                    .HasColumnName("custId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AroundWord).HasColumnName("aroundWord");

                entity.Property(e => e.GetCode).HasColumnName("getCode");

                entity.Property(e => e.InnerCode)
                    .HasColumnName("innerCode")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.InterCode)
                    .HasColumnName("interCode")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SignP).HasColumnName("signP");

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.RightHolder)
                    .HasForeignKey<RightHolder>(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RIGHTHOL_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<SaldoDay>(entity =>
            {
                entity.HasKey(e => new { e.AccId, e.DateBegin, e.DateEnd });

                entity.ToTable("SaldoDay", "dbo");

                entity.Property(e => e.AccId).HasColumnName("accId");

                entity.Property(e => e.DateBegin)
                    .HasColumnName("dateBegin")
                    .HasColumnType("date");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("dateEnd")
                    .HasColumnType("date");

                entity.Property(e => e.Deboborot)
                    .HasColumnName("deboborot")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.DeboborotCur)
                    .HasColumnName("deboborotCur")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.KrdOborot)
                    .HasColumnName("krdOborot")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.KrdOborotCur)
                    .HasColumnName("krdOborotCur")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.R030)
                    .HasColumnName("r030")
                    .HasColumnType("char(3)");

                entity.Property(e => e.Rest)
                    .HasColumnName("rest")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.RestBegin)
                    .HasColumnName("restBegin")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.RestBeginCur)
                    .HasColumnName("restBeginCur")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.RestCur)
                    .HasColumnName("restCur")
                    .HasColumnType("numeric(20, 2)");
            });

            modelBuilder.Entity<SeekObject>(entity =>
            {
                entity.ToTable("SeekObject", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodeI).HasColumnName("codeI");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.HasOne(d => d.CodeINavigation)
                    .WithMany(p => p.SeekObject)
                    .HasForeignKey(d => d.CodeI)
                    .HasConstraintName("FK_SEEKOBJE_REFERENCE_SEEKTYPE");

                entity.HasOne(d => d.Obj)
                    .WithMany(p => p.SeekObject)
                    .HasForeignKey(d => d.ObjId)
                    .HasConstraintName("FK_SEEKOBJE_REFERENCE_OBJECTRI");
            });

            modelBuilder.Entity<SeekType>(entity =>
            {
                entity.HasKey(e => e.CodeI);

                entity.ToTable("SeekType", "dbo");

                entity.Property(e => e.CodeI)
                    .HasColumnName("codeI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
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

            modelBuilder.Entity<TableColumn>(entity =>
            {
                entity.ToTable("TableColumn", "dbo");

                entity.HasIndex(e => new { e.Lang, e.TName, e.CName })
                    .HasName("Index_Unique")
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.TName, e.CName, e.Lang })
                    .HasName("TableColumn_UI")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DText)
                    .HasColumnName("dText")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HText)
                    .HasColumnName("hText")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.TName)
                    .HasColumnName("tName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TableColumnTech>(entity =>
            {
                entity.ToTable("TableColumnTech", "dbo");

                entity.HasIndex(e => new { e.Tname, e.Cname })
                    .HasName("ITableColumn")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DnameEn)
                    .HasColumnName("dnameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DnameRu)
                    .HasColumnName("dnameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DnameUk)
                    .HasColumnName("dnameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tname)
                    .HasColumnName("tname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTab).HasColumnName("typeTab");
            });

            modelBuilder.Entity<TableObject>(entity =>
            {
                entity.ToTable("TableObject", "dbo");

                entity.HasIndex(e => new { e.Lang, e.CName })
                    .HasName("uni_01")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("cName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DText)
                    .HasColumnName("dText")
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.HText)
                    .HasColumnName("hText")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");
            });

            modelBuilder.Entity<TableType>(entity =>
            {
                entity.HasKey(e => e.TName)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("TableType", "dbo");

                entity.HasIndex(e => e.TName)
                    .HasName("Index_Unique")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.TName)
                    .HasColumnName("tName")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TType).HasColumnName("tType");
            });

            modelBuilder.Entity<TermsOfService>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.CrkindCode });

                entity.ToTable("TermsOfService", "dbo");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.CrkindCode).HasColumnName("CRKindCode");

                entity.HasOne(d => d.CrkindCodeNavigation)
                    .WithMany(p => p.TermsOfService)
                    .HasForeignKey(d => d.CrkindCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TERMSOFS_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.TermsOfService)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TERMSOFS_REFERENCE_RIGHTHOL");
            });

            modelBuilder.Entity<TermUse>(entity =>
            {
                entity.HasKey(e => e.TermUseCode);

                entity.ToTable("TermUse", "dbo");

                entity.Property(e => e.TermUseCode)
                    .HasColumnName("termUseCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.TermUseNameEn)
                    .HasColumnName("termUseNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TermUseNameRu)
                    .HasColumnName("termUseNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TermUseNameUk)
                    .HasColumnName("termUseNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TerritoryExclude>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.CountryCode });

                entity.ToTable("territoryExclude", "dbo");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.CountryCode).HasColumnType("char(3)");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.TerritoryExclude)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TERRITOR_REFERENCE_COUNTRY");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.TerritoryExclude)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TERRITOR_REFERENCE_RIGHTHOL");
            });

            modelBuilder.Entity<TerritoryInclude>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.CountryCode });

                entity.ToTable("territoryInclude", "dbo");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.CountryCode).HasColumnType("char(3)");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.TerritoryInclude)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICEA_REFERENCE_COUNTRY2");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.TerritoryInclude)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICEA_REFERENCE_RIGHTHOL2");
            });

            modelBuilder.Entity<TmpTradeLog>(entity =>
            {
                entity.ToTable("tmpTradeLog", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RegId).HasColumnName("regId");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TradeStatus>(entity =>
            {
                entity.HasKey(e => e.StatusCode);

                entity.ToTable("TradeStatus", "dbo");

                entity.Property(e => e.StatusCode)
                    .HasColumnName("statusCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.StatusNameEn)
                    .HasColumnName("statusNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusNameRu)
                    .HasColumnName("statusNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusNameUk)
                    .HasColumnName("statusNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeInternetObject>(entity =>
            {
                entity.HasKey(e => e.TypeInetCode);

                entity.ToTable("TypeInternetObject", "dbo");

                entity.Property(e => e.TypeInetCode)
                    .HasColumnName("typeInetCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.TypeInetNameEn)
                    .HasColumnName("typeInetNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeInetNameRu)
                    .HasColumnName("typeInetNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeInetNameUk)
                    .HasColumnName("typeInetNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);
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

            modelBuilder.Entity<UseAreaType>(entity =>
            {
                entity.HasKey(e => e.UseAreaTypeCode);

                entity.ToTable("UseAreaType", "dbo");

                entity.Property(e => e.UseAreaTypeCode)
                    .HasColumnName("useAreaTypeCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.ReqType).HasColumnName("reqType");

                entity.Property(e => e.UseAreaTypeNameEn)
                    .HasColumnName("useAreaTypeNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UseAreaTypeNameRu)
                    .HasColumnName("useAreaTypeNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UseAreaTypeNameUk)
                    .HasColumnName("useAreaTypeNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.UseAreaType)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USEAREAT_REFERENCE_CATEGORY");

                entity.HasOne(d => d.ReqTypeNavigation)
                    .WithMany(p => p.UseAreaType)
                    .HasForeignKey(d => d.ReqType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USEAREAT_REFERENCE_REQUESTT");
            });

            modelBuilder.Entity<UseMediaType>(entity =>
            {
                entity.HasKey(e => e.UseMediaTypeCode);

                entity.ToTable("UseMediaType", "dbo");

                entity.Property(e => e.UseMediaTypeCode)
                    .HasColumnName("useMediaTypeCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.ReqType).HasColumnName("reqType");

                entity.Property(e => e.UseMediaTypeNameEn)
                    .HasColumnName("useMediaTypeNameEn")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UseMediaTypeNameRu)
                    .HasColumnName("useMediaTypeNameRu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UseMediaTypeNameUk)
                    .HasColumnName("useMediaTypeNameUk")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.UseMediaType)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USEMEDIA_REFERENCE_CATEGORY");

                entity.HasOne(d => d.ReqTypeNavigation)
                    .WithMany(p => p.UseMediaType)
                    .HasForeignKey(d => d.ReqType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USEMEDIA_REFERENCE_REQUESTT");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.RoleType, e.UserId });

                entity.ToTable("userRole", "dbo");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.RoleType).HasColumnName("roleType");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(48);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERROLE_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.RoleTypeNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERROLE_REFERENCE_USERROLE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERROLE_REFERENCE_ASPNETUS");
            });

            modelBuilder.Entity<UserRoleType>(entity =>
            {
                entity.HasKey(e => e.TypeCode);

                entity.ToTable("UserRoleType", "dbo");

                entity.Property(e => e.TypeCode)
                    .HasColumnName("typeCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.TypeNameEn)
                    .HasColumnName("typeNameEn")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TypeNameRu)
                    .HasColumnName("typeNameRu")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TypeNameUk)
                    .HasColumnName("typeNameUk")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
}
