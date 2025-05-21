using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class FormJoinObjIdToWic : Form
    {
        private int _objId;
        private string _iswc;

        private bool _ignoreTextChanged = false;

        public int FoundWic { get; private set; }
        public string FoundIswc { get; private set; }

        public FormJoinObjIdToWic(int objId, string iswc)
        {
            InitializeComponent();
            _objId = objId;
            _iswc = iswc;
        }

        private void FormJoinObjIdToWic_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {

            tbObjId.Text = _objId.ToString();
            tbWic.Text = "";
            tbIswc.Text = _iswc;

            labNameWid.Text = "";
            labAuthorsWid.Text = "";
            labPerformersWid.Text = "";

            FillMsWorkInfo();

            UpdateControls();
        }

        private void FillMsWorkInfo()
        {

            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select
	                      Name
	                    , Author
	                    , Performer
                    from MediaService..ObjectRight
                    where ObjId = @objId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@objId", _objId);
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();

                    labNameMs.Text = r.GetString(0);
                    labAuthorsMs.Text = r.GetString(1);
                    labPerformersMs.Text = r.GetString(2);
                }
            });
        }

        private void FillWidWorkInfo()
        {
            labNameWid.Text = "";
            labAuthorsWid.Text = "";
            labPerformersWid.Text = "";

            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select Name, Authors, Performers
                    from MediaService..vWidWorkInfo
                    where Wic = @wic
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@wic", int.Parse(tbWic.Text));
                using (var r = cmd.ExecuteReader())
                {
                    if (r.HasRows)
                    {
                        r.Read();

                        labNameWid.Text = r.GetString(0);
                        labAuthorsWid.Text = r.GetString(1);
                        labPerformersWid.Text = r.GetString(2);
                    }
                }
            });
        }

        private void UpdateControls()
        {
            btnApply.Enabled = labNameWid.Text.Trim() != "";
            btnCompareWorks.Enabled = tbWic.Text.Trim() != "" && tbIswc.Text.Trim() == "" ||
                tbIswc.Text.Trim() != "" && tbWic.Text.Trim() == "";
        }

        private bool UpdateIswcFromWic()
        {
            if (tbWic.Text.Trim() == "")
            {
                return false;
            }

            int wic;
            if (!int.TryParse(tbWic.Text, out wic))
            {
                MessageBox.Show("Невірний формат коду WIC", "Порівняння творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var isWicFound = false;
            var iswc = "";
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select null
                    from SocWid..WidTitle
                    where Wic = @wic
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@wic", wic);
                using (var r = cmd.ExecuteReader())
                {
                    isWicFound = r.HasRows;
                }

                if (isWicFound)
                {
                    cmd.CommandText = @"
                        select max(PrefIswc)
                        from SocWid..WidIswc
                        where Wic = @wic
                    ";
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            r.Read();
                            iswc = r.GetString(0);
                        }
                    }
                }
            });

            if (!isWicFound)
            {
                MessageBox.Show("Не знайденио твір за кодом WIC", "Порівняння творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _ignoreTextChanged = true;
            tbIswc.Text = iswc;
            _ignoreTextChanged = false;

            return true;

        }

        private bool UpdateWicFromIswc()
        {
            if (tbIswc.Text.Trim() == "")
            {
                return false;
            }

            _ignoreTextChanged = true;
            tbIswc.Text = tbIswc.Text.Replace("-", "");
            tbIswc.Text = tbIswc.Text.Replace(".", "");
            _ignoreTextChanged = false;

            var isIswcFound = false;
            var wic = 0;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select distinct Wic
                    from SocWid..WidIswc
                    where Iswc = @iswc
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@iswc", tbIswc.Text);
                using (var r = cmd.ExecuteReader())
                {
                    isIswcFound = r.HasRows;
                    if (isIswcFound)
                    {
                        r.Read();
                        wic = r.GetInt32(0);
                    }
                }

            });

            if (!isIswcFound)
            {
                MessageBox.Show("Не знайдено твір за кодом ISWC", "Порівняння творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _ignoreTextChanged = true;
            tbWic.Text = wic.ToString();
            _ignoreTextChanged = false;

            return true;

        }

        private void tbWic_TextChanged(object sender, EventArgs e)
        {
            if (_ignoreTextChanged)
            {
                return;
            }

            tbIswc.Text = "";
            labNameWid.Text = "";
            labAuthorsWid.Text = "";
            labPerformersWid.Text = "";
            UpdateControls();
        }

        private void tbIswc_TextChanged(object sender, EventArgs e)
        {
            if (_ignoreTextChanged)
            {
                return;
            }

            tbWic.Text = "";
            labNameWid.Text = "";
            labAuthorsWid.Text = "";
            labPerformersWid.Text = "";
            UpdateControls();
        }

        private void btnCompareWorks_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (tbWic.Text.Trim() != "" && tbIswc.Text.Trim() == "")
                {
                    if (UpdateIswcFromWic())
                    {
                        FillWidWorkInfo();
                    }
                }
                else if (tbIswc.Text.Trim() != "" && tbWic.Text.Trim() == "")
                {
                    _ignoreTextChanged = true;
                    tbIswc.Text = tbIswc.Text.Replace("-", "");
                    tbIswc.Text = tbIswc.Text.Replace(".", "");
                    _ignoreTextChanged = false;

                    if (UpdateWicFromIswc())
                    {
                        FillWidWorkInfo();
                    }
                }

                UpdateControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Поєднання творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                FoundWic = int.Parse(tbWic.Text);
                FoundIswc = tbIswc.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Поєднання творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
