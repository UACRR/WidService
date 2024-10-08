using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WidService
{
    public class EntityCreator
    {
        const string connectString = @"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = WID_IPI; Server=89.184.65.168\IPSDATA,60675";

        const string entityFilesDir = @"D:\UACRR\WID\Sources\WidService\WidService\Entities\";

        public static void CreateEntityFiles()
        {
            Helpers.GetEntityNameList().ForEach(x =>
            {
                CreateEntityFile(x);
            });
        }

        private static void CreateEntityFile(string entityName)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();

                cmd.CommandText = $@"
                    select 
                          column_name
                        , data_type
                        , character_maximum_length
                        , is_nullable
                    from information_schema.columns
                    where table_name = @tableName
                    order by ordinal_position
                ";
                cmd.Parameters.AddWithValue("@tableName", $"{Helpers.GetEntityTableName(entityName)}");
                var r = cmd.ExecuteReader();
                var propsText = "";
                while (r.Read())
                {
                    propsText += new string(' ', 8);
                    string columnName = r.GetString(0);
                    string dataType = r.GetString(1);
                    int? dataLength = !r.IsDBNull(2) ? r.GetInt32(2) : (int?)null;
                    bool isNullable = r.GetString(3).Equals("yes", StringComparison.OrdinalIgnoreCase);
                    propsText += $"{GetPropertyText(columnName, dataType, dataLength, isNullable)}\r\n";
                }
                var fileText =
$@"using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidService.Entities
{{
    [Table(""{Helpers.GetEntityTableName(entityName)}"")]
    public class {Helpers.GetEntityClassName(entityName)}
    {{
{propsText}
    }}
}}
";
                File.WriteAllText($"{entityFilesDir}{Helpers.GetEntityClassName(entityName)}.cs", fileText);
            }
        }

        private static string GetColumnAttributeText(string dataType, int? dataLength)
        {
            var dataLengthText = dataLength == null ? "" : $"({dataLength})";
            return $"[Column(TypeName = \"{dataType}{dataLengthText}\")]";
        }

        private static string GetColumnCSharpName(string dataType)
        {
            switch (dataType)
            {
                case "char": return "string";
                case "datetime": return "DateTime";
                case "int": return "int";
                case "smallint": return "int";
                case "smallmoney": return "decimal";
                case "tinyint": return "int";
                case "varchar": return "string";
                default:
                    throw new Exception($"Unknown data type {dataType}");
            }
        }
        private static string GetRequredAttribureText(string dataType, bool isNullable)
        {
            switch (dataType)
            {
                case "char":
                case "varchar": 
                    return isNullable ? "" : "[Required]";
                case "datetime":
                case "int":
                case "smallint":
                case "smallmoney":
                case "tinyint": 
                    return "";
                default:
                    throw new Exception($"Unknown data type {dataType}");
            }
        }
        private static string GetRequredPostfixText(string dataType, bool isNullable)
        {
            switch (dataType)
            {
                case "char":
                case "varchar":
                    return "";
                case "datetime":
                case "int":
                case "smallint":
                case "smallmoney":
                case "tinyint":
                    return isNullable ? "?" : "";
                default:
                    throw new Exception($"Unknown data type {dataType}");
            }
        }
        private static string GetPropertyText(string columnName, string dataType, int? dataLength, bool isNullable)
        {
            var columnAttributeText = GetColumnAttributeText(dataType, dataLength);
            var requredAttribureText = GetRequredAttribureText(dataType, isNullable);
            var columnCSharpName = GetColumnCSharpName(dataType);
            var requredPostfixText = GetRequredPostfixText(dataType, isNullable);
            return $"{columnAttributeText}{requredAttribureText} public {columnCSharpName}{requredPostfixText} {columnName} {{ get; set; }}";
        }
    }
}
