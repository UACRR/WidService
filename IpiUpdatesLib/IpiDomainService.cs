using IpiUpdatesLib.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IpiUpdatesLib
{
    public class IpiDomainService
    {
        private static Dictionary<string, Type> RecToEntityType = new Dictionary<string, Type>
        {
            { "CCL", typeof(DicCcl) },
            { "CSC", typeof(DicCsc) },
            { "HNA", typeof(DicHna) },
            { "HNR", typeof(DicHnr) },
            { "IRI", typeof(DicIri) },
            { "ISC", typeof(DicIsc) },
            { "NMT", typeof(DicNmt) },
            { "RCC", typeof(DicRcc) },
            { "RIG", typeof(DicRig) },
            { "RIS", typeof(DicRis) },
            { "RIX", typeof(DicRix) },
            { "ROL", typeof(DicRol) },
            { "SOC", typeof(DicSoc) },
            { "SOP", typeof(DicSop) },
            { "TNA", typeof(DicTna) },
            { "TNR", typeof(DicTnr) },
        };

        private IpiUpdatesDbContext _dbc;
        private RpnSettings _settings;

        public IpiDomainService()
        {
            _dbc = new IpiUpdatesDbContext();
            _settings = _dbc.RpnSettings.Single();
        }

        public void ApplyFileDomains()
        {
            var lines = File.ReadAllLines(Path.Combine(_settings.WorkFilesRootPath, "Domains.Edi"));

           for (int lineIdx = 0; lineIdx < lines.Length; lineIdx++)
           {
                var line = lines[lineIdx];
                var recName = line.Substring(0, 3);
                if(recName == "IDA")
                {
                    var dicName = line.Substring(56, 3);
                    Logger.WriteLine($"Processing {dicName}");
                    var recs = new List<string>();
                    for (int nestedLineIdx = lineIdx + 1; nestedLineIdx < lines.Length; nestedLineIdx++)
                    {
                        var nestedLine = lines[nestedLineIdx];
                        var nestedRecName = nestedLine.Substring(0, 3);
                        if(nestedRecName != dicName)
                        {
                            ApplyDic(dicName, recs);
                            Logger.WriteLine($"End Processing {dicName}");
                            lineIdx = nestedLineIdx - 1;
                            break;
                        }
                        
                        recs.Add(nestedLine);
                    }
                }
           }
        }

        private void ApplyDic(string dicName, List<string> recs)
        {
            var dicType = RecToEntityType[dicName];
            var tableName = ((TableAttribute)dicType.GetCustomAttribute(typeof(TableAttribute))).Name;
            var dicTypeProps = dicType.GetProperties().ToList();

            var conn = (SqlConnection)_dbc.Database.GetDbConnection();
            conn.Open();
            using(var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $"truncate table {tableName}";
                cmd.ExecuteNonQuery();

                var bl = new BulkUploadToSql();
                bl.conn = conn;
                bl.TableName = tableName;

                recs.ForEach(rec =>
                {
                    var data = new List<object> { DBNull.Value };
                    dicTypeProps.ForEach(x =>
                    {
                        var posInFile = (CustomPosInFileAttribute)x.GetCustomAttribute(typeof(CustomPosInFileAttribute));
                        if(posInFile != null)
                        {
                            var val = rec.Substring(posInFile.Start - 1, posInFile.Size);
                            data.Add(val);
                        }
                    });
                    bl.AddData(data);
                });

                bl.Flush();
            }
            
            conn.Close();
        }
    }
}
