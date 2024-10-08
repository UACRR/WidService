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

        public DbSet<ExternalObject> ExternalObjects { get; set; }
        public DbSet<TmpSelectedId>  TmpSelectedIds  { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        // Virtual Entities
        public DbSet<FoundNameAuthorsPerformers> FoundNameAuthorsPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("CopyrightObjectSearchDbContext OnConfiguring");
            //optionsBuilder.UseSqlServer(@"Persist Security Info=False;User=OlegM;Password=111111;Server=193.178.146.103\\IPSDATA,60675;database=CopyrightObjectSearch;");
            Console.WriteLine("CopyrightObjectSearchDbContext OnConfiguring OK");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("CopyrightObjectSearchDbContext OnConfiOnModelConfiguring");

            modelBuilder.Entity<FoundNameAuthorsPerformers>().Metadata.SetIsTableExcludedFromMigrations(true);

            modelBuilder.Entity<ExternalObject>()
                .HasIndex(x => new { x.Title })
                .IsUnique(false);

            modelBuilder.Entity<ExternalObject>()
                .HasIndex(x => new { x.Title, x.Authors, x.Performers, x.Iswc })
                .IsUnique(true);

            modelBuilder
                .Entity<Role>()
                .HasData([
                    new Role { Id = 1,  Code = "UserAdmin"   , Description = "Адміністратор користувачів" },
                    new Role { Id = 2,  Code = "TaskAdmin"   , Description = "Адміністратор завдань"      },
                    new Role { Id = 3,  Code = "TaskOperator", Description = "Виконавець завдань"         },
                ]);
        }

    }
}
