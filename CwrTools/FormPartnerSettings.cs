using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwrTools
{
    public partial class FormPartnerSettings : Form
    {
        private int _partnerId;

        private int    _id              ;
        private int    _partnerGroupId  ;
        private string _name            ;
        private int    _periodType      ;
        private string _eMail           ;
        private string _ftpUrl          ;
        private string _ftpLogin        ;
        private string _ftpPwd          ;
        private string _ftpPort         ;


        public FormPartnerSettings(int patnerId)
        {
            InitializeComponent();

            _partnerId = patnerId;
        }

        private void FormPartnerSettings_Load(object sender, EventArgs e)
        {
            Configure();
            LoadData();
        }

        private void Configure()
        {
            cbPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPeriod.Items.Add("Раз на місяць");
            cbPeriod.Items.Add("Раз на квартал");
            cbPeriod.Items.Add("Раз на півріччя");
            cbPeriod.Items.Add("Раз на рік");
        }

        private void LoadData()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                    select
                          Id
                        , PartnerGroupId
                        , Name
                        , PeriodType
                        , EMail
                        , FtpUrl
                        , FtpLogin
                        , FtpPwd
                        , FtpPort
                    from Partners
                    where Id = @partnerId
                ";
                cmd.Parameters.AddWithValue("@partnerId",  _partnerId);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    var idx = 0;
                    _id             = r.GetInt32 (idx++);
                    _partnerGroupId = r.GetInt32 (idx++);
                    _name           = r.GetString(idx++);
                    _periodType     = r.GetInt32 (idx++);
                    _eMail          = r.GetString(idx++);
                    _ftpUrl         = r.GetString(idx++);
                    _ftpLogin       = r.GetString(idx++);
                    _ftpPwd         = r.GetString(idx++);
                    _ftpPort        = r.GetString(idx++);
                }
            });

            cbPeriod.SelectedIndex  = _periodType - 1;
            tbEmail.Text            = _eMail;
            tbFtpUrl.Text           = _ftpUrl;
            tbFtpLogin.Text         = _ftpLogin;
            tbFtpPwd.Text           = _ftpPwd;
            tbFtpPort.Text          = _ftpPort;

            labTitle.Text = $"Налаштування партнера {_name}";

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Helpers.RunSqlCwr(cmd =>
            {
                 cmd.CommandText = @"
                    update Partners set
                          PeriodType = @periodType
                        , EMail      = @eMail
                        , FtpUrl     = @ftpUrl
                        , FtpLogin   = @ftpLogin
                        , FtpPwd     = @ftpPwd
                        , FtpPort    = @ftpPort
                    where Id = @partnerId
                ";
                cmd.Parameters.AddWithValue("@partnerId", _partnerId);
                cmd.Parameters.AddWithValue("@periodType", cbPeriod.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@eMail"     , tbEmail.Text   );
                cmd.Parameters.AddWithValue("@ftpUrl"    , tbFtpUrl.Text  );
                cmd.Parameters.AddWithValue("@ftpLogin"  , tbFtpLogin.Text);
                cmd.Parameters.AddWithValue("@ftpPwd"    , tbFtpPwd.Text  );
                cmd.Parameters.AddWithValue("@ftpPort"   , tbFtpPort.Text );
                cmd.ExecuteNonQuery();
            });

            Close();
        }

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes != MessageBox.Show("Скасувати зміни?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            Close();
        }
    }
}
