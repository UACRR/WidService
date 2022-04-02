using InvoicingLib;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    static public class EntityManager
    {
        const string FileTypeGuid = "BADF00D6-0E55-48AA-934F-EBEF3C23F633";

        public delegate Task SqlOperation(SqlCommand cmd);
        public delegate void ProcessingPropress(string progressMessage, bool isFinal = false);

        public static async void RunSqlOperationT(string connectionString, ProcessingPropress processingPropress, SqlOperation oper)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.Transaction = tran;
                            cmd.CommandTimeout = 0;
                            await oper(cmd);
                            tran.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        processingPropress($"ВИНИКЛИ ПОМИЛКИ: {ex.Message}", true);
                    }
                }
            }
        }

        static public async void ExportExceptionSetToCsvFile(
            string connectionString, int setCode, string fileFullName, ProcessingPropress processingPropress)
        {
            processingPropress("ЕКСПОРТ РОЗПОЧАТО");
            try
            {
                using (var sw = new StreamWriter(fileFullName))
                using (var conn = new SqlConnection())
                {
                    processingPropress("Встановлення конекції до бази даних");
                    conn.ConnectionString = connectionString;
                    await conn.OpenAsync();

                    sw.WriteLine(FileTypeGuid);

                    processingPropress("Обробка ExceptionSet");
                    var exceptionSetList = new EntityList<ExceptionSet>();
                    processingPropress("   Завантаженя інформації з бази даних");
                    await exceptionSetList.LoadFromDb(conn, $" setCode = {setCode}");
                    processingPropress("   Запис інформації до файлу");
                    await exceptionSetList.SaveToFile(sw, "SetCode", "", "");

                    processingPropress("Обробка ExceptionMember");
                    var exceptionMemberList = new EntityList<ExceptionMember>();
                    processingPropress("   Завантаженя інформації з бази даних");
                    await exceptionMemberList.LoadFromDb(conn, $" setCode = {setCode}");
                    processingPropress("   Запис інформації до файлу");
                    await exceptionMemberList.SaveToFile(sw, "Id", "ExceptionSet", "SetCode");

                    processingPropress("Обробка ExceptionAdd");
                    var exceptionAddList = new EntityList<ExceptionAdd>();
                    processingPropress("   Завантаженя інформації з бази даних");
                    await exceptionAddList.LoadFromDb(conn, $" excId in (select id from ExceptionMember where setCode = {setCode})");
                    processingPropress("   Запис інформації до файлу");
                    await exceptionAddList.SaveToFile(sw, "Id", "ExceptionMember", "ExcId");

                    processingPropress("ЕКСПОРТ ЗАВЕРШЕНО", true);
                }
            }
            catch(Exception ex)
            {
                processingPropress($"ВИНИКЛИ ПОМИЛКИ: {ex.Message}", true);
            }
        }

        static public bool IsValidCsvFile(string fileFullName)
        {
            using (var sr = new StreamReader(fileFullName))
            {
                var firstLine = sr.ReadLine();
                return firstLine.Equals(FileTypeGuid);
            }
        }

        static public void ImportFromCsvFile(string connectionString, string fileFullName, ProcessingPropress processingPropress)
        {
            processingPropress("ІМПОРТ РОЗПОЧАТО");
            var lineCount = 0;
            using (var sr = new StreamReader(fileFullName))
            {
                while (sr.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            RunSqlOperationT(connectionString, processingPropress, async cmd =>
            {
                using (var sr = new StreamReader(fileFullName))
                {
                    string line = null;
                    string tableName = null;
                    string pkName = null;
                    string fkTableName = null;
                    string fkName = null;
                    List<PropertyInfo> propertyList = null;

                    int oldPkValue = 0;
                    Dictionary<string, Dictionary<int, int>> pkMap = new Dictionary<string, Dictionary<int, int>>();

                    sr.ReadLine(); // Skip line with ID

                    int lineIndex = 1;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parser = new TextFieldParser(new StringReader(line))
                        {
                            HasFieldsEnclosedInQuotes = true
                        };
                        parser.SetDelimiters(",");
                        var fields = parser.ReadFields();
                        parser.Close();
                        if (fields[0].Equals("#"))
                        {
                            tableName = fields[1];
                            var entityType = Type.GetType($"ExportImport.{ tableName}");
                            propertyList = entityType.GetProperties().ToList();

                            pkName = propertyList
                                .Single(x => Attribute.IsDefined(x, typeof(PkAttribute)))
                                .Name;

                            var fkPd = propertyList
                                .SingleOrDefault(x => Attribute.IsDefined(x, typeof(FkAttribute)));
                            if(fkPd == null)
                            {
                                fkTableName = "";
                                fkName = "";
                            }
                            else
                            {
                                fkTableName = fkPd.GetCustomAttribute<FkAttribute>().TableName;
                                fkName = fkPd.Name;
                            }

                            pkMap.Add(tableName, new Dictionary<int, int>());

                            var colsString = "";
                            var paramsString = "";
                            propertyList.ForEach(x =>
                            {
                                if (!string.IsNullOrEmpty(colsString))
                                {
                                    colsString += ", ";
                                    paramsString += ", ";
                                }
                                if (!x.Name.Equals(pkName))
                                {
                                    colsString += $"{x.Name}";
                                    paramsString += $"@{x.Name}";
                                }
                            });
                            cmd.CommandText = $"insert into {tableName} ({colsString}) values ({paramsString}); select SCOPE_IDENTITY()";
                            continue;
                        }

                        var fieldIndex = 0;
                        cmd.Parameters.Clear();
                        propertyList.ForEach(x =>
                        {
                            var paramName = $"@{x.Name}";
                            var valueString = fields[fieldIndex];

                            // Change for static value if appropriate
                            if (Attribute.IsDefined(x, typeof(ImportCurrentAttribute)))
                            {
                                valueString = Formatter.ToExportString(DateTime.Now);
                            }
                            else if (Attribute.IsDefined(x, typeof(ImportValueAttribute)))
                            {
                                valueString = Formatter.ToExportString(x.GetCustomAttribute<ImportValueAttribute>().Value);
                            }

                            // Add parameter with value
                            if (x.Name.Equals(pkName))
                            {
                                oldPkValue = int.Parse(valueString);
                            }
                            else if (x.Name.Equals(fkName))
                            {
                                if (string.IsNullOrEmpty(valueString))
                                {
                                    cmd.Parameters.AddWithValue(paramName, DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue(paramName, pkMap[fkTableName][int.Parse(valueString)]);
                                }
                            }
                            else
                            {
                                if (x.PropertyType.Equals(typeof(int)) || x.PropertyType.Equals(typeof(int?)))
                                {
                                    if (string.IsNullOrEmpty(valueString))
                                    {
                                        cmd.Parameters.AddWithValue(paramName, DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue(paramName, int.Parse(valueString));
                                    }
                                }
                                else if (x.PropertyType.Equals(typeof(decimal)) || x.PropertyType.Equals(typeof(decimal?)))
                                {
                                    if (string.IsNullOrEmpty(valueString))
                                    {
                                        cmd.Parameters.AddWithValue(paramName, DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue(paramName, Formatter.ToDecimal(valueString));
                                    }
                                }
                                else if (x.PropertyType.Equals(typeof(string)))
                                {
                                    cmd.Parameters.AddWithValue(paramName, valueString);
                                }
                                else if (x.PropertyType.Equals(typeof(DateTime)) || x.PropertyType.Equals(typeof(DateTime?)))
                                {
                                    if (string.IsNullOrEmpty(valueString))
                                    {
                                        cmd.Parameters.AddWithValue(paramName, DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue(paramName, Formatter.ToDateTime(valueString));
                                    }
                                }
                            }

                            fieldIndex++;
                        });

                        var newPkValue = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                        pkMap[tableName].Add(oldPkValue, newPkValue);
                        if(lineIndex % 10 == 0)
                        {
                            processingPropress($"Оброблено {lineIndex} з {lineCount} записів");
                        }
                        lineIndex++;
                    }
                };
                processingPropress($"ІМПОРТ ЗАВЕРШЕНО", true);
            });
        }
    }
}
