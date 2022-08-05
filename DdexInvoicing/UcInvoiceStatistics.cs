using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using InvoicingLib;

namespace DdexInvoicing
{
    public partial class UcInvoiceStatistics : UserControl
    {
        public int ccidInFileId;
        public string connectString = @"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = DDEX_37; Server=93.126.99.28\IPSDATA,60675";

        private bool isAdvert;
        private bool hasResp;

        public UcInvoiceStatistics()
        {
            InitializeComponent();
        }

        public void Init(int fileId, int fileType)
        {
            if (fileType == 0)
            {
                ccidInFileId = fileId;
            }
            else
            {
                Helpers.RunSqlOperationDdex(cmd =>
                {
                    cmd.CommandText = @"
                        select t2.fileId
                            from CcidClFile t1
                                join CcidInFile t2 on t1.ccidInvoiceId = t2.ccidInvoiceId and t1.InstanceIndex = t2.InstanceIndex
                            where t1.fileId = @ccidClFileId
                        ";
                    cmd.Parameters.AddWithValue("@ccidClFileId", fileId);
                    ccidInFileId = (int)cmd.ExecuteScalar();
                });
            }
            //wbControl.DocumentText = html;
            //wbControl.D()

            string path = $@"file://{Path.GetDirectoryName(Application.ExecutablePath)}\CcidStat.html";
            wbControl.Url = new Uri(path);

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"
                        select t2.fileId
                            from CcidInFile t1
                                join CcidClFile t2 on t1.ccidInvoiceId = t2.ccidInvoiceId and t1.InstanceIndex = t2.InstanceIndex
                            where t1.fileId = @ccidInFileId
                        ";
                cmd.Parameters.AddWithValue("@ccidInFileId", ccidInFileId);
                hasResp = cmd.ExecuteScalar() != null;

                cmd.CommandText = @"
                        select top 1 fileId
                            from DdexAdjustment
                            where fileId = @ccidInFileId
                        ";
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    isAdvert = r.HasRows;
                }
            });
        }

        private void CalcPerSales()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                var table = wbControl.Document.Body.GetElementsByTagName("table")[0];
                var rows = table.GetElementsByTagName("tr");
                var cells = rows[2].GetElementsByTagName("td");
                cmd.CommandText = @"
                    select 
                            count(*)
                        , cast(sum(amount_invoiced_total) as decimal(20, 6))

                        , sum(case when amount_invoiced_total > 0 then 1 else 0 end) 
                        , cast(sum(case when amount_invoiced_total > 0 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            
                        , sum(case when amount_invoiced_total = 0 and claim_licensor_combined > 0 then 1 else 0 end) 
                        , cast(sum(case when amount_invoiced_total = 0 and claim_licensor_combined > 0 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            
                        , sum(case when amount_invoiced_total = 0 and claim_licensor_combined = 0 then 1 else 0 end)
                        , cast(sum(case when amount_invoiced_total = 0 and claim_licensor_combined = 0 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            
                        , 0
                        , cast(0 as decimal(20, 6))
                    from ccidInDetail
                    where fileId = @ccidInFileId                   
                    ";
                cmd.Parameters.AddWithValue("@ccidInFileId", ccidInFileId);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();
                    for (int i = 1; i < 11; i++)
                    {
                        cells[i].InnerText = r.GetValue(i - 1).ToString();
                    }
                }

                if (hasResp)
                {
                    if (isAdvert)
                    {
                        cells = rows[3].GetElementsByTagName("td");
                        cmd.CommandText = @"
                            select 
                                  count(*)
                                , sum(t1.allocatedNetRevenue)

                                , sum(case when t1.allocatedNetRevenue > 0 then 1 else 0 end)
                                , sum(case when t1.allocatedNetRevenue > 0 then t1.allocatedNetRevenue else 0 end)

                                , ''
                                , ''

                                , ''
                                , ''

                                , sum(case when t2.fileId is null then 1 else 0 end)
                                , sum(case when t2.fileId is null then t1.allocatedNetRevenue else 0 end)

                            from DdexAdjustment t1
                               left join CcidInDetail t2 on t1.salesTransactionId = t2.sales_transaction_id
                            where t1.fileId = @ccidInFileId
                        ";
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            r.Read();
                            int i;
                            for (i = 1; i < 5; i++)
                            {
                                cells[i].InnerText = r.GetValue(i - 1).ToString();
                            }
                            cells[5].InnerText = "Відсутня інформація";
                            for (i = 9; i < 11; i++)
                            {
                                cells[i - 3].InnerText = r.GetValue(i - 1).ToString();
                            }
                        }
                    }

                    cells = rows[4].GetElementsByTagName("td");
                    cmd.CommandText = @"
                        declare @ccidClFileId int = (
                            select t2.fileId
                            from CcidInFile t1
                                join CcidClFile t2 on t1.ccidInvoiceId = t2.ccidInvoiceId and t1.InstanceIndex = t2.InstanceIndex
                            where t1.fileId = @ccidInFileId
                        );

                        select 
                            count(*)
                            , cast(sum(amount_invoiced_total) as decimal(20, 6))

                            , sum(case when amount_invoiced_total > 0 then 1 else 0 end) 
                            , cast(sum(case when amount_invoiced_total > 0 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            
                            , sum(case when amount_invoiced_total = 0 and claim_licensor_combined > 0 then 1 else 0 end) 
                            , cast(sum(case when amount_invoiced_total = 0 and claim_licensor_combined > 0 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            
                            , sum(case when amount_invoiced_total = 0 and claim_licensor_combined = 0 then 1 else 0 end)
                            , cast(sum(case when amount_invoiced_total = 0 and claim_licensor_combined = 0 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            
                            , 0
                            , cast(0 as decimal(20, 6))
                        from ccidClDetail
                        where fileId = @ccidClFileId
                        ";
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        r.Read();
                        for (int i = 1; i < 11; i++)
                        {
                            cells[i].InnerText = r.GetValue(i - 1).ToString();
                        }
                    }
                }
            });
        }

        private void CalcPerMusicWorks()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                var table = wbControl.Document.Body.GetElementsByTagName("table")[1];
                var rows = table.GetElementsByTagName("tr");
                var cells = rows[2].GetElementsByTagName("td");
                cmd.CommandText = @"
                        with tbl as (
                             select 
                                   workcode
                                 , count(*) cnt
                                 , sum(amount_invoiced_total) amount_invoiced_total
                                 , sum(claim_licensor_combined) claim_licensor_combined
                             from ccidInDetail
                             where fileId = @ccidInFileId
                             group by workcode
                        )
                         select 
                              count(*)
                            , cast(sum(amount_invoiced_total) as decimal(20, 6))

                            , sum(case when amount_invoiced_total > 0 then 1 else 0 end) 
                            , cast(sum(case when amount_invoiced_total > 0 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            
                            , sum(case when amount_invoiced_total = 0 and claim_licensor_combined > 0 then 1 else 0 end) 
                            , cast(sum(case when amount_invoiced_total = 0 and claim_licensor_combined > 0 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            
                            , sum(case when amount_invoiced_total = 0 and claim_licensor_combined = 0 then 1 else 0 end)
                            , cast(sum(case when amount_invoiced_total = 0 and claim_licensor_combined = 0 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            
                            , 0
                            , cast(0 as decimal(20, 6))
                        from tbl
                    ";
                cmd.Parameters.AddWithValue("@ccidInFileId", ccidInFileId);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();
                    for (int i = 1; i < 11; i++)
                    {
                        cells[i].InnerText = r.GetValue(i - 1).ToString();
                    }
                }

                if (hasResp)
                {
                    cells = rows[3].GetElementsByTagName("td");
                    cells[1].InnerText = "Відсутня інформація";

                    cells = rows[4].GetElementsByTagName("td");
                    cmd.CommandText = @"
                        declare @ccidClFileId int = (
                          select t2.fileId
                          from CcidInFile t1
                            join CcidClFile t2 on t1.ccidInvoiceId = t2.ccidInvoiceId and t1.InstanceIndex = t2.InstanceIndex
                          where t1.fileId = @ccidInFileId
                        );
                        with tbl as (
                             select 
                                   workcode
                                 , count(*) cnt
                                 , sum(amount_invoiced_total) amount_invoiced_total
                                 , sum(claim_licensor_combined) claim_licensor_combined
                             from ccidClDetail
                             where fileId = @ccidClFileId
                             group by workcode
                        )
                         select 
                              count(*)
                            , cast(sum(amount_invoiced_total) as decimal(20, 6))

                            , sum(case when amount_invoiced_total > 0 then 1 else 0 end) 
                            , cast(sum(case when amount_invoiced_total > 0 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            
                            , sum(case when amount_invoiced_total = 0 and claim_licensor_combined > 0 then 1 else 0 end) 
                            , cast(sum(case when amount_invoiced_total = 0 and claim_licensor_combined > 0 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            
                            , sum(case when amount_invoiced_total = 0 and claim_licensor_combined = 0 then 1 else 0 end)
                            , cast(sum(case when amount_invoiced_total = 0 and claim_licensor_combined = 0 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            
                            , 0
                            , cast(0 as decimal(20, 6))
                        from tbl
                    ";
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        r.Read();
                        for (int i = 1; i < 11; i++)
                        {
                            cells[i].InnerText = r.GetValue(i - 1).ToString();
                        }
                    }
                }
            });
        }

        private void CalcPerRevenue(decimal exchRate)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
            cmd.CommandText = @"
                       declare @ccidClFileId int = (
                        select t2.fileId
                        from CcidInFile t1
                            join CcidClFile t2 on t1.ccidInvoiceId = t2.ccidInvoiceId and t1.InstanceIndex = t2.InstanceIndex
                        where t1.fileId = @ccidInFileId
                        );

                        select 
                         -- >= 1
                            -- USD
                               sum(case when amount_invoiced_total >= 1 then 1 else 0 end) 
                            ,  cast(sum(case when amount_invoiced_total >= 1 then amount_licensor_mech else 0 end) as decimal(20, 6))
                            ,  cast(sum(case when amount_invoiced_total >= 1 then amount_licensor_perf else 0 end) as decimal(20, 6))
                            ,  cast(sum(case when amount_invoiced_total >= 1 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            -- HRN
                            ,  sum(case when amount_invoiced_total * @exchRate >= 1 then 1 else 0 end) 
                            ,  cast(sum(case when amount_invoiced_total * @exchRate >= 1 then amount_licensor_mech * @exchRate else 0 end) as decimal(20, 6))
                            ,  cast(sum(case when amount_invoiced_total * @exchRate >= 1 then amount_licensor_perf * @exchRate else 0 end) as decimal(20, 6))
                            ,  cast(sum(case when amount_invoiced_total * @exchRate >= 1 then amount_invoiced_total * @exchRate else 0 end) as decimal(20, 6))
                        -- >= 0.1
                            -- USD
                            ,  sum(case when amount_invoiced_total >= 0.1 then 1 else 0 end) 
                            ,  cast(sum(case when amount_invoiced_total >= 0.1 then amount_licensor_mech else 0 end) as decimal(20, 6))
                            ,  cast(sum(case when amount_invoiced_total >= 0.1 then amount_licensor_perf else 0 end) as decimal(20, 6))
                            ,  cast(sum(case when amount_invoiced_total >= 0.1 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            -- HRN
                            ,  sum(case when amount_invoiced_total * @exchRate >= 0.1 then 1 else 0 end) 
                            ,  cast(sum(case when amount_invoiced_total * @exchRate >= 0.1 then amount_licensor_mech * @exchRate else 0 end) as decimal(20, 6))
                            ,  cast(sum(case when amount_invoiced_total * @exchRate >= 0.1 then amount_licensor_perf * @exchRate else 0 end) as decimal(20, 6))
                            ,  cast(sum(case when amount_invoiced_total * @exchRate >= 0.1 then amount_invoiced_total * @exchRate else 0 end) as decimal(20, 6))
                        -- >= 0.01
                            -- USD
                            ,  sum(case when amount_invoiced_total >= 0.01 then 1 else 0 end) 
                            ,  cast(sum(case when amount_invoiced_total >= 0.01 then amount_licensor_mech else 0 end) as decimal(20, 6))
                            ,  cast(sum(case when amount_invoiced_total >= 0.01 then amount_licensor_perf else 0 end) as decimal(20, 6))
                            ,  cast(sum(case when amount_invoiced_total >= 0.01 then amount_invoiced_total else 0 end) as decimal(20, 6))
                            -- HRN
                            ,  sum(case when amount_invoiced_total * @exchRate >= 0.01 then 1 else 0 end) 
                            ,  cast(sum(case when amount_invoiced_total * @exchRate >= 0.01 then amount_licensor_mech * @exchRate else 0 end) as decimal(20, 6))
                            ,  cast(sum(case when amount_invoiced_total * @exchRate >= 0.01 then amount_licensor_perf * @exchRate else 0 end) as decimal(20, 6))
                            ,  cast(sum(case when amount_invoiced_total * @exchRate >= 0.01 then amount_invoiced_total * @exchRate else 0 end) as decimal(20, 6))
                        -- ALL
                            -- USD
                            ,  count(*) 
                            ,  cast(sum(amount_licensor_mech) as decimal(20, 6))
                            ,  cast(sum(amount_licensor_perf) as decimal(20, 6))
                            ,  cast(sum(amount_invoiced_total) as decimal(20, 6))
                            -- HRN
                            ,  count(*) 
                            ,  cast(sum(amount_licensor_mech * @exchRate) as decimal(20, 6))
                            ,  cast(sum(amount_licensor_perf * @exchRate) as decimal(20, 6))
                            ,  cast(sum(amount_invoiced_total * @exchRate) as decimal(20, 6))
                        from ccidClDetail
                        where fileId = @ccidClFileId   
                    ";
                cmd.Parameters.AddWithValue("@ccidInFileId", ccidInFileId);
                cmd.Parameters.AddWithValue("@exchRate", @exchRate);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();
                    var table = wbControl.Document.Body.GetElementsByTagName("table")[2];
                    var rows = table.GetElementsByTagName("tr");
                    int col = 0;
                    for (int row = 2; row < 6; row++)
                    {
                        var cells = rows[row].GetElementsByTagName("td");

                        for (int i = 1; i < 9; i++)
                        {
                            cells[i].InnerText = r.GetValue(col++).ToString();
                        }
                    }
                }
            });
        }

        private void OnDocumentCompleted()
        {
            wbControl.Document.Body.Click += new HtmlElementEventHandler(Body_Click);
        }

        private void wbControl_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            OnDocumentCompleted();
        }

        void Body_Click(Object sender, HtmlElementEventArgs e)
        {
            HtmlElement element = wbControl.Document.GetElementFromPoint(e.ClientMousePosition);
            if (element == null || element.Id == null)
                return;
            if (element.Id.Equals("calcPerSales"))
            {
                CalcPerSales();
            }
            else if (element.Id.Equals("calcPerMusicWorks"))
            {
                CalcPerMusicWorks();
            }
            else if (element.Id.Equals("calcPerRevenue"))
            {
                if (!hasResp)
                {
                    MessageBox.Show("Відповідь ще не отримана", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var elExchRate = wbControl.Document.GetElementById("exchRate");
                string strExchRate = elExchRate.GetAttribute("value");
                decimal exchRate;
                var nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };
                if (!decimal.TryParse(strExchRate, System.Globalization.NumberStyles.Number, nfi, out exchRate))
                {
                    MessageBox.Show("Не вірне значення обмінного курсу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CalcPerRevenue(exchRate);
            }
        }
    }

}
