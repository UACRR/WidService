using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private string _reportFileFullName;

        public ReportParameters OutputParameters { get; set; }

        public bool IsNewReport { get; set; }

        public FormReportParams()
        {
            InitializeComponent();
        }

        public void SetExistingReport(Report report)
        {
            _report = report;
            FillControls();
        }

        public void SetNewReport(string reportFileFullName)
        {
            _reportFileFullName = reportFileFullName;
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

            cbRadioStation.Text = _report == null ? "" : _report.RadioStationName == null ? "" : _report.RadioStationName;
        }

        private void FillControls()
        {
            FillRadioStations();

            if (_report != null)
            {
                tbFileName.Text   = _report.FileName;
                tbStartYear.Text  = _report.StartYear  == null ? "" : _report.StartYear.ToString();
                tbStartMonth.Text = _report.StartMonth == null ? "" : _report.StartMonth.ToString();
                tbEndYear.Text    = _report.EndYear    == null ? "" : _report.EndYear.ToString();
                tbEndMonth.Text   = _report.EndMonth   == null ? "" : _report.EndMonth.ToString();
            }
            else
            {
                tbFileName.Text   = Path.GetFileName(_reportFileFullName);
                tbStartYear.Text  = "";
                tbStartMonth.Text = "";
                tbEndYear.Text    = "";
                tbEndMonth.Text   = "";
            }

            UpdateBtnNewRadioStation();
        }

        private void UpdateBtnNewRadioStation()
        {
            var name = cbRadioStation.Text;
            btnNewRadioStation.Visible = !string.IsNullOrEmpty(name) &&
                !_radioStations.Any(x => x.Name.ToUpper() == name.ToUpper());
            btnDeleteRadioStation.Visible = _radioStations.Any(x => x.Name.ToUpper() == name.ToUpper());
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

            if (string.IsNullOrEmpty(cbRadioStation.Text))
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
            OutputParameters = new ReportParameters
            {
                RadioStationId   = radioStationId              ,
                RadioStationName = cbRadioStation.Text         ,     
                StartYear        = int.Parse(tbStartYear.Text ),
                StartMonth       = int.Parse(tbStartMonth.Text),
                EndYear          = int.Parse(tbEndYear.Text   ),
                EndMonth         = int.Parse(tbEndMonth.Text  ),
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CreateRadioStation()
        {
            var radioStationName = cbRadioStation.Text;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    if not exists (select null from RadioStations where Name = @RadioStationName)
                    insert RadioStations (Name) values (@RadioStationName)
                ";

                cmd.Parameters.AddWithValue("@RadioStationName", radioStationName);

                cmd.ExecuteNonQuery();
            });

            FillRadioStations();
            cbRadioStation.Text = radioStationName;
            UpdateBtnNewRadioStation();
        }

        private void DeleteRadioStation()
        {
            var radioStationName = cbRadioStation.Text;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    delete from RadioStations where Name = @RadioStationName
                ";

                cmd.Parameters.AddWithValue("@RadioStationName", radioStationName);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Радіостанція вказана у звітах, видалення неможливе.",
                        "Параметри договору", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            });

            FillRadioStations();
            UpdateBtnNewRadioStation();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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

        private void btnNewRadioStation_Click(object sender, EventArgs e)
        {
            CreateRadioStation();
        }

        private void btnDeleteRadioStation_Click(object sender, EventArgs e)
        {
            DeleteRadioStation();
        }
    }
}
