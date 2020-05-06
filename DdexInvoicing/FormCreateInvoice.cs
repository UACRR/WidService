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

namespace DdexInvoicing
{
    public partial class FormCreateInvoice : Form
    {
        private static HashSet<int> requiredParamsAd = new HashSet<int> { 1, 2, 3, 4 };
        private static HashSet<int> requiredParamsSubscr = new HashSet<int> {1, 2, 3, 4, 5, 6 };

        public int ddexReportId;
        bool hasMissingParams;
        public FormCreateInvoice()
        {
            InitializeComponent();
        }

        private void FormCreateInvoice_Load(object sender, EventArgs e)
        {
            FillParams();
            radBtnOk.Enabled = !hasMissingParams;
            if(!hasMissingParams)
                radLabelPrompt.Text = "При розрахунку суми до виплати будуть використані параметри договору, що показані нижче. У разі необхідності, закрийте цю форму, змініть параметри на потрібні і повторіть створення рахунку.";
            else
                radLabelPrompt.Text = "Відсутні значення одного чи декількох параметрів договору, які необхідні для розрахунку суми до виплати. Закрийте цю форму, внесіть відсутні значення і повторіть створення рахунку.";
        }

        private void FillParams()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                int licId;
                //int licVersion;
                int custId;
                string fileType;
                int ddexReportingPeriodId;
                cmd.CommandText = $@"
                    select licId, custId, fileType, ddexReportingPeriodId
                    from DdexReport
                    where id = @ddexReportId
                ";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();
                    licId = r.GetInt32(0);
                    //licVersion = r.GetInt32(1);
                    custId = r.GetInt32(1);
                    fileType = r.GetString(2);
                    ddexReportingPeriodId = r.GetInt32(3);
                }
                HashSet<int> requiredParams = fileType.Equals("AdSupport-Music", StringComparison.OrdinalIgnoreCase) ? requiredParamsAd : requiredParamsSubscr;
                string inList = fileType.Equals("AdSupport-Music", StringComparison.OrdinalIgnoreCase) ? "1, 2, 3, 4" : "1, 2, 3, 4, 5, 6";

                cmd.CommandText = $@"
                    select Id paramId 
                        , name paramName
                        , '' paramValue
                    from AgrParamType
                    where id in ({inList})
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
                //cmd.Parameters.AddWithValue("@licVersion", licVersion);
                cmd.Parameters.AddWithValue("@custId", custId);

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    hasMissingParams = false;
                    while (r.Read())
                    {
                        string paramValue = r.GetString(1);
                        if (!requiredParams.Contains(r.GetInt32(0)))
                            continue;
                        if (string.IsNullOrEmpty(paramValue.Trim()))
                            hasMissingParams = true;
                        dt.Rows[r.GetInt32(0) - 1][2] = paramValue;
                    }
                }

                if (!fileType.Equals("AdSupport-Music", StringComparison.OrdinalIgnoreCase))
                {
                    cmd.CommandText = $@"
                        select year, quarter
                        from DdexReportingPeriod
                        where id = @ddexReportingPeriodId
                    ";
                    cmd.Parameters.AddWithValue("@ddexReportingPeriodId", ddexReportingPeriodId);
                    int year;
                    int quarter;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        r.Read();
                        year = r.GetInt32(0);
                        quarter = r.GetInt32(1);
                    }

                    int month = 3 * quarter - 2;
                    cmd.CommandText = $@"
                        select exchRate
                        from CcidExchangeRate
                        where licId = @licId and custId = @custId and year = @year and month = @month
                    ";
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@month", month);

                    object exchRate = cmd.ExecuteScalar();
                    if (exchRate == null || exchRate == DBNull.Value)
                        hasMissingParams = true;
                    DataRow newRow = dt.NewRow();
                    newRow[1] = "ExchangeRate";
                    newRow[2] = exchRate == null || exchRate == DBNull.Value ? "" : exchRate.ToString();
                    dt.Rows.Add(newRow);
                }


                radGridParams.DataSource = dt;
            });
        }

        private void radBtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void radBtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
