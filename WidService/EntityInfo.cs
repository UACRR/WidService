using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WidServiceLib
{
    public class EntityInfo
    {
        public delegate object FieldConverter(string fieldString);

        public class EntityPropInfo
        {
            public FieldConverter fieldConverter;
            public PropertyInfo propertyInfo;
            public int seqNrInFile;
        }
        public class EntityInfoEntry
        {
            public string name;
            public string tableName;
            public string tableNameHist;
            public string className;
            public string fileName;
            public string zipFileName;
            public Type entityType;
            public List<EntityPropInfo> entityPropInfoList;
        }
        public static List<EntityInfoEntry> entityInfoList;
        static Dictionary<string, EntityInfoEntry> entityInfoEntryFromName;

        public static object StringFieldConverter(string fieldString)
        {
            if (string.IsNullOrEmpty(fieldString))
                return "";
            else
                return fieldString;
        }
        public static object IntFieldConverter(string fieldString)
        {
            if (string.IsNullOrEmpty(fieldString))
                return DBNull.Value;
            else
                return int.Parse(fieldString);
        }
        public static object DecimalFieldConverter(string fieldString)
        {
            var format = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = ""
            };
            if (string.IsNullOrEmpty(fieldString))
                return DBNull.Value;
            else
                return decimal.Parse(fieldString, format);
        }
        public static object DateTimeFieldConverter(string fieldString)
        {
            if (string.IsNullOrEmpty(fieldString))
                return DBNull.Value;
            else
            {
                DateTime retVal;
                if(!DateTime.TryParse(fieldString, out retVal))
                {
                    try
                    {
                        retVal = new DateTime(
                          int.Parse(fieldString.Substring(0, 4)),
                          int.Parse(fieldString.Substring(4, 2)),
                          int.Parse(fieldString.Substring(6, 2))
                        );
                    }
                    catch
                    {
                        return DBNull.Value;
                    }
                }
                if (retVal < Helpers.msSqlMinDate)
                    return Helpers.msSqlMinDate;
                else if (retVal > Helpers.msSqlMaxDate)
                    return Helpers.msSqlMaxDate;
                else
                    return retVal;
            }
        }
        static EntityInfoEntry InitEntityInfoEntry(PropertyInfo piFromDbContext)
        {
            var entitySetType = piFromDbContext.PropertyType;
            var entityType = entitySetType.GenericTypeArguments[0];
            var entityName = entityType.Name.Substring(0, entityType.Name.Length - "Entity".Length);

            if(entityName.Contains("Hist"))
            {
                return null;
            }

            var tableName = ((TableAttribute)entityType.GetCustomAttribute(typeof(TableAttribute))).Name;
            var entityInfo = new EntityInfoEntry
            {
                name = entityName,
                tableName = tableName,
                tableNameHist = $"{tableName}Hist",
                className = entityType.Name,
                fileName = $"tbl{entityName}.asc",
                zipFileName = $"tbl{entityName}.zip",
                entityType = entityType,
                entityPropInfoList = new List<EntityPropInfo>(),
            };
            int i = 0;
            entityType.GetProperties().ToList().ForEach(x =>
            {
                var propType = x.PropertyType;
                FieldConverter converter = null;
                if (propType == typeof(string))
                    converter = StringFieldConverter;
                else if (propType == typeof(int) || propType == typeof(int?))
                    converter = IntFieldConverter;
                else if (propType == typeof(decimal) || propType == typeof(decimal?))
                    converter = DecimalFieldConverter;
                else if (propType == typeof(DateTime) || propType == typeof(DateTime?))
                    converter = DateTimeFieldConverter;

                var seqNrInFile = -1;
                CustomSeqNrInFileAttribute seqNrInFileAttribute = (CustomSeqNrInFileAttribute)x.GetCustomAttribute(typeof(CustomSeqNrInFileAttribute));

                if (seqNrInFileAttribute != null)
                    seqNrInFile = seqNrInFileAttribute.SeqNr;

                var entityPropInfo = new EntityPropInfo
                {
                    fieldConverter = converter,
                    propertyInfo = x,
                    seqNrInFile = seqNrInFile,
                };
                entityInfo.entityPropInfoList.Add(entityPropInfo);
                i++;
            });
            return entityInfo;
        }
        private  static void Init()
        {
            if(entityInfoList != null)
            {
                return;
            }

            entityInfoList = new List<EntityInfoEntry>();
            entityInfoEntryFromName = new Dictionary<string, EntityInfoEntry>();
            var dbContextType = typeof(WidDbContext);
            dbContextType
                .GetProperties(BindingFlags.Public
                    | BindingFlags.Instance
                    | BindingFlags.DeclaredOnly)
                .ToList()
                .ForEach(x => {
                    var entitySetType = x.PropertyType;
                    var entityType = entitySetType.GenericTypeArguments[0];
                    var initEntityInfoEntry = InitEntityInfoEntry(x);
                    if(initEntityInfoEntry != null)
                    {
                        entityInfoList.Add(initEntityInfoEntry);
                        entityInfoEntryFromName.Add(initEntityInfoEntry.name, initEntityInfoEntry);
                    }
                });
        }

        public static string GetEntityClassName(string entityName)
        {
            Init();
            return entityInfoEntryFromName[entityName].className;
        }

        public static string GetEntityFileName(string entityName)
        {
            Init();
            return entityInfoEntryFromName[entityName].fileName;
        }

        public static string GetEntityZipFileName(string entityName)
        {
            Init();
            string retVal = entityInfoEntryFromName[entityName].zipFileName;
            if (retVal.Equals("tblIpiBase.zip", StringComparison.OrdinalIgnoreCase))
                retVal = "tblIPIBase.zip";
            else if (retVal.Equals("tblIpiName.zip", StringComparison.OrdinalIgnoreCase))
                retVal = "tblIPIName.zip";
            else if (retVal.Equals("tblIpiStatus.zip", StringComparison.OrdinalIgnoreCase))
                retVal = "tblIPIStatus.zip";
            else if (retVal.Equals("tblIswc.zip", StringComparison.OrdinalIgnoreCase))
                retVal = "tblISWC.zip";
            return retVal;
        }

        public static string GetEntityTableName(string entityName)
        {
            Init();
            return entityInfoEntryFromName[entityName].className;
        }

        public static EntityInfoEntry GetEntityInfoEntry(string entityName)
        {
            Init();
            return entityInfoEntryFromName[entityName];
        }

        public static EntityPropInfo GetEntityPropInfo(string entityName, string propName)
        {
            Init();
            var entityInfoEntry = GetEntityInfoEntry(entityName);
            return entityInfoEntry.entityPropInfoList.SingleOrDefault(x => x.propertyInfo.Name == propName);
        }

        public static List<string> GetEntityNames()
        {
            Init();
            var retVal = new List<string>();
            entityInfoList.ForEach(x => retVal.Add(x.name));
            return retVal;
        }

        public static List<EntityInfoEntry> GetEntityInfoList()
        {
            Init();
            return entityInfoList;
        }
    }
}
