using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ipsmedserviceapp.Model
{
    public partial class MediaServiceContext : DbContext
    {
        public MediaServiceContext()
        {
        }

        public MediaServiceContext(DbContextOptions<MediaServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountBals> AccountBals { get; set; }
        public virtual DbSet<AccountBalsTr> AccountBalsTr { get; set; }
        public virtual DbSet<AccountStatus> AccountStatus { get; set; }
        public virtual DbSet<AccountStatusTr> AccountStatusTr { get; set; }
        public virtual DbSet<ActivityType> ActivityType { get; set; }
        public virtual DbSet<ActivityTypeTr> ActivityTypeTr { get; set; }
        public virtual DbSet<AgreementAddBR> AgreementAddBR { get; set; }
        public virtual DbSet<AgreementAddPartner> AgreementAddPartner { get; set; }
        public virtual DbSet<AgreementAddRH> AgreementAddRH { get; set; }
        public virtual DbSet<AgreementMaster> AgreementMaster { get; set; }
        public virtual DbSet<AgreementStatus> AgreementStatus { get; set; }
        public virtual DbSet<AgreementStatusTr> AgreementStatusTr { get; set; }
        public virtual DbSet<AgreementType> AgreementType { get; set; }
        public virtual DbSet<AgreementTypeTr> AgreementTypeTr { get; set; }
        public virtual DbSet<AgrLicenseType> AgrLicenseType { get; set; }
        public virtual DbSet<AgrLicenseTypeTr> AgrLicenseTypeTr { get; set; }
        public virtual DbSet<AlgorithmType> AlgorithmType { get; set; }
        public virtual DbSet<AnketaAddName> AnketaAddName { get; set; }
        public virtual DbSet<AnketaAddNick> AnketaAddNick { get; set; }
        public virtual DbSet<AnketaAddParam> AnketaAddParam { get; set; }
        public virtual DbSet<AnketaCompany> AnketaCompany { get; set; }
        public virtual DbSet<AnketaExternal> AnketaExternal { get; set; }
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
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<BankAccount> BankAccount { get; set; }
        public virtual DbSet<BrRegister> BrRegister { get; set; }
        public virtual DbSet<BrRegItem> BrRegItem { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryStatusType> CategoryStatusType { get; set; }
        public virtual DbSet<CategoryStatusTypeTr> CategoryStatusTypeTr { get; set; }
        public virtual DbSet<CategoryTr> CategoryTr { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientBrand> ClientBrand { get; set; }
        public virtual DbSet<ClientBrandTr> ClientBrandTr { get; set; }
        public virtual DbSet<ClientGroup> ClientGroup { get; set; }
        public virtual DbSet<ClientGroupTr> ClientGroupTr { get; set; }
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
        public virtual DbSet<CopyRTranslate> CopyRTranslate { get; set; }
        public virtual DbSet<CounterNumber> CounterNumber { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CountryTr> CountryTr { get; set; }
        public virtual DbSet<CreativeRoleType> CreativeRoleType { get; set; }
        public virtual DbSet<CreativeRoleTypeTr> CreativeRoleTypeTr { get; set; }
        public virtual DbSet<CreativeTranslate> CreativeTranslate { get; set; }
        public virtual DbSet<CRightStatus> CRightStatus { get; set; }
        public virtual DbSet<CRightStatusTr> CRightStatusTr { get; set; }
        public virtual DbSet<CRKindGroup> CRKindGroup { get; set; }
        public virtual DbSet<CRKindGroupTr> CRKindGroupTr { get; set; }
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
        public virtual DbSet<DistribStatusTr> DistribStatusTr { get; set; }
        public virtual DbSet<DistribType> DistribType { get; set; }
        public virtual DbSet<DistribTypeTr> DistribTypeTr { get; set; }
        public virtual DbSet<Distribution> Distribution { get; set; }
        public virtual DbSet<DistributionItem> DistributionItem { get; set; }
        public virtual DbSet<DocPreparePay> DocPreparePay { get; set; }
        public virtual DbSet<DocReq> DocReq { get; set; }
        public virtual DbSet<DocText> DocText { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<DocumentTypeTr> DocumentTypeTr { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EpisodeType> EpisodeType { get; set; }
        public virtual DbSet<EpisodeTypeTr> EpisodeTypeTr { get; set; }
        public virtual DbSet<EtGenre> EtGenre { get; set; }
        public virtual DbSet<EtGenreRate> EtGenreRate { get; set; }
        public virtual DbSet<EtGenreRole> EtGenreRole { get; set; }
        public virtual DbSet<EtRole> EtRole { get; set; }
        public virtual DbSet<ExternalPay> ExternalPay { get; set; }
        public virtual DbSet<FileCustomer> FileCustomer { get; set; }
        public virtual DbSet<FileType> FileType { get; set; }
        public virtual DbSet<Fixation> Fixation { get; set; }
        public virtual DbSet<FixFile> FixFile { get; set; }
        public virtual DbSet<FixStageStatus> FixStageStatus { get; set; }
        public virtual DbSet<FixStorageDevice> FixStorageDevice { get; set; }
        public virtual DbSet<FolkType> FolkType { get; set; }
        public virtual DbSet<FolkTypeTr> FolkTypeTr { get; set; }
        public virtual DbSet<GenreType> GenreType { get; set; }
        public virtual DbSet<GenreTypeTr> GenreTypeTr { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<ItemStatus> ItemStatus { get; set; }
        public virtual DbSet<ItemStatusTr> ItemStatusTr { get; set; }
        public virtual DbSet<KindComposition> KindComposition { get; set; }
        public virtual DbSet<KindCompositionTr> KindCompositionTr { get; set; }
        public virtual DbSet<KindFilm> KindFilm { get; set; }
        public virtual DbSet<KindFilmTr> KindFilmTr { get; set; }
        public virtual DbSet<KindSerial> KindSerial { get; set; }
        public virtual DbSet<KindSerialTr> KindSerialTr { get; set; }
        public virtual DbSet<KL_R030> KL_R030 { get; set; }
        public virtual DbSet<KL_R030Tr> KL_R030Tr { get; set; }
        public virtual DbSet<KL_R031> KL_R031 { get; set; }
        public virtual DbSet<Lang> Lang { get; set; }
        public virtual DbSet<LangTr> LangTr { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<LegalBasis> LegalBasis { get; set; }
        public virtual DbSet<LegalBasisTr> LegalBasisTr { get; set; }
        public virtual DbSet<LicAuthorBR> LicAuthorBR { get; set; }
        public virtual DbSet<License> License { get; set; }
        public virtual DbSet<LicenseAgreement> LicenseAgreement { get; set; }
        public virtual DbSet<LicenseAgrParam> LicenseAgrParam { get; set; }
        public virtual DbSet<LicenseBigR> LicenseBigR { get; set; }
        public virtual DbSet<LicenseClass> LicenseClass { get; set; }
        public virtual DbSet<LicenseType> LicenseType { get; set; }
        public virtual DbSet<LicenseTypeTr> LicenseTypeTr { get; set; }
        public virtual DbSet<licPlace> licPlace { get; set; }
        public virtual DbSet<MediaFile> MediaFile { get; set; }
        public virtual DbSet<MediaSearchData> MediaSearchData { get; set; }
        public virtual DbSet<MediaTrack> MediaTrack { get; set; }
        public virtual DbSet<ModifyMusicType> ModifyMusicType { get; set; }
        public virtual DbSet<ModifyMusicTypeTr> ModifyMusicTypeTr { get; set; }
        public virtual DbSet<ModifyTextType> ModifyTextType { get; set; }
        public virtual DbSet<ModifyTextTypeTr> ModifyTextTypeTr { get; set; }
        public virtual DbSet<ModifyType> ModifyType { get; set; }
        public virtual DbSet<ModifyTypeTr> ModifyTypeTr { get; set; }
        public virtual DbSet<MoneyLinkStatus> MoneyLinkStatus { get; set; }
        public virtual DbSet<MoneyLinkStatusTr> MoneyLinkStatusTr { get; set; }
        public virtual DbSet<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public virtual DbSet<MoneyPrepayLink> MoneyPrepayLink { get; set; }
        public virtual DbSet<MoneyReceived> MoneyReceived { get; set; }
        public virtual DbSet<MoneyType> MoneyType { get; set; }
        public virtual DbSet<MoneyTypeTr> MoneyTypeTr { get; set; }
        public virtual DbSet<MusicalDesign> MusicalDesign { get; set; }
        public virtual DbSet<MyAnketa> MyAnketa { get; set; }
        public virtual DbSet<MyCategory> MyCategory { get; set; }
        public virtual DbSet<myCopyRightType> myCopyRightType { get; set; }
        public virtual DbSet<ObjAct> ObjAct { get; set; }
        public virtual DbSet<ObjActTr> ObjActTr { get; set; }
        public virtual DbSet<ObjectRight> ObjectRight { get; set; }
        public virtual DbSet<ObjectStatus> ObjectStatus { get; set; }
        public virtual DbSet<ObjectStatusTr> ObjectStatusTr { get; set; }
        public virtual DbSet<PaidPeriod> PaidPeriod { get; set; }
        public virtual DbSet<ParametersListBox> ParametersListBox { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<PartnerClient> PartnerClient { get; set; }
        public virtual DbSet<PaymentCase> PaymentCase { get; set; }
        public virtual DbSet<PaymentKind> PaymentKind { get; set; }
        public virtual DbSet<PaymentKindTr> PaymentKindTr { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }
        public virtual DbSet<PaymentStatusTr> PaymentStatusTr { get; set; }
        public virtual DbSet<PayMethodType> PayMethodType { get; set; }
        public virtual DbSet<PayMethodTypeTr> PayMethodTypeTr { get; set; }
        public virtual DbSet<PayTurn> PayTurn { get; set; }
        public virtual DbSet<Performer> Performer { get; set; }
        public virtual DbSet<PerformType> PerformType { get; set; }
        public virtual DbSet<PerformTypeTr> PerformTypeTr { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<PeriodStatus> PeriodStatus { get; set; }
        public virtual DbSet<PeriodStatusTr> PeriodStatusTr { get; set; }
        public virtual DbSet<PeriodTr> PeriodTr { get; set; }
        public virtual DbSet<PermitType> PermitType { get; set; }
        public virtual DbSet<PermitTypeTr> PermitTypeTr { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PopGenre> PopGenre { get; set; }
        public virtual DbSet<PopGenreTr> PopGenreTr { get; set; }
        public virtual DbSet<PortalObjectRights> PortalObjectRights { get; set; }
        public virtual DbSet<PortalSupportRights> PortalSupportRights { get; set; }
        public virtual DbSet<PositionType> PositionType { get; set; }
        public virtual DbSet<PositionTypeTr> PositionTypeTr { get; set; }
        public virtual DbSet<PrePayType> PrePayType { get; set; }
        public virtual DbSet<PrePayTypeTr> PrePayTypeTr { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<RegionTr> RegionTr { get; set; }
        public virtual DbSet<Register> Register { get; set; }
        public virtual DbSet<RegisterAuthors> RegisterAuthors { get; set; }
        public virtual DbSet<RegisterCount> RegisterCount { get; set; }
        public virtual DbSet<RegisterExtra> RegisterExtra { get; set; }
        public virtual DbSet<RegisterItem> RegisterItem { get; set; }
        public virtual DbSet<RegisterItemType> RegisterItemType { get; set; }
        public virtual DbSet<RegisterListStatus> RegisterListStatus { get; set; }
        public virtual DbSet<RegisterListStatusTr> RegisterListStatusTr { get; set; }
        public virtual DbSet<RegisterRatedList> RegisterRatedList { get; set; }
        public virtual DbSet<RegisterStatus> RegisterStatus { get; set; }
        public virtual DbSet<RegisterStatusTr> RegisterStatusTr { get; set; }
        public virtual DbSet<RelAdaptUseArea> RelAdaptUseArea { get; set; }
        public virtual DbSet<relCounterDoc> relCounterDoc { get; set; }
        public virtual DbSet<RelDocAgrType> RelDocAgrType { get; set; }
        public virtual DbSet<RelEmployee> RelEmployee { get; set; }
        public virtual DbSet<relEtGenre> relEtGenre { get; set; }
        public virtual DbSet<relEtRole> relEtRole { get; set; }
        public virtual DbSet<RelGenreAdapt> RelGenreAdapt { get; set; }
        public virtual DbSet<RelGenreMovie> RelGenreMovie { get; set; }
        public virtual DbSet<RelGenrePercent> RelGenrePercent { get; set; }
        public virtual DbSet<relGenreRole> relGenreRole { get; set; }
        public virtual DbSet<RelGenreSerial> RelGenreSerial { get; set; }
        public virtual DbSet<relLicCopyR> relLicCopyR { get; set; }
        public virtual DbSet<RelMovieEpisode> RelMovieEpisode { get; set; }
        public virtual DbSet<RelObjPerformer> RelObjPerformer { get; set; }
        public virtual DbSet<RelPopGenre> RelPopGenre { get; set; }
        public virtual DbSet<RelReqMedia> RelReqMedia { get; set; }
        public virtual DbSet<RelReqObj> RelReqObj { get; set; }
        public virtual DbSet<RelSerialEpisode> RelSerialEpisode { get; set; }
        public virtual DbSet<RelTVEpisode> RelTVEpisode { get; set; }
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
        public virtual DbSet<RequestAimTr> RequestAimTr { get; set; }
        public virtual DbSet<RequestInternet> RequestInternet { get; set; }
        public virtual DbSet<RequestMovie> RequestMovie { get; set; }
        public virtual DbSet<RequestOther> RequestOther { get; set; }
        public virtual DbSet<RequestSerial> RequestSerial { get; set; }
        public virtual DbSet<RequestStatusType> RequestStatusType { get; set; }
        public virtual DbSet<RequestStatusTypeTr> RequestStatusTypeTr { get; set; }
        public virtual DbSet<RequestTVRadio> RequestTVRadio { get; set; }
        public virtual DbSet<RequestType> RequestType { get; set; }
        public virtual DbSet<RequestTypeTr> RequestTypeTr { get; set; }
        public virtual DbSet<ResidentType> ResidentType { get; set; }
        public virtual DbSet<ResidentTypeTr> ResidentTypeTr { get; set; }
        public virtual DbSet<RHolderType> RHolderType { get; set; }
        public virtual DbSet<RHolderTypeTr> RHolderTypeTr { get; set; }
        public virtual DbSet<RightHolder> RightHolder { get; set; }
        public virtual DbSet<SaldoDay> SaldoDay { get; set; }
        public virtual DbSet<SeekObject> SeekObject { get; set; }
        public virtual DbSet<SeekType> SeekType { get; set; }
        public virtual DbSet<SeekTypeTr> SeekTypeTr { get; set; }
        public virtual DbSet<SexType> SexType { get; set; }
        public virtual DbSet<SexTypeTr> SexTypeTr { get; set; }
        public virtual DbSet<SpecType> SpecType { get; set; }
        public virtual DbSet<SpecTypeTr> SpecTypeTr { get; set; }
        public virtual DbSet<TableColumn> TableColumn { get; set; }
        public virtual DbSet<TableColumnTech> TableColumnTech { get; set; }
        public virtual DbSet<TableObject> TableObject { get; set; }
        public virtual DbSet<TableType> TableType { get; set; }
        public virtual DbSet<TermsOfService> TermsOfService { get; set; }
        public virtual DbSet<TermUse> TermUse { get; set; }
        public virtual DbSet<TermUseTr> TermUseTr { get; set; }
        public virtual DbSet<TerritoryExclude> TerritoryExclude { get; set; }
        public virtual DbSet<TerritoryInclude> TerritoryInclude { get; set; }
        public virtual DbSet<TradeStatus> TradeStatus { get; set; }
        public virtual DbSet<TypeInternetObject> TypeInternetObject { get; set; }
        public virtual DbSet<TypeInternetObjectTr> TypeInternetObjectTr { get; set; }
        public virtual DbSet<TypeMethodGet> TypeMethodGet { get; set; }
        public virtual DbSet<TypeMethodGetTr> TypeMethodGetTr { get; set; }
        public virtual DbSet<TypePlace> TypePlace { get; set; }
        public virtual DbSet<TypePlaceParam> TypePlaceParam { get; set; }
        public virtual DbSet<TypePlaceParamTr> TypePlaceParamTr { get; set; }
        public virtual DbSet<TypePlaceTr> TypePlaceTr { get; set; }
        public virtual DbSet<TypeVAT> TypeVAT { get; set; }
        public virtual DbSet<TypeVATTr> TypeVATTr { get; set; }
        public virtual DbSet<UseAreaType> UseAreaType { get; set; }
        public virtual DbSet<UseAreaTypeTr> UseAreaTypeTr { get; set; }
        public virtual DbSet<UseMediaType> UseMediaType { get; set; }
        public virtual DbSet<UseMediaTypeTr> UseMediaTypeTr { get; set; }
        public virtual DbSet<userRole> userRole { get; set; }
        public virtual DbSet<UserRoleType> UserRoleType { get; set; }
        public virtual DbSet<UserRoleTypeTr> UserRoleTypeTr { get; set; }
        public virtual DbSet<UsesKind> UsesKind { get; set; }
        public virtual DbSet<UsesKindTr> UsesKindTr { get; set; }
        public virtual DbSet<UsesType> UsesType { get; set; }
        public virtual DbSet<UsesTypeTr> UsesTypeTr { get; set; }
        public virtual DbSet<WorkRH> WorkRH { get; set; }
        public virtual DbSet<WorkType> WorkType { get; set; }
        public virtual DbSet<WorkTypeTr> WorkTypeTr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=IPSDATA,60675;Initial Catalog=MediaService;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.accId);

                entity.HasIndex(e => new { e.r030, e.accNls, e.accStatus })
                    .HasName("AccountUI")
                    .IsUnique();

                entity.Property(e => e.accName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.accNls)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.dateClose).HasColumnType("date");

                entity.Property(e => e.dateModify).HasColumnType("datetime");

                entity.Property(e => e.dateOpen).HasColumnType("date");

                entity.Property(e => e.r030)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.accStatusNavigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.accStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNT_REFERENCE_ACCOUNTS");

                entity.HasOne(d => d.balsCodeNavigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.balsCode)
                    .HasConstraintName("FK_ACCOUNT_REFERENCE_ACCOUNTB");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_ACCOUNT_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.objId)
                    .HasConstraintName("FK_ACCOUNT_REFERENCE_OBJECTRI");

                entity.HasOne(d => d.r030Navigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.r030)
                    .HasConstraintName("FK_ACCOUNT_REFERENCE_CURRENCY");
            });

            modelBuilder.Entity<AccountBals>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccountBalsTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.AccountBalsTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTB_REFERENCE_ACCOUNTB");
            });

            modelBuilder.Entity<AccountStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccountStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.AccountStatusTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTS_REFERENCE_ACCOUNTS");
            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ActivityTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.ActivityTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .HasConstraintName("FK_ACTIVITY_REFERENCE_ACTIVITY");
            });

            modelBuilder.Entity<AgreementAddBR>(entity =>
            {
                entity.HasKey(e => new { e.agrId, e.version });

                entity.Property(e => e.agrDate).HasColumnType("date");

                entity.Property(e => e.agrNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.dateBegin).HasColumnType("date");

                entity.Property(e => e.dateEnd).HasColumnType("date");

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.HasOne(d => d.agr)
                    .WithMany(p => p.AgreementAddBR)
                    .HasForeignKey(d => d.agrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AGRBR_REFERENCE_AGRMASTER");

                entity.HasOne(d => d.agrStatusNavigation)
                    .WithMany(p => p.AgreementAddBR)
                    .HasForeignKey(d => d.agrStatus)
                    .HasConstraintName("FK_AGRBR_REFERENCE_AGRSTATUS");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.AgreementAddBR)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_CLIENT");

                entity.HasOne(d => d.periodCodeNavigation)
                    .WithMany(p => p.AgreementAddBR)
                    .HasForeignKey(d => d.periodCode)
                    .HasConstraintName("FK_AGRBR_REFERENCE_PERIOD");
            });

            modelBuilder.Entity<AgreementAddPartner>(entity =>
            {
                entity.HasKey(e => new { e.agrId, e.version });

                entity.Property(e => e.agrDate).HasColumnType("date");

                entity.Property(e => e.agrNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.courtCompRate).HasColumnType("numeric(10, 5)");

                entity.Property(e => e.courtRate).HasColumnType("numeric(10, 5)");

                entity.Property(e => e.dateBegin).HasColumnType("date");

                entity.Property(e => e.dateEnd).HasColumnType("date");

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.noCourtRate).HasColumnType("numeric(10, 5)");

                entity.Property(e => e.pfFirstRate).HasColumnType("numeric(10, 5)");

                entity.Property(e => e.pfMonthRate).HasColumnType("numeric(10, 5)");

                entity.Property(e => e.srFirstRate).HasColumnType("numeric(10, 5)");

                entity.Property(e => e.srMonthRate).HasColumnType("numeric(10, 5)");

                entity.HasOne(d => d.agr)
                    .WithMany(p => p.AgreementAddPartner)
                    .HasForeignKey(d => d.agrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_AGREEMEN");

                entity.HasOne(d => d.agrStatusNavigation)
                    .WithMany(p => p.AgreementAddPartner)
                    .HasForeignKey(d => d.agrStatus)
                    .HasConstraintName("FK_AGREEMEN_REFER_AGREEMEN");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.AgreementAddPartner)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_PARTNER");

                entity.HasOne(d => d.periodCodeNavigation)
                    .WithMany(p => p.AgreementAddPartner)
                    .HasForeignKey(d => d.periodCode)
                    .HasConstraintName("FK_AGREEMEN_REFER_PERIOD");
            });

            modelBuilder.Entity<AgreementAddRH>(entity =>
            {
                entity.HasKey(e => new { e.agrId, e.version });

                entity.Property(e => e.agrDate).HasColumnType("date");

                entity.Property(e => e.agrNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.dateBegin).HasColumnType("date");

                entity.Property(e => e.dateEnd).HasColumnType("date");

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.rateCommiss).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.rateCourt).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.responsUser).HasMaxLength(48);

                entity.HasOne(d => d.agr)
                    .WithMany(p => p.AgreementAddRH)
                    .HasForeignKey(d => d.agrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_AGREEM");

                entity.HasOne(d => d.agrStatusNavigation)
                    .WithMany(p => p.AgreementAddRH)
                    .HasForeignKey(d => d.agrStatus)
                    .HasConstraintName("FK_AGREEMEN_REF_AGREEMEN");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.AgreementAddRH)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_RIGHTHOL");

                entity.HasOne(d => d.getCodeNavigation)
                    .WithMany(p => p.AgreementAddRH)
                    .HasForeignKey(d => d.getCode)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_TYPEMETH");

                entity.HasOne(d => d.periodCodeNavigation)
                    .WithMany(p => p.AgreementAddRH)
                    .HasForeignKey(d => d.periodCode)
                    .HasConstraintName("FK_AGREEMEN_REF_PERIOD");

                entity.HasOne(d => d.responsUserNavigation)
                    .WithMany(p => p.AgreementAddRH)
                    .HasForeignKey(d => d.responsUser)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_ASPNETUS");
            });

            modelBuilder.Entity<AgreementMaster>(entity =>
            {
                entity.HasKey(e => e.agrId);

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.HasOne(d => d.agrStatusNavigation)
                    .WithMany(p => p.AgreementMaster)
                    .HasForeignKey(d => d.agrStatus)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_STATUS");

                entity.HasOne(d => d.agrTypeNavigation)
                    .WithMany(p => p.AgreementMaster)
                    .HasForeignKey(d => d.agrType)
                    .HasConstraintName("FK_AGREEMEN_REF_AGRTYPE");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.AgreementMaster)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AGREEMEN_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<AgreementStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AgreementStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.AgreementStatusTr)
                    .HasForeignKey(d => d.codeI)
                    .HasConstraintName("FK_AGREEMENS_REF_AGREEMTR");
            });

            modelBuilder.Entity<AgreementType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.templateName)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AgreementTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.AgreementTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AGREEMET_REFERENCE_AGREEMEN");
            });

            modelBuilder.Entity<AgrLicenseType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.templateName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.algorithm)
                    .WithMany(p => p.AgrLicenseType)
                    .HasForeignKey(d => d.algorithmId)
                    .HasConstraintName("FK_AGRLICENTYPE_REF_ALGORITH");

                entity.HasOne(d => d.kindCodeNavigation)
                    .WithMany(p => p.AgrLicenseType)
                    .HasForeignKey(d => d.kindCode)
                    .HasConstraintName("FK_AGRLICEN_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.usesKindNavigation)
                    .WithMany(p => p.AgrLicenseType)
                    .HasForeignKey(d => d.usesKind)
                    .HasConstraintName("FK_AGRLICEN_REFERENCE_USESKIND");
            });

            modelBuilder.Entity<AgrLicenseTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.AgrLicenseTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .HasConstraintName("FK_ARGLICEN_REFERENCE_ARGLICEN");
            });

            modelBuilder.Entity<AlgorithmType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AnketaAddName>(entity =>
            {
                entity.HasKey(e => new { e.custId, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.firstName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.lastName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.nikName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.shortName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.surName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.AnketaAddName)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETAADN_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<AnketaAddNick>(entity =>
            {
                entity.HasKey(e => e.addId);

                entity.Property(e => e.nikName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.AnketaAddNick)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETAAD_REFERENCE_RIGHTHOL");
            });

            modelBuilder.Entity<AnketaAddParam>(entity =>
            {
                entity.HasKey(e => new { e.paramCode, e.langCode });

                entity.Property(e => e.langCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.paramName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.paramValue)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.AnketaAddParam)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_ANKETAAD_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<AnketaCompany>(entity =>
            {
                entity.HasKey(e => new { e.custId, e.version });

                entity.HasIndex(e => e.custId)
                    .HasName("Association26_FK");

                entity.Property(e => e.faAddress)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.faCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.faCountry)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.jaAddress)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.jaCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.jaCountry)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.leAddress)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.leCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.leCountry)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.lePostIndex)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.numberVAT)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.okpo)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.registrDate).HasColumnType("date");

                entity.Property(e => e.registrNumber)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.registrWho)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.shortName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.activityCodeNavigation)
                    .WithMany(p => p.AnketaCompany)
                    .HasForeignKey(d => d.activityCode)
                    .HasConstraintName("FK_ANKETACO_REFERENCE_ACTIVITY");

                entity.HasOne(d => d.banAcc)
                    .WithMany(p => p.AnketaCompany)
                    .HasForeignKey(d => d.banAccId)
                    .HasConstraintName("FK_ANKETACO_REFERENCE_BANKACCO");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.AnketaCompany)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETACO_ASSOCIATI_COMPANY");

                entity.HasOne(d => d.custNavigation)
                    .WithMany(p => p.AnketaCompany)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETACO_ASSOCIATI_CUSTOMER");

                entity.HasOne(d => d.faCountryNavigation)
                    .WithMany(p => p.AnketaCompanyfaCountryNavigation)
                    .HasForeignKey(d => d.faCountry)
                    .HasConstraintName("FK_ANKETACO_REF_FaCOUNTRY");

                entity.HasOne(d => d.faRegionNavigation)
                    .WithMany(p => p.AnketaCompanyfaRegionNavigation)
                    .HasForeignKey(d => d.faRegion)
                    .HasConstraintName("FK_ANKETACO_REFERENCE_REGFA");

                entity.HasOne(d => d.jaCountryNavigation)
                    .WithMany(p => p.AnketaCompanyjaCountryNavigation)
                    .HasForeignKey(d => d.jaCountry)
                    .HasConstraintName("FK_ANKETACO_REF_jaCOUNTRY");

                entity.HasOne(d => d.jaRegionNavigation)
                    .WithMany(p => p.AnketaCompanyjaRegionNavigation)
                    .HasForeignKey(d => d.jaRegion)
                    .HasConstraintName("FK_ANKETACO_REFERENCE_REGJA");

                entity.HasOne(d => d.leCountryNavigation)
                    .WithMany(p => p.AnketaCompanyleCountryNavigation)
                    .HasForeignKey(d => d.leCountry)
                    .HasConstraintName("FK_ANKETALE_REF_LECOUNTRY");

                entity.HasOne(d => d.leRegionNavigation)
                    .WithMany(p => p.AnketaCompanyleRegionNavigation)
                    .HasForeignKey(d => d.leRegion)
                    .HasConstraintName("FK_ANKETACO_REF_LEREGION");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.AnketaCompany)
                    .HasForeignKey(d => d.status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETACO_REFERENCE_ANKETAST");

                entity.HasOne(d => d.typeVATNavigation)
                    .WithMany(p => p.AnketaCompany)
                    .HasForeignKey(d => d.typeVAT)
                    .HasConstraintName("FK_ANKETACO_REFERENCE_TYPEVAT");
            });

            modelBuilder.Entity<AnketaExternal>(entity =>
            {
                entity.HasKey(e => e.custId);

                entity.Property(e => e.custId).ValueGeneratedNever();

                entity.Property(e => e.countryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.innOkpo)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.interCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.countryCodeNavigation)
                    .WithMany(p => p.AnketaExternal)
                    .HasForeignKey(d => d.countryCode)
                    .HasConstraintName("FK_ANKETAEX_REFERENCE_COUNTRY");

                entity.HasOne(d => d.cust)
                    .WithOne(p => p.AnketaExternal)
                    .HasForeignKey<AnketaExternal>(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETAEX_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<AnketaPerson>(entity =>
            {
                entity.HasKey(e => new { e.custId, e.version });

                entity.HasIndex(e => e.custId)
                    .HasName("Association26_FK");

                entity.Property(e => e.birthDate).HasColumnType("date");

                entity.Property(e => e.buisDateRegistration).HasColumnType("date");

                entity.Property(e => e.buisNumberPayer)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.buisNumberRegistration)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.buisSertNumberPayer)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.citizenship)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.eMail)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.faAddress)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.faCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.faCountry)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.firstName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.inn)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.lastName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.leAddress)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.leCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.leCountry)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.lePostIndex)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.nikName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.pFIssuedDate).HasColumnType("date");

                entity.Property(e => e.pFNumber)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.pFSeries)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.pFValidity).HasColumnType("date");

                entity.Property(e => e.pUIssuedWhen).HasColumnType("date");

                entity.Property(e => e.pUIssuedWho)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.pUNumber)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.pUSeries)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.phoneHome)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.phoneMobileExtra)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.phoneMobileMain)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.reAddress)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.reCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.reCountry)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.surName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.banAcc)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.banAccId)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_BANKACCO");

                entity.HasOne(d => d.citizenshipNavigation)
                    .WithMany(p => p.AnketaPersoncitizenshipNavigation)
                    .HasForeignKey(d => d.citizenship)
                    .HasConstraintName("FK_ANKETAPE_REF_SitizCOUNTRY");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETAPE_ASSOCIATI_CUSTOMER");

                entity.HasOne(d => d.custNavigation)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETAPE_ASSOCIATI_PERSON");

                entity.HasOne(d => d.faCountryNavigation)
                    .WithMany(p => p.AnketaPersonfaCountryNavigation)
                    .HasForeignKey(d => d.faCountry)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_COUNTRY");

                entity.HasOne(d => d.faRegionNavigation)
                    .WithMany(p => p.AnketaPersonfaRegionNavigation)
                    .HasForeignKey(d => d.faRegion)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_REGFa");

                entity.HasOne(d => d.langNavigation)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.lang)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_LANG");

                entity.HasOne(d => d.leRegionNavigation)
                    .WithMany(p => p.AnketaPersonleRegionNavigation)
                    .HasForeignKey(d => d.leRegion)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_REGLe");

                entity.HasOne(d => d.reCountryNavigation)
                    .WithMany(p => p.AnketaPersonreCountryNavigation)
                    .HasForeignKey(d => d.reCountry)
                    .HasConstraintName("FK_ANKETAPE_REF_RegistCOUNTRY");

                entity.HasOne(d => d.reRegionNavigation)
                    .WithMany(p => p.AnketaPersonreRegionNavigation)
                    .HasForeignKey(d => d.reRegion)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_REGRe");

                entity.HasOne(d => d.residencyNavigation)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.residency)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_RESIDENT");

                entity.HasOne(d => d.sexNavigation)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.sex)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_SEXTYPE");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_ANKETAST");

                entity.HasOne(d => d.typeVATNavigation)
                    .WithMany(p => p.AnketaPerson)
                    .HasForeignKey(d => d.typeVAT)
                    .HasConstraintName("FK_ANKETAPE_REFERENCE_TYPEVAT");
            });

            modelBuilder.Entity<AnketaStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AnketaStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.AnketaStatusTr)
                    .HasForeignKey(d => d.codeI)
                    .HasConstraintName("FK_ANKETAST_REFERENCE_ANKETAST");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.roleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.roleId).IsRequired();

                entity.HasOne(d => d.role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.roleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.normalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.description).HasMaxLength(256);

                entity.Property(e => e.name).HasMaxLength(256);

                entity.Property(e => e.normalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.userId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.userId)
                    .IsRequired()
                    .HasMaxLength(48);

                entity.HasOne(d => d.user)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.loginProvider, e.providerKey });

                entity.HasIndex(e => e.userId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.userId)
                    .IsRequired()
                    .HasMaxLength(48);

                entity.HasOne(d => d.user)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.userId, e.roleId });

                entity.HasIndex(e => e.roleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.HasIndex(e => e.userId)
                    .HasName("IX_AspNetUserRoles_UserId");

                entity.Property(e => e.userId).HasMaxLength(48);

                entity.HasOne(d => d.role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.roleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.normalizedEmail)
                    .HasName("EmailIndex");

                entity.Property(e => e.id)
                    .HasMaxLength(48)
                    .ValueGeneratedNever();

                entity.Property(e => e.email).HasMaxLength(256);

                entity.Property(e => e.firstName).HasMaxLength(256);

                entity.Property(e => e.lastName).HasMaxLength(256);

                entity.Property(e => e.normalizedEmail).HasMaxLength(256);

                entity.Property(e => e.normalizedUserName).HasMaxLength(256);

                entity.Property(e => e.surName).HasMaxLength(256);

                entity.Property(e => e.userName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.userId, e.loginProvider, e.name });
            });

            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.authId);

                entity.HasIndex(e => new { e.authorName, e.custId })
                    .HasName("IdxNames");

                entity.Property(e => e.authorName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_AUTHORS_REFERENCE_RIGHTHOL");

                entity.HasOne(d => d.folkTypeNavigation)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.folkType)
                    .HasConstraintName("FK_AUTHORS_REFERENCE_FOLKTYPE");

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.objId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AUTHORS_REFERENCE_OBJECTRI");

                entity.HasOne(d => d.roleCodeNavigation)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.roleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AUTHORS_REFERENCE_CREATIVE");
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(e => e.banAccID);

                entity.Property(e => e.accountNumber)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.currency)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.mfoName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.mfoOkpo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.pAddress)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.pCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.pCountry)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.pIndex)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.transitNumber)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.currencyNavigation)
                    .WithMany(p => p.BankAccount)
                    .HasForeignKey(d => d.currency)
                    .HasConstraintName("FK_BANKACCO_REFERENCE_KL_R030");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.BankAccount)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_BANKACCO_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<BrRegister>(entity =>
            {
                entity.HasKey(e => e.regId);

                entity.Property(e => e.createDate).HasColumnType("date");

                entity.Property(e => e.fileName)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.fullAmount).HasColumnType("money");

                entity.Property(e => e.rAmount).HasColumnType("money");

                entity.Property(e => e.userId).HasMaxLength(48);

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.BrRegister)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_BRREGIST_REFERENCE_CLIENT");

                entity.HasOne(d => d.period)
                    .WithMany(p => p.BrRegister)
                    .HasForeignKey(d => d.periodId)
                    .HasConstraintName("FK_BRREGIST_REFERENCE_PAIDPERI");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.BrRegister)
                    .HasForeignKey(d => d.status)
                    .HasConstraintName("FK_BRREGIST_REFERENCE_REGISTER");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.BrRegister)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_BRREGIST_REF_ASPNETUS");
            });

            modelBuilder.Entity<BrRegItem>(entity =>
            {
                entity.HasKey(e => new { e.regItemId, e.regId });

                entity.Property(e => e.ItemName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.fullAmount).HasColumnType("money");

                entity.Property(e => e.fullRate).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.musicAmount).HasColumnType("money");

                entity.Property(e => e.musicRate).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.rAmount).HasColumnType("money");

                entity.HasOne(d => d.lic)
                    .WithMany(p => p.BrRegItem)
                    .HasForeignKey(d => d.licId)
                    .HasConstraintName("FK_BRREGITE_REFERENCE_LICENSEA");

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.BrRegItem)
                    .HasForeignKey(d => d.objId)
                    .HasConstraintName("FK_BRREGITE_REFERENCE_OBJECTRI");

                entity.HasOne(d => d.reg)
                    .WithMany(p => p.BrRegItem)
                    .HasForeignKey(d => d.regId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRREGITE_REFERENCE_BRREGIST");

                entity.HasOne(d => d.regIdSrNavigation)
                    .WithMany(p => p.BrRegItem)
                    .HasForeignKey(d => d.regIdSr)
                    .HasConstraintName("FK_BRREGITE_REFERENCE_REGISTER");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.BrRegItem)
                    .HasForeignKey(d => d.status)
                    .HasConstraintName("FK_BRREGITE_REFERENCE_ITEMSTAT");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.TableObj)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.comment)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.status)
                    .HasConstraintName("FK_CATEGORY_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<CategoryStatusType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryStatusTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.CategoryStatusTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .HasConstraintName("FK_CATEGORY_REFERENCE_CATSTTR");
            });

            modelBuilder.Entity<CategoryTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.CategoryTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATEGORY_REF_CATEGORYTR");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.custId);

                entity.Property(e => e.custId).ValueGeneratedNever();

                entity.Property(e => e.clientBrand)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.clientGroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.cust)
                    .WithOne(p => p.Client)
                    .HasForeignKey<Client>(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENT_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<ClientBrand>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientBrandTr>(entity =>
            {
                entity.HasKey(e => new { e.lang, e.codeI });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.ClientBrandTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTBR_REFERENCE_CLIENTBR");
            });

            modelBuilder.Entity<ClientGroup>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientGroupTr>(entity =>
            {
                entity.HasKey(e => new { e.lang, e.codeI });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.ClientGroupTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTGR_REFERENCE_CLIENTGR");
            });

            modelBuilder.Entity<ClnBusinessPlace>(entity =>
            {
                entity.HasKey(e => e.placeId);

                entity.Property(e => e.placeAddress)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.placeCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.placeCountry)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.placeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.placePhone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.ClnBusinessPlace)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_CLNBUSIN_REFERENCE_CLIENT");

                entity.HasOne(d => d.plCodeNavigation)
                    .WithMany(p => p.ClnBusinessPlace)
                    .HasForeignKey(d => d.plCode)
                    .HasConstraintName("FK_CLNBUSIN_REFERENCE_TYPEPLAC");
            });

            modelBuilder.Entity<ClnPlaceHoll>(entity =>
            {
                entity.HasKey(e => e.hollId);

                entity.Property(e => e.hollName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.valueAdd)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.valuePlace)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.place)
                    .WithMany(p => p.ClnPlaceHoll)
                    .HasForeignKey(d => d.placeId)
                    .HasConstraintName("FK_CLNPLACE_REFERENCE_CLNBUSIN");
            });

            modelBuilder.Entity<CommentCause>(entity =>
            {
                entity.HasKey(e => e.causeCode);

                entity.Property(e => e.causeCode).ValueGeneratedNever();

                entity.Property(e => e.causeNameEn)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.causeNameRu)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.causeNameUk)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Community>(entity =>
            {
                entity.HasKey(e => e.custId);

                entity.Property(e => e.custId).ValueGeneratedNever();

                entity.HasOne(d => d.cust)
                    .WithOne(p => p.Community)
                    .HasForeignKey<Community>(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMUNIT_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.custId);

                entity.HasIndex(e => e.custId)
                    .HasName("Association20_FK");

                entity.HasIndex(e => new { e.custId, e.version })
                    .HasName("Association25_FK");

                entity.Property(e => e.custId).ValueGeneratedNever();

                entity.HasOne(d => d.cust)
                    .WithOne(p => p.Company)
                    .HasForeignKey<Company>(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMPANY_ASSOCIATI_CUSTOMER");
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContinentTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.ContinentTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONTINEN_REFERENCE_CONTINEN");
            });

            modelBuilder.Entity<CopyRight>(entity =>
            {
                entity.HasKey(e => e.cRightId);

                entity.HasIndex(e => e.custId)
                    .HasName("Association10_FK");

                entity.Property(e => e.beginDate).HasColumnType("date");

                entity.Property(e => e.createDate).HasColumnType("datetime");

                entity.Property(e => e.endDate).HasColumnType("date");

                entity.Property(e => e.lBasisComment)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.rate).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.roleRate).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.CopyRight)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COPYRIGH_ASSOCIATI_RIGHTHOL");

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.CopyRight)
                    .HasForeignKey(d => d.objId)
                    .HasConstraintName("FK_COPYRIGH_REFERENCE_OBJECTRI");

                entity.HasOne(d => d.roleCodeNavigation)
                    .WithMany(p => p.CopyRight)
                    .HasForeignKey(d => d.roleCode)
                    .HasConstraintName("FK_COPYRIGH_REFERENCE_CREATIVE");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.CopyRight)
                    .HasForeignKey(d => d.status)
                    .HasConstraintName("FK_COPYRIGH_REFERENCE_CRIGHTST");
            });

            modelBuilder.Entity<CopyrightKind>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.HasOne(d => d.crGroupCodeNavigation)
                    .WithMany(p => p.CopyrightKind)
                    .HasForeignKey(d => d.crGroupCode)
                    .HasConstraintName("FK_COPYRIGH_REFERENCE_CRKINDGR");
            });

            modelBuilder.Entity<CopyrightKindTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.CopyrightKindTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COPYRIGH_REFERENCE_COPYR");
            });

            modelBuilder.Entity<CopyrightType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CopyrightTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.CopyrightTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COPYRIGH_REFERENCE_COPYRIGH");
            });

            modelBuilder.Entity<CopyRTranslate>(entity =>
            {
                entity.HasKey(e => e.cRightId);

                entity.Property(e => e.cRightId).ValueGeneratedNever();

                entity.Property(e => e.langFrom)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.langTo)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.cRight)
                    .WithOne(p => p.CopyRTranslate)
                    .HasForeignKey<CopyRTranslate>(d => d.cRightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COPYRTRA_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.langFromNavigation)
                    .WithMany(p => p.CopyRTranslatelangFromNavigation)
                    .HasForeignKey(d => d.langFrom)
                    .HasConstraintName("FK_CRTRAFROM_REFERENCE_LANGUAGE");

                entity.HasOne(d => d.langToNavigation)
                    .WithMany(p => p.CopyRTranslatelangToNavigation)
                    .HasForeignKey(d => d.langTo)
                    .HasConstraintName("FK_CPTRATO_REFERENCE_LANGUAGE");

                entity.HasOne(d => d.roleCodeNavigation)
                    .WithMany(p => p.CopyRTranslate)
                    .HasForeignKey(d => d.roleCode)
                    .HasConstraintName("FK_COPYRTRA_REFERENCE_CREATIVE");
            });

            modelBuilder.Entity<CounterNumber>(entity =>
            {
                entity.HasKey(e => e.counterId);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.prefix)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.symbolN)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.countryCode);

                entity.Property(e => e.countryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.a2)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.countryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.countryNameShort)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.kOD_LIT)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.continentCodeNavigation)
                    .WithMany(p => p.Country)
                    .HasForeignKey(d => d.continentCode)
                    .HasConstraintName("FK_COUNTRY_REFERENCE_CONTINEN");
            });

            modelBuilder.Entity<CountryTr>(entity =>
            {
                entity.HasKey(e => new { e.countryCode, e.lang })
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.countryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.countryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.countryNameShort)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.countryCodeNavigation)
                    .WithMany(p => p.CountryTr)
                    .HasForeignKey(d => d.countryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COUNTRYT_REFERENCE_COUNTRY");
            });

            modelBuilder.Entity<CreativeRoleType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.CRTypeNavigation)
                    .WithMany(p => p.CreativeRoleType)
                    .HasForeignKey(d => d.CRType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREATIVE_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.CreativeRoleType)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREATIVE_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<CreativeRoleTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.CreativeRoleTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREATIVE_REFERENCE_CREATIVE");
            });

            modelBuilder.Entity<CreativeTranslate>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.HasOne(d => d.codeINavigation)
                    .WithOne(p => p.CreativeTranslate)
                    .HasForeignKey<CreativeTranslate>(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTRANSLATE_REFERENCE_CREATIVE");
            });

            modelBuilder.Entity<CRightStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CRightStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.CRightStatusTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRIGHTST_REFERENCE_CRIGHTST");
            });

            modelBuilder.Entity<CRKindGroup>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CRKindGroupTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.CRKindGroupTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRKINDGR_REFERENCE_CRKINDGR");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.r030);

                entity.Property(e => e.r030)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.a3)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.countryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.nAIM)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.r030NameEn)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.r030NameRu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.r030NameUk)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CurrencyCourse>(entity =>
            {
                entity.HasKey(e => new { e.r030, e.cDate });

                entity.Property(e => e.r030)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.cDate).HasColumnType("date");

                entity.Property(e => e.cAmount).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.cAmountNBU).HasColumnType("numeric(18, 5)");

                entity.HasOne(d => d.r030Navigation)
                    .WithMany(p => p.CurrencyCourse)
                    .HasForeignKey(d => d.r030)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CURRENCY_REFERENCE_KL_R030");
            });

            modelBuilder.Entity<CustCmRight>(entity =>
            {
                entity.HasKey(e => new { e.custId, e.cRKindCode, e.dateBegin, e.cmCustId });

                entity.Property(e => e.dateBegin).HasColumnType("date");

                entity.Property(e => e.dateEnd).HasColumnType("date");

                entity.HasOne(d => d.cmCust)
                    .WithMany(p => p.CustCmRight)
                    .HasForeignKey(d => d.cmCustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTCMRI_REFERENCE_COMMUNIT");

                entity.HasOne(d => d.c)
                    .WithMany(p => p.CustCmRight)
                    .HasForeignKey(d => new { d.custId, d.cRKindCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTCMRI_REFERENCE_TERMSOFS");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.custId);

                entity.HasOne(d => d.custTypeNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.custType)
                    .HasConstraintName("FK_CUSTOMER_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMER_REFERENCE_Status");
            });

            modelBuilder.Entity<CustomerStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.CustomerStatusTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMER_REFERENCE_CUSTOMTr");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.CustomerTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMER_REFERENCE_CUSTTR");
            });

            modelBuilder.Entity<DicCategoryItems>(entity =>
            {
                entity.HasKey(e => e.dicName);

                entity.Property(e => e.dicName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.dicType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.url)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeNavigation)
                    .WithMany(p => p.DicCategoryItems)
                    .HasForeignKey(d => d.code)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DICCATEG_REFERENCE_DICTCATE");
            });

            modelBuilder.Entity<DicList>(entity =>
            {
                entity.HasKey(e => e.dicId);

                entity.Property(e => e.dKind)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.dNameEn)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.dNameRu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.dNameUk)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DictCategory>(entity =>
            {
                entity.HasKey(e => e.code);

                entity.Property(e => e.code).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DistribStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DistribStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.DistribStatusTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRIBS_REFERENCE_DISTRIBS");
            });

            modelBuilder.Entity<DistribType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DistribTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.DistribTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRIBT_REFERENCE_DISTRIBT");
            });

            modelBuilder.Entity<Distribution>(entity =>
            {
                entity.HasKey(e => e.distId);

                entity.Property(e => e.amount).HasColumnType("money");

                entity.Property(e => e.courtFee).HasColumnType("money");

                entity.Property(e => e.distribDate).HasColumnType("date");

                entity.Property(e => e.partnerCommiss).HasColumnType("money");

                entity.HasOne(d => d.cRKindCodeNavigation)
                    .WithMany(p => p.Distribution)
                    .HasForeignKey(d => d.cRKindCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.Distribution)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_CLIENT");

                entity.HasOne(d => d.partner)
                    .WithMany(p => p.Distribution)
                    .HasForeignKey(d => d.partnerId)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_PARTNER");

                entity.HasOne(d => d.reg)
                    .WithMany(p => p.Distribution)
                    .HasForeignKey(d => d.regId)
                    .HasConstraintName("FK_DISTRIB_REF_REGISTER");

                entity.HasOne(d => d.regIdBrNavigation)
                    .WithMany(p => p.Distribution)
                    .HasForeignKey(d => d.regIdBr)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_BRREGIST");

                entity.HasOne(d => d.rm)
                    .WithMany(p => p.Distribution)
                    .HasForeignKey(d => d.rmId)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_REGISTER");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.Distribution)
                    .HasForeignKey(d => d.status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_DISTRIBS");
            });

            modelBuilder.Entity<DistributionItem>(entity =>
            {
                entity.HasKey(e => e.distItemId);

                entity.Property(e => e.amount).HasColumnType("numeric(20, 2)");

                entity.HasOne(d => d.dist)
                    .WithMany(p => p.DistributionItem)
                    .HasForeignKey(d => d.distId)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_DISTRIBU");

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.DistributionItem)
                    .HasForeignKey(d => d.objId)
                    .HasConstraintName("FK_DISTRIBU_REFERENCE_OBJECTRI");
            });

            modelBuilder.Entity<DocPreparePay>(entity =>
            {
                entity.HasKey(e => new { e.docPayId, e.dateWork });

                entity.Property(e => e.docPayId).ValueGeneratedOnAdd();

                entity.Property(e => e.dateWork).HasColumnType("datetime");

                entity.Property(e => e.accCredit)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.accDebet)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.amount).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.amountCur).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.dateOper).HasColumnType("date");

                entity.Property(e => e.nD)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.nDDate).HasColumnType("date");

                entity.Property(e => e.payNote)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.r030)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.payStatusNavigation)
                    .WithMany(p => p.DocPreparePay)
                    .HasForeignKey(d => d.payStatus)
                    .HasConstraintName("FK_DOCPREPA_REFERENCE_PAYMENTS");
            });

            modelBuilder.Entity<DocReq>(entity =>
            {
                entity.HasKey(e => new { e.docId, e.reqId });

                entity.HasOne(d => d.req)
                    .WithMany(p => p.DocReq)
                    .HasForeignKey(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCREQ_REFERENCE_REQUEST");
            });

            modelBuilder.Entity<DocText>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Text_En)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Text_Ru)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Text_Uk)
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DocumentTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.DocumentTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCUMENT_REFERENCE_DOCUMENT");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.emplid);

                entity.Property(e => e.email)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.firstName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.lastName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.phoneNumber)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.surName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.userId).HasMaxLength(48);

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_EMPLOYEE_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_EMPLOYEE_REFERENCE_ASPNETUS");
            });

            modelBuilder.Entity<EpisodeType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EpisodeTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.EpisodeTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EPISODET_REFERENCE_EPISODET");
            });

            modelBuilder.Entity<EtGenre>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.EtGenre)
                    .HasForeignKey(d => d.categoryCode)
                    .HasConstraintName("FK_ETGENRE_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<EtGenreRate>(entity =>
            {
                entity.HasKey(e => new { e.actCode, e.genreCode });

                entity.Property(e => e.rate).HasColumnType("numeric(10, 5)");

                entity.HasOne(d => d.actCodeNavigation)
                    .WithMany(p => p.EtGenreRate)
                    .HasForeignKey(d => d.actCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ETGENRER_REFERENCE_ACT");

                entity.HasOne(d => d.genreCodeNavigation)
                    .WithMany(p => p.EtGenreRate)
                    .HasForeignKey(d => d.genreCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ETGENRER_REF_ETGENRE");
            });

            modelBuilder.Entity<EtGenreRole>(entity =>
            {
                entity.HasKey(e => new { e.genreCode, e.roleCode, e.actCode });

                entity.Property(e => e.rate).HasColumnType("numeric(10, 5)");

                entity.HasOne(d => d.actCodeNavigation)
                    .WithMany(p => p.EtGenreRole)
                    .HasForeignKey(d => d.actCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ETGENRER_REFERENCE_OBJACT");

                entity.HasOne(d => d.genreCodeNavigation)
                    .WithMany(p => p.EtGenreRole)
                    .HasForeignKey(d => d.genreCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ETGENRER_REFERENCE_ETGENRE");

                entity.HasOne(d => d.roleCodeNavigation)
                    .WithMany(p => p.EtGenreRole)
                    .HasForeignKey(d => d.roleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ETGENRER_REFERENCE_ETROLE");
            });

            modelBuilder.Entity<EtRole>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.EtRole)
                    .HasForeignKey(d => d.categoryCode)
                    .HasConstraintName("FK_ETROLE_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<ExternalPay>(entity =>
            {
                entity.HasKey(e => e.paidId);

                entity.Property(e => e.account)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.accountCorr)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.codeOper)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.dateOper).HasColumnType("date");

                entity.Property(e => e.docDate).HasColumnType("date");

                entity.Property(e => e.docNum)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.inputDate).HasColumnType("datetime");

                entity.Property(e => e.mfo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.mfoCorr)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.nameCorr)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.nameMfoCorr)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.nplat)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.okpoCorr)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.okpol)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.r030)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.sCredit).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.sDebet).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.sNcCur).HasColumnType("numeric(20, 2)");
            });

            modelBuilder.Entity<FileCustomer>(entity =>
            {
                entity.HasKey(e => e.docId);

                entity.Property(e => e.createDate).HasColumnType("datetime");

                entity.Property(e => e.docComment)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.docFile)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.mimeType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.FileCustomer)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILECUST_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.docTypeNavigation)
                    .WithMany(p => p.FileCustomer)
                    .HasForeignKey(d => d.docType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILECUST_REFERENCE_TYPE");
            });

            modelBuilder.Entity<FileType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fixation>(entity =>
            {
                entity.HasKey(e => e.fixId);

                entity.Property(e => e.address).HasMaxLength(255);

                entity.Property(e => e.city).HasMaxLength(255);

                entity.Property(e => e.clientInnOkpo).HasMaxLength(12);

                entity.Property(e => e.clientName).HasMaxLength(255);

                entity.Property(e => e.courtFeeAmount).HasColumnType("money");

                entity.Property(e => e.eventDates).HasMaxLength(255);

                entity.Property(e => e.eventName).HasMaxLength(255);

                entity.Property(e => e.fixationDate).HasColumnType("date");

                entity.Property(e => e.placement).HasMaxLength(255);

                entity.Property(e => e.rewardAmount).HasColumnType("money");

                entity.Property(e => e.ticketPriceMax).HasColumnType("money");

                entity.Property(e => e.ticketPriceMin).HasColumnType("money");

                entity.Property(e => e.userId).HasMaxLength(48);

                entity.HasOne(d => d.clientCust)
                    .WithMany(p => p.Fixation)
                    .HasForeignKey(d => d.clientCustId)
                    .HasConstraintName("FK_FIXATION_REFERENCE_CLIENT");

                entity.HasOne(d => d.lic)
                    .WithMany(p => p.Fixation)
                    .HasForeignKey(d => d.licId)
                    .HasConstraintName("FK_FIXATION_REFERENCE_LICENSEA");

                entity.HasOne(d => d.partnerCust)
                    .WithMany(p => p.Fixation)
                    .HasForeignKey(d => d.partnerCustId)
                    .HasConstraintName("FK_FIXATION_REFERENCE_PARTNER");

                entity.HasOne(d => d.stageStatusNavigation)
                    .WithMany(p => p.Fixation)
                    .HasForeignKey(d => d.stageStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FIXATION_REFERENCE_FIXSTAGE");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.Fixation)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_FIXATION_REF_ASPNETUSER");

                entity.HasOne(d => d.usesTypeNavigation)
                    .WithMany(p => p.Fixation)
                    .HasForeignKey(d => d.usesType)
                    .HasConstraintName("FK_FIXATION_REFERENCE_USESTYPE");
            });

            modelBuilder.Entity<FixFile>(entity =>
            {
                entity.HasKey(e => e.fileId);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.path)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.fix)
                    .WithMany(p => p.FixFile)
                    .HasForeignKey(d => d.fixId)
                    .HasConstraintName("FK_FIXFILE_REF_FIXATION");
            });

            modelBuilder.Entity<FixStageStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.StageName).HasMaxLength(255);

                entity.Property(e => e.StatusName).HasMaxLength(255);
            });

            modelBuilder.Entity<FixStorageDevice>(entity =>
            {
                entity.HasKey(e => e.storageId);

                entity.Property(e => e.capacity).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.serialNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.fix)
                    .WithMany(p => p.FixStorageDevice)
                    .HasForeignKey(d => d.fixId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FIXSTORAGE_REF_FIXATION");
            });

            modelBuilder.Entity<FolkType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FolkTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.FolkTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FOLKTYPE_REFERENCE_FOLKTYPE");
            });

            modelBuilder.Entity<GenreType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.GenreType)
                    .HasForeignKey(d => d.categoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBJECTTY_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<GenreTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.GenreTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GENRETYP_REFERENCE_GENRETYP");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.docId);

                entity.Property(e => e.docId).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.purpose)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.r030)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.recBankName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.recMFO)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.ItemStatusTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEMSTAT_REFERENCE_ITEMSTAT");
            });

            modelBuilder.Entity<KindComposition>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.KindComposition)
                    .HasForeignKey(d => d.categoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KINDCOMP_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<KindCompositionTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.KindCompositionTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KINDCOMP_REFERENCE_KINDCOMP");
            });

            modelBuilder.Entity<KindFilm>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KindFilmTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.KindFilmTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KINDFILM_REFERENCE_KINDFILM");
            });

            modelBuilder.Entity<KindSerial>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KindSerialTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.KindSerialTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KINDSERI_REFERENCE_KINDSERI");
            });

            modelBuilder.Entity<KL_R030>(entity =>
            {
                entity.HasKey(e => e.r030);

                entity.Property(e => e.r030)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.a3)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.countryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.nAIM)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.r030Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.countryCodeNavigation)
                    .WithMany(p => p.KL_R030)
                    .HasForeignKey(d => d.countryCode)
                    .HasConstraintName("FK_KL_R030_REFERENCE_COUNTRY");

                entity.HasOne(d => d.r031Navigation)
                    .WithMany(p => p.KL_R030)
                    .HasForeignKey(d => d.r031)
                    .HasConstraintName("FK_KL_R030_REFERENCE_KL_R031");
            });

            modelBuilder.Entity<KL_R030Tr>(entity =>
            {
                entity.HasKey(e => new { e.r030, e.lang });

                entity.Property(e => e.r030)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.r030Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.r030Navigation)
                    .WithMany(p => p.KL_R030Tr)
                    .HasForeignKey(d => d.r030)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_R030TR_REFERENCE_KL_R030");
            });

            modelBuilder.Entity<KL_R031>(entity =>
            {
                entity.HasKey(e => e.r031);

                entity.Property(e => e.r031).ValueGeneratedNever();

                entity.Property(e => e.r031NameEn)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.r031NameRu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.r031NameUk)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lang>(entity =>
            {
                entity.HasKey(e => e.codeS);

                entity.Property(e => e.codeS)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LangTr>(entity =>
            {
                entity.HasKey(e => new { e.codeS, e.lang });

                entity.Property(e => e.codeS)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeSNavigation)
                    .WithMany(p => p.LangTr)
                    .HasForeignKey(d => d.codeS)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LANGTR_REFERENCE_LANG");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.codeS);

                entity.Property(e => e.codeS)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.nameSh3)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LegalBasis>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LegalBasisTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.LegalBasisTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LEGALBAS_REFERENCE_LEGALBAS");
            });

            modelBuilder.Entity<LicAuthorBR>(entity =>
            {
                entity.HasKey(e => e.cRightId);

                entity.Property(e => e.cRightId).ValueGeneratedNever();

                entity.Property(e => e.dateAccept).HasColumnType("date");

                entity.Property(e => e.dateClose).HasColumnType("date");

                entity.Property(e => e.dateCreate).HasColumnType("date");

                entity.Property(e => e.dateModify).HasColumnType("date");

                entity.Property(e => e.prepayDateDo).HasColumnType("date");

                entity.Property(e => e.prepayRest).HasColumnType("money");

                entity.Property(e => e.prepaySum).HasColumnType("money");

                entity.Property(e => e.prepaySumAuthor).HasColumnType("money");

                entity.Property(e => e.prepayUsed).HasColumnType("money");

                entity.Property(e => e.r030)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.rate).HasColumnType("numeric(10, 5)");

                entity.HasOne(d => d.cRight)
                    .WithOne(p => p.LicAuthorBR)
                    .HasForeignKey<LicAuthorBR>(d => d.cRightId)
                    .HasConstraintName("FK_LICAUTHO_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.prepayTypeNavigation)
                    .WithMany(p => p.LicAuthorBR)
                    .HasForeignKey(d => d.prepayType)
                    .HasConstraintName("FK_LICAUTHO_REFERENCE_PREPAYTY");
            });

            modelBuilder.Entity<License>(entity =>
            {
                entity.HasKey(e => e.lId);

                entity.Property(e => e.lDate).HasColumnType("date");

                entity.Property(e => e.lNum)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.place)
                    .WithMany(p => p.License)
                    .HasForeignKey(d => d.placeId)
                    .HasConstraintName("FK_LICENSE_REFERENCE_CLNBUSIN");

                entity.HasOne(d => d.lic)
                    .WithMany(p => p.License)
                    .HasForeignKey(d => new { d.licId, d.licVersion })
                    .HasConstraintName("FK_LICENSE_REFERENCE_LICENSEA");
            });

            modelBuilder.Entity<LicenseAgreement>(entity =>
            {
                entity.HasKey(e => e.licId);

                entity.HasOne(d => d.agr)
                    .WithMany(p => p.LicenseAgreement)
                    .HasForeignKey(d => d.agrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICENSEA_REF_AGREEMEN");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.LicenseAgreement)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_LICENSEA_REFERENCE_CLIENT");

                entity.HasOne(d => d.licCodeNavigation)
                    .WithMany(p => p.LicenseAgreement)
                    .HasForeignKey(d => d.licCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICENSEA_REFERENCE_ARGLICEN");

                entity.HasOne(d => d.licStatusNavigation)
                    .WithMany(p => p.LicenseAgreement)
                    .HasForeignKey(d => d.licStatus)
                    .HasConstraintName("FK_LICENSEA_REFERENCE_MASTER");

                entity.HasOne(d => d.licTypeNavigation)
                    .WithMany(p => p.LicenseAgreement)
                    .HasForeignKey(d => d.licType)
                    .HasConstraintName("FK_LICENSEA_REFERENCE_LICENSET");
            });

            modelBuilder.Entity<LicenseAgrParam>(entity =>
            {
                entity.HasKey(e => new { e.licId, e.licVersion });

                entity.Property(e => e.addRate).HasColumnType("numeric(10, 5)");

                entity.Property(e => e.comment)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.dateBegin).HasColumnType("date");

                entity.Property(e => e.dateEnd).HasColumnType("date");

                entity.Property(e => e.indxInfl).HasColumnType("numeric(10, 5)");

                entity.Property(e => e.licDate).HasColumnType("date");

                entity.Property(e => e.licNum)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.minAmount).HasColumnType("money");

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.rateAmount).HasColumnType("numeric(10, 5)");

                entity.HasOne(d => d.lic)
                    .WithMany(p => p.LicenseAgrParam)
                    .HasForeignKey(d => d.licId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICENSEA_REFERENCE_LICENSEA");

                entity.HasOne(d => d.licStatusNavigation)
                    .WithMany(p => p.LicenseAgrParam)
                    .HasForeignKey(d => d.licStatus)
                    .HasConstraintName("FK_LICENSEA_REFERENCE_AGREEMEN");

                entity.HasOne(d => d.periodCodeNavigation)
                    .WithMany(p => p.LicenseAgrParam)
                    .HasForeignKey(d => d.periodCode)
                    .HasConstraintName("FK_LICENSEA_REF_PERIOD");
            });

            modelBuilder.Entity<LicenseBigR>(entity =>
            {
                entity.HasKey(e => e.licId);

                entity.Property(e => e.licId).ValueGeneratedNever();

                entity.Property(e => e.datePremiere).HasColumnType("date");

                entity.Property(e => e.fillingRate).HasColumnType("numeric(10, 5)");

                entity.Property(e => e.langCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.prepayRest).HasColumnType("money");

                entity.Property(e => e.rate).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.rateMusic).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ticketPriceNC).HasColumnType("money");

                entity.Property(e => e.ticketPriceUSD).HasColumnType("money");

                entity.Property(e => e.whereTour)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.langCodeNavigation)
                    .WithMany(p => p.LicenseBigR)
                    .HasForeignKey(d => d.langCode)
                    .HasConstraintName("FK_LICENSEB_REFERENCE_LANGUAGE");

                entity.HasOne(d => d.lic)
                    .WithOne(p => p.LicenseBigR)
                    .HasForeignKey<LicenseBigR>(d => d.licId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICENSEB_REFERENCE_LICENSEA");

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.LicenseBigR)
                    .HasForeignKey(d => d.objId)
                    .HasConstraintName("FK_LICENSEB_REFERENCE_OBJECTRI");

                entity.HasOne(d => d.performTypeNavigation)
                    .WithMany(p => p.LicenseBigR)
                    .HasForeignKey(d => d.performType)
                    .HasConstraintName("FK_LICENSEB_REFERENCE_PERFORMT");
            });

            modelBuilder.Entity<LicenseClass>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LicenseType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LicenseTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.LicenseTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICENSET_REFERENCE_LICENSET");
            });

            modelBuilder.Entity<licPlace>(entity =>
            {
                entity.HasKey(e => new { e.licId, e.placeId });

                entity.HasOne(d => d.lic)
                    .WithMany(p => p.licPlace)
                    .HasForeignKey(d => d.licId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICPLACE_REFERENCE_LICENSEA");

                entity.HasOne(d => d.place)
                    .WithMany(p => p.licPlace)
                    .HasForeignKey(d => d.placeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICPLACE_REFERENCE_CLNBUSIN");
            });

            modelBuilder.Entity<MediaFile>(entity =>
            {
                entity.Property(e => e.fileType)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.path)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.MediaFile)
                    .HasForeignKey(d => d.objId)
                    .HasConstraintName("FK_MEDIAFIL_ASSOCIATI_MEDIATRA");
            });

            modelBuilder.Entity<MediaSearchData>(entity =>
            {
                entity.HasIndex(e => new { e.typeData, e.alterNameNormalize, e.objId })
                    .HasName("search_idx");

                entity.Property(e => e.alterName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.alterNameNormalize)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MediaTrack>(entity =>
            {
                entity.HasKey(e => e.objId);

                entity.Property(e => e.objId).ValueGeneratedNever();

                entity.Property(e => e.Album)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.composers)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.genre)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.iswc)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.label)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.lyrics)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.performers)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.obj)
                    .WithOne(p => p.MediaTrack)
                    .HasForeignKey<MediaTrack>(d => d.objId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEDIATRA_ASSOCIATI_OBJECTRI");
            });

            modelBuilder.Entity<ModifyMusicType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.ModifyMusicType)
                    .HasForeignKey(d => d.categoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MODIFYMU_REFERENCE_CATEGORY");

                entity.HasOne(d => d.kindCompCodeNavigation)
                    .WithMany(p => p.ModifyMusicType)
                    .HasForeignKey(d => d.kindCompCode)
                    .HasConstraintName("FK_MODIFYMU_REFERENCE_KINDCOMP");
            });

            modelBuilder.Entity<ModifyMusicTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.ModifyMusicTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MODIFYMU_REFERENCE_MODIFYMU");
            });

            modelBuilder.Entity<ModifyTextType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.ModifyTextType)
                    .HasForeignKey(d => d.categoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MODIFYTE_REFERENCE_CATEGORY");

                entity.HasOne(d => d.kindCompCodeNavigation)
                    .WithMany(p => p.ModifyTextType)
                    .HasForeignKey(d => d.kindCompCode)
                    .HasConstraintName("FK_MODIFYTE_REFERENCE_KINDCOMP");
            });

            modelBuilder.Entity<ModifyTextTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.ModifyTextTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MODIFYTE_REFERENCE_MODIFYTE");
            });

            modelBuilder.Entity<ModifyType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.ModifyType)
                    .HasForeignKey(d => d.categoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MODIFYTY_REFERENCE_CATEGORY");

                entity.HasOne(d => d.kindCompCodeNavigation)
                    .WithMany(p => p.ModifyType)
                    .HasForeignKey(d => d.kindCompCode)
                    .HasConstraintName("FK_MODIFYTY_REFERENCE_KINDCOMP");
            });

            modelBuilder.Entity<ModifyTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.ModifyTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MODIFYTY_REFERENCE_MODIFYTY");
            });

            modelBuilder.Entity<MoneyLinkStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MoneyLinkStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.MoneyLinkStatusTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYLIN_REFERENCE_MONEYLIN");
            });

            modelBuilder.Entity<MoneyPeriodLink>(entity =>
            {
                entity.HasKey(e => new { e.paidId, e.periodId, e.licId });

                entity.Property(e => e.amount).HasColumnType("money");

                entity.Property(e => e.modifyDate).HasColumnType("date");

                entity.HasOne(d => d.lic)
                    .WithMany(p => p.MoneyPeriodLink)
                    .HasForeignKey(d => d.licId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYPER_REFERENCE_LICENSEA");

                entity.HasOne(d => d.paid)
                    .WithMany(p => p.MoneyPeriodLink)
                    .HasForeignKey(d => d.paidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYPER_REFERENCE_MONEYREC");

                entity.HasOne(d => d.period)
                    .WithMany(p => p.MoneyPeriodLink)
                    .HasForeignKey(d => d.periodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYPER_REFERENCE_PAIDPERI");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.MoneyPeriodLink)
                    .HasForeignKey(d => d.status)
                    .HasConstraintName("FK_MONEYPER_REFERENCE_MONEYLIN");
            });

            modelBuilder.Entity<MoneyPrepayLink>(entity =>
            {
                entity.HasKey(e => new { e.paidId, e.cRightId });

                entity.Property(e => e.amount).HasColumnType("money");

                entity.HasOne(d => d.paid)
                    .WithMany(p => p.MoneyPrepayLink)
                    .HasForeignKey(d => d.paidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYPRE_REFERENCE_MONEYREC");
            });

            modelBuilder.Entity<MoneyReceived>(entity =>
            {
                entity.HasKey(e => e.paidId);

                entity.Property(e => e.paidId).ValueGeneratedNever();

                entity.Property(e => e.amount).HasColumnType("money");

                entity.Property(e => e.dateInvoice).HasColumnType("date");

                entity.Property(e => e.destribAmount).HasColumnType("money");

                entity.Property(e => e.destribPrepay).HasColumnType("money");

                entity.Property(e => e.goalInvoice)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.numberInvoice)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.MoneyReceived)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYREC_REFERENCE_CLIENT");

                entity.HasOne(d => d.moneyTypeNavigation)
                    .WithMany(p => p.MoneyReceived)
                    .HasForeignKey(d => d.moneyType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYREC_REFERENCE_MONEYTYP");
            });

            modelBuilder.Entity<MoneyType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MoneyTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.MoneyTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONEYTYP_REFERENCE_MONEYTYP");
            });

            modelBuilder.Entity<MusicalDesign>(entity =>
            {
                entity.HasKey(e => e.mdId);

                entity.Property(e => e.authorText)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.nameMusician)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.nameSinger)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.objName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.lic)
                    .WithMany(p => p.MusicalDesign)
                    .HasForeignKey(d => d.licId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MUSICALD_REFERENCE_LICENSEB");

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.MusicalDesign)
                    .HasForeignKey(d => d.objid)
                    .HasConstraintName("FK_MUSICALD_REFERENCE_OBJECTRI");
            });

            modelBuilder.Entity<MyAnketa>(entity =>
            {
                entity.HasKey(e => e.custId);

                entity.Property(e => e.custId).ValueGeneratedNever();

                entity.Property(e => e.accCommission)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.accCompany)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.accCourt)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.accInCommission)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.cust)
                    .WithOne(p => p.MyAnketa)
                    .HasForeignKey<MyAnketa>(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MYANKETA_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<MyCategory>(entity =>
            {
                entity.HasKey(e => new { e.custId, e.codeI });

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.MyCategory)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MYCATEGO_REFERENCE_CATEGORY");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.MyCategory)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MYCATEGO_REFERENCE_MYANKETA");
            });

            modelBuilder.Entity<myCopyRightType>(entity =>
            {
                entity.HasKey(e => new { e.custId, e.cRType });

                entity.HasOne(d => d.cRTypeNavigation)
                    .WithMany(p => p.myCopyRightType)
                    .HasForeignKey(d => d.cRType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MYCOPYRI_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.myCopyRightType)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MYCOPYRI_REFERENCE_MYANKETA");
            });

            modelBuilder.Entity<ObjAct>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ObjActTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.ObjActTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBJACTTR_REFERENCE_OBJACT");
            });

            modelBuilder.Entity<ObjectRight>(entity =>
            {
                entity.HasKey(e => e.objId);

                entity.HasIndex(e => e.reqId)
                    .HasName("Relationship_13_FK");

                entity.HasIndex(e => new { e.name, e.author, e.performer })
                    .HasName("idx_name");

                entity.Property(e => e.ObjImg)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.author)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.createDate).HasColumnType("datetime");

                entity.Property(e => e.innerCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.performer)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.actCodeNavigation)
                    .WithMany(p => p.ObjectRight)
                    .HasForeignKey(d => d.actCode)
                    .HasConstraintName("FK_OBJECTRI_REFERENCE_OBJACT");

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.ObjectRight)
                    .HasForeignKey(d => d.categoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBJECTRI_REFERENCE_CATEGORY");

                entity.HasOne(d => d.specTypeNavigation)
                    .WithMany(p => p.ObjectRight)
                    .HasForeignKey(d => d.specType)
                    .HasConstraintName("FK_OBJECTRI_REFERENCE_SPECTYPE");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.ObjectRight)
                    .HasForeignKey(d => d.status)
                    .HasConstraintName("FK_OBJECTRI_REFERENCE_OBJECTST");
            });

            modelBuilder.Entity<ObjectStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ObjectStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.ObjectStatusTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBJECTST_REFERENCE_OBJECTST");
            });

            modelBuilder.Entity<PaidPeriod>(entity =>
            {
                entity.HasKey(e => e.periodId);

                entity.HasIndex(e => new { e.periodId, e.periodName })
                    .HasName("idx_paidPeriod01")
                    .IsUnique();

                entity.HasIndex(e => new { e.licId, e.beginDate, e.endDate })
                    .HasName("uipaidperiod_001")
                    .IsUnique();

                entity.Property(e => e.amount).HasColumnType("money");

                entity.Property(e => e.beginDate).HasColumnType("date");

                entity.Property(e => e.dateActPrint).HasColumnType("date");

                entity.Property(e => e.distribamount).HasColumnType("money");

                entity.Property(e => e.endDate).HasColumnType("date");

                entity.Property(e => e.periodName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.undistribamount).HasColumnType("money");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.PaidPeriod)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAIDPERI_REFERENCE_CLIENT");

                entity.HasOne(d => d.lic)
                    .WithMany(p => p.PaidPeriod)
                    .HasForeignKey(d => d.licId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAIDPERI_REFERENCE_LICENSEA");

                entity.HasOne(d => d.periodTypeNavigation)
                    .WithMany(p => p.PaidPeriod)
                    .HasForeignKey(d => d.periodType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAIDPERI_REFERENCE_PERIOD");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.PaidPeriod)
                    .HasForeignKey(d => d.status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAIDPERI_REFERENCE_PERIODST");
            });

            modelBuilder.Entity<ParametersListBox>(entity =>
            {
                entity.HasKey(e => new { e.repId, e.pId });

                entity.Property(e => e.valueName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.valuePar)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.valueType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasKey(e => e.custId);

                entity.Property(e => e.custId).ValueGeneratedNever();

                entity.HasOne(d => d.cust)
                    .WithOne(p => p.Partner)
                    .HasForeignKey<Partner>(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARTNER_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<PartnerClient>(entity =>
            {
                entity.HasKey(e => new { e.custId, e.clCustId });

                entity.HasOne(d => d.clCust)
                    .WithMany(p => p.PartnerClient)
                    .HasForeignKey(d => d.clCustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARTNERC_REFERENCE_CLIENT");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.PartnerClient)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARTNERC_REFERENCE_PARTNER");
            });

            modelBuilder.Entity<PaymentCase>(entity =>
            {
                entity.HasKey(e => e.reqId);

                entity.Property(e => e.reqId).ValueGeneratedNever();

                entity.Property(e => e.dateForPay).HasColumnType("date");

                entity.Property(e => e.dateInvoce).HasColumnType("date");

                entity.Property(e => e.datePay).HasColumnType("date");

                entity.Property(e => e.datePayFact).HasColumnType("date");

                entity.Property(e => e.otherCase)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.payKindNavigation)
                    .WithMany(p => p.PaymentCase)
                    .HasForeignKey(d => d.payKind)
                    .HasConstraintName("FK_PAYMENTC_REFERENCE_PAYMENTK");

                entity.HasOne(d => d.payMethodNavigation)
                    .WithMany(p => p.PaymentCase)
                    .HasForeignKey(d => d.payMethod)
                    .HasConstraintName("FK_PAYMENTC_REFERENCE_PAYMETHO");

                entity.HasOne(d => d.req)
                    .WithOne(p => p.PaymentCase)
                    .HasForeignKey<PaymentCase>(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMENTC_REFERENCE_REQUEST");
            });

            modelBuilder.Entity<PaymentKind>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.HasIndex(e => e.codeI)
                    .HasName("AK_KEY_1_PAYMENTK")
                    .IsUnique();

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentKindTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.PaymentKindTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMENTK_REFERENCE_PAYMENTK");
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.PaymentStatusTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMENTS_REFERENCE_PAYMENTS");
            });

            modelBuilder.Entity<PayMethodType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PayMethodTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.PayMethodTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMETHO_REFERENCE_PAYMETHO");
            });

            modelBuilder.Entity<PayTurn>(entity =>
            {
                entity.HasKey(e => new { e.turnId, e.dateWork });

                entity.HasIndex(e => e.dateOper)
                    .HasName("date_idx");

                entity.Property(e => e.dateWork).HasColumnType("datetime");

                entity.Property(e => e.accCredit)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.accDebet)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.amount).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.amountCur).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.dateOper).HasColumnType("date");

                entity.Property(e => e.nD)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.nDDate).HasColumnType("date");

                entity.Property(e => e.payNote)
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.r030)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.accIdDebetNavigation)
                    .WithMany(p => p.PayTurn)
                    .HasForeignKey(d => d.accIdDebet)
                    .HasConstraintName("FK_PAYTURN_REFERENCE_ACCOUNT");

                entity.HasOne(d => d.payStatusNavigation)
                    .WithMany(p => p.PayTurn)
                    .HasForeignKey(d => d.payStatus)
                    .HasConstraintName("FK_PAYTURN_REFERENCE_PAYMENTS");
            });

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.HasKey(e => e.perId);

                entity.Property(e => e.perName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PerformType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PerformTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.PerformTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERFORMT_REFERENCE_PERFORMT");
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.nameR)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PeriodStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PeriodStatusTr>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.lang)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithOne(p => p.PeriodStatusTr)
                    .HasForeignKey<PeriodStatusTr>(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERIODST_REFERENCE_PERIODST");
            });

            modelBuilder.Entity<PeriodTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.nameR)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.PeriodTr)
                    .HasForeignKey(d => d.codeI)
                    .HasConstraintName("FK_PERIODTR_REFERENCE_PERIOD");
            });

            modelBuilder.Entity<PermitType>(entity =>
            {
                entity.HasKey(e => e.codeB);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PermitTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeB, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeBNavigation)
                    .WithMany(p => p.PermitTypeTr)
                    .HasForeignKey(d => d.codeB)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERMITTY_REFERENCE_PERMITTY");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.custId);

                entity.HasIndex(e => e.custId)
                    .HasName("Association21_FK");

                entity.HasIndex(e => new { e.custId, e.version })
                    .HasName("Association24_FK");

                entity.Property(e => e.custId).ValueGeneratedNever();

                entity.HasOne(d => d.cust)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERSON_ASSOCIATI_CUSTOMER");
            });

            modelBuilder.Entity<PopGenre>(entity =>
            {
                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.PopGenre)
                    .HasForeignKey(d => d.categoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GENRE_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<PopGenreTr>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.PopGenreTr)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GENRETR_REFERENCE_GENRE");
            });

            modelBuilder.Entity<PortalObjectRights>(entity =>
            {
                entity.HasKey(e => new { e.objId, e.cRKindCode });

                entity.HasOne(d => d.cRKindCodeNavigation)
                    .WithMany(p => p.PortalObjectRights)
                    .HasForeignKey(d => d.cRKindCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PORTALOB_REFERENCE_PORTALSU");

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.PortalObjectRights)
                    .HasForeignKey(d => d.objId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PORTALOB_REFERENCE_OBJECTRI");
            });

            modelBuilder.Entity<PortalSupportRights>(entity =>
            {
                entity.HasKey(e => e.cRKindCode);

                entity.Property(e => e.cRKindCode).ValueGeneratedNever();

                entity.HasOne(d => d.cRKindCodeNavigation)
                    .WithOne(p => p.PortalSupportRights)
                    .HasForeignKey<PortalSupportRights>(d => d.cRKindCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PORTALOB_REFERENCE_COPYRIGH");
            });

            modelBuilder.Entity<PositionType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PositionTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.PositionTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POSITION_REFERENCE_POSITION");
            });

            modelBuilder.Entity<PrePayType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrePayTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.PrePayTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PREPAYTY_REFERENCE_PREPAYTY");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegionTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.RegionTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGIONTR_REFERENCE_REGION");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.regId);

                entity.Property(e => e.authAmount).HasColumnType("money");

                entity.Property(e => e.authRate).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.createDate).HasColumnType("datetime");

                entity.Property(e => e.fileName)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.musicAmount).HasColumnType("money");

                entity.Property(e => e.musicRate).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.number)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.paidAmount).HasColumnType("money");

                entity.Property(e => e.regAmount).HasColumnType("money");

                entity.Property(e => e.regRate).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.regRoyalty).HasColumnType("money");

                entity.Property(e => e.userId).HasMaxLength(48);

                entity.HasOne(d => d.algorithm)
                    .WithMany(p => p.Register)
                    .HasForeignKey(d => d.algorithmId)
                    .HasConstraintName("FK_REGISTER_REFERENCE_ALGORITH");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.Register)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REG_REF_CLIENT");

                entity.HasOne(d => d.rgStatusNavigation)
                    .WithMany(p => p.Register)
                    .HasForeignKey(d => d.rgStatus)
                    .HasConstraintName("FK_REGISTER_REFERENCE_REGISTER2");

                entity.HasOne(d => d.rm)
                    .WithMany(p => p.Register)
                    .HasForeignKey(d => d.rmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REG_REF_REGRATELIST");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.Register)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_REGISTER_REFERENCE_ASPNETUS");
            });

            modelBuilder.Entity<RegisterAuthors>(entity =>
            {
                entity.HasKey(e => new { e.regId, e.regIItemId, e.authId });

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeRoleNavigation)
                    .WithMany(p => p.RegisterAuthors)
                    .HasForeignKey(d => d.codeRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REG_REF_CREAROLE");
            });

            modelBuilder.Entity<RegisterCount>(entity =>
            {
                entity.HasKey(e => e.regCntId);

                entity.Property(e => e.regCntId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.prepaySum).HasColumnType("money");

                entity.Property(e => e.rate).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.rateCommiss).HasColumnType("decimal(10, 5)");

                entity.HasOne(d => d.cRKindCodeNavigation)
                    .WithMany(p => p.RegisterCount)
                    .HasForeignKey(d => d.cRKindCode)
                    .HasConstraintName("FK_REGISTER_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.cmCust)
                    .WithMany(p => p.RegisterCount)
                    .HasForeignKey(d => d.cmCustId)
                    .HasConstraintName("FK_REGISTER_REFERENCE_COMMUNIT");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.RegisterCount)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_REGISTER_REFERENCE_RIGHTHOL");

                entity.HasOne(d => d.regI)
                    .WithMany(p => p.RegisterCount)
                    .HasForeignKey(d => new { d.regItemIdBr, d.regIdBr })
                    .HasConstraintName("FK_REGISTER_REFERENCE_BRREGITE");
            });

            modelBuilder.Entity<RegisterExtra>(entity =>
            {
                entity.HasKey(e => e.regExtraId);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.roleCodeNavigation)
                    .WithMany(p => p.RegisterExtra)
                    .HasForeignKey(d => d.roleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGEX_REF_CREATIVEROLE");

                entity.HasOne(d => d.regI)
                    .WithMany(p => p.RegisterExtra)
                    .HasForeignKey(d => new { d.regId, d.regIItemId })
                    .HasConstraintName("FK_REGEX_REF_REGITEM");
            });

            modelBuilder.Entity<RegisterItem>(entity =>
            {
                entity.HasKey(e => new { e.regId, e.regIItemId });

                entity.Property(e => e.ItemName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.authorMusic)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.authorText)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.performer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeItemNavigation)
                    .WithMany(p => p.RegisterItem)
                    .HasForeignKey(d => d.codeItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGITEM_REF_REGITEMTYPE");

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.RegisterItem)
                    .HasForeignKey(d => d.objId)
                    .HasConstraintName("FK_REGITEM_REF_OBJRIGHT");

                entity.HasOne(d => d.reg)
                    .WithMany(p => p.RegisterItem)
                    .HasForeignKey(d => d.regId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGISTER_REF_REGITEM");
            });

            modelBuilder.Entity<RegisterItemType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegisterListStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegisterListStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.RegisterListStatusTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGISTERList_REF_REGISTERSt");
            });

            modelBuilder.Entity<RegisterRatedList>(entity =>
            {
                entity.HasKey(e => e.rmId);

                entity.Property(e => e.amount).HasColumnType("money");

                entity.Property(e => e.createDate).HasColumnType("date");

                entity.Property(e => e.paidAmount).HasColumnType("money");

                entity.Property(e => e.royalty).HasColumnType("money");

                entity.Property(e => e.userId).HasMaxLength(48);

                entity.HasOne(d => d.period)
                    .WithMany(p => p.RegisterRatedList)
                    .HasForeignKey(d => d.periodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGRATEDLIST_REF_PAIDPER");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.RegisterRatedList)
                    .HasForeignKey(d => d.status)
                    .HasConstraintName("FK_REGISTER_REF_REGISTERList");
            });

            modelBuilder.Entity<RegisterStatus>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegisterStatusTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.RegisterStatusTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGISTER_REFERENCE_REGISTER");
            });

            modelBuilder.Entity<RelAdaptUseArea>(entity =>
            {
                entity.HasKey(e => new { e.reqId, e.useAreaTypeCode });

                entity.HasOne(d => d.req)
                    .WithMany(p => p.RelAdaptUseArea)
                    .HasForeignKey(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELADAPT_REFERENCE_REQUESTA");

                entity.HasOne(d => d.useAreaTypeCodeNavigation)
                    .WithMany(p => p.RelAdaptUseArea)
                    .HasForeignKey(d => d.useAreaTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELADAPT_REFERENCE_USEAREAT");
            });

            modelBuilder.Entity<relCounterDoc>(entity =>
            {
                entity.HasKey(e => e.cDocId);

                entity.HasOne(d => d.counter)
                    .WithMany(p => p.relCounterDoc)
                    .HasForeignKey(d => d.counterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELCOUNT_REFERENCE_COUNTERN");

                entity.HasOne(d => d.docTypeNavigation)
                    .WithMany(p => p.relCounterDoc)
                    .HasForeignKey(d => d.docType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELCOUNT_REFERENCE_DOCUMENT");

                entity.HasOne(d => d.licTypeNavigation)
                    .WithMany(p => p.relCounterDoc)
                    .HasForeignKey(d => d.licType)
                    .HasConstraintName("FK_RELCOUNT_REFERENCE_AGRLICEN");
            });

            modelBuilder.Entity<RelDocAgrType>(entity =>
            {
                entity.HasKey(e => new { e.agrType, e.docType });

                entity.HasOne(d => d.agrTypeNavigation)
                    .WithMany(p => p.RelDocAgrType)
                    .HasForeignKey(d => d.agrType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELDOCAG_REFERENCE_AGREEMEN");

                entity.HasOne(d => d.docTypeNavigation)
                    .WithMany(p => p.RelDocAgrType)
                    .HasForeignKey(d => d.docType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELDOCAG_REFERENCE_DOCUMENT");
            });

            modelBuilder.Entity<RelEmployee>(entity =>
            {
                entity.HasKey(e => new { e.custId, e.emplid, e.positionCode });

                entity.Property(e => e.relDocument)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.RelEmployee)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELEMPLO_ASSOCIATI_COMPANY");

                entity.HasOne(d => d.empl)
                    .WithMany(p => p.RelEmployee)
                    .HasForeignKey(d => d.emplid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELEMPLO_ASSOCIATI_EMPLOYEE");

                entity.HasOne(d => d.positionCodeNavigation)
                    .WithMany(p => p.RelEmployee)
                    .HasForeignKey(d => d.positionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELEMPLO_REFERENCE_POSITION");
            });

            modelBuilder.Entity<relEtGenre>(entity =>
            {
                entity.HasKey(e => new { e.genreCode, e.etGenreCode });

                entity.HasOne(d => d.etGenreCodeNavigation)
                    .WithMany(p => p.relEtGenre)
                    .HasForeignKey(d => d.etGenreCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELETGEN_REFERENCE_ETGENRE");

                entity.HasOne(d => d.genreCodeNavigation)
                    .WithMany(p => p.relEtGenre)
                    .HasForeignKey(d => d.genreCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELETGEN_REFERENCE_GENRETYP");
            });

            modelBuilder.Entity<relEtRole>(entity =>
            {
                entity.HasKey(e => new { e.roleCode, e.etRoleCode });

                entity.HasOne(d => d.etRoleCodeNavigation)
                    .WithMany(p => p.relEtRole)
                    .HasForeignKey(d => d.etRoleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELETROL_REFERENCE_ETROLE");

                entity.HasOne(d => d.roleCodeNavigation)
                    .WithMany(p => p.relEtRole)
                    .HasForeignKey(d => d.roleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELETROL_REFERENCE_CREATIVE");
            });

            modelBuilder.Entity<RelGenreAdapt>(entity =>
            {
                entity.HasKey(e => new { e.reqId, e.genreId });

                entity.HasOne(d => d.genre)
                    .WithMany(p => p.RelGenreAdapt)
                    .HasForeignKey(d => d.genreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENREAD_REF_GENRE");

                entity.HasOne(d => d.req)
                    .WithMany(p => p.RelGenreAdapt)
                    .HasForeignKey(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REFERENCE_REQUESTA");
            });

            modelBuilder.Entity<RelGenreMovie>(entity =>
            {
                entity.HasKey(e => new { e.reqId, e.genreId });

                entity.HasOne(d => d.genre)
                    .WithMany(p => p.RelGenreMovie)
                    .HasForeignKey(d => d.genreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REFERENCE_GENRE");

                entity.HasOne(d => d.req)
                    .WithMany(p => p.RelGenreMovie)
                    .HasForeignKey(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REFERENCE_REQUESTM");
            });

            modelBuilder.Entity<RelGenrePercent>(entity =>
            {
                entity.HasKey(e => new { e.actCode, e.genreType });

                entity.Property(e => e.rate).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.actCodeNavigation)
                    .WithMany(p => p.RelGenrePercent)
                    .HasForeignKey(d => d.actCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REFERENCE_OBJACT");

                entity.HasOne(d => d.genreTypeNavigation)
                    .WithMany(p => p.RelGenrePercent)
                    .HasForeignKey(d => d.genreType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGPerc_REFERENCE_GENRETYP");
            });

            modelBuilder.Entity<relGenreRole>(entity =>
            {
                entity.HasKey(e => new { e.roleCode, e.genreType, e.actCode });

                entity.Property(e => e.rate).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.genreTypeNavigation)
                    .WithMany(p => p.relGenreRole)
                    .HasForeignKey(d => d.genreType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REFERENCE_GENRETYP");

                entity.HasOne(d => d.roleCodeNavigation)
                    .WithMany(p => p.relGenreRole)
                    .HasForeignKey(d => d.roleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REFERENCE_CREATIVE");
            });

            modelBuilder.Entity<RelGenreSerial>(entity =>
            {
                entity.HasKey(e => new { e.reqId, e.genreId });

                entity.HasOne(d => d.genre)
                    .WithMany(p => p.RelGenreSerial)
                    .HasForeignKey(d => d.genreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REF_GENRESERI");

                entity.HasOne(d => d.req)
                    .WithMany(p => p.RelGenreSerial)
                    .HasForeignKey(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELGENRE_REF_REQUESTSERI");
            });

            modelBuilder.Entity<relLicCopyR>(entity =>
            {
                entity.HasKey(e => new { e.agrLlicCode, e.cRKindCode });

                entity.HasOne(d => d.agrLlicCodeNavigation)
                    .WithMany(p => p.relLicCopyR)
                    .HasForeignKey(d => d.agrLlicCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELLICCO_REFERENCE_AGRLICEN");

                entity.HasOne(d => d.cRKindCodeNavigation)
                    .WithMany(p => p.relLicCopyR)
                    .HasForeignKey(d => d.cRKindCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELLICCO_REFERENCE_COPYRIGH");
            });

            modelBuilder.Entity<RelMovieEpisode>(entity =>
            {
                entity.HasKey(e => new { e.episodeTypeCode, e.reqId });

                entity.HasOne(d => d.episodeTypeCodeNavigation)
                    .WithMany(p => p.RelMovieEpisode)
                    .HasForeignKey(d => d.episodeTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELMOVIE_REFERENCE_EPISODET");

                entity.HasOne(d => d.req)
                    .WithMany(p => p.RelMovieEpisode)
                    .HasForeignKey(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELMOVIE_REFERENCE_REQUESTM");
            });

            modelBuilder.Entity<RelObjPerformer>(entity =>
            {
                entity.HasKey(e => new { e.objId, e.perId });

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.RelObjPerformer)
                    .HasForeignKey(d => d.objId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELOBJPE_REFERENCE_OBJECTRI");

                entity.HasOne(d => d.per)
                    .WithMany(p => p.RelObjPerformer)
                    .HasForeignKey(d => d.perId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELOBJPE_REFERENCE_PERFOMER");
            });

            modelBuilder.Entity<RelPopGenre>(entity =>
            {
                entity.HasKey(e => new { e.objId, e.genreId });

                entity.HasOne(d => d.genre)
                    .WithMany(p => p.RelPopGenre)
                    .HasForeignKey(d => d.genreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELOBJGE_REFERENCE_GENRE");

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.RelPopGenre)
                    .HasForeignKey(d => d.objId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELOBJGE_REFERENCE_OBJECTRI");
            });

            modelBuilder.Entity<RelReqMedia>(entity =>
            {
                entity.HasKey(e => new { e.useMediaTypeCode, e.reqId });

                entity.HasOne(d => d.req)
                    .WithMany(p => p.RelReqMedia)
                    .HasForeignKey(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELREQME_REFERENCE_REQUEST");

                entity.HasOne(d => d.useMediaTypeCodeNavigation)
                    .WithMany(p => p.RelReqMedia)
                    .HasForeignKey(d => d.useMediaTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELREQME_REFERENCE_USEMEDIA");
            });

            modelBuilder.Entity<RelReqObj>(entity =>
            {
                entity.HasKey(e => new { e.categoryCode, e.reqType, e.kindGroupId });

                entity.HasOne(d => d.reqTypeNavigation)
                    .WithMany(p => p.RelReqObj)
                    .HasForeignKey(d => d.reqType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELREQOB_REFERENCE_REQUESTT");
            });

            modelBuilder.Entity<RelSerialEpisode>(entity =>
            {
                entity.HasKey(e => new { e.reqId, e.episodeTypeCode });

                entity.HasOne(d => d.episodeTypeCodeNavigation)
                    .WithMany(p => p.RelSerialEpisode)
                    .HasForeignKey(d => d.episodeTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELSERIAEP_REF_EPISODET");

                entity.HasOne(d => d.req)
                    .WithMany(p => p.RelSerialEpisode)
                    .HasForeignKey(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELSERIAEP_REF_REQSERIAL");
            });

            modelBuilder.Entity<RelTVEpisode>(entity =>
            {
                entity.HasKey(e => new { e.reqId, e.episodeTypeCode });

                entity.HasOne(d => d.episodeTypeCodeNavigation)
                    .WithMany(p => p.RelTVEpisode)
                    .HasForeignKey(d => d.episodeTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELTVEPI_REFERENCE_EPISODET");

                entity.HasOne(d => d.req)
                    .WithMany(p => p.RelTVEpisode)
                    .HasForeignKey(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELTVEPI_REFERENCE_REQUESTT");
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.Property(e => e.repname)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReqAgreement>(entity =>
            {
                entity.HasKey(e => e.rAgrId);

                entity.HasIndex(e => e.custId)
                    .HasName("Association16_FK");

                entity.HasIndex(e => e.custIdRh)
                    .HasName("Association15_FK");

                entity.Property(e => e.agrDate).HasColumnType("datetime");

                entity.Property(e => e.amount).HasColumnType("money");

                entity.Property(e => e.costOffer).HasColumnType("money");

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.r030)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.r030Offer)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.rAgrComment)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.statusDate).HasColumnType("datetime");

                entity.Property(e => e.userId).HasMaxLength(48);

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.ReqAgreement)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQAGREE_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.custIdRhNavigation)
                    .WithMany(p => p.ReqAgreement)
                    .HasForeignKey(d => d.custIdRh)
                    .HasConstraintName("FK_REQAGREE_REFERENCE_RIGHTHOL");

                entity.HasOne(d => d.req)
                    .WithMany(p => p.ReqAgreement)
                    .HasForeignKey(d => d.reqId)
                    .HasConstraintName("FK_REQAGREE_REFERENCE_REQUEST");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.ReqAgreement)
                    .HasForeignKey(d => d.status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQAGREE_REFERENCE_REQAGREE");
            });

            modelBuilder.Entity<ReqAgreementStatus>(entity =>
            {
                entity.HasKey(e => e.statusCode);

                entity.Property(e => e.statusCode).ValueGeneratedNever();

                entity.Property(e => e.statusNameEn)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.statusNameRu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.statusNameUk)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReqCustomer>(entity =>
            {
                entity.HasKey(e => e.reqCustId);

                entity.Property(e => e.comment)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.countryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.nickName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.okpo)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.activityCodeNavigation)
                    .WithMany(p => p.ReqCustomer)
                    .HasForeignKey(d => d.activityCode)
                    .HasConstraintName("FK_REQCUSTO_REFERENCE_ACTIVITY");

                entity.HasOne(d => d.countryCodeNavigation)
                    .WithMany(p => p.ReqCustomer)
                    .HasForeignKey(d => d.countryCode)
                    .HasConstraintName("FK_REQCUSTO_REFERENCE_COUNTRY");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.ReqCustomer)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_REQCUSTO_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<ReqLocationUse>(entity =>
            {
                entity.HasKey(e => e.locUsId);

                entity.Property(e => e.countryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.continentCodeNavigation)
                    .WithMany(p => p.ReqLocationUse)
                    .HasForeignKey(d => d.continentCode)
                    .HasConstraintName("FK_REQLOCAT_REFERENCE_CONTINEN");

                entity.HasOne(d => d.countryCodeNavigation)
                    .WithMany(p => p.ReqLocationUse)
                    .HasForeignKey(d => d.countryCode)
                    .HasConstraintName("FK_REQLOCAT_REFERENCE_COUNTRY");

                entity.HasOne(d => d.req)
                    .WithMany(p => p.ReqLocationUse)
                    .HasForeignKey(d => d.reqId)
                    .HasConstraintName("FK_REQLOCAT_REFERENCE_REQUEST");
            });

            modelBuilder.Entity<ReqTrade>(entity =>
            {
                entity.HasKey(e => e.tradeId);

                entity.Property(e => e.costClient).HasColumnType("money");

                entity.Property(e => e.costRHolder).HasColumnType("money");

                entity.Property(e => e.createDate).HasColumnType("datetime");

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.r030)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.statusDate).HasColumnType("datetime");

                entity.Property(e => e.tradeComment)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.causeCodeNavigation)
                    .WithMany(p => p.ReqTrade)
                    .HasForeignKey(d => d.causeCode)
                    .HasConstraintName("FK_REQTRADE_REFERENCE_COMMENTC");

                entity.HasOne(d => d.rAgr)
                    .WithMany(p => p.ReqTrade)
                    .HasForeignKey(d => d.rAgrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQTRADE_REFERENCE_REQAGREE");

                entity.HasOne(d => d.req)
                    .WithMany(p => p.ReqTrade)
                    .HasForeignKey(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQTRADE_REFERENCE_REQUEST");

                entity.HasOne(d => d.statusNavigation)
                    .WithMany(p => p.ReqTrade)
                    .HasForeignKey(d => d.status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQTRADE_REFERENCE_TRADESTA");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.reqId);

                entity.Property(e => e.beginDate).HasColumnType("date");

                entity.Property(e => e.createDate).HasColumnType("datetime");

                entity.Property(e => e.endDate).HasColumnType("date");

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.r030)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.reqAmount).HasColumnType("money");

                entity.Property(e => e.reqComment)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.reqDate).HasColumnType("date");

                entity.Property(e => e.userId).HasMaxLength(48);

                entity.Property(e => e.workName)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.categoryCode)
                    .HasConstraintName("FK_REQUEST_REFERENCE_CATEGORY");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.custId)
                    .HasConstraintName("FK_REQUEST_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.kindCompCodeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.kindCompCode)
                    .HasConstraintName("FK_REQUEST_REFERENCE_KINDCOMP");

                entity.HasOne(d => d.licCodeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.licCode)
                    .HasConstraintName("FK_REQUEST_REFERENCE_LICENSET");

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.objId)
                    .HasConstraintName("FK_REQUEST_REFERENCE_OBJECTRI");

                entity.HasOne(d => d.reqAimCodeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.reqAimCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUEST_REFERENCE_REQUESTA");

                entity.HasOne(d => d.reqCust)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.reqCustId)
                    .HasConstraintName("FK_REQUEST_REFERENCE_REQCUSTO");

                entity.HasOne(d => d.reqTypeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.reqType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUEST_REFERENCE_REQUESTT");

                entity.HasOne(d => d.reqstatusNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.reqstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUEST_REFERENCE_REQUESTS");

                entity.HasOne(d => d.termUseCodeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.termUseCode)
                    .HasConstraintName("FK_REQUEST_REFERENCE_TERMUSE");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_REQUEST_REFERENCE_ASPNETUS");
            });

            modelBuilder.Entity<RequestAdapt>(entity =>
            {
                entity.HasKey(e => e.reqId);

                entity.Property(e => e.reqId).ValueGeneratedNever();

                entity.Property(e => e.execNick)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.modifyMusictComment)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.modifyTextComment)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.useAreaComment)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.modifyMusicTypeNavigation)
                    .WithMany(p => p.RequestAdapt)
                    .HasForeignKey(d => d.modifyMusicType)
                    .HasConstraintName("FK_REQUESTA_REFERENCE_MODIFYMU");

                entity.HasOne(d => d.modifyTextTypeNavigation)
                    .WithMany(p => p.RequestAdapt)
                    .HasForeignKey(d => d.modifyTextType)
                    .HasConstraintName("FK_REQUESTA_REFERENCE_MODIFYTE");

                entity.HasOne(d => d.modifyTypeNavigation)
                    .WithMany(p => p.RequestAdapt)
                    .HasForeignKey(d => d.modifyType)
                    .HasConstraintName("FK_REQUESTA_REFERENCE_MODIFYTY");

                entity.HasOne(d => d.req)
                    .WithOne(p => p.RequestAdapt)
                    .HasForeignKey<RequestAdapt>(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTA_REF_REQUESTADA");
            });

            modelBuilder.Entity<RequestAdvertising>(entity =>
            {
                entity.HasKey(e => e.reqId);

                entity.Property(e => e.reqId).ValueGeneratedNever();

                entity.Property(e => e.tradeMark)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.req)
                    .WithOne(p => p.RequestAdvertising)
                    .HasForeignKey<RequestAdvertising>(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTA_REF_REQUESTADV");
            });

            modelBuilder.Entity<RequestAim>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.RequestAim)
                    .HasForeignKey(d => d.categoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTA_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<RequestAimTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.RequestAimTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTA_REFERENCE_REQUESTA");
            });

            modelBuilder.Entity<RequestInternet>(entity =>
            {
                entity.HasKey(e => e.reqId);

                entity.Property(e => e.reqId).ValueGeneratedNever();

                entity.Property(e => e.url)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.useDesc)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.req)
                    .WithOne(p => p.RequestInternet)
                    .HasForeignKey<RequestInternet>(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTI_REF_INTERNREQUEST");

                entity.HasOne(d => d.typeInternetObjectNavigation)
                    .WithMany(p => p.RequestInternet)
                    .HasForeignKey(d => d.typeInternetObject)
                    .HasConstraintName("FK_REQUESTI_REFERENCE_TYPEINTE");
            });

            modelBuilder.Entity<RequestMovie>(entity =>
            {
                entity.HasKey(e => e.reqId);

                entity.Property(e => e.reqId).ValueGeneratedNever();

                entity.Property(e => e.episodeComment)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.kindFilmNavigation)
                    .WithMany(p => p.RequestMovie)
                    .HasForeignKey(d => d.kindFilm)
                    .HasConstraintName("FK_REQUESTM_REFERENCE_KINDFILM");

                entity.HasOne(d => d.req)
                    .WithOne(p => p.RequestMovie)
                    .HasForeignKey<RequestMovie>(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTM_REFERENCE_REQUEST");
            });

            modelBuilder.Entity<RequestOther>(entity =>
            {
                entity.HasKey(e => e.reqId);

                entity.Property(e => e.reqId).ValueGeneratedNever();

                entity.Property(e => e.useDesc)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.req)
                    .WithOne(p => p.RequestOther)
                    .HasForeignKey<RequestOther>(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTO_REFERENCE_REQUEST");
            });

            modelBuilder.Entity<RequestSerial>(entity =>
            {
                entity.HasKey(e => e.reqId);

                entity.Property(e => e.reqId).ValueGeneratedNever();

                entity.Property(e => e.episodeComment)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.kindSerialNavigation)
                    .WithMany(p => p.RequestSerial)
                    .HasForeignKey(d => d.kindSerial)
                    .HasConstraintName("FK_REQUESTS_REFERENCE_KINDSERI");

                entity.HasOne(d => d.req)
                    .WithOne(p => p.RequestSerial)
                    .HasForeignKey<RequestSerial>(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTS_REF_REQUESTS");
            });

            modelBuilder.Entity<RequestStatusType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequestStatusTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.RequestStatusTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTS_REFERENCE_REQUESTS");
            });

            modelBuilder.Entity<RequestTVRadio>(entity =>
            {
                entity.HasKey(e => e.reqId);

                entity.Property(e => e.reqId).ValueGeneratedNever();

                entity.Property(e => e.episodeComment)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.nameTVChanel)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.shortTitle)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.req)
                    .WithOne(p => p.RequestTVRadio)
                    .HasForeignKey<RequestTVRadio>(d => d.reqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTT_REF_TVREQUEST");
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.RequestType)
                    .HasForeignKey(d => d.categoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTT_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<RequestTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.RequestTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUESTT_REF_REQUESTTR");
            });

            modelBuilder.Entity<ResidentType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResidentTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.ResidentTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESIDENT_REFERENCE_RESIDENT");
            });

            modelBuilder.Entity<RHolderType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RHolderTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.RHolderTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RHOLDERT_REFERENCE_RHOLDERT");
            });

            modelBuilder.Entity<RightHolder>(entity =>
            {
                entity.HasKey(e => e.custId);

                entity.Property(e => e.custId).ValueGeneratedNever();

                entity.Property(e => e.innerCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.interCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.rHolderType).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.cust)
                    .WithOne(p => p.RightHolder)
                    .HasForeignKey<RightHolder>(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RIGHTHOL_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<SaldoDay>(entity =>
            {
                entity.HasKey(e => new { e.accId, e.dateBegin, e.dateEnd });

                entity.Property(e => e.dateBegin).HasColumnType("date");

                entity.Property(e => e.dateEnd).HasColumnType("date");

                entity.Property(e => e.deboborot).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.deboborotCourt).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.krdOborot).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.krdOborotCourt).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.r030)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.rest).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.restBegin).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.restBeginCourt).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.restCourt).HasColumnType("numeric(20, 2)");
            });

            modelBuilder.Entity<SeekObject>(entity =>
            {
                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.SeekObject)
                    .HasForeignKey(d => d.codeI)
                    .HasConstraintName("FK_SEEKOBJE_REFERENCE_SEEKTYPE");

                entity.HasOne(d => d.obj)
                    .WithMany(p => p.SeekObject)
                    .HasForeignKey(d => d.objId)
                    .HasConstraintName("FK_SEEKOBJE_REFERENCE_OBJECTRI");
            });

            modelBuilder.Entity<SeekType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SeekTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.SeekTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SEEKTYPE_REFERENCE_SEEKTYPE");
            });

            modelBuilder.Entity<SexType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SexTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.SexTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SEXTYPET_REFERENCE_SEXTYPE");
            });

            modelBuilder.Entity<SpecType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SpecTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.SpecTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SPECTYPE_REFERENCE_SPECTYPE");
            });

            modelBuilder.Entity<TableColumn>(entity =>
            {
                entity.HasKey(e => e.id)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => new { e.lang, e.tName, e.cName })
                    .HasName("Index_Unique")
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.tName, e.cName, e.lang })
                    .HasName("TableColumn_UI")
                    .IsUnique();

                entity.Property(e => e.id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.cName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.dText)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.hText)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.tName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TableColumnTech>(entity =>
            {
                entity.HasIndex(e => new { e.tname, e.cname })
                    .HasName("ITableColumn")
                    .IsUnique();

                entity.Property(e => e.id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.cname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.dnameEn)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.dnameRu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.dnameUk)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.tname)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TableObject>(entity =>
            {
                entity.HasKey(e => e.id)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => new { e.lang, e.cName })
                    .HasName("uni_01")
                    .IsUnique();

                entity.Property(e => e.id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.cName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.dText)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.hText)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TableType>(entity =>
            {
                entity.HasKey(e => e.tName)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.tName)
                    .HasName("Index_Unique")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.tName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TermsOfService>(entity =>
            {
                entity.HasKey(e => new { e.custId, e.CRKindCode });

                entity.HasOne(d => d.CRKindCodeNavigation)
                    .WithMany(p => p.TermsOfService)
                    .HasForeignKey(d => d.CRKindCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TERMSOFS_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.TermsOfService)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TERMSOFS_REFERENCE_RIGHTHOL");
            });

            modelBuilder.Entity<TermUse>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TermUseTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.TermUseTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TERMUSET_REFERENCE_TERMUSE");
            });

            modelBuilder.Entity<TerritoryExclude>(entity =>
            {
                entity.HasKey(e => new { e.custId, e.countryCode });

                entity.Property(e => e.countryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.countryCodeNavigation)
                    .WithMany(p => p.TerritoryExclude)
                    .HasForeignKey(d => d.countryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TERRITOR_REFERENCE_COUNTRY");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.TerritoryExclude)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TERRITOR_REFERENCE_RIGHTHOL");
            });

            modelBuilder.Entity<TerritoryInclude>(entity =>
            {
                entity.HasKey(e => new { e.custId, e.countryCode });

                entity.Property(e => e.countryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.countryCodeNavigation)
                    .WithMany(p => p.TerritoryInclude)
                    .HasForeignKey(d => d.countryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICEA_REFERENCE_COUNTRY2");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.TerritoryInclude)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICEA_REFERENCE_RIGHTHOL2");
            });

            modelBuilder.Entity<TradeStatus>(entity =>
            {
                entity.HasKey(e => e.statusCode);

                entity.Property(e => e.statusCode).ValueGeneratedNever();

                entity.Property(e => e.statusNameEn)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.statusNameRu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.statusNameUk)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeInternetObject>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.typeInetNameEn)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.typeInetNameRu)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeInternetObjectTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.TypeInternetObjectTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEINTE_REFERENCE_TYPEINTE");
            });

            modelBuilder.Entity<TypeMethodGet>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeMethodGetTr>(entity =>
            {
                entity.HasKey(e => new { e.lang, e.codeI });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.TypeMethodGetTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEMETH_REFERENCE_TYPEMETH");
            });

            modelBuilder.Entity<TypePlace>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.paramTypeNavigation)
                    .WithMany(p => p.TypePlace)
                    .HasForeignKey(d => d.paramType)
                    .HasConstraintName("FK_TYPEPLAC_REF_TYPEPLAC");
            });

            modelBuilder.Entity<TypePlaceParam>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypePlaceParamTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.TypePlaceParamTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEPLAC_REF_TYPEPLACTR");
            });

            modelBuilder.Entity<TypePlaceTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.TypePlaceTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEPLAC_REFERENCE_TYPEPLAC");
            });

            modelBuilder.Entity<TypeVAT>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeVATTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.TypeVATTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEVATT_REFERENCE_TYPEVAT");
            });

            modelBuilder.Entity<UseAreaType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.UseAreaType)
                    .HasForeignKey(d => d.categoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USEAREAT_REFERENCE_CATEGORY");

                entity.HasOne(d => d.reqTypeNavigation)
                    .WithMany(p => p.UseAreaType)
                    .HasForeignKey(d => d.reqType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USEAREAT_REFERENCE_REQUESTT");
            });

            modelBuilder.Entity<UseAreaTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.UseAreaTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USEAREAT_REFERENCE_USEAREAT");
            });

            modelBuilder.Entity<UseMediaType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoryCodeNavigation)
                    .WithMany(p => p.UseMediaType)
                    .HasForeignKey(d => d.categoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USEMEDIA_REFERENCE_CATEGORY");

                entity.HasOne(d => d.reqTypeNavigation)
                    .WithMany(p => p.UseMediaType)
                    .HasForeignKey(d => d.reqType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USEMEDIA_REFERENCE_REQUESTT");
            });

            modelBuilder.Entity<UseMediaTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.UseMediaTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USEMEDIA_REFERENCE_USEMEDIA");
            });

            modelBuilder.Entity<userRole>(entity =>
            {
                entity.HasKey(e => new { e.custId, e.roleType, e.userId });

                entity.Property(e => e.userId).HasMaxLength(48);

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.userRole)
                    .HasForeignKey(d => d.custId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERROLE_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.roleTypeNavigation)
                    .WithMany(p => p.userRole)
                    .HasForeignKey(d => d.roleType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERROLE_REFERENCE_USERROLE");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.userRole)
                    .HasForeignKey(d => d.userId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERROLE_REFERENCE_ASPNETUS");
            });

            modelBuilder.Entity<UserRoleType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.typeNameEn)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.typeNameRu)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRoleTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.UserRoleTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERROLE_REFERENCE_USERROLE2");
            });

            modelBuilder.Entity<UsesKind>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.usesTypeNavigation)
                    .WithMany(p => p.UsesKind)
                    .HasForeignKey(d => d.usesType)
                    .HasConstraintName("FK_USESKIND_REFERENCE_USESTYPE");
            });

            modelBuilder.Entity<UsesKindTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.UsesKindTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USESKIND_REFERENCE_USESKIND");
            });

            modelBuilder.Entity<UsesType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsesTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.UsesTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USESTYPE_REFERENCE_USESTYPE");
            });

            modelBuilder.Entity<WorkRH>(entity =>
            {
                entity.HasKey(e => e.cRightId);

                entity.Property(e => e.cRightId).ValueGeneratedNever();

                entity.Property(e => e.modifyDate).HasColumnType("datetime");

                entity.Property(e => e.modifyLogin)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.workCommentRH)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.workCoommentCl)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.workDateCl).HasColumnType("date");

                entity.Property(e => e.workDateRH).HasColumnType("date");

                entity.HasOne(d => d.cRight)
                    .WithOne(p => p.WorkRH)
                    .HasForeignKey<WorkRH>(d => d.cRightId)
                    .HasConstraintName("FK_WORKRH_REFERENCE_COPYRIGH");

                entity.HasOne(d => d.workTypeClNavigation)
                    .WithMany(p => p.WorkRHworkTypeClNavigation)
                    .HasForeignKey(d => d.workTypeCl)
                    .HasConstraintName("FK_WORKCL_REFERENCE_WORKTYPE");

                entity.HasOne(d => d.workTypeRHNavigation)
                    .WithMany(p => p.WorkRHworkTypeRHNavigation)
                    .HasForeignKey(d => d.workTypeRH)
                    .HasConstraintName("FK_WORKRH_REFERENCE_WORKTYPE");
            });

            modelBuilder.Entity<WorkType>(entity =>
            {
                entity.HasKey(e => e.codeI);

                entity.Property(e => e.codeI).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkTypeTr>(entity =>
            {
                entity.HasKey(e => new { e.codeI, e.lang });

                entity.Property(e => e.lang)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.codeINavigation)
                    .WithMany(p => p.WorkTypeTr)
                    .HasForeignKey(d => d.codeI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WORKTYPE_REFERENCE_WORKTYPE");
            });
        }
    }
}
