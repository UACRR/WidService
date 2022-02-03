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
using Telerik.WinControls.UI;

namespace DdexInvoicing
{
    public partial class FormAgreementParams : Form
    {
        public int licId;
        public int custId;
        Dictionary<string, string> exchRateChanges;

        public FormAgreementParams()
        {
            InitializeComponent();
        }

        private void FormAgreementParams_Load(object sender, EventArgs e)
        {
            FillParams();
            FillExchRates();

            exchRateChanges = new Dictionary<string, string>();
        }

        private void FillParams()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                        select Id paramId 
                            , name paramName
                            , '' paramValue
                        from AgrParamType
                        order by id
                    ";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                cmd.CommandText = $@"
                    select paramId paramId 
                        , paramValue paramValue
                    from AgreementParam
                    where licId = @licId and custId = @custId
                ";
                cmd.Parameters.AddWithValue("@licId", licId);
                cmd.Parameters.AddWithValue("@custId", custId);

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        dt.Rows[r.GetInt32(0) - 1][2] = r.GetValue(1) == DBNull.Value ? "" : r.GetString(1);
                    }
                }

                radGridParams.DataSource = dt;
            });
        }

        private void FillExchRates()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    if not exists(select null
                        from CcidExchangeRate
                        where licId = @licId and custId = @custId)
                    begin
                        insert CcidExchangeRate(custId, licId, year, month, currency, exchRate)
                        values
                              (@custId, @licId, 2018, 10, 'USD', 0.035860)
                            , (@custId, @licId, 2018, 11, 'USD', 0.035860)
                            , (@custId, @licId, 2018, 12, 'USD', 0.035860)
                    end
                ";
                cmd.Parameters.AddWithValue("@licId", licId);
                cmd.Parameters.AddWithValue("@custId", custId);
                cmd.ExecuteNonQuery();

                cmd.CommandText = $@"
                    select distinct
                        year, '' m1, '' m2, '' m3, '' m4, '' m5
                            , '' m6, '' m7, '' m8, '' m9, '' m10
                            , '' m11, '' m12
                    from CcidExchangeRate
                    where licId = @licId and custId = @custId
                    order by year desc
                ";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                cmd.CommandText = $@"
                    select year, month, exchRate
                    from CcidExchangeRate
                    where licId = @licId and custId = @custId
                    order by year desc
                ";
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();

                    int curRowIndex = 0;
                    int curYear = r.GetInt32(0);
                    do
                    {
                        int nextYear = r.GetInt32(0);
                        int month = r.GetInt16(1);
                        if (nextYear != curYear)
                        {
                            curRowIndex++;
                            curYear = nextYear;
                        }
                        DataRow row = dt.Rows[curRowIndex];
                        row[month] = Formatter.ToString(r.GetDouble(2));
                    }
                    while (r.Read());
                }


                radGridExchRates.DataSource = dt;
            });
        }

        private void radBtnOk_Click(object sender, EventArgs e)
        {
            SaveParams();
            SaveExchRates();
            Close();
        }

        private void SaveParams()
        {
            Helpers.RunSqlOperationDdexT(cmd =>
            {
                cmd.CommandText = $@"
                    delete from AgreementParam
                    where licId = @licId and custId = @custId
                ";
                cmd.Parameters.AddWithValue("@licId", licId);
                //cmd.Parameters.AddWithValue("@licVersion", licVersion);
                cmd.Parameters.AddWithValue("@custId", custId);
                cmd.ExecuteNonQuery();

                DataTable dt = (DataTable)radGridParams.DataSource;
                cmd.CommandText = $@"
                   insert AgreementParam(licId, custId, paramId, paramValue) values(@licId, @custId, @paramId, @paramValue)
                ";
                cmd.Parameters.AddWithValue("@paramId", 0);
                cmd.Parameters.AddWithValue("@paramValue", "");
                foreach (DataRow row in dt.Rows)
                {
                    cmd.Parameters["@paramId"].Value = (int)row[0];
                    cmd.Parameters["@paramValue"].Value = row[2] == null ? DBNull.Value :row[2];
                    cmd.ExecuteNonQuery();
                }
            });
        }

        private void SaveExchRates()
        {
            Helpers.RunSqlOperationDdexT(cmd =>
            {
                cmd.CommandText = $@"
                    if exists(select null 
                        from CcidExchangeRate
                        where licId = @licId and custId = @custId and year = @year and month = @month
                        )
                        update CcidExchangeRate
                        set exchRate = @exchRate
                        where licId = @licId and custId = @custId and year = @year and month = @month
                    else
                        insert CcidExchangeRate(licId, custId, year, month, exchRate)
                        values(@licId, @custId, @year, @month, @exchRate)
                ";
                cmd.Parameters.AddWithValue("@licId", licId);
                //cmd.Parameters.AddWithValue("@licVersion", licVersion);
                cmd.Parameters.AddWithValue("@custId", custId);
                cmd.Parameters.AddWithValue("@year", 0);
                cmd.Parameters.AddWithValue("@month", 0);
                cmd.Parameters.AddWithValue("@exchRate", 0.0);

                foreach (var pair in exchRateChanges)
                {
                    string[] yearMonth = pair.Key.Split(':');
                    cmd.Parameters["@year"].Value = int.Parse(yearMonth[0]);
                    cmd.Parameters["@month"].Value = int.Parse(yearMonth[1]);
                    if (pair.Value != null)
                    {
                        cmd.Parameters["@exchRate"].Value = Formatter.ToDouble(pair.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                cmd.CommandText = $@"
                    delete from CcidExchangeRate
                    where licId = @licId and custId = @custId and year = @year and month = @month
                ";
                foreach (var pair in exchRateChanges)
                {
                    string[] yearMonth = pair.Key.Split(':');
                    cmd.Parameters["@year"].Value = int.Parse(yearMonth[0]);
                    cmd.Parameters["@month"].Value = int.Parse(yearMonth[1]);
                    if (pair.Value == null)
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            });
        }

        private void radBtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radGridParams_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.Column.FieldName.Equals("paramName", StringComparison.OrdinalIgnoreCase))
            {
                e.CellElement.Enabled = false;
            }
        }

        private void radGridParams_CellValidating(object sender, CellValidatingEventArgs e)
        {
            if (e.Column.FieldName.Equals("paramValue", StringComparison.OrdinalIgnoreCase))
            {
                var paramName = (string)e.Row.Cells["paramName"].Value;
                var paramValueType = DdexReport.GetParamValueType(paramName);

                if (e.Value == null)
                    return;

                if (paramValueType == DdexReport.AgreementParamValueTypeEnum.CURRENCY_CODE)
                {
                    string value = (string)e.Value;
                    if (!(value.Equals("USD", StringComparison.OrdinalIgnoreCase) || value.Equals("EUR", StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Невірне значення, повинно бути USD або EUR", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else if (paramValueType == DdexReport.AgreementParamValueTypeEnum.PERCENT)
                {
                    if (!Formatter.IsValidDecimal((string)e.Value))
                    {
                        MessageBox.Show("Невірне значення, повинні бути проценти, що менше або дорівнюють 100", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                    decimal res = Formatter.ToDecimal((string)e.Value);
                    if(!(res <= 100 && res >= 0))
                    {
                        MessageBox.Show("Невірне значення, повинні бути проценти, що менше або дорівнють 100", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else if (paramValueType == DdexReport.AgreementParamValueTypeEnum.PRICE)
                {
                    if (!Formatter.IsValidDecimal((string)e.Value))
                    {
                        MessageBox.Show("Невірне значення, повинна бути ціна в гривнях", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else if (paramValueType == DdexReport.AgreementParamValueTypeEnum.MONEY)
                {
                    if (!Formatter.IsValidDecimal((string)e.Value))
                    {
                        MessageBox.Show("Невірне значення, повинне бути значення в доларах", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void radGridExchRates_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.FieldName.Equals("year", StringComparison.OrdinalIgnoreCase))
            {
                e.CellElement.Enabled = false;
            }
        }

        private void radGridExchRates_CellValidating(object sender, CellValidatingEventArgs e)
        {
            if (!e.Column.FieldName.Equals("year", StringComparison.OrdinalIgnoreCase))
            {
                if (e.Value != null && e.Value != DBNull.Value && !string.IsNullOrEmpty(((string)e.Value).Trim()) && !Formatter.IsValidDouble((string)e.Value))
                {
                    MessageBox.Show("Невірне значення, має бути обмінний курс гривні до долару", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void radBtnAddYear_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)radGridExchRates.DataSource;
            int nextYear = (int)dt.Rows[0][0] + 1;
            dt.Rows.InsertAt(dt.NewRow(), 0);
            dt.Rows[0][0] = nextYear;
        }

        private void radGridExchRates_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            string key = $"{e.Row.Cells[0].Value.ToString()}:{e.ColumnIndex.ToString()}";
            string value = e.Value != DBNull.Value ? (string)e.Value : null;
            if (exchRateChanges.ContainsKey(key))
                    exchRateChanges[key] = value;
            else
                exchRateChanges.Add(key, value);
        }
    }

}
