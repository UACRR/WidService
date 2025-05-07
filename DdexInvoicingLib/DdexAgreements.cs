using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class DdexAgreements
    {
        public static List<DdexAgreement> Agreements { get; set; }

        public static void Load()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {

                Agreements = new List<DdexAgreement>();

                cmd.CommandText = $@"
                    select licId
                        , custId
                        , Name licenseeName
                        , licCodeName licenseDescription
                    from vMSCustomerUses
                    order by custId
/*                    union
                    select 1001 licId
                        , 10000 custId
                        , 'Deezer' licenseeName
                        , 'Ліцензійний договір (всі сервіси)' licenseDescription

                    union
                    select 1340 licId
                        , 39556 custId
                        , 'ТОВ ""Гугл ЛТД""' licenseeName
                        , 'Ліцензійний договір онлайн-сервіси (pre-claim)' licenseDescription
                    union
                    select 1001 licId
                        , 10000 custId
                        , 'Spotify' licenseeName
                        , 'Free' licenseDescription
                    union
                    select 1003 licId
                        , 10000 custId
                        , 'Spotify' licenseeName
                        , 'Premium' licenseDescription
*/
                    -- order by t4.[year] desc,  t4.[quarter] desc
                ";

                using (var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        Agreements.Add(new DdexAgreement
                        {
                            LicId               = r.GetInt32(0),
                            CustId              = r.GetInt32(1),
                            LicenseeName        = r.GetString(2),
                            LicenseDescription  = r.GetString(3),
                        });
                    }
                }

                cmd.CommandText = $@"
                    select 
                          licId
                        , custId
                        , paramId
                        , paramValue
                    from AgreementParam
                ";

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var licId = r.GetInt32(0);
                        var CustId = r.GetInt32(1);
                        var agreement = Agreements.Single(x => x.LicId == r.GetInt32(0) && x.CustId == r.GetInt32(1));
                        var paramId = r.GetInt32(2);
                        if(r.IsDBNull(3))
                        {
                            continue;
                        }
                        var paramValue = r.GetString(3);
                        if(string.IsNullOrEmpty(paramValue))
                        {
                            continue;
                        }
                        switch (paramId)
                        {
                            case (int)DdexReport.AgreementParamEnum.MUSICRATE:
                                agreement.MusicRate = Formatter.ToDecimal(paramValue);
                                break;
                            case (int)DdexReport.AgreementParamEnum.GERATE:
                                agreement.GeRate = Formatter.ToDecimal(paramValue);
                                break;
                            case (int)DdexReport.AgreementParamEnum.MECHSPLIT:
                                agreement.MechSplit = Formatter.ToDecimal(paramValue);
                                break;
                            case (int)DdexReport.AgreementParamEnum.PERFSPLIT:
                                agreement.PerfSplit = Formatter.ToDecimal(paramValue);
                                break;
                            case (int)DdexReport.AgreementParamEnum.MUSICPSM:
                                agreement.MusicPSM = Formatter.ToDecimal(paramValue);
                                break;
                            case (int)DdexReport.AgreementParamEnum.GEPSM:
                                agreement.GePSM = Formatter.ToDecimal(paramValue);
                                break;
                            case (int)DdexReport.AgreementParamEnum.REPORTCURRENCY:
                                agreement.ReportCurrency = paramValue;
                                break;
                            case (int)DdexReport.AgreementParamEnum.REPORTTYPE:
                                agreement.ReportType = paramValue;
                                break;
                            case (int)DdexReport.AgreementParamEnum.ROYALTYTHRESHOLD:
                                agreement.RoyaltyThreshold = Formatter.ToDecimal(paramValue);
                                break;
                            default:
                                throw new Exception($"Невідомий параметр договору з кодом {paramId}");
                       }
                    }
                }

            });
        }
    }
}
