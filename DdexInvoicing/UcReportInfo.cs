using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoicingLib;
using System.Data.SqlClient;

namespace DdexInvoicing
{
    public partial class UcReportInfo : UserControl
    {
        public UcReportInfo()
        {
            InitializeComponent();
        }

        public void Update(DdexReportInfo ddexReportInfo)
        {
            radGridReportStatistics.AutoSizeRows = true;
            for (int i = 0; i < radGridReportStatistics.Columns.Count; i++)
                radGridReportStatistics.Columns[i].WrapText = true;

            radGridNetRevenueDistr.AutoSizeRows = true;
            for (int i = 0; i < radGridNetRevenueDistr.Columns.Count; i++)
                radGridNetRevenueDistr.Columns[i].WrapText = true;

            Helpers.RunSqlOperationDdex(cmd =>
            {
                var dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("Count");
                dt.Columns.Add("NetRevenue");

                cmd.CommandText = $@"
                    select SalesTransCnt, NetRevenue, MwCnt, MwCntUnmatched, NetRevenueUnmatched
                        , MwCntIswcTotal, MwNetRevenueIswcTotal, MwCntIswcMatched, MwNetRevenueIswcMatched
                    from DdexReport
                    where Id = @ddexReportId
                 ";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportInfo.DdexReportId);

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();

                    for (int i = 0; i < r.FieldCount; i++)
                    { 
                        if (r.IsDBNull(i))
                        {
                            return;
                        }
                    }
                    dt.Rows.Add("Продажі", FormatInt(r.GetInt32(0)), FormatMoney(r.GetDecimal(1)));
                    dt.Rows.Add("Твори", FormatInt(r.GetInt32(2)), FormatMoney(r.GetDecimal(1)));
                    dt.Rows.Add("Твори, що потребують обробку в ручну", FormatInt(r.GetInt32(3)), FormatMoney(r.GetDecimal(4)));
                    dt.Rows.Add("Твори що мають код ISWC", FormatInt(r.GetInt32(5)), FormatMoney(r.GetDecimal(6)));
                    dt.Rows.Add("Твори ідентифіковані за кодом ISWC", FormatInt(r.GetInt32(7)), FormatMoney(r.GetDecimal(8)));
                }

                radGridReportStatistics.DataSource = dt;
            });

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    select * 
                    from DdexNetRevenueDistr
                    where ddexReportId = @ddexReportId
                    order by firstRec
                 ";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportInfo.DdexReportId);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                radGridNetRevenueDistr.DataSource = dt;
            });

            var dtGeneralInfo = new DataTable();
            dtGeneralInfo.Columns.Add("Name");
            dtGeneralInfo.Columns.Add("Value");

            dtGeneralInfo.Rows.Add("Системний ідентифікатор", ddexReportInfo.DdexReportId);
            dtGeneralInfo.Rows.Add("Стадія обробки", ddexReportInfo.Status);
            dtGeneralInfo.Rows.Add("Стан завершенності стадії", ddexReportInfo.SubStatus);
            dtGeneralInfo.Rows.Add("Тип вхідного файлу", ddexReportInfo.FileType);
            dtGeneralInfo.Rows.Add("Розташування файлу", ddexReportInfo.FileFolder);
            dtGeneralInfo.Rows.Add("Ім'я файлу", ddexReportInfo.FileName);
            dtGeneralInfo.Rows.Add("Код повідомлення", ddexReportInfo.MessageId);
            dtGeneralInfo.Rows.Add("Час створення повідомлення", ddexReportInfo.MessageCreatedDateTime);
            dtGeneralInfo.Rows.Add("Дата початку періоду звітування", ddexReportInfo.UsageStartDate);
            dtGeneralInfo.Rows.Add("Дата закінчення періоду звітування", ddexReportInfo.UsageEndDate);
            dtGeneralInfo.Rows.Add("Ім'я відправника", ddexReportInfo.SenderName);

            radGridGeneralInfo.DataSource = dtGeneralInfo;

            var dtCalcParams = new DataTable();
            dtCalcParams.Columns.Add("Name");
            dtCalcParams.Columns.Add("Value");

            dtCalcParams.Rows.Add("Процент за музичний контент:", ddexReportInfo.MusicRate);
            dtCalcParams.Rows.Add("Процент за розважальний контент", ddexReportInfo.GeRate);
            dtCalcParams.Rows.Add("Процент правовласності за механічне виконання", ddexReportInfo.MechSplit);
            dtCalcParams.Rows.Add("Процент правовласності за публічне виконання", ddexReportInfo.PerfSplit);
            if(!ddexReportInfo.FileType.Equals("AdSupport-Music", StringComparison.OrdinalIgnoreCase))
            {
                    dtCalcParams.Rows.Add("Тариф на музичний контент", ddexReportInfo.MusicPSM);
                    dtCalcParams.Rows.Add("Тариф на розважальний контент", ddexReportInfo.GePSM);
                    dtCalcParams.Rows.Add("Курс обміну (доларів за гривню)", ddexReportInfo.ExchRate);
            }
            dtCalcParams.Rows.Add("Мінімум роялті що приймається до розгляду (USD)", ddexReportInfo.RoyaltyThreshold);
            radGridCalcParams.DataSource = dtCalcParams;

            //pgDdexReportInfo.SelectedObject = ddexReportInfo;
        }

        private string FormatInt(int value)
        {
            return string.Format("{0:### ### ##0.##}", value);
        }
        private string FormatMoney(decimal value)
        {
            return string.Format("{0:### ### ##0.##}", value);
        }

    }
}
