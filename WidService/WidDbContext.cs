using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using WidServiceLib.Entities;

namespace WidServiceLib
{
    public class WidDbContext : DbContext
    {
        public DbSet<AltTtlEntity>          AltTtlSet { get; set; }
        public DbSet<ArtistEntity>          ArtistSet { get; set; }
        public DbSet<ComponentEntity>       ComponentSet { get; set; }
        public DbSet<ConflictEntity>        ConflictSet { get; set; }
        public DbSet<InstnEntity>           InstnSet { get; set; }
        public DbSet<InstnDtlEntity>        InstnDtlSet { get; set; }
        public DbSet<IntrPtyEntity>         IntrPtySet { get; set; }
        public DbSet<IpiBaseEntity>         IPIBaseSet { get; set; }
        public DbSet<IpiNameEntity>         IPINameSet { get; set; }
        public DbSet<IpiStatusEntity>       IPIStatusSet { get; set; }
        public DbSet<IswcEntity>            ISWCSet { get; set; }
        public DbSet<MbrAgreeTerrEntity>    MbrAgreeTerrSet { get; set; }
        public DbSet<OrgTtlVrExrpEntity>    OrgTtlVrExrpSet { get; set; }
        public DbSet<SharesEntity>          SharesSet { get; set; }
        public DbSet<SubmissionEntity>      SubmissionSet { get; set; }
        public DbSet<TitleEntity>           TitleSet { get; set; }
        public DbSet<WrkOrgEntity>          WrkOrgSet { get; set; }
        public DbSet<WtrPubRelEntity>       WtrPubRelSet { get; set; }


        public DbSet<AltTtlHistEntity> AltTtlHistSet { get; set; }
        public DbSet<ArtistHistEntity> ArtistHistSet { get; set; }
        public DbSet<ComponentHistEntity> ComponentHistSet { get; set; }
        public DbSet<ConflictHistEntity> ConflictHistSet { get; set; }
        public DbSet<InstnHistEntity> InstnHistSet { get; set; }
        public DbSet<InstnDtlHistEntity> InstnDtlHistSet { get; set; }
        public DbSet<IntrPtyHistEntity> IntrPtyHistSet { get; set; }
        public DbSet<IpiBaseHistEntity> IPIBaseHistSet { get; set; }
        public DbSet<IpiNameHistEntity> IPINameHistSet { get; set; }
        public DbSet<IpiStatusHistEntity> IPIStatusHistSet { get; set; }
        public DbSet<IswcHistEntity> ISWCHistSet { get; set; }
        public DbSet<MbrAgreeTerrHistEntity> MbrAgreeTerrHistSet { get; set; }
        public DbSet<OrgTtlVrExrpHistEntity> OrgTtlVrExrpHistSet { get; set; }
        public DbSet<SharesHistEntity> SharesHistSet { get; set; }
        public DbSet<SubmissionHistEntity> SubmissionHistSet { get; set; }
        public DbSet<TitleHistEntity> TitleHistSet { get; set; }
        public DbSet<WrkOrgHistEntity> WrkOrgHistSet { get; set; }
        public DbSet<WtrPubRelHistEntity> WtrPubRelHistSet { get; set; }


