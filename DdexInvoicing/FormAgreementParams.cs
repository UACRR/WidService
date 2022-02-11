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

        private DdexAgreement agreement;

        public FormAgreementParams()
        {
            InitializeComponent();
        }

        private void FormAgreementParams_Load(object sender, EventArgs e)
        {
            agreement = DdexAgreements.Agreements.Single(x => x.LicId == licId && x.CustId == custId);
            exchRateChanges = new Dictionary<string, string>();

            Text = $"Параметри договору з {agreement.LicenseeName} - {agreement.LicenseDescription}";

            var items = radDropDownListReportFileTypes.Items;
            items.Clear();
            DdexReport
                .AgreementReportTypes
                .Keys
                .ToList()
                .ForEach(x => {
                    items.Add(x);
                });
            if(!string.IsNullOrWhiteSpace(agreement.ReportType))
            {
                radDropDownListReportFileTypes.SelectedIndex = (int)DdexReport.AgreementReportTypes[agreement.ReportType.ToLower()];
            }

            RefreshControls();
        }

        private void RefreshControls()
        {
            radPageViewMain.SelectedPage = radPageViewMainParams;
            if (string.IsNullOrEmpty(radDropDownListReportFileTypes.Text))
            {
                radGridParams.DataSource = null;
                radGridExchRates.DataSource = null;
                radPageViewMainParams.Enabled = false;
                radPageViewMainExchRate.Enabled = false;
                return;
            }

            var agreementReportType = DdexReport.AgreementReportTypes[radDropDownListReportFileTypes.Text];
            var reportType = DdexReport.ReportTypes.Single(x => x.ReportType == agreementReportType);

            radPageViewMainParams.Enabled = true;
            radPageViewMainExchRate.Enabled = reportType.NeedsExchRate;

            FillParams(reportType);
            if(reportType.NeedsExchRate)
            {
                FillExchRates();
            }
        }

        private void FillParams(DdexReport.ReportTypeInfo reportType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("paramId");
            dt.Columns.Add("paramName");
            dt.Columns.Add("paramValue");
            reportType.RequiredParams.ToList().ForEach(x =>
            {
                var row = dt.NewRow();
                row["paramId"] = (int)x;
                row["paramName"] = DdexReport.AgreementParams.Single(y => y.Key == x).Value.Description;
                switch (x)
                {
                    case DdexReport.AgreementParamEnum.MUSICRATE:
                        row["paramValue"] = Formatter.ToString(agreement.MusicRate);
                        break;
                    case DdexReport.AgreementParamEnum.GERATE:
                        row["paramValue"] = Formatter.ToString(agreement.GeRate);
                        break;
                    case DdexReport.AgreementParamEnum.MECHSPLIT:
                        row["paramValue"] = Formatter.ToString(agreement.MechSplit);
                        break;
                    case DdexReport.AgreementParamEnum.PERFSPLIT:
                        row["paramValue"] = Formatter.ToString(agreement.PerfSplit);
                        break;
                    case DdexReport.AgreementParamEnum.MUSICPSM:
                        row["paramValue"] = Formatter.ToString(agreement.MusicPSM);
                        break;
                    case DdexReport.AgreementParamEnum.GEPSM:
                        row["paramValue"] = Formatter.ToString(agreement.GePSM);
                        break;
                    case DdexReport.AgreementParamEnum.REPORTCURRENCY:
                        row["paramValue"] = agreement.ReportCurrency;
                        break;
                    case DdexReport.AgreementParamEnum.REPORTTYPE:
                        row["paramValue"] = agreement.ReportType;
                        break;
                    case DdexReport.AgreementParamEnum.ROYALTYTHRESHOLD:
                        row["paramValue"] = Formatter.ToString(agreement.RoyaltyThreshold);
                        break;
                    default:
                        throw new Exception($"Невідомий параметр договору з кодом {x}");
                }
                dt.Rows.Add(row);
            });
            radGridParams.DataSource = dt;

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
            var agreementReportType = DdexReport.AgreementReportTypes[radDropDownListReportFileTypes.Text];
            var reportType = DdexReport.ReportTypes.Single(x => x.ReportType == agreementReportType);
            SaveParams();
            if (reportType.NeedsExchRate)
            {
                SaveExchRates();
            }

            DdexAgreements.Load();
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
                    cmd.Parameters["@paramId"].Value = int.Parse((string)row[0]);
                    cmd.Parameters["@paramValue"].Value = row[2] == null ? DBNull.Value :row[2];
                    cmd.ExecuteNonQuery();
                }

                cmd.Parameters["@paramId"].Value = (int)DdexReport.AgreementParamEnum.REPORTTYPE;
                cmd.Parameters["@paramValue"].Value = radDropDownListReportFileTypes.Text;
                cmd.ExecuteNonQuery();

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

        private void radDropDownListReportFileTypes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            RefreshControls();
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
                var paramValueType = DdexReport.GetParamValueTypeFromDescription(paramName);

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
