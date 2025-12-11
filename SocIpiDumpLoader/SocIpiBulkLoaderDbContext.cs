using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using SocIpiDumpLoader.Entities;
using SocIpiDumpLoader.Entities.Main;

namespace SocIpiDumpLoader
{
    public class SocIpiBulkLoaderDbContext : DbContext
    {

        public DbSet<IpiAgreement> IpiAgreement { get; set; }
        public DbSet<IpiBase> IpiBase { get; set; }
        public DbSet<IpiName> IpiName { get; set; }

        public DbSet<IpiNameUsage> IpiNameUsage { get; set; }
        public DbSet<IpiNationality> IpiNationality { get; set; }
        public DbSet<IpiRemark> IpiRemark { get; set; }
        public DbSet<IpiStatus> IpiStatus { get; set; }
        public DbSet<IpiTerritory> IpiTerritory { get; set; }

        public DbSet<SocIpiDumpLoader.Entities.UpdFile> UpdFiles { get; set; }
        public DbSet<SocIpiDumpLoader.Entities.UpdTrans> UpdTrans { get; set; }

        public DbSet<RecHdr> RecHdr { get; set; }
        public DbSet<RecGrh> RecGrh { get; set; }
        public DbSet<RecGrt> RecGrt { get; set; }

        public DbSet<RecBdn> RecBdn { get; set; }
        public DbSet<RecBdo> RecBdo { get; set; }

        public DbSet<RecImn> RecImn { get; set; }
        public DbSet<RecImo> RecImo { get; set; }


        public DbSet<RecInn> RecInn { get; set; }
        public DbSet<RecIno> RecIno { get; set; }

        public DbSet<RecMan> RecMan { get; set; }
        public DbSet<RecMao> RecMao { get; set; }


        public DbSet<RecMcn> RecMcn { get; set; }
        public DbSet<RecMco> RecMco { get; set; }


        public DbSet<RecMun> RecMun { get; set; }
        public DbSet<RecMuo> RecMuo { get; set; }

        public DbSet<RecNcn> RecNcn { get; set; }
        public DbSet<RecNco> RecNco { get; set; }
        
        public DbSet<RecNtn> RecNtn { get; set; }
        public DbSet<RecNto> RecNto { get; set; }
        public DbSet<RecNun> RecNun { get; set; }
        public DbSet<RecNuo> RecNuo { get; set; }

        public DbSet<RecOnn> RecOnn { get; set; }
        public DbSet<RecOno> RecOno { get; set; }


       public DbSet<RecRen> RecRen { get; set; }
        public DbSet<RecReo> RecReo { get; set; }


        public DbSet<RecStn> RecStn { get; set; }
        public DbSet<RecSto> RecSto { get; set; }
        

        public DbSet<RecTma> RecTma { get; set; }

        // DOMAINS
        public DbSet<RecCcl> RecCcl { get; set; }
        public DbSet<RecIri> RecIri { get; set; }
        public DbSet<RecIsc> RecIsc { get; set; }
        public DbSet<RecNmt> RecNmt { get; set; }
        public DbSet<RecRcc> RecRcc { get; set; }
        public DbSet<RecRig> RecRig { get; set; }
        public DbSet<RecRis> RecRis { get; set; }
        public DbSet<RecRix> RecRix { get; set; }
        public DbSet<RecRol> RecRol { get; set; }
        public DbSet<RecSoc> RecSoc { get; set; }
        public DbSet<RecSop> RecSop { get; set; }
        public DbSet<RecCsc> RecCsc { get; set; }
        public DbSet<RecTnr> RecTnr { get; set; }
        public DbSet<RecTna> RecTna { get; set; }
        public DbSet<RecHnr> RecHnr { get; set; }
        public DbSet<RecHna> RecHna { get; set; }


        public SocIpiBulkLoaderDbContext() : base()
        {
        }
        public string GetConnectionString()
        {
               return $@"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocIpiDump; Server=193.178.146.103\\IPSDATA,60675";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWidAdmin; Server=89.184.65.168\IPSDATA,60675");
            //optionsBuilder.UseSqlServer(@"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWidUpdates; Server=DESKTOP-FT79FOI\SQLEXPRESS");
            var connectionString = GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
