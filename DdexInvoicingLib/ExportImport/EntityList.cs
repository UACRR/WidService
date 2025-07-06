using InvoicingLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    public class EntityList<T> where T: new()
    {
        private List<T> _entities = new List<T>();

        public delegate void ImportStatus(string status);

        public async Task LoadFromDb(SqlConnection conn, string whereString)
        {
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                var colsString = "";
                typeof(T).GetProperties().ToList().ForEach(x =>
                {
                    if(!string.IsNullOrEmpty(colsString))
                    {
                        colsString += ", ";
                    }
                    colsString += $"{x.Name} as {x.Name}";
                });

                cmd.CommandText = $"select {colsString} from {typeof(T).Name} where {whereString}";
                using (var r = await cmd.ExecuteReaderAsync())
                {
                    while (await r.ReadAsync())
                    {
                        _entities.Add(LoadEntityFromReader(r));
                    }
                }
            }
        }

        public T LoadEntityFromReader(SqlDataReader r)
        {
            var retVal = new T();
            var i = 0;
            typeof(T).GetProperties().ToList().ForEach(x =>
            {
                if(!r.IsDBNull(i))
                {
                    if (x.PropertyType.Equals(typeof(int)) || x.PropertyType.Equals(typeof(int?)))
                    {
                        x.SetValue(retVal, r.GetInt32(i));
                    }
                    else if (x.PropertyType.Equals(typeof(decimal)) || x.PropertyType.Equals(typeof(decimal?)))
                    {
                        x.SetValue(retVal, r.GetDecimal(i));
                    }
                    else if (x.PropertyType.Equals(typeof(string)))
                    {
                        x.SetValue(retVal, r.GetString(i));
                    }
                    else if (x.PropertyType.Equals(typeof(DateTime)) || x.PropertyType.Equals(typeof(DateTime?)))
                    {
                        x.SetValue(retVal, r.GetDateTime(i));
                    }
                    else if (x.PropertyType.Equals(typeof(bool)) || x.PropertyType.Equals(typeof(bool?)))
                    {
                        x.SetValue(retVal, r.GetBoolean(i));
                    }
                }
                else
                {
                    x.SetValue(retVal, null);
                }
                i++;
            });
            return retVal;
        }

        public async Task SaveToFile(StreamWriter sw, string pkName, string fkTable, string fkName)
        {
            var entityType = typeof(T);
            sw.WriteLine($"\"#\", \"{entityType.Name}\", \"{pkName}\",\"{fkTable}\",\"{fkName}\"");
            foreach(var entity in _entities)
            {
                var line = "";
                entityType.GetProperties().ToList().ForEach(pd =>
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        line += ",";
                    }
                    line += $"\"{Formatter.ToExportString(pd.GetValue(entity))}\"";
                });
                await sw.WriteLineAsync(line);
            }
        }

    }
}
