using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Data;
using Telerik.WinControls.Export;

namespace DdexInvoicing
{
    public partial class FormStatistics : Form
    {
        public int ddexReportId;

        public FormStatistics()
        {
            InitializeComponent();
        }
        
        private void FormStatistics_Load(object sender, EventArgs e)
        {
            GroupDescriptor descriptor = new GroupDescriptor();
            descriptor.GroupNames.Add("block", ListSortDirection.Ascending);
            radGridProcessingProgressByBlocks.GroupDescriptors.Add(descriptor);
            FillDatesCombo();
        }

        private void radBtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string FormatInt(int value)
        {
            return string.Format("{0:### ### ##0.##}", value);
        }
        private string FormatMoney(decimal value)
        {
            return string.Format("{0:### ### ##0.##}", value);
        }

        private void radBtnRefresh_Click(object sender, EventArgs e)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"spUpdateIdentProgress";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.ExecuteNonQuery();
            });
            FillDatesCombo();
            ShowProgressInfo(DateTime.Now);
        }

        private void ShowProgressInfo(DateTime date)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                var dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("Count");
                dt.Columns.Add("NetRevenue");

                var filter = DdexReport.GetFilterString(cmd, ddexReportId);

                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);

                int id = 0;
                cmd.CommandText = $@"
                    select id 
                    from IdentProgress 
                    where {filter}
                        and UpdatedOn = @UpdatedOn";
                SqlParameter dateParam = new SqlParameter("@UpdatedOn", SqlDbType.Date);
                dateParam.Value = date;
                cmd.Parameters.Add(dateParam);
                id = (int)cmd.ExecuteScalar();
                //id = (Int32)idObj;

                cmd.CommandText = "select * from IdentProgress where id = @id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();
                    int i = 3;
                    dt.Rows.Add("Загалом для обробки вручну", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    //dt.Rows.Add("До сплати", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    dt.Rows.Add("Обробка не розпочата", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    dt.Rows.Add("Твори визначені як такі, що не можуть бути ідентифіковані", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    dt.Rows.Add("Твори ідентифіковані", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    dt.Rows.Add("Твори, розгляд яких відкладено", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    dt.Rows.Add("Твори не знайдені", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    dt.Rows.Add("Твори знайдені за головною назвою, автори не визначені", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    dt.Rows.Add("Знайдено один твір за головною назвою і автором", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    dt.Rows.Add("Знайдено декілька творів за головною назвою і автором", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    dt.Rows.Add("Твори знайдені за альтернативною назвою, автори не визначені", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    dt.Rows.Add("Знайдено один твір за альтернативною назвою і автором", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    dt.Rows.Add("Знайдено декілька творів за альтернативною назвою і автором", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                }

                radGridProcessingProgress.DataSource = dt;


                dt = new DataTable();
                dt.Columns.Add("Block");
                dt.Columns.Add("Name");
                dt.Columns.Add("Count");
                dt.Columns.Add("NetRevenue");

                cmd.CommandText = "select * from IdentProgressByBlock where IdentProgressId = @id order by firstRec";

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        int i = 3;
                        string blockText = string.Format("{0:D5}", r.GetInt32(1)) + "-" + string.Format("{0:D5}", r.GetInt32(2));
                        dt.Rows.Add(blockText, $"Обробка не розпочата", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                        dt.Rows.Add(blockText, $"Твори визначені як такі, що не можуть бути ідентифіковані", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                        dt.Rows.Add(blockText, $"Твори ідентифіковані", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                        dt.Rows.Add(blockText, $"Твори, розгляд яких відкладено", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                        dt.Rows.Add(blockText, $"Твори не знайдені", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                        dt.Rows.Add(blockText, $"Твори знайдені за головною назвою, автори не визначені", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                        dt.Rows.Add(blockText, $"Знайдено один твір за головною назвою і автором", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                        dt.Rows.Add(blockText, $"Знайдено декілька творів за головною назвою і автором", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                        dt.Rows.Add(blockText, $"Твори знайдені за альтернативною назвою, автори не визначені", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                        dt.Rows.Add(blockText, $"Знайдено один твір за альтернативною назвою і автором", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                        dt.Rows.Add(blockText, $"Знайдено декілька творів за альтернативною назвою і автором", FormatInt(r.GetInt32(i++)), FormatMoney(r.GetDecimal(i++)));
                    }
                }

                radGridProcessingProgressByBlocks.DataSource = dt;


            });
        }

        private void radBtnShow_Click(object sender, EventArgs e)
        {
            if (radComboDate.SelectedItem == null)
            {
                MessageBox.Show("Не вибрана дата", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] dateParts = radComboDate.SelectedItem.Text.Split('-');
            DateTime date = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));

            ShowProgressInfo(date);
        }

        private void FillDatesCombo()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                var filter = DdexReport.GetFilterString(cmd, ddexReportId);

                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);

                cmd.CommandText = $@"select id, UpdatedOn from IdentProgress where {filter} order by UpdatedOn desc";
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    radComboDate.Items.Clear();
                    while (r.Read())
                    {
                        radComboDate.Items.Add(r.GetDateTime(1).ToString("yyyy-MM-dd"));
                    }
                    if(radComboDate.Items.Count > 0)
                    {
                        radComboDate.Items[0].Selected = true;
                    }
                }
            });
        }

    }
}
