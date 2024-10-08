using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WidServiceInstallBuilder
{
    class Program
    {
        class DbContextInfo
        {
            public string DbName { get; set; }
            public string ProjectFile { get; set; }
        }

        static List<DbContextInfo> dbContexts = new List<DbContextInfo>
        {
            new DbContextInfo
            {
                DbName = "SocIpi",
                ProjectFile = @"IpiUpdatesLib\IpiUpdatesLib.csproj",
            },
            new DbContextInfo
            {
                DbName = "SocWid",
                ProjectFile = @"WidService\WidServiceLib.csproj",
            },
            new DbContextInfo
            {
                DbName = "SocWidUpdates",
                ProjectFile = @"WidUpdatesLib\WidUpdatesLib.csproj",
            },
            new DbContextInfo
            {
                DbName = "SocWidInitial",
                ProjectFile = @"WidService\WidServiceLib.csproj",
            },
            new DbContextInfo
            {
                DbName = "SocWidAdmin",
                ProjectFile = @"WidAdmin\WidAdminLib.csproj",
            },
        };
        static void Main(string[] args)
        {
            var destRootFolder = @"D:\UACRR\WID\WidServiceInstallPack";
            var srcRootFolder = @"D:\UACRR\WID\Sources\WidService";

            if (Directory.Exists(destRootFolder))
            { 
                Directory.Delete(destRootFolder, true); 
            }
            Directory.CreateDirectory(destRootFolder);
            Directory.CreateDirectory(Path.Combine(destRootFolder, @"SqlScripts"));
            Directory.CreateDirectory(Path.Combine(destRootFolder, @"WidAdminApi"));
            Directory.CreateDirectory(Path.Combine(destRootFolder, @"WidAdminConsole"));
            Directory.CreateDirectory(Path.Combine(destRootFolder, @"WidViewer"));

            Copy(Path.Combine(srcRootFolder, @"WidAdminApi\bin\Release\netcoreapp3.1"), Path.Combine(destRootFolder, @"WidAdminApi"));
            Directory.Delete(Path.Combine(destRootFolder, @"WidAdminApi\Meta"), true);
            Directory.Delete(Path.Combine(destRootFolder, @"WidAdminApi\Log"), true);

            Copy(Path.Combine(srcRootFolder, @"WidAdminConsole\bin\Release"), Path.Combine(destRootFolder, @"WidAdminConsole"));

            Copy(Path.Combine(srcRootFolder, @"WidViewer\bin\Release"), Path.Combine(destRootFolder, @"WidViewer"));

            Directory.GetFiles(Path.Combine(srcRootFolder, @"WidServiceInstaller\bin\Release")).ToList().ForEach(x =>
            {
                File.Copy(x, Path.Combine(destRootFolder, Path.GetFileName(x)));
            });

            var migrations = new List<string>();
            
            var createDbTexts = new List<string>();
            createDbTexts.Add($"use master");
            createDbTexts.Add($"go");
            createDbTexts.Add($"\r\n");
            createDbTexts.Add($"create login WidReplicationService with password=N'WidReplicationServicePwd'");
            createDbTexts.Add($"go");
            createDbTexts.Add($"\r\n");
            dbContexts.ForEach(x =>
            {
                createDbTexts.Add($"create database {x.DbName}");
                createDbTexts.Add($"go");
                createDbTexts.Add($"use {x.DbName}");
                createDbTexts.Add($"go");
                createDbTexts.Add($"create user WidReplicationService for login WidReplicationService with default_schema=dbo");
                createDbTexts.Add($"go");
                createDbTexts.Add($"alter role db_owner add member WidReplicationService");
                createDbTexts.Add($"go");
                createDbTexts.Add($"\r\n");
            });
            File.WriteAllLines($@"{destRootFolder}\SqlScripts\CreateDatabasesSample.sql", createDbTexts);

            var fileIdx = 1;
            dbContexts.ForEach(x =>
            {
                var migrationFileFullName = $@"{destRootFolder}\SqlScripts\({fileIdx.ToString("##")})-{x.DbName}.sql";
                var cmd = $@"/c dotnet ef migrations script --project {srcRootFolder}\{x.ProjectFile} --idempotent -o {migrationFileFullName}";
                var process = System.Diagnostics.Process.Start("CMD.exe", cmd);
                process.WaitForExit();

                var lines = File.ReadAllLines(migrationFileFullName).ToList();
                lines.Insert(0, "\r\n");
                lines.Insert(0, $"GO");
                lines.Insert(0, $"USE {x.DbName}");
                File.WriteAllLines(migrationFileFullName, lines);

                var migrationLine = lines.First(x => x.Contains("[MigrationId] = "));
                migrations.Add($"{x.DbName}:{migrationLine.Split('\'')[1]}");

                fileIdx++;

            });
            File.WriteAllLines(Path.Combine(destRootFolder, "Migrations.txt"), migrations);

            File.Copy(Path.Combine(srcRootFolder, $@"IpiUpdatesLib\Sql\SocIpiIndices.sql"), Path.Combine(destRootFolder, $@"SqlScripts\({fileIdx++})-SocIpiIndices.sql"));
            File.Copy(Path.Combine(srcRootFolder, $@"WidService\Sql\SocWidIndices.sql"), Path.Combine(destRootFolder, $@"SqlScripts\({fileIdx++})-SocWidIndices.sql"));

            Copy(Path.Combine(srcRootFolder, @"WidAdminApi\bin\Release\netcoreapp3.1"), Path.Combine(destRootFolder, @"WidAdminApi"));

            //var script = dbContext.
        }

        private static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                //Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
