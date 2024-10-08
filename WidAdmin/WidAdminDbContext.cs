using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using WidAdminLib.Entities;

namespace WidAdminLib
{
    public class WidAdminDbContext : DbContext
    {
        public DbSet<WidConfigurationEntity> WidConfigurations { get; set; }
        public DbSet<WidUpdatePeriodEntity> WidUpdatePeriods{ get; set; }
        public DbSet<WidTaskSubjectEntity> WidTaskSubjects { get; set; }
        public DbSet<WidTaskObjectEntity> WidTaskObjects { get; set; }
        public DbSet<WidTaskEntity>     WidTasks        { get; set; }
        public DbSet<WidTaskTypeEnum>   WidTaskTypes    { get; set; }
        public DbSet<WidTaskStatusEnum> WidTaskStatuses { get; set; }
        public DbSet<WidTaskSubjectTypeEnum> WidTaskSubjectTypes { get; set; }


        public WidAdminDbContext() : base()
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
                return $"Initial Catalog=SocWidAdmin;{connectionString}";
            }
            else
            {
                return @"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWidAdmin; Server=localhost";
                //return @"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWidAdmin; Server=DESKTOP-FT79FOI\SQLEXPRESS";
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWidAdmin; Server=89.184.65.168\IPSDATA,60675");
            //optionsBuilder.UseSqlServer(@"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWidAdmin; Server=DESKTOP-FT79FOI\SQLEXPRESS");
            var connectionString = GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<WidConfigurationEntity>()
                .HasData(new WidConfigurationEntity[]
                {
                    new WidConfigurationEntity { 
                        Id = 1,
                        Name = "Development environment",
                        WidFtpUrl = "ftp://ftp-aws.fasttrackdcn.net",
                        WidFtpLogin = "wid_140",
                        WidFtpPassword = "ad1WropKoPhlyb",
                        WidFtpDumpPath = "wid-dump",
                        WidFtpUpdatesPath = "outbox/SOC",
                        WidWorkFilesRootPath = @"D:\UACRR\WID\ReplicationWorkFiles\Wid",

                        IpiFtpUrl = "ftp://ftp.suisa.ch",
                        IpiFtpLogin = "UACRR",
                        IpiFtpPassword = "0RvLrb0M",
                        IpiFtpDumpPath = "IPI/IPI_Pub/Complete_IPI",
                        IpiFtpUpdatesPath = "IPI/download",
                        IpiWorkFilesRootPath = @"D:\UACRR\WID\ReplicationWorkFiles\Ipi",

                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                });

            modelBuilder
                .Entity<WidTaskSubjectTypeEnum>()
                .HasData(new WidTaskSubjectTypeEnum[]
                {
                    new WidTaskSubjectTypeEnum { Id = 1, Code = "InitFromDump",             Description = "Створення початкової бази з дампу"                       },
                    new WidTaskSubjectTypeEnum { Id = 2, Code = "CalcInitDumpTs",           Description = "Знайти дату початкового дампу"                           },
                    new WidTaskSubjectTypeEnum { Id = 3, Code = "UpdateFromTranFiles",      Description = "Внесення змін в базу на основі файлів транзакцій"        },
                    new WidTaskSubjectTypeEnum { Id = 4, Code = "InitNewDump",              Description = "Заповнення проміжної бази інформацією з нового дампу"    },
                    new WidTaskSubjectTypeEnum { Id = 5, Code = "CalcNewDumpTs",            Description = "Знайти дату нового дампу"                                },
                    new WidTaskSubjectTypeEnum { Id = 6, Code = "UpdateFromNewDump",        Description = "Внесення змін в базу на основі нового дампу"             },
                });

            modelBuilder
                .Entity<WidTaskTypeEnum>()
                .HasData(new WidTaskTypeEnum[]
                {
                    new WidTaskTypeEnum { Id = 1,  Code = "FileDownload",               Description = "Завантажити файл з FTP"                          },
                    new WidTaskTypeEnum { Id = 2,  Code = "FileUnzip",                  Description = "Розпакувати файл"                                },
                    new WidTaskTypeEnum { Id = 3,  Code = "FileZipDelete",              Description = "Видалити файл архіву"                            },
                    new WidTaskTypeEnum { Id = 4,  Code = "FileApplyToDb",              Description = "Обробити файл"                                   },
                    new WidTaskTypeEnum { Id = 5,  Code = "FileDelete",                 Description = "Видалити файл"                                   },
                    new WidTaskTypeEnum { Id = 6,  Code = "CalcWidDumpTs",              Description = "Знайти дату останньої зміни в таблицях дампу"    },
                    new WidTaskTypeEnum { Id = 7,  Code = "TableApplyToDb",             Description = "Застосувати інформацію з таблиці нового дампу"   },
                    new WidTaskTypeEnum { Id = 8,  Code = "TableApplyToSocDb",          Description = "Створити копію файлу змін в базі даних"          },
                    new WidTaskTypeEnum { Id = 9,  Code = "CreateHistRecords",          Description = "Створити історичні записи"                       },
                    new WidTaskTypeEnum { Id = 10, Code = "RenSocWidToSocWid_",         Description = "Змінити назву SocWid на SocWid_"                 },
                    new WidTaskTypeEnum { Id = 11, Code = "RenSocWidInitialToSocWid",   Description = "Змінити назву SocWidInitial на SocWid"           },
                    new WidTaskTypeEnum { Id = 12, Code = "RenSocWid_ToSocWidInitial",  Description = "Змінити назву SocWid_ на SocWidInitial"          },
                });

            modelBuilder
                .Entity<WidTaskStatusEnum>()
                .HasData(new WidTaskStatusEnum[]
                {
                    new WidTaskStatusEnum { Id = 1, Code = "Pending",     Description = "Очікує початку виконання"                },
                    new WidTaskStatusEnum { Id = 2, Code = "InProgress",  Description = "Виконується"                             },
                    new WidTaskStatusEnum { Id = 3, Code = "Completed",   Description = "Завершено"                               },
                    new WidTaskStatusEnum { Id = 4, Code = "Failed",      Description = "Перервано внаслідок помилок"             },
                });

            modelBuilder
                .Entity<WidTaskEntity>()
                .HasOne(x => x.PrevWidTask)
                .WithMany(x => x.NextWidTasks)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Entity<WidTaskEntity>()
                .HasOne(x => x.WidTaskObject)
                .WithMany(x => x.WidTasks)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Entity<WidTaskSubjectEntity>()
                .HasOne(x => x.WidUpdatePeriod)
                .WithMany(x => x.WidTaskSubjects)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder
                .Entity<WidTaskObjectEntity>()
                .HasOne(x => x.WidTaskSubject)
                .WithMany(x => x.WidTaskObjects)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
