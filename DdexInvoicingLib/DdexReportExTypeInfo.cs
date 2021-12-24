using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public partial class DdexReport
    {
        public delegate ReportingPeriodInfo GetReportingPeriodInfo(string fullFileName);
        public delegate void InsertHead(SqlCommand cmd, int ddexReportId, string fullFileName);

        public enum ReportTypeEnum
        {
            YOUTUBE_ADSUPPORT_MUSIC,
            YOUTUBE_SUBSCRIPTION_MUSIC,
            YOUTUBE_SUBSCRIPTION_PREMIUM,
            YOUTUBE_SRMF,
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

        public enum FileTypeEnum
        {
            UNKNOWN = 0,
            DSR = 1,
            SRMF = 2,
        }

        public class FileNameParts
        {
            private string[] RawParts { get; set; }

            public string FileFormat    { get => FileType == FileTypeEnum.UNKNOWN ? "" : FileType == FileTypeEnum.DSR ? RawParts[0] : RawParts[RawParts.Length - 1]; }
            public string To            { get => FileType == FileTypeEnum.UNKNOWN ? "" : FileType == FileTypeEnum.DSR ? RawParts[1] : $"{RawParts[2]}-{RawParts[3]}"; }
            public string From          { get => FileType == FileTypeEnum.UNKNOWN ? "" : FileType == FileTypeEnum.DSR ? RawParts[2] : RawParts[1]; }
            public string ReportType    { get => FileType == FileTypeEnum.UNKNOWN ? "" : FileType == FileTypeEnum.DSR ? RawParts[3] : RawParts[RawParts.Length - 1]; }
            public string Period        { get => FileType == FileTypeEnum.UNKNOWN ? "" : FileType == FileTypeEnum.DSR ? RawParts[4] : RawParts[5]; }
            public string Region        { get => FileType == FileTypeEnum.UNKNOWN ? "" : FileType == FileTypeEnum.DSR ? RawParts[5] : RawParts[4]; }
            public string SeqN          { get => FileType == FileTypeEnum.UNKNOWN ? "" : FileType == FileTypeEnum.DSR ? RawParts[6] : ""; }
            public string Timestamp     { get => FileType == FileTypeEnum.UNKNOWN ? "" : FileType == FileTypeEnum.DSR ? RawParts[7] : RawParts[6]; }

            public int Year
            {
                get => 
                    FileType == FileTypeEnum.UNKNOWN ?  0 : 
                    FileType == FileTypeEnum.DSR     ?  int.Parse(Period.Split('-')[0]) : 
                                                        int.Parse(Period.Substring(0, 4));
            }

            public int Quarter
            {
                get {
                    if(FileType == FileTypeEnum.UNKNOWN)
                    {
                        return 0;
                    }
                    else if (FileType == FileTypeEnum.SRMF)
                    {
                        return (int.Parse(Period.Substring(4, 2)) + 2) / 3;
                    }
                    var dateParts = Period.Split('-');
                    if(dateParts[0].Equals("Q", StringComparison.OrdinalIgnoreCase))
                    {
                        return int.Parse(dateParts[1]);
                    }
                    return (int.Parse(dateParts[1]) + 2) / 3;
                }
            }

            public int Month
            {
                get
                {
                    if (FileType == FileTypeEnum.UNKNOWN)
                    {
                        return 0;
                    }
                    else if (FileType == FileTypeEnum.SRMF)
                    {
                        return int.Parse(Period.Substring(4, 2));
                    }
                    var dateParts = Period.Split('-');
                    if (dateParts[0].Equals("Q", StringComparison.OrdinalIgnoreCase))
                    {
                        return 3 * int.Parse(dateParts[1]) - 2;
                    }
                    return int.Parse(dateParts[1]);
                }
            }
            public FileTypeEnum FileType { get; private set; }

            public FileNameParts(string fileName)
            {
                RawParts = fileName.Split('_');
                if(RawParts[0].Equals("DSR", StringComparison.OrdinalIgnoreCase))
                {
                    FileType = FileTypeEnum.DSR;
                }
                else if (RawParts[0].Equals("Report", StringComparison.OrdinalIgnoreCase) &&
                    RawParts[1].Equals("YouTube", StringComparison.OrdinalIgnoreCase) &&
                    RawParts[RawParts.Length - 1].Equals("srmf", StringComparison.OrdinalIgnoreCase))
                {
                    FileType = FileTypeEnum.SRMF;
                }
                else
                {
                    FileType = FileTypeEnum.UNKNOWN;
                }
            }
        }

        public class AgreementParam
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Definition { get; set; }
            public string DdexReportColumn { get; set; }
        }

        public class ReportTypeInfo
        {
            public ReportTypeEnum ReportType { get; set; }
            public string Name { get; set; } // Like used in agreement params
            public bool IsMonthly { get; set; }
            public string FileNameWildcard { get; set; }
            public DigitalServiceProviderEnum DigitalServiceProvider { get; set; }
            public bool NeedsExchRate { get; set; }
            public bool FileMayHaveErrors { get; set; }
            public HashSet<AgreementParamEnum> RequiredParams { get; set; }

            public GetReportingPeriodInfo GetReportingPeriodInfo;
            public InsertHead InsertHead;
        }

        public class ReportingPeriodInfo
        {
            public int Year { get; set; }
            public int? Quarter { get; set; }
            public int? Month { get; set; }
        }

        public static List<ReportTypeInfo> ReportTypes = new List<ReportTypeInfo>()
        {
            new ReportTypeInfo
            {
                ReportType = ReportTypeEnum.YOUTUBE_ADSUPPORT_MUSIC,
                Name = "adsupport-music",
                IsMonthly = false,
                FileNameWildcard = "DSR_UACRR-CS_YouTube_Usage-AdSupport-Music-All_*_UA_1of1_*.tsv",
                DigitalServiceProvider = DigitalServiceProviderEnum.YOUTUBE,
                NeedsExchRate = false,
                FileMayHaveErrors = true,
                RequiredParams = new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.GERATE,
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.MUSICPSM,
                    AgreementParamEnum.GEPSM,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                },
                GetReportingPeriodInfo = GetYouTubeDsrReportingPeriodInfo,
                InsertHead = InsertDsrHead,
            },
            new ReportTypeInfo
            {
                ReportType = ReportTypeEnum.YOUTUBE_SUBSCRIPTION_MUSIC,
                Name = "subscription-music",
                IsMonthly = false,
                FileNameWildcard = "DSR_UACRR-CS_YouTube_Usage-SubscriptionMusic-Music-All_*_UA_1of1_*.tsv",
                DigitalServiceProvider = DigitalServiceProviderEnum.YOUTUBE,
                NeedsExchRate = true,
                FileMayHaveErrors = true,
                RequiredParams = new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.GERATE,
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.MUSICPSM,
                    AgreementParamEnum.GEPSM,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                },
                GetReportingPeriodInfo = GetYouTubeDsrReportingPeriodInfo,
                InsertHead = InsertDsrHead,
            },
            new ReportTypeInfo
            {
                ReportType = ReportTypeEnum.YOUTUBE_SUBSCRIPTION_PREMIUM,
                Name = "subscription-premium",
                IsMonthly = false,
                FileNameWildcard = "DSR_UACRR-CS_YouTube_Usage-SubscriptionPremium-Music-All_*_UA_1of1_*.tsv",
                DigitalServiceProvider = DigitalServiceProviderEnum.YOUTUBE,
                NeedsExchRate = true,
                FileMayHaveErrors = true,
                RequiredParams = new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.GERATE,
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.MUSICPSM,
                    AgreementParamEnum.GEPSM,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                },
                GetReportingPeriodInfo = GetYouTubeDsrReportingPeriodInfo,
                InsertHead = InsertDsrHead,
            },
            new ReportTypeInfo
            {
                ReportType = ReportTypeEnum.YOUTUBE_SRMF,
                Name = "srmf",
                IsMonthly = true,
                FileNameWildcard = "Report_YouTube_uacrr_cs_UA_*_*_srmf.csv",
                DigitalServiceProvider = DigitalServiceProviderEnum.YOUTUBE,
                NeedsExchRate = false,
                FileMayHaveErrors = false,
                RequiredParams = new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                },
                GetReportingPeriodInfo = GetYouTubeSrmfReportingPeriodInfo,
                InsertHead = InsertSrmfHead,
            },
            new ReportTypeInfo
            {
                ReportType = ReportTypeEnum.SPOTIFY_FREE,
                Name = "spotify-free",
                IsMonthly = true,
                FileNameWildcard = "DSR_uacrr_Spotify_free_*_UA_1of1_*.tsv",
                DigitalServiceProvider = DigitalServiceProviderEnum.SPOTIFY,
                NeedsExchRate = false,
                FileMayHaveErrors = false,
                RequiredParams = new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.GERATE,
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.MUSICPSM,
                    AgreementParamEnum.GEPSM,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                },
                GetReportingPeriodInfo = GetSpotifyDsrReportingPeriodInfo,
                InsertHead = InsertDsrHead,
            },
            new ReportTypeInfo
            {
                ReportType = ReportTypeEnum.SPOTIFY_FREE_PREMIUM,
                Name = "spotify-free-premium",
                IsMonthly = true,
                FileNameWildcard = "DSR_uacrr_Spotify_free-premium_*_UA_1of1_*.tsv",
                DigitalServiceProvider = DigitalServiceProviderEnum.SPOTIFY,
                NeedsExchRate = false,
                FileMayHaveErrors = false,
                RequiredParams = new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.GERATE,
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.MUSICPSM,
                    AgreementParamEnum.GEPSM,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                },
                GetReportingPeriodInfo = GetSpotifyDsrReportingPeriodInfo,
                InsertHead = InsertDsrHead,
            },
            new ReportTypeInfo
            {
                ReportType = ReportTypeEnum.SPOTIFY_PREMIUM,
                Name = "spotify-premium",
                IsMonthly = true,
                FileNameWildcard = "DSR_uacrr_Spotify_premium_*_UA_1of1_*.tsv",
                DigitalServiceProvider = DigitalServiceProviderEnum.SPOTIFY,
                NeedsExchRate = false,
                FileMayHaveErrors = false,
                RequiredParams = new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.GERATE,
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.MUSICPSM,
                    AgreementParamEnum.GEPSM,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                },
                GetReportingPeriodInfo = GetSpotifyDsrReportingPeriodInfo,
                InsertHead = InsertDsrHead,
            },
            new ReportTypeInfo
            {
                ReportType = ReportTypeEnum.SPOTIFY_FAMILYPLAN6,
                Name = "spotify-familyplan6",
                IsMonthly = true,
                FileNameWildcard = "DSR_uacrr_Spotify_familyplan6_*_UA_1of1_*.tsv",
                DigitalServiceProvider = DigitalServiceProviderEnum.SPOTIFY,
                NeedsExchRate = false,
                FileMayHaveErrors = false,
                RequiredParams = new HashSet<AgreementParamEnum>
                {
                    AgreementParamEnum.MUSICRATE,
                    AgreementParamEnum.GERATE,
                    AgreementParamEnum.MECHSPLIT,
                    AgreementParamEnum.PERFSPLIT,
                    AgreementParamEnum.MUSICPSM,
                    AgreementParamEnum.GEPSM,
                    AgreementParamEnum.REPORTTYPE,
                    AgreementParamEnum.ROYALTYTHRESHOLD,
                },
                GetReportingPeriodInfo = GetSpotifyDsrReportingPeriodInfo,
                InsertHead = InsertDsrHead,
            },
        };

        public static Dictionary<string, ReportTypeEnum> AgreementReportTypes = new Dictionary<string, ReportTypeEnum>()
        {
            { "adsupport-music",        ReportTypeEnum.YOUTUBE_ADSUPPORT_MUSIC},
            { "subscription-music",     ReportTypeEnum.YOUTUBE_SUBSCRIPTION_MUSIC},
            { "subscription-premium",   ReportTypeEnum.YOUTUBE_SUBSCRIPTION_PREMIUM},
            { "srmf",                   ReportTypeEnum.YOUTUBE_SRMF},
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
                        { "usage-adsupport-music-all",             ReportTypeEnum.YOUTUBE_ADSUPPORT_MUSIC},
                        { "usage-subscriptionmusic-music-all",     ReportTypeEnum.YOUTUBE_SUBSCRIPTION_MUSIC},
                        { "usage-subscriptionpremium-music-all",   ReportTypeEnum.YOUTUBE_SUBSCRIPTION_PREMIUM},
                        { "srmf",                                  ReportTypeEnum.YOUTUBE_SRMF},
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

        #region METHODS

        private static ReportTypeInfo GetReportTypeInfo(string agreementReportType)
        {
            return ReportTypes.Single(x => x.Name == agreementReportType.ToLower());
        }

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

        public static string GetFileNameWildcard(string agreementReportType)
        {
            return GetReportTypeInfo(agreementReportType).FileNameWildcard;
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
            var agreementReportType = (string)cmd.ExecuteScalar();

            return GetReportTypeInfo(agreementReportType).IsMonthly;
        }

        public static bool IsYouTubeAdSupportType(string agreementReportType)
        {
           return AgreementReportTypes.ContainsKey(agreementReportType.ToLower()) &&
                AgreementReportTypes[agreementReportType.ToLower()] == ReportTypeEnum.YOUTUBE_ADSUPPORT_MUSIC;
        }

        public static bool IsYouTubeSrmfType(string agreementReportType)
        {
            return AgreementReportTypes.ContainsKey(agreementReportType.ToLower()) &&
                 AgreementReportTypes[agreementReportType.ToLower()] == ReportTypeEnum.YOUTUBE_SRMF;
        }

        public static DigitalServiceProviderEnum GetDigitalServiceProvider(string agreementReportType)
        {
            return GetReportTypeInfo(agreementReportType).DigitalServiceProvider;
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
            if (fileNameParts.FileType.Equals(FileTypeEnum.UNKNOWN))
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
            var requiredParams =  ReportTypes.Single(x => x.ReportType == reportTypeEnum).RequiredParams;
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

        public static string GetAgreementParametersText(int licId, int custId, string fullFileName)
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
            var requiredParams = ReportTypes.Single(x => x.ReportType == reportTypeEnum).RequiredParams;
            foreach (var x in requiredParams.Where(y => y != AgreementParamEnum.REPORTTYPE))
            {
                var paramValue = parameters[x];
                var agreementParam = AgreementParams[x];
                var text = $"{agreementParam.Description}: {paramValue}";
                if (!string.IsNullOrEmpty(retVal))
                    retVal += Environment.NewLine;
                retVal += text;
            };

            var exchRate = GetExchangeRate(licId, custId, agreementReportType, fullFileName);
            if(exchRate != null)
            {
                retVal += Environment.NewLine + $"Курс обміну: {exchRate}";
            }
            return retVal;
        }

        public static string GetAgreementParametersSqlInsertCols(string agreementReportType)
        {
            var retVal = "";
            var reportTypeEnum = AgreementReportTypes[agreementReportType];
            var requiredParams = ReportTypes.Single(x => x.ReportType == reportTypeEnum).RequiredParams;
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
            var requiredParams = ReportTypes.Single(x => x.ReportType == reportTypeEnum).RequiredParams;
            foreach (var x in requiredParams.Where(y => y != AgreementParamEnum.REPORTTYPE))
            {
                var agreementParam = AgreementParams[x];
                retVal += $"\r\n, (select cast(paramValue as {agreementParam.Definition}) from AgreementParam where paramId = {(int)x} and licId = @licId and custId = @custId)";
            };
            return retVal;
        }

        public static ReportingPeriodInfo GetYouTubeDsrReportingPeriodInfo(string fullFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(fullFileName);
            var periodPart = fileName.Split('_')[4];
            var dateParts = periodPart.Split('-');
            return new ReportingPeriodInfo
            {
                Year = int.Parse(dateParts[0]),
                Quarter = int.Parse(dateParts[1].Substring(1)),
                Month = null,
            };
        }

        public static ReportingPeriodInfo GetYouTubeSrmfReportingPeriodInfo(string fullFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(fullFileName);
            var periodPart = fileName.Split('_')[5];
            return new ReportingPeriodInfo
            {
                Year = int.Parse(periodPart.Substring(0,4)),
                Quarter = null,
                Month = int.Parse(periodPart.Substring(4)),
            };
        }

        public static ReportingPeriodInfo GetSpotifyDsrReportingPeriodInfo(string fullFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(fullFileName);
            var periodPart = fileName.Split('_')[4];
            var dateParts = periodPart.Split('-');
            return new ReportingPeriodInfo
            {
                Year = int.Parse(dateParts[0]),
                Quarter = null,
                Month = int.Parse(dateParts[2]),
            };
        }

        public static int CreateReportingPeriod(string agreementReportType, string fullFileName)
        {
            var rpi = GetReportTypeInfo(agreementReportType).GetReportingPeriodInfo(fullFileName);
            var quarterOrMonth = rpi.Quarter == null ? "month" : "quarter";
            int ddexReportingPeriodId = 0;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    if not exists (select null from DdexReportingPeriod where year = @year and {quarterOrMonth} = @{quarterOrMonth})
                    begin
                        insert into DdexReportingPeriod (status, substatus, [year], [{quarterOrMonth}]) values (0, 0, @year, @{quarterOrMonth})
                    end
                    select Id from DdexReportingPeriod where year = @year and {quarterOrMonth} = @{quarterOrMonth}
                    ";
                cmd.Parameters.AddWithValue("@year", rpi.Year);
                cmd.Parameters.AddWithValue($"@{quarterOrMonth}", rpi.Quarter == null ? rpi.Month : rpi.Quarter);
                ddexReportingPeriodId = (int)cmd.ExecuteScalar();
            }, true);
            return ddexReportingPeriodId;
        }

        public static bool CheckReportExists(string agreementReportType, int ddexReportingPeriodId)
        {
            var retVal = 0;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"if not exists (select null from DdexReport where DdexReportingPeriodId = @DdexReportingPeriodId and filetype = @agreementReportType)
                            select 0
                            else
                            select 1";
                cmd.Parameters.AddWithValue("@ddexReportingPeriodId", ddexReportingPeriodId);
                cmd.Parameters.AddWithValue("@agreementReportType", agreementReportType);
                retVal = (int)cmd.ExecuteScalar();
            }, true);
            return retVal == 1;
        }

        public static float? GetExchangeRate(int licId, int custId, string agreementReportType, string fullFileName)
        {
            if (!GetReportTypeInfo(agreementReportType).NeedsExchRate)
            {
                return null;
            }
            var rpi = GetReportTypeInfo(agreementReportType).GetReportingPeriodInfo(fullFileName);
            float res = 0;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                        if not exists (
                            select null
                            from CcidExchangeRate
                            where licId = @licId and custId = @custId and year = @year and month = @month
                        )
                            select 0
                        else
                            select exchRate
                            from CcidExchangeRate
                            where licId = @licId and custId = @custId and year = @year and month = @month";
                cmd.Parameters.AddWithValue("@licId", licId);
                cmd.Parameters.AddWithValue("@custId", custId);
                cmd.Parameters.AddWithValue("@year", rpi.Year);
                cmd.Parameters.AddWithValue($"@month", rpi.Quarter == null ? rpi.Month : rpi.Quarter * 3 - 2);
                res = (float)cmd.ExecuteScalar();
            }, true);
            return res == 0 ? null : (float?)res;
        }

        public static bool CheckExchangeRateExists(int licId, int custId, string agreementReportType, string fullFileName)
        {
            return GetExchangeRate(licId, custId, agreementReportType, fullFileName) != null;
        }

        private static void DoInsertHead(SqlCommand cmd, string agreementReportType, int ddexReportId, string fullFileName)
        {
            GetReportTypeInfo(agreementReportType).InsertHead(cmd, ddexReportId, fullFileName);
        }

        public static bool FileMayHaveErrors(int ddexReportId)
        {
            string agreementReportType = "";
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "select FileType from DdexReport where Id = @ddexReportId";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                agreementReportType = (string)cmd.ExecuteScalar();
            });
            return GetReportTypeInfo(agreementReportType).FileMayHaveErrors;
        }

        public static bool IsSrmf(int ddexReportId)
        {
            string agreementReportType = "";
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "select FileType from DdexReport where Id = @ddexReportId";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                agreementReportType = (string)cmd.ExecuteScalar();
            });
            return GetReportTypeInfo(agreementReportType).Name == "srmf";
        }

        #endregion
    }
}
