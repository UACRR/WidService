using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class FormReportParams : Form
    {
        private Report _report;
        private List<RadioStation> _radioStations = new List<RadioStation>();

        public FormReportParams()
        {
            InitializeComponent();
        }

        public void SetReport(Report report)
        {
            _report = report;
            FillControls();
        }
        private void FillRadioStations()
        {
            _radioStations.Clear();
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = "select * from RadioStations order by Name";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _radioStations.Add(new RadioStation
                        {
                            Id = r.GetInt32(0),
                            Name = r.GetString(1),
                        });
                    }
                }
            });

            cbRadioStation.Items.Clear();
            _radioStations.ForEach(x =>
            {
                var item = cbRadioStation.Items.Add(x);
            });

            cbRadioStation.Text = _report.RadioStationName == null ? "" : _report.RadioStationName;
        }

        private void FillControls()
        {
            FillRadioStations();

            tbFileName.Text = _report.FileName;
            tbStartYear.Text = _report.StartYear == null ? "" : _report.StartYear.ToString();
            tbStartMonth.Text = _report.StartMonth == null ? "" : _report.StartMonth.ToString();
            tbEndYear.Text = _report.EndYear == null ? "" : _report.EndYear.ToString();
            tbEndMonth.Text = _report.EndMonth == null ? "" : _report.EndMonth.ToString();

            UpdateBtnNewRadioStation();
        }

        private void UpdateBtnNewRadioStation()
        {
            var name = cbRadioStation.Text;
            btnNewRadioStation.Visible = !string.IsNullOrEmpty(name) &&
                !_radioStations.Any(x => x.Name.ToUpper() == name.ToUpper());
        }

        private bool ValideatePeriod()
        {
            try
            {
                var startDate = new DateTime(int.Parse(tbStartYear.Text), int.Parse(tbStartMonth.Text), 1);
                var endDate = new DateTime(int.Parse(tbEndYear.Text), int.Parse(tbEndMonth.Text), 1);
                if (startDate > endDate)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void Apply()
        {
            if (!ValideatePeriod())
            {
                MessageBox.Show("Невірний період договору", "Параметри договору", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(string.IsNullOrEmpty(cbRadioStation.Text))
            {
                MessageBox.Show("Не вказана радіостанція", "Параметри договору", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_radioStations.Any(x => x.Name.ToUpper() == cbRadioStation.Text.ToUpper()))
            {
                MessageBox.Show("Невідома радіостанція. Створіть нову радіостанцію або вебиріть радіостанцію, що існує.", "Параметри договору", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var radioStationId = _radioStations.Single(x => x.Name.ToUpper() == cbRadioStation.Text.ToUpper()).Id;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    update Reports
                    set 
                          RadioStationId = @RadioStationId
                        , StartYear      = @StartYear
                        , StartMonth     = @StartMonth
                        , EndYear        = @EndYear
                        , EndMonth       = @EndMonth
                    where Id = @ReportId
                ";

                cmd.Parameters.AddWithValue("@ReportId"         , _report.Id        );
                cmd.Parameters.AddWithValue("@RadioStationId"   , radioStationId    );
                cmd.Parameters.AddWithValue("@StartYear"        , int.Parse(tbStartYear.Text  ));
                cmd.Parameters.AddWithValue("@StartMonth"       , int.Parse(tbStartMonth.Text ));
                cmd.Parameters.AddWithValue("@EndYear"          , int.Parse(tbEndYear.Text    ));
                cmd.Parameters.AddWithValue("@EndMonth"         , int.Parse(tbEndMonth.Text   ));

                cmd.ExecuteNonQuery();
            });

            _report.RadioStationName    = cbRadioStation.Text;
            _report.StartYear           = int.Parse(tbStartYear.Text );
            _report.StartMonth          = int.Parse(tbStartMonth.Text);
            _report.EndYear             = int.Parse(tbEndYear.Text   );
            _report.EndMonth            = int.Parse(tbEndMonth.Text  );

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void cbRadioStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBtnNewRadioStation();
        }

        private void cbRadioStation_TextUpdate(object sender, EventArgs e)
        {
            UpdateBtnNewRadioStation();
        }
    }
}
