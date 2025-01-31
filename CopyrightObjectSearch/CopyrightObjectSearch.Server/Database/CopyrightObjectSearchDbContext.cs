using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace CopyrightObjectSearch.Server
{
    public class CopyrightObjectSearchDbContext : DbContext
    {
        //private IConfiguration Configuration { get; }

        public CopyrightObjectSearchDbContext() 
        {
            Console.WriteLine("CopyrightObjectSearchDbContext construct default");
        }

        public CopyrightObjectSearchDbContext(DbContextOptions<CopyrightObjectSearchDbContext> options) : base(options)
        {
            Console.WriteLine($"CopyrightObjectSearchDbContext construct with options - {options.Extensions}");
        }

        public DbSet<PartnerWork> PartnerWorks { get; set; }
        public DbSet<PartnerWorkAlbum> PartnerWorkAlbums { get; set; }
        public DbSet<PartnerWorkName> PartnerWorkNames { get; set; }
        public DbSet<PartnerWorkAuthor> PartnerWorkAuthors { get; set; }
        public DbSet<PartnerWorkPerformer> PartnerWorkPerformers { get; set; }
        public DbSet<PartnerWorkIswc> PartnerWorkIswcs { get; set; }



        public DbSet<TmpSelectedId>  TmpSelectedIds  { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerWorkSource> PartnerWorkSources { get; set; }
        public DbSet<PartnerWorkSourceType> PartnerWorkSourceTypes { get; set; }
        public DbSet<PartnerWorkToSource> PartnerWorkToSources { get; set; }
        public DbSet<PartnerToSourceType> PartnerToSourceType { get; set; }

        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<UserTaskItem> UserTaskItems { get; set; }
        public DbSet<UserTaskStatus> UserTaskStatuses { get; set; }
        public DbSet<UserTaskType> UserTaskType { get; set; }


        // Virtual Entities
        public DbSet<FoundNameAuthorsPerformers> FoundNameAuthorsPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("CopyrightObjectSearchDbContext OnConfiguring");
        //    optionsBuilder.UseSqlServer(@"Persist Security Info=False;User=OlegM;Password=111111;Server=193.178.146.103\\IPSDATA,60675;database=CopyrightObjectSearch;");
            Console.WriteLine("CopyrightObjectSearchDbContext OnConfiguring OK");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("CopyrightObjectSearchDbContext OnConfiOnModelConfiguring");

            modelBuilder.Entity<FoundNameAuthorsPerformers>().Metadata.SetIsTableExcludedFromMigrations(true);

            modelBuilder.Entity<PartnerWork>()
                .HasIndex(x => new { x.NameId })
                .IsUnique(false);

            modelBuilder.Entity<PartnerWork>()
                .HasIndex(x => new { x.AlbumId, x.NameId, x.AuthorsId, x.PerformersId, x.IswcId })
                .IsUnique(true);

            modelBuilder.Entity<PartnerToSourceType>()
                .HasKey(x => new { x.PartnerId, x.SourceTypeId });

            modelBuilder
                .Entity<Role>()
                .HasData([
                    new Role { Id = 1,  Code = "UserAdmin"   , Description = "Адміністратор користувачів" },
                    new Role { Id = 2,  Code = "TaskAdmin"   , Description = "Адміністратор завдань"      },
                    new Role { Id = 3,  Code = "TaskOperator", Description = "Виконавець завдань"         },
                ]);

            modelBuilder
                .Entity<Partner>()
                .HasData([
                    new Partner { Id = 1,  Code = "Google"         , Description = "Google"           },
                    new Partner { Id = 2,  Code = "Spotify"        , Description = "Spotify"          },
                    new Partner { Id = 3,  Code = "Deezer"         , Description = "Deezer"           },
                    new Partner { Id = 4,  Code = "RadioStation"   , Description = "Українське радіо" },
                ]);

            modelBuilder
                .Entity<PartnerWorkSourceType>()
                .HasData([
                    new PartnerWorkSourceType { Id = 1,  Code = "YouTubeAdv"         , Description = "Реклама"                  },
                    new PartnerWorkSourceType { Id = 2,  Code = "YouTubeMusic"       , Description = "Підписка звичайна"        },
                    new PartnerWorkSourceType { Id = 3,  Code = "YouTubePemium"      , Description = "Підписка преміальна"      },
                    new PartnerWorkSourceType { Id = 4,  Code = "YouTubePreClaim"    , Description = "Попереднє прослуховування"},
                    new PartnerWorkSourceType { Id = 5,  Code = "SpotifyFree"        , Description = "Реклама"                  },
                    new PartnerWorkSourceType { Id = 6,  Code = "SpotifySubscr"      , Description = "Підписка"                 },
                    new PartnerWorkSourceType { Id = 7,  Code = "DeezerAll"          , Description = "Прослуховування музики"   },
                    new PartnerWorkSourceType { Id = 8,  Code = "RadioStationReport" , Description = "Прослуховування музики"   },
                ]);

            modelBuilder
                .Entity<UserTaskStatus>()
                .HasData([
                    new UserTaskStatus { Id = 1,  Code = "New"        , Description = "Нова"        },
                    new UserTaskStatus { Id = 2,  Code = "Assigned"   , Description = "Запланована" },
                    new UserTaskStatus { Id = 3,  Code = "InProgress" , Description = "В роботі"    },
                    new UserTaskStatus { Id = 4,  Code = "Completed"  , Description = "Завершена"   },
                ]);

            modelBuilder
                .Entity<UserTaskType>()
                .HasData([
                    new UserTaskType { Id = 1,  Code = "SeachSocWork"          , Description = "Пошук творів товариства"      },
                    new UserTaskType { Id = 2,  Code = "SearchPartnerWork"     , Description = "Пошук творів партнерів"       },
                    new UserTaskType { Id = 3,  Code = "SearchRightHolderWork" , Description = "Пошук творів правовласників"  },
                ]);

            modelBuilder
                .Entity<PartnerToSourceType>()
                .HasData([
                    new PartnerToSourceType { PartnerId = 1, SourceTypeId = 1 },
                    new PartnerToSourceType { PartnerId = 1, SourceTypeId = 2 },
                    new PartnerToSourceType { PartnerId = 1, SourceTypeId = 3 },
                    new PartnerToSourceType { PartnerId = 1, SourceTypeId = 4 },

                    new PartnerToSourceType { PartnerId = 2, SourceTypeId = 5 },
                    new PartnerToSourceType { PartnerId = 2, SourceTypeId = 6 },

                    new PartnerToSourceType { PartnerId = 3, SourceTypeId = 7 },

                    new PartnerToSourceType { PartnerId = 4, SourceTypeId = 8 },
                ]);
        }

    }
}