        public WidDbContext() : base()
        {
        }
        private string GetConnectionString()
        {
            var exeFileFullName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var rootPath = System.IO.Path.GetDirectoryName(exeFileFullName);
            var fileName = Path.Combine(rootPath, "appsettings.json");

            var builder = new ConfigurationBuilder();
            if (File.Exists(fileName))
            {
                var connectionString = builder
                    .AddJsonFile(fileName, optional: false)
                    .Build()
                    .GetConnectionString("WidDbServer");
                return $"Initial Catalog=SocWid;{connectionString}";
            }
            else
            {
                return @"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWid; Server=localhost";
                //return @"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWidInitial; Server=DESKTOP-FT79FOI\SQLEXPRESS";
                //return @"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWid; Server=DESKTOP-FT79FOI\SQLEXPRESS";
                //return @"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWid; Server=89.184.65.168\IPSDATA,60675";
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWid; Server=89.184.65.168\IPSDATA,60675");
            //optionsBuilder.UseSqlServer(@"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWid; Server=DESKTOP-FT79FOI\SQLEXPRESS");
            var connectionString = GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<AltTtlEntity>()
                .HasKey(x => new { x.Wic, x.SeqNr });
            modelBuilder.Entity<ArtistEntity>()
                .HasKey(x => new { x.Wic, x.SeqNr });
            modelBuilder.Entity<ComponentEntity>()
                .HasKey(x => new { x.Wic, x.SeqNr });
            modelBuilder.Entity<ConflictEntity>()
                .HasKey(x => new { x.Wic, x.SocCde, x.RgtTyp });
            modelBuilder.Entity<InstnEntity>()
                .HasKey(x => new { x.Wic, x.StdInstnCde, x.SeqNr });
            modelBuilder.Entity<InstnDtlEntity>()
                .HasKey(x => new { x.Wic, x.SeqNr, x.Cde, x.SeqNrInst });
            modelBuilder.Entity<IntrPtyEntity>()
                .HasKey(x => new { x.Wic, x.RolId });
            modelBuilder.Entity<IpiBaseEntity>()
                .HasKey(x => new { x.IpBaseNr});
            modelBuilder.Entity<IpiNameEntity>()
                .HasKey(x => new { x.IpNameNr, x.IpBaseNr });
            modelBuilder.Entity<IpiStatusEntity>()
                .HasKey(x => new {x.IpBaseNr, x.RelIpiBaseNr, x.StsCde, x.FromDt });
            modelBuilder.Entity<IswcEntity>()
                .HasKey(x => new { x.Iswc, x.Wic });
            modelBuilder.Entity<MbrAgreeTerrEntity>()
                .HasKey(x => new { x.IpBaseNr, x.SocId, x.CreClass, x.Rol, x.Rgt, x.TisNr, x.Tisan, x.IncExc, x.FromDt});
            modelBuilder.Entity<OrgTtlVrExrpEntity>()
                .HasKey(x => new { x.Wic, x.VrExrpInd });
            modelBuilder.Entity<SharesEntity>()
                .HasKey(x => new { x.Wic, x.IntrPtyRolid, x.RgtTyp, x.CtlPtySub });
            modelBuilder.Entity<SubmissionEntity>()
                .HasKey(x => new { x.Wic, x.SocCde, x.SubmDt, x.SocWorkCde, x.TrTyp });
            modelBuilder.Entity<TitleEntity>()
                .HasKey(x => new { x.Wic });
            modelBuilder.Entity<WrkOrgEntity>()
                .HasKey(x => new { x.Wic });
            modelBuilder.Entity<WtrPubRelEntity>()
                .HasKey(x => new { x.Wic, x.WtrIntrPtySeq, x.PubIntrPtySeq });


            modelBuilder.Entity<AltTtlEntity>().HasNoKey();
            modelBuilder.Entity<ArtistEntity>().HasNoKey();
            modelBuilder.Entity<ComponentEntity>().HasNoKey();
            modelBuilder.Entity<ConflictEntity>().HasNoKey();
            modelBuilder.Entity<InstnEntity>().HasNoKey();
            modelBuilder.Entity<InstnDtlEntity>().HasNoKey();
            modelBuilder.Entity<IntrPtyEntity>().HasNoKey();
            modelBuilder.Entity<IpiBaseEntity>().HasNoKey();
            modelBuilder.Entity<IpiNameEntity>().HasNoKey();
            modelBuilder.Entity<IpiStatusEntity>().HasNoKey();
            modelBuilder.Entity<IswcEntity>().HasNoKey();
            modelBuilder.Entity<MbrAgreeTerrEntity>().HasNoKey();
            modelBuilder.Entity<OrgTtlVrExrpEntity>().HasNoKey();
            modelBuilder.Entity<SharesEntity>().HasNoKey();
            modelBuilder.Entity<SubmissionEntity>().HasNoKey();
            modelBuilder.Entity<TitleEntity>().HasNoKey();
            modelBuilder.Entity<WrkOrgEntity>().HasNoKey();
            modelBuilder.Entity<WtrPubRelEntity>().HasNoKey();
            modelBuilder.Entity<TitleHistEntity>().HasNoKey();

            */

            modelBuilder.Entity<AltTtlHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<ArtistHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<ComponentHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<ConflictHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<InstnHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<InstnDtlHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<IntrPtyHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<IpiBaseHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<IpiNameHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<IpiStatusHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<IswcHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<MbrAgreeTerrHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<OrgTtlVrExrpHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<SharesHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<SubmissionHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<TitleHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<WrkOrgHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });
            modelBuilder.Entity<WtrPubRelHistEntity>().HasKey(x => new { x.Id, x.ValidFrom, x.ValidTo });

        }
    }
}
