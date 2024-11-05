using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

namespace CopyrightObjectSearch.Server
{
    public class ProgrammabilityBuilder
    {
        public static readonly List<string> FileNames = new List<string>
        {
            "fnPreProcessNames.sql",
            "fnDdexFileTitle.sql",
            "fnDdexFileTypePartnerId.sql",
            "fnDdexFileTypeSourceTypeId.sql",

            "spNormalizeNames.sql",
            "spUpdatePartnerWorkAlbums.sql",
            "spUpdatePartnerWorkNames.sql",
            "spUpdatePartnerWorkAuthors.sql",
            "spUpdatePartnerWorkPerformers.sql",
            "spUpdatePartnerWorkIswcs.sql",
            "spUpdatePartnerWorks.sql",
            "spSetPartnerWorkObjId.sql",
            "spSetPartnerWorkWic.sql",
            "spSetPartnerWorkIswc.sql",

            "vWidAuthorAgg.sql",
            "vWidPerformerAgg.sql",
            "vWidPartyAgg.sql",
            "vWidNameAuthorsPerformers.sql",
        };

        private readonly MigrationBuilder _migrationBuilder;

        public ProgrammabilityBuilder(MigrationBuilder migrationBuilder)
        {
            _migrationBuilder = migrationBuilder;
        }

        public void Run() {
            
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames().ToList();

            FileNames.ForEach(file => {
                var resourceName = resourceNames.SingleOrDefault(x => x.EndsWith(file));
                if (resourceName != null)
                {
                    using var stream = assembly.GetManifestResourceStream(resourceName);
                    if (stream != null)
                    {
                        using var reader = new StreamReader(stream);
                        if(stream != null)
                        {
                            var sql = reader.ReadToEnd();
                            _migrationBuilder.Sql(sql);
                        };
                    }
                };
            });

            //migrationBuilder.Sql("use master");
        } 
        
        public string GetSql()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames().ToList();
            resourceNames.ForEach(x =>
            {
                var fileNameParts = Path.GetFileNameWithoutExtension(x).Split('.');
                var fileName = fileNameParts[fileNameParts.Length - 1];
            });

                // .FirstOrDefault(x => x.EndsWith($"{script}.sql"));
                // using var stream = assembly.GetManifestResourceStream(resourceName);
                //using var reader = new StreamReader(stream);
                //var sqlResult = reader.ReadToEnd();
            return null;
 //           migrationBuilder.Sql(sqlResult);
        }
    }
}
