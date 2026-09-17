using IpiUpdatesLib;
using IpiUpdatesLib.Entities;
using IpiUpdatesLib.Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Reflection.Emit;
using static IpiUpdatesLib.IpiUpdatesDbContext;

namespace IpiUpdatesLib
{
    public class IpiUpdatesDbContext : DbContext
    {
        public enum RpnJobTypeEnum
        {              
            LoadDict = 1,
            LoadIpi,
            ApplyUpdates,
        }

        public enum RpnJobTaskTypeEnum
        {
            ApplyDict = 1,     
            ApplyIpiFile,  
            ApplyUpdateFile,
        }; 

        public enum RpnJobTaskStepTypeEnum
        {
            DownloadFile = 1, 
            UnzipFile,    
            DeleteZipFile,
            ApplyFile,    
            DeleteFile,   
        };

        public DbSet<IpiAgreement> IpiAgreement { get; set; }
        public DbSet<IpiBase> IpiBase { get; set; }
        public DbSet<IpiName> IpiName { get; set; }

        public DbSet<IpiNameUsage> IpiNameUsage { get; set; }
        public DbSet<IpiNationality> IpiNationality { get; set; }
        public DbSet<IpiRemark> IpiRemark { get; set; }
        public DbSet<IpiStatus> IpiStatus { get; set; }
        public DbSet<IpiTerritory> IpiTerritory { get; set; }

        public DbSet<UpdFile> UpdFiles { get; set; }
        public DbSet<UpdTrans> UpdTrans { get; set; }

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

        public DbSet<RpnSettings>           RpnSettings         { get; set; }
        public DbSet<RpnPeriod>             RpnPeriods          { get; set; }
        public DbSet<RpnJob>                RpnJobs             { get; set; }
        public DbSet<RpnJobTask>            RpnJobTasks         { get; set; }
        public DbSet<RpnJobTaskStep>        RpnJobTaskSteps         { get; set; }
        public DbSet<RpnJobTaskStepType>    RpnJobTaskStepType  { get; set; }
        public DbSet<RpnJobTaskType>        RpnJobTaskTypes     { get; set; }
        public DbSet<RpnJobType>            RpnJobTypes         { get; set; }

        // DOMAINS
        public DbSet<DicCcl> RecCcl { get; set; }
        public DbSet<DicIri> RecIri { get; set; }
        public DbSet<DicIsc> RecIsc { get; set; }
        public DbSet<DicNmt> RecNmt { get; set; }
        public DbSet<DicRcc> RecRcc { get; set; }
        public DbSet<DicRig> RecRig { get; set; }
        public DbSet<DicRis> RecRis { get; set; }
        public DbSet<DicRix> RecRix { get; set; }
        public DbSet<DicRol> RecRol { get; set; }
        public DbSet<DicSoc> RecSoc { get; set; }
        public DbSet<DicSop> RecSop { get; set; }
        public DbSet<DicCsc> RecCsc { get; set; }
        public DbSet<DicTnr> RecTnr { get; set; }
        public DbSet<DicTna> RecTna { get; set; }
        public DbSet<DicHnr> RecHnr { get; set; }
        public DbSet<DicHna> RecHna { get; set; }


        public IpiUpdatesDbContext() : base()
        {
        }
        public string GetConnectionString()
        {
            var exeFileFullName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var rootPath = Path.GetDirectoryName(exeFileFullName);
            var fileName = Path.Combine(rootPath, "appsettings.json");

            var builder = new ConfigurationBuilder();
            if (File.Exists(fileName))
            {
                var connectionString = builder
                    .AddJsonFile(fileName, optional: false)
                    .Build()
                    .GetConnectionString("SocIpiDb");
                return connectionString;
            }
            else
            {
                //return @"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocIpi; Server=localhost";
                //return @"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWidUpdates; Server=DESKTOP-FT79FOI\SQLEXPRESS";
                return $@"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocIpi; Server=193.178.146.103\\IPSDATA,60675";
            }
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
            modelBuilder
                .Entity<RpnJobType>()
                .HasData(new RpnJobType[]
                {
                    new RpnJobType { Id = (int)RpnJobTypeEnum.LoadDict,     Code = "LoadDict",    Description = "Завантажити словники"      },
                    new RpnJobType { Id = (int)RpnJobTypeEnum.LoadIpi,      Code = "LoadIpi",      Description = "Завантажити повну БД"      },
                    new RpnJobType { Id = (int)RpnJobTypeEnum.ApplyUpdates, Code = "ApplyUpdates", Description = "Застосувати щоденні зміни" },
                });

            modelBuilder
                .Entity<RpnJobTaskType>()
                .HasData(new RpnJobTaskType[]
                {
                    new RpnJobTaskType { Id = (int)RpnJobTaskTypeEnum.ApplyDict,       Code = "ApplyDict",        Description = "Оновити словники"                   },
                    new RpnJobTaskType { Id = (int)RpnJobTaskTypeEnum.ApplyIpiFile,    Code = "ApplyIpiFile",     Description = "Додати дані з файлу повної бази"    },
                    new RpnJobTaskType { Id = (int)RpnJobTaskTypeEnum.ApplyUpdateFile, Code = "ApplyUpdateFile",  Description = "Застосувати дані з файлу оновлення" },
                }); 

            modelBuilder
                .Entity<RpnJobTaskStepType>()
                .HasData(new RpnJobTaskStepType[]
                {
                    new RpnJobTaskStepType { Id = (int)RpnJobTaskStepTypeEnum.DownloadFile,  Code = "DownloadFile",  Description = "Завантажити файл"          },
                    new RpnJobTaskStepType { Id = (int)RpnJobTaskStepTypeEnum.UnzipFile,     Code = "UnzipFile",     Description = "Розпакувати файл"          },
                    new RpnJobTaskStepType { Id = (int)RpnJobTaskStepTypeEnum.DeleteZipFile, Code = "DeleteZipFile", Description = "Видалити запакований файл" },
                    new RpnJobTaskStepType { Id = (int)RpnJobTaskStepTypeEnum.ApplyFile,     Code = "ApplyFile",     Description = "Застосувати файл"          },
                    new RpnJobTaskStepType { Id = (int)RpnJobTaskStepTypeEnum.DeleteFile,    Code = "DeleteFile",    Description = "Видалити файл"             },
                });

            modelBuilder
                .Entity<RpnSettings>()
            .HasData(new RpnSettings[]
            {
                    new RpnSettings {
                        Id                = 1,
                        FtpUrl            = "ftp.suisa.ch",
                        FtpPort           = 22,
                        FtpLogin          = "UACRR",
                        FtpPassword       = "S0c-74084lXY-?",
                        FtpUseSsl         = false,
                        FtpUseSftp        = true,
                        FtpDumpPath       = "IPI/IPI_Pub/Complete_IPI",
                        FtpUpdatesPath    = "IPI/download",
                        WorkFilesRootPath = @"C:\UACRR\WID_Service\ReplicationWorkFiles\Ipi",
                    },
                });
        }
    }
}
