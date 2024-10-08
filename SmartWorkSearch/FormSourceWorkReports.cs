using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWorkSearch
{
    public partial class FormSourceWorkReports : Form
    {
        private class MsReportRow
    {
        public int RegId { get; set; }
        public int RegIItemId { get; set; }
        public string FileName    { get; set; }
        public DateTime BeginDate   { get; set; }
        public DateTime EndDate     { get; set; }
        public int CountUse    { get; set; }
        public int ObjId       { get; set; }
        public int Wic          { get; set; }
        }
        private class MsCustomer
        {
            public int CustId { get; set; }
            public string ShortName { get; set; }

            public List<MsReportRow> ReportRows { get; set; }
        }

        private class DdexReportRow
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public int Quarter { get; set; }
            public string FileType { get; set; }
            public string SalesTransactionId { get; set; }
            public decimal CountUse { get; set; }
            public int ObjId { get; set; }
            public int Wic { get; set; }
        }
        private class DdexCustomer
        {
            public int CustId { get; set; }
            public string ShortName { get; set; }

            public List<DdexReportRow> ReportRows { get; set; }
        }

        private List<MsCustomer> _msCustomers;
        private List<DdexCustomer> _ddexCustomers;

        private const string _htmlHead = @"
            <head>
                <meta charset='utf-8' />
                <title></title>
                <style>
                    body {
                        font-family: Tahoma;
                        font-size: small;
                        font-weight: normal;
                        margin-top: 10px;
                        margin-bottom: 10px;
                    }        
                    h1 {
                        font-family: Tahoma;
                        font-size: small;
                        font-weight: bold;
                        text-decoration: none;
                        margin-top: 10px;
                        margin-bottom: 10px;
                    }
                    table, th, td {
                        border: 1px solid black;
                        padding: 10px 10px 10px 10px;
                    }
                </style>
            </head>
            ";


        private int _sourceWorkId;
        private string _name;
        private string _authors;
        private string _performers;
        public FormSourceWorkReports(int sourceWorkId, string name, string authors, string performers)
        {
            InitializeComponent();
            _sourceWorkId = sourceWorkId;
            _name = name;
            _authors = authors;
            _performers = performers;
        }

        private void FormSourceWorkReports_Load(object sender, EventArgs e)
        {
            tbName.Text = _name;
            tbAuthors.Text = _authors;
            tbPerformers.Text = _performers;

            wbReportRecords.DocumentText = "Завантаження ...";

            timerLoad.Enabled = true;

        }

        private void ReadData()
        {
            ReadMsData();
            ReadDdexData();
        }

        private void ReadMsData()
        {
            _msCustomers = new List<MsCustomer>();
            Helpers.RunSqlSmartWorkSearch(cmd =>
            {
                cmd.CommandText = $@"
                    select
                          t1.RegId
                        , t1.RegIItemId
                        , t3.CustId
                        , t5.shortName
                        , t3.fileName
                        , t4.beginDate
                        , t4.endDate
                        , t2.countUse
                        , t2.ObjId
                        , t2.Wic
                    from MsReportRows t1
                        join MediaService..RegisterItem t2 on t1.RegId = t2.regId and t1.RegIItemId = t2.regIItemId
                        join MediaService..Register t3 on t2.regId = t3.RegId
                        join Mediaservice..PaidPeriod t4 on t3.periodId = t4.periodId
                        join MediaService..AnketaCompany t5 on t3.custId = t5.custId
                    where t1.SourceWorkId = @SourceWorkId
                    order by t3.custId, t4.beginDate
                ";
                cmd.Parameters.AddWithValue("@SourceWorkId", _sourceWorkId);
                MsCustomer curMsCustomer = null;
                var curCustIdId = 0;
                var seqNr = 0;
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        seqNr++;
                        curCustIdId = r.GetInt32(2);
                        if (curMsCustomer == null || curMsCustomer.CustId != curCustIdId)
                        {
                            curMsCustomer = new MsCustomer
                            {
                                CustId = curCustIdId,
                                ShortName = r.GetString(3),
                                ReportRows = new List<MsReportRow>(),
                            };
                            _msCustomers.Add(curMsCustomer);
                        }
                        var reports = curMsCustomer.ReportRows;
                        reports.Add(new MsReportRow
                        {
                            FileName = r.GetString(4),
                            BeginDate = r.GetDateTime(5),
                            EndDate = r.GetDateTime(6),
                            CountUse = r.GetInt32(7),
                            ObjId = r.IsDBNull(8) ? 0 : r.GetInt32(8),
                            Wic = r.IsDBNull(9) ? 0 : r.GetInt32(9),
                        });
                    }
                }
            });
        }

        private void ReadDdexData()
        {
            _ddexCustomers = new List<DdexCustomer>();
            Helpers.RunSqlSmartWorkSearch(cmd =>
            {
                cmd.CommandText = $@"
                    select
                          t3.CustId
                        , t5.shortName
                        , t4.year
                        , isnull(t4.month, 0) as month
                        , isnull(t4.quarter, 0) as quarter
                        , lower(t3.FileType)
                        , t2.DdexReportId
                        , t2.BlockId
                        , t2.SalesTransactionId
                        , t2.Usages
                        , isnull(t6.ObjId, 0)
                        , isnull(t6.Wic, 0)
                    from DdexReportRows t1
                        join Ddex..IdentBacklog t2 on t1.DdexReportId = t2.DdexReportId 
                            and t1.BlockId = t2.BlockId
                            and t1.SalesTransactionId = t2.SalesTransactionId
                        join Ddex..DdexReport t3 on t2.DdexReportId = t3.Id
                        join Ddex..DdexReportingPeriod t4 on t3.ddexReportingPeriodId = t4.Id
                        join MediaService..AnketaCompany t5 on t3.custId = t5.custId
                        join Ddex..IdentMw t6 on t2.MwId = t6.Id
                    where t1.SourceWorkId = @SourceWorkId
                    order by t3.CustId, t4.year, t4.month, t4.quarter, t3.FileType
                ";
                cmd.Parameters.AddWithValue("@SourceWorkId", _sourceWorkId);
                DdexCustomer curDdexCustomer = null;
                var curCustIdId = 0;
                var seqNr = 0;
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        seqNr++;
                        curCustIdId = r.GetInt32(2);
                        if (curDdexCustomer == null || curDdexCustomer.CustId != curCustIdId)
                        {
                            curDdexCustomer = new DdexCustomer
                            {
                                CustId = curCustIdId,
                                ShortName = r.GetString(1),
                                ReportRows = new List<DdexReportRow>(),
                            };
                            _ddexCustomers.Add(curDdexCustomer);
                        }
                        var reports = curDdexCustomer.ReportRows;
                        reports.Add(new DdexReportRow
                        {
                            Year = r.GetInt32(2),
                            Month = r.GetInt32(3),
                            Quarter = r.GetInt32(4),
                            FileType = r.GetString(5),
                            SalesTransactionId = r.GetString(8),
                            CountUse = r.GetDecimal(9),
                            ObjId = r.GetInt32(10),
                            Wic = r.GetInt32(11),
                        });
                    }
                }
            });
        }

        private string FormatHtml()
        {
            var html = $@"
                <!DOCTYPE html>
                <html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
                {_htmlHead}
                <body>
                {GetBodyHtml()}
                </body>
                </html>
            ";

            return html;
        }

        public string GetHtml()
        {
           return FormatHtml();
        }

        private string GetBodyHtml()
        {
            var retVal = "";
            _msCustomers.ForEach(x=>
            {
                retVal += $@"
                    <h1>{x.ShortName}</h1>
                    <table>
                        <thead>
                            <th>Файл Звіту</th>
                            <th>Початок періоду</th>
                            <th>Кінець періоду</th>
                            <th>Кількість використань</th>
                            <th>Код твору у MS</th>
                            <th>Код знайденого твору у WID</th>
                        </thead>
                    <tbody>
                        {GetReportsHtml(x.ReportRows)}
                    </tbody>
                    </table>
                ";
            });

            _ddexCustomers.ForEach(x =>
            {
                retVal += $@"
                    <h1>{x.ShortName}</h1>
                    <table>
                        <thead>
                            <th>Рік</th>
                            <th>Місяць</th>
                            <th>Квартал</th>
                            <th>Тип файлу</th>
                            <th>Кількість використань</th>
                            <th>Код твору у MS</th>
                            <th>Код знайденого твору у WID</th>
                        </thead>
                    <tbody>
                        {GetReportsHtml(x.ReportRows)}
                    </tbody>
                    </table>
                ";
            });
            return retVal;
        }

        private string GetReportsHtml(List<MsReportRow> reportRows)
        {
            var retVal = "";
            reportRows.ForEach(x =>
            {
                var objIdTxt = x.ObjId == 0 ? "-" : x.ObjId.ToString();
                var wicTxt = x.Wic == 0 ? "-" : x.Wic.ToString();
                retVal += $@"
                    <tr>
                        <td>{x.FileName}</td>
                        <td>{x.BeginDate.ToString("yyyy-MM-dd")}</td>
                        <td>{x.EndDate.ToString("yyyy-MM-dd")}</td>
                        <td>{x.CountUse}</td>
                        <td>{objIdTxt}</td>
                        <td>{wicTxt}</td>
                    </tr>
                ";
            });
            return retVal;
        }

        private string GetReportsHtml(List<DdexReportRow> reportRows)
        {
            var retVal = "";
            reportRows.ForEach(x =>
            {
                var objIdTxt = x.ObjId == 0 ? "-" : x.ObjId.ToString();
                var wicTxt = x.Wic == 0 ? "-" : x.Wic.ToString();
                retVal += $@"
                    <tr>
                        <td>{x.Year}</td>
                        <td>{x.Month}</td>
                        <td>{x.Quarter}</td>
                        <td>{x.FileType}</td>
                        <td>{x.CountUse}</td>
                        <td>{objIdTxt}</td>
                        <td>{wicTxt}</td>
                    </tr>
                ";
            });
            return retVal;
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            timerLoad.Enabled = false;
            ReadData();
            wbReportRecords.DocumentText = GetHtml();

        }
    }
}
