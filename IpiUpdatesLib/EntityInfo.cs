using IpiUpdatesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IpiUpdatesLib
{
    public class EntityInfo
    {
        private static readonly List<string> _transRecTypes = new List<string>
        {
            "IDA",
            "IPA",
            "MAA",
            "NCA",
            "NPA",
            "NTA",
            "NUA",
            "REA",
            "STA",
            "BDU",
            "MAU",
            "NCU",
            "NTU",
            "MAD",
            "NCD",
            "NTD",
            "NUD",
            "RED",
            "STD",
            "FRJ",
            "GRJ",
        };

        private static readonly List<string> _detailRecTypes = new List<string>
        {
            "BDN",
            "INN",
            "IMN",
            "MAN",
            "MCN",
            "MUN",
            "NCN",
            "NTN",
            "NUN",
            "ONN",
            "REN",
            "STN",

            "BDO",
            "INO",
            "IMO",
            "MAO",
            "MCO",
            "MUO",
            "NCO",
            "NTO",
            "NUO",
            "ONO",
            "REO",
            "STO",

            "TMA",
        };

        private static readonly List<string> _domainRecTypes = new List<string>
        {
            "CCL",
            "IRI",
            "ISC",
            "NMT",
            "RCC",
            "RIG",
            "RIS",
            "RIX",
            "ROL",
            "SOC",
            "SOP",
            "CSC",

            "TNR",
            "TNA",
            "HNR",
            "HNA",

            "TRS",
            "DRS",
       };

        public delegate object FieldConverter(string fieldString);

        public class EntityPropInfo
        {
            public FieldConverter fieldConverter;
            public PropertyInfo propertyInfo;
            public int start;
            public int size;
         }
        public class EntityInfoEntry
        {
            public string name;
            public string tableName;
            public Type entityType;
            public bool isTrans;
            public bool isDetail;
            public bool isDomain;
            public List<EntityPropInfo> entityPropInfoList;
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

            var fileTimeColAttribute = ((CustomFileTimeColAttribute)entityType.GetCustomAttribute(typeof(CustomFileTimeColAttribute)));
            var entityInfo = new EntityInfoEntry
            {
                name = entityType.Name,
                tableName = ((TableAttribute)entityType.GetCustomAttribute(typeof(TableAttribute))).Name,
                entityType = entityType,
                isTrans = entityType.Name == "UpdTrans",
                isDetail = _detailRecTypes.Contains(entityType.Name.Substring(3).ToUpper()),
                isDomain = _domainRecTypes.Contains(entityType.Name.Substring(3).ToUpper()),
                entityPropInfoList = new List<EntityPropInfo>(),
            };

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

                    var entityPropInfo = new EntityPropInfo
                    {
                        fieldConverter = converter,
                        propertyInfo = x,
                        start = customPosInFileAttribute.Start,
                        size = customPosInFileAttribute.Size,
                    };
                    entityInfo.entityPropInfoList.Add(entityPropInfo);
                }
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
            entityInfoEntryFromRecCode = new Dictionary<string, EntityInfoEntry>();
            var dbContextType = typeof(IpiUpdatesDbContext);
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
                    else if(entityType.Name == "UpdTrans")
                    {
                        var initEntityInfoEntry = InitEntityInfoEntry(x);
                        entityInfoList.Add(initEntityInfoEntry);
                        entityInfoEntryFromRecCode.Add(entityType.Name, initEntityInfoEntry);
                    }
                });
        }

        public static EntityInfoEntry GetEntityInfoEntry(string recCode)
        {
            Init();
            var key = _transRecTypes.Contains(recCode) ? "UpdTrans" : recCode;
            if(entityInfoEntryFromRecCode.ContainsKey(key))
            {
                return entityInfoEntryFromRecCode[key];
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
