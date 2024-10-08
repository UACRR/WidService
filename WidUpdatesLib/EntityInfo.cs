using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WidUpdatesLib
{
    public class EntityInfo
    {
        public delegate object FieldConverter(string fieldString);

        public class EntityPropInfo
        {
            public FieldConverter fieldConverter;
            public PropertyInfo propertyInfo;
            public int start;
            public int size;
            public bool isForMatch;
            public bool isForUpdate;
            public WidServiceLib.EntityInfo.EntityPropInfo widServicePropInfo;
        }
        public class EntityInfoEntry
        {
            public string name;
            public Type updClassType;
            public string tableName;
            public Type entityType;
            public bool isTran;
            public bool hasSeqNr;
            public string updateMethod;
            public string fileTimeCol;
            public bool hasVrExrpIndV;
            public bool hasVrExrpIndE;
            public PropertyInfo piWicCode;
            public PropertyInfo piIswc;
            public List<EntityPropInfo> entityPropInfoList;
            public WidServiceLib.EntityInfo.EntityInfoEntry widServiceEntityInfoEntry;
            public string cmdTextSearch;
            public string cmdTextInsert;
            public string cmdTextUpdate;
            public string cmdTextCompare;
        }
        public static List<EntityInfoEntry> entityInfoList;
        static Dictionary<string, EntityInfoEntry> entityInfoEntryFromRecCode;

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
                var retVal = DateTime.Parse(fieldString);
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

            string targetWidEntityName = null;
            var targetWidEntityAttribute = (CustomTargetWidEntityAttribute)entityType.GetCustomAttribute(typeof(CustomTargetWidEntityAttribute));
            if (targetWidEntityAttribute != null)
            {
                targetWidEntityName = targetWidEntityAttribute.Name;
            }

            var updateMethod = ((CustomUpdateMethodAttribute)entityType.GetCustomAttribute(typeof(CustomUpdateMethodAttribute))).UpdateMethod;
            var fileTimeColAttribute = ((CustomFileTimeColAttribute)entityType.GetCustomAttribute(typeof(CustomFileTimeColAttribute)));
            var entityInfo = new EntityInfoEntry
            {
                name = entityType.Name,
                updClassType = Type.GetType($"WidUpdatesLib.UpdRecs.DerivedUpdRecs.Upd{entityType.Name}"),
                tableName = ((TableAttribute)entityType.GetCustomAttribute(typeof(TableAttribute))).Name,
                entityType = entityType,
                isTran = entityType.GetCustomAttribute(typeof(CustomIsTranAttribute)) != null,
                hasSeqNr = false,
                updateMethod = updateMethod,
                hasVrExrpIndE = entityType.GetCustomAttribute(typeof(CustomVrExrpIndEAttribute)) != null,
                hasVrExrpIndV = entityType.GetCustomAttribute(typeof(CustomVrExrpIndVAttribute)) != null,
                fileTimeCol = fileTimeColAttribute != null ? fileTimeColAttribute.FileTimeCol : null,
                piWicCode = null,
                piIswc = null,
                entityPropInfoList = new List<EntityPropInfo>(),
            };

            if (targetWidEntityName != null)
            {
                entityInfo.widServiceEntityInfoEntry = WidServiceLib.EntityInfo.GetEntityInfoEntry(targetWidEntityName);
            }

            var searchExpr = "";
            var insertColNames = "";
            var insertParamNames = "";
            var updateAssignText = "";
            var compareExpr = "";

            entityType.GetProperties().ToList().ForEach(x =>
            {
                CustomPosInFileAttribute customPosInFileAttribute = (CustomPosInFileAttribute)x.GetCustomAttribute(typeof(CustomPosInFileAttribute));

                if(customPosInFileAttribute != null)
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

                    if(x.Name == "WicCode")
                    {
                        entityInfo.piWicCode = x;
                    }
                    else if (x.Name == "Iswc")
                    {
                        entityInfo.piIswc = x;
                    }

                    WidServiceLib.EntityInfo.EntityPropInfo widServicePropInfo = null; 
                    if (targetWidEntityName != null)
                    {
                        widServicePropInfo = WidServiceLib.EntityInfo.GetEntityPropInfo(targetWidEntityName, x.Name);
                    }

                    var entityPropInfo = new EntityPropInfo
                    {
                        fieldConverter = converter,
                        propertyInfo = x,
                        start = customPosInFileAttribute.Start,
                        size = customPosInFileAttribute.Size,
                        isForMatch = x.GetCustomAttribute(typeof(CustomForMatchAttribute)) != null,
                        isForUpdate = x.GetCustomAttribute(typeof(CustomForMatchAttribute)) != null,
                        widServicePropInfo = widServicePropInfo,
                    };
                    entityInfo.entityPropInfoList.Add(entityPropInfo);
                }
            });

            if (entityInfo.widServiceEntityInfoEntry != null)
            {
                entityInfo.entityPropInfoList
                    .Where(x => x.widServicePropInfo != null)
                    .ToList()
                    .ForEach(x =>
                    {
                        var colName = x.widServicePropInfo.propertyInfo.Name;
                        insertColNames += $", {colName}";
                        insertParamNames += $", @{colName}";
                        updateAssignText += $", {colName} = @{colName}";
                        if(entityInfo.updateMethod == "I" || x.isForMatch)
                        {
                            searchExpr += $" and {colName} = @{colName}";
                        }
                        compareExpr += $" and {colName} = @{colName}";
                    });

                if(entityType.Name == "RecSip" || entityType.Name == "RecOip")
                {
                    insertColNames += $", RolId";
                    insertParamNames += $", @RolId";
                }

                if (entityType.Name == "RecSsr" || entityType.Name == "RecOsr")
                {
                    insertColNames += $", IntrPtyRolid";
                    insertParamNames += $", @IntrPtyRolid";
                }

                if (entityType.Name == "RecWpl")
                {
                    insertColNames += $", WtrIntrPtySeq, PubIntrPtySeq";
                    insertParamNames += $", @WtrIntrPtySeq, @PubIntrPtySeq";
                }

                if (entityType.Name == "RecIsw")
                {
                    insertColNames += $", PrefIswc";
                    insertParamNames += $", @PrefIswc";
                }


                if (entityInfo.widServiceEntityInfoEntry.entityPropInfoList.Any(pi => pi.propertyInfo.Name == "SeqNr"))
                {
                    entityInfo.hasSeqNr = true; ;
                    insertColNames += $", SeqNr";
                    insertParamNames += $", @SeqNr";
                }

                if(entityInfo.fileTimeCol != null)
                {
                    insertColNames += $", {entityInfo.fileTimeCol}";
                    insertParamNames += $", @{entityInfo.fileTimeCol}";
                    updateAssignText += $", {entityInfo.fileTimeCol} = @{entityInfo.fileTimeCol}";
                }

                var vrExrpIndCol = "";
                var vrExrpIndVal = "";
                if (entityInfo.hasVrExrpIndE)
                {
                    vrExrpIndCol = ", VrExrpInd";
                    vrExrpIndVal = ", 'E'";
                }
                else if(entityInfo.hasVrExrpIndV)
                {
                    vrExrpIndCol = ", VrExrpInd";
                    vrExrpIndVal = ", 'V'";
                }

                insertColNames += ", CreTs, CreUid, UpdTs, UpdUid";
                insertParamNames += ", @CreTs, @CreUid, @UpdTs, @UpdUid";
                updateAssignText += ", UpdTs = @UpdTs, UpdUid = @UpdUid";

                entityInfo.cmdTextSearch = $"select Id from SocWid..{entityInfo.widServiceEntityInfoEntry.tableName}\r\n"
                    + $"where Wic = @updWic {searchExpr}";
                entityInfo.cmdTextInsert = $"insert SocWid..{entityInfo.widServiceEntityInfoEntry.tableName} (Wic{vrExrpIndCol}{insertColNames})\r\n"
                            + $"values (@updWic{vrExrpIndVal}{insertParamNames})\r\n"
                            + "select scope_identity()";
                entityInfo.cmdTextUpdate = $"update SocWid..{entityInfo.widServiceEntityInfoEntry.tableName}\r\n"
                    + $"set Wic = @updWic{updateAssignText} where Id = @widId";
                entityInfo.cmdTextCompare = $"if exists (select null from SocWid..{entityInfo.widServiceEntityInfoEntry.tableName}\r\n"
                    + $"where Wic = @updWic {compareExpr}) select 1 else select 0";
            }
            return entityInfo;
        }
        private  static void Init()
        {
            if(entityInfoList != null)
            {
                return;
            }

            entityInfoList = new List<EntityInfoEntry>();
            entityInfoEntryFromRecCode = new Dictionary<string, EntityInfoEntry>();
            var dbContextType = typeof(WidUpdatesDbContext);
            dbContextType
                .GetProperties(BindingFlags.Public
                    | BindingFlags.Instance
                    | BindingFlags.DeclaredOnly)
                .ToList()
                .ForEach(x => {
                    var entitySetType = x.PropertyType;
                    var entityType = entitySetType.GenericTypeArguments[0];
                    if(entityType.Name.Substring(0, 3).Equals("Rec", StringComparison.OrdinalIgnoreCase))
                    {
                        var initEntityInfoEntry = InitEntityInfoEntry(x);
                        entityInfoList.Add(initEntityInfoEntry);
                        entityInfoEntryFromRecCode.Add(entityType.Name.Substring(3).ToUpper(), initEntityInfoEntry);
                    }
                });
        }

        public static EntityInfoEntry GetEntityInfoEntry(string recCode)
        {
            Init();
            if(entityInfoEntryFromRecCode.ContainsKey(recCode))
            {
                return entityInfoEntryFromRecCode[recCode];
            }
            else
            {
                return null;
            }
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
