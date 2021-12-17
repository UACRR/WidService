using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public partial class DdexReport
    {
        public enum ReportTypeEnum
        {
            YOUTUBE_ADSUPPORT_MUSIC,
            YOUTUBE_SUBSCRIPTION_MUSIC,
            YOUTUBE_SUBSCRIPTION_PREMIUM,
            SPOTIFY_FREE,
            SPOTIFY_FREE_PREMIUM,
            SPOTIFY_PREMIUM,
            SPOTIFY_FAMILYPLAN6,
        }

        public enum AgreementParamEnum
        {
            MUSICRATE = 1,
            GERATE = 2,
            MECHSPLIT = 3,
            PERFSPLIT = 4,
            MUSICPSM = 5,
            GEPSM = 6,
            REPORTCURRENCY = 7,
            REPORTTYPE = 8,
            ROYALTYTHRESHOLD = 9,
        }

        public enum DigitalServiceProviderEnum
        {
            YOUTUBE,
            SPOTIFY,
        }

        public class FileNameParts
        {
            private string[] RawParts { get; set; }

            public string FileFormat { get => RawParts[0]; }
            public string To { get => RawParts[1]; }
            public string From { get => RawParts[2]; }
            public string ReportType { get => RawParts[3]; }
            public string Period { get => RawParts[4]; }
            public string Region { get => RawParts[5]; }
            public string SeqN { get => RawParts[6]; }
            public string Timestamp { get => RawParts[7]; }

            public FileNameParts(string fileName)
            {
                RawParts = fileName.Split('_');
            }
        }

        public class AgreementParam
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Definition { get; set; }
            public string DdexReportColumn { get; set; }
        }

        public static Dictionary<string, ReportTypeEnum> AgreementReportTypes = new Dictionary<string, ReportTypeEnum>()
        {
            { "adsupport-music",        ReportTypeEnum.YOUTUBE_ADSUPPORT_MUSIC},
            { "subscription-music",     ReportTypeEnum.YOUTUBE_SUBSCRIPTION_MUSIC},
            { "subscription-premium",   ReportTypeEnum.YOUTUBE_SUBSCRIPTION_PREMIUM},
            { "spotify-free",           ReportTypeEnum.SPOTIFY_FREE},
            { "spotify-free-premium",   ReportTypeEnum.SPOTIFY_FREE_PREMIUM},
            { "spotify-premium",        ReportTypeEnum.SPOTIFY_PREMIUM},
            { "spotify-familyplan6",    ReportTypeEnum.SPOTIFY_FAMILYPLAN6},
        };

        public static Dictionary<DigitalServiceProviderEnum, Dictionary<string, ReportTypeEnum>> DspFileReportTypes =
            new Dictionary<DigitalServiceProviderEnum, Dictionary<string, ReportTypeEnum>>()
            {
                {
                    DigitalServiceProviderEnum.YOUTUBE,
                    new Dictionary<string, ReportTypeEnum>()
                    {
                        { "usage-adsupport-music",        ReportTypeEnum.YOUTUBE_ADSUPPORT_MUSIC},
                        { "usage-subscription-music",     ReportTypeEnum.YOUTUBE_SUBSCRIPTION_MUSIC},
                        { "usage-subscription-premium",   ReportTypeEnum.YOUTUBE_SUBSCRIPTION_PREMIUM},
                    }
                },
                {
                    DigitalServiceProviderEnum.SPOTIFY,
                    new Dictionary<string, ReportTypeEnum>()
                    {
                        { "free",           ReportTypeEnum.SPOTIFY_FREE},
                        { "free-premium",   ReportTypeEnum.SPOTIFY_FREE_PREMIUM},
                        { "premium",        ReportTypeEnum.SPOTIFY_PREMIUM},
                        { "familyplan6",    ReportTypeEnum.SPOTIFY_FAMILYPLAN6},
                    }
                },
            };

        public static Dictionary<string, DigitalServiceProviderEnum> AgreementDigitalServiceProviders = new Dictionary<string, DigitalServiceProviderEnum>()
        {
            { "adaupport-music",        DigitalServiceProviderEnum.YOUTUBE},
            { "subscription-music",     DigitalServiceProviderEnum.YOUTUBE},
            { "subscription-premium",   DigitalServiceProviderEnum.YOUTUBE},
            { "spotify-free",           DigitalServiceProviderEnum.SPOTIFY},
            { "spotify-free-premium",   DigitalServiceProviderEnum.SPOTIFY},
            { "spotify-premium",        DigitalServiceProviderEnum.SPOTIFY},
            { "spotify-familyplan6",    DigitalServiceProviderEnum.SPOTIFY},
        };

        public static Dictionary<string, DigitalServiceProviderEnum> FileDsps = new Dictionary<string, DigitalServiceProviderEnum>()
        {
            { "youtube", DigitalServiceProviderEnum.YOUTUBE},
            { "spotify", DigitalServiceProviderEnum.SPOTIFY},
        };

        public static Dictionary<AgreementParamEnum, AgreementParam> AgreementParams =
            new Dictionary<AgreementParamEnum, AgreementParam>
            {
               {
                    AgreementParamEnum.MUSICRATE,
                    new AgreementParam
                    {
                        Name = "MusicRate",
                        Description = "Процент за музичний контент",
                        Definition = "decimal(5,2)",
                        DdexReportColumn = "musicRate",
                    }
                },
               {
                    AgreementParamEnum.GERATE,
                    new AgreementParam
                    {
                        Name = "GeRate",
                        Description = "Процент за розважальний контент",
                        Definition = "decimal(5,2)",
                        DdexReportColumn = "geRate",
                    }
                },
                {
                    AgreementParamEnum.MECHSPLIT,
                    new AgreementParam
                    {
                        Name = "MechSplit",
                        Description = "Процент правовласності за механічне виконання",
                        Definition = "decimal(5,2)",
                        DdexReportColumn = "mechSplit",
                    }
                },
                {
                    AgreementParamEnum.PERFSPLIT,
                    new AgreementParam
                    {
                        Name = "PerfSplit",
                        Description = "Процент правовласності за публічне виконання",
                        Definition = "decimal(5,2)",
                        DdexReportColumn = "perfSplit",
                    }
                },
                {
                    AgreementParamEnum.MUSICPSM,
                    new AgreementParam
                    {
                        Name = "MusicPSM",
                        Description = "Тариф на музичний контент",
                        Definition = "decimal(5,2)",
                        DdexReportColumn = "musicPSM",
                    }
                },
                {
                    AgreementParamEnum.GEPSM,
                    new AgreementParam
                    {
                        Name = "GePSM",
                        Description = "Тариф на розважальний контент",
                        Definition = "decimal(5,2)",
                        DdexReportColumn = "gePSM",
                    }
                },
                {
                    AgreementParamEnum.REPORTCURRENCY,
                    new AgreementParam
                    {
                        Name = "ReportCurrency",
                        Description = "Валюта",
                        Definition = "varchar(3)",
                        DdexReportColumn = null,
                    }
                },
                {
                    AgreementParamEnum.REPORTTYPE,
                    new AgreementParam
                    {
                        Name = "ReportType",
                        Description = "Означення звіту для ідентифікації із назви файлу",
                        Definition = "varchar(100)",
                        DdexReportColumn = null,
                    }
                },
                {
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                    new AgreementParam
                    {
                        Name = "RoyaltyThreshold",
                        Description = "Мінімум роялті що приймається до розгляду",
                        Definition = "decimal(20,6)",
                        DdexReportColumn = "royaltyThreshold",
                    }
                },
            };

        public static Dictionary<ReportTypeEnum, HashSet<AgreementParamEnum>> ReportTypeRequiredParams = new Dictionary<ReportTypeEnum, HashSet<AgreementParamEnum>>()
        {
            {
                ReportTypeEnum.YOUTUBE_ADSUPPORT_MUSIC,
                new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.GERATE,
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                }
            },
            {
                ReportTypeEnum.YOUTUBE_SUBSCRIPTION_MUSIC,
                new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.GERATE,
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.MUSICPSM,
                    AgreementParamEnum.GEPSM,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                }
            },
            {
                ReportTypeEnum.YOUTUBE_SUBSCRIPTION_PREMIUM,
                new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.GERATE,
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.MUSICPSM,
                    AgreementParamEnum.GEPSM,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                }
            },
            {
                ReportTypeEnum.SPOTIFY_FREE,
                new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                }
            },
            {
                ReportTypeEnum.SPOTIFY_FREE_PREMIUM,
                new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                }
            },
            {
                ReportTypeEnum.SPOTIFY_PREMIUM,
                new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                }
            },
            {
                ReportTypeEnum.SPOTIFY_FAMILYPLAN6,
                new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                }
            },
        };

        #region METHODS
        public static string GetAgreementReportType(int licId, int custId)
        {
            object reportType = null;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    select paramValue paramValue
                    from AgreementParam
                    where paramId = 8 and licId = @licId and custId = @custId
                ";
                cmd.Parameters.AddWithValue("@licId", licId);
                cmd.Parameters.AddWithValue("@custId", custId);

                reportType = cmd.ExecuteScalar();
            });

            if (reportType == null)
                return null;
            if (!AgreementReportTypes.ContainsKey((string)reportType))
                return null;
            return (string)reportType;
        }

        public static ReportTypeEnum GetAgreementReportType(SqlCommand cmd, int ddexReportId)
        {
            cmd.CommandText = $@"
                    select FileType
                    from DdexReport
                    where id = @ddexReportId
                ";
            cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
            var reportType = (string)cmd.ExecuteScalar();

            return AgreementReportTypes[reportType];
        }

        public static bool IsMonthlyReport(SqlCommand cmd, int licId, int custId)
        {
            cmd.CommandText = $@"
                    select paramValue paramValue
                    from AgreementParam
                    where paramId = 8 and licId = @licId and custId = @custId
                ";
            cmd.Parameters.AddWithValue("@licId", licId);
            cmd.Parameters.AddWithValue("@custId", custId);
            var reportTypeName = (string)cmd.ExecuteScalar();

            var reportType = AgreementReportTypes[reportTypeName.ToLower()];
            switch(reportType)
            {
                case ReportTypeEnum.SPOTIFY_FREE:
                case ReportTypeEnum.SPOTIFY_FREE_PREMIUM:
                case ReportTypeEnum.SPOTIFY_PREMIUM:
                case ReportTypeEnum.SPOTIFY_FAMILYPLAN6:
                    return true;
            }
            return false;
        }

        public static bool IsYouTubeAdSupportType(string agreementReportType)
        {
           return AgreementReportTypes.ContainsKey(agreementReportType.ToLower()) &&
                AgreementReportTypes[agreementReportType.ToLower()] == ReportTypeEnum.YOUTUBE_ADSUPPORT_MUSIC;
        }

        public static DigitalServiceProviderEnum GetDigitalServiceProvider(string agreementReportType)
        {
            return AgreementDigitalServiceProviders[agreementReportType.ToLower()];
        }

        public static DigitalServiceProviderEnum GetDigitalServiceProvider(int ddexReportId)
        {
            string dspName = null;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "select SenderName from DdexRecordHead where ddexReportId = @ddexReportId";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                dspName = (string)cmd.ExecuteScalar();
            });
            return FileDsps[dspName.ToLower()];
        }

        public static bool FileMeetsAgreement(string agreementReportType, FileNameParts fileNameParts)
        {
            if (!FileDsps.ContainsKey(fileNameParts.From.ToLower()))
                return false;
            var dspFileReportTypes = DspFileReportTypes[FileDsps[fileNameParts.From.ToLower()]];
            if (!dspFileReportTypes.ContainsKey(fileNameParts.ReportType.ToLower()))
                return false;
            return dspFileReportTypes[fileNameParts.ReportType.ToLower()] == AgreementReportTypes[agreementReportType.ToLower()];
        }

        public static string CheckAgreementParameters(int licId, int custId)
        {
            var parameters = new Dictionary<AgreementParamEnum, string>();
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"select paramId, isnull(paramValue, '') from AgreementParam where licId = @licId and custId = @custId";
                cmd.Parameters.AddWithValue("@licId", licId);
                cmd.Parameters.AddWithValue("@custId", custId);

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        parameters.Add((AgreementParamEnum)r.GetInt32(0), r.GetString(1));
                    }
                }
            });

            if (!parameters.ContainsKey(AgreementParamEnum.REPORTTYPE))
                return "Параметри договору не містять типу файлу звіту";

            var agreementReportType = parameters[AgreementParamEnum.REPORTTYPE];
            if(!AgreementReportTypes.ContainsKey(agreementReportType))
                return "Невірний тип файлу звіту в параметрах договору";

            var reportTypeEnum = AgreementReportTypes[agreementReportType];
            var requiredParams =  ReportTypeRequiredParams[reportTypeEnum];
            foreach(var x in requiredParams.Where(y => y != AgreementParamEnum.REPORTTYPE))
            {
                var paramValue = parameters[x];
                var agreementParam = AgreementParams[x];
                if (string.IsNullOrEmpty(paramValue))
                    return $"Невірне значення параметру договору {agreementParam.Name}";
                if (agreementParam.Definition.StartsWith("decimal") && !Formatter.IsValidDecimal(paramValue))
                    return $"Невірне значення параметру договору {agreementParam.Name}, мусить бути нулем або додатнім числом.";
            };
            return null;
        }

        public static string GetAgreementParametersText(int licId, int custId)
        {
            string retVal = "";
            var parameters = new Dictionary<AgreementParamEnum, string>();
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"select paramId, isnull(paramValue, '') from AgreementParam where licId = @licId and custId = @custId";
                cmd.Parameters.AddWithValue("@licId", licId);
                cmd.Parameters.AddWithValue("@custId", custId);

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        parameters.Add((AgreementParamEnum)r.GetInt32(0), r.GetString(1));
                    }
                }
            });

            var agreementReportType = parameters[AgreementParamEnum.REPORTTYPE];
            var reportTypeEnum = AgreementReportTypes[agreementReportType];
            var requiredParams = ReportTypeRequiredParams[reportTypeEnum];
            foreach (var x in requiredParams.Where(y => y != AgreementParamEnum.REPORTTYPE))
            {
                var paramValue = parameters[x];
                var agreementParam = AgreementParams[x];
                var text = $"{agreementParam.Description}: {paramValue}";
                if (!string.IsNullOrEmpty(retVal))
                    retVal += Environment.NewLine;
                retVal += text;
            };
            return retVal;
        }

        public static string GetAgreementParametersSqlInsertCols(string agreementReportType)
        {
            var retVal = "";
            var reportTypeEnum = AgreementReportTypes[agreementReportType];
            var requiredParams = ReportTypeRequiredParams[reportTypeEnum];
            foreach (var x in requiredParams.Where(y => y != AgreementParamEnum.REPORTTYPE))
            {
                var agreementParam = AgreementParams[x];
                retVal += $"\r\n, {agreementParam.DdexReportColumn}";
            };
            return retVal;
        }

        public static string GetAgreementParametersSqlInsertValues(string agreementReportType)
        {
            var retVal = "";
            var reportTypeEnum = AgreementReportTypes[agreementReportType];
            var requiredParams = ReportTypeRequiredParams[reportTypeEnum];
            foreach (var x in requiredParams.Where(y => y != AgreementParamEnum.REPORTTYPE))
            {
                var agreementParam = AgreementParams[x];
                retVal += $"\r\n, (select cast(paramValue as {agreementParam.Definition}) from AgreementParam where paramId = {(int)x} and licId = @licId and custId = @custId)";
            };
            return retVal;
        }
        #endregion
    }
}
