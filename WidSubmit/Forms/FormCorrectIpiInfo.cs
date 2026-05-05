using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidSubmit
{
    public partial class FormCorrectIpiInfo : Form
    {
        private string _ipBaseNr;
        private int _ipNameNr;
        private string _ipiName;
        private int _custId;
        private string _msName;

        public FormCorrectIpiInfo(int custId, string ipBaseNr, string ipNameNr, string msName)
        {
            InitializeComponent();

            _custId = custId;
            _ipBaseNr = ipBaseNr;
            if(!int.TryParse(ipNameNr, out _ipNameNr)) _ipNameNr = 0;
            _msName = msName;
        }

        private void FormCorrectIpiInfo_Load(object sender, EventArgs e)
        {
            tbCustId.Text =  _custId.ToString();
            tbIpBaseNr.Text = _ipBaseNr;
            tbIpNameNr.Text = _ipNameNr.ToString();
            tbMsName.Text = _msName;

            lvIpCodes.FullRowSelect = true;
            lvIpCodes.GridLines = true;
            lvIpCodes.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvIpCodes.MultiSelect = false;
            lvIpCodes.View = View.Details;

            lvIpCodes.Columns.Clear();
            lvIpCodes.Columns.Add("Базовий код", 90);
            lvIpCodes.Columns.Add("Код назви", 90);
            lvIpCodes.Columns.Add("Назва", 300);
            lvIpCodes.Columns.Add("Дата", 80);
        }

        private bool CheckCodes()
        {
            _ipBaseNr = tbIpBaseNr.Text.Trim();
            if(!int.TryParse(tbIpNameNr.Text.Trim(), out _ipNameNr)) _ipNameNr = 0;

            var cnt = 0;

            Helpers.RunProtected(()  => {
                Helpers.RunSqlSocWidSubmitEx(cmd =>
                {
                    cmd.CommandText = $@"
                        select count(*)
                        from SocIpi..IpiName
                        where (
	                           IpBaseNr = @IpBaseNr
	                        or IpNameNr = @IpNameNr
	                        )
	                        and NameType = 'PA'
                    ";
                
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", _ipBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", _ipNameNr);

                    cnt = (int)cmd.ExecuteScalar();
                });
            });

            return cnt == 1;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(!CheckCodes())
            {
                var res = MessageBox.Show(
                        "Для введених кодів не знайдено правовласника в локальній БД IPI.\r\n"
                        + "Це може трапитись, якщо потрібне оновлення локальної бази ще не було виконане.\r\n"
                        + "Також можлива помилка при заповненні полей для кодів на формі.\r\n"
                        + "Застосувати коди?\r\n"
                        , "Перевірка кодів"
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Warning);
                if(res != DialogResult.Yes) return;
            }

            Helpers.RunProtected(()  => {
                Helpers.RunSqlSocWidSubmitEx(cmd =>
                {
                    cmd.CommandText = $@"
                        update MediaService..RightHolder
                        set InterCode = @ipBaseNr,  IPIBase = @ipNameNr
                        where CustId = @custId
                    ";
                
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@custId", _custId);
                    cmd.Parameters.AddWithValue("@IpBaseNr", tbIpBaseNr.Text);
                    cmd.Parameters.AddWithValue("@IpNameNr", tbIpNameNr.Text);

                    cmd.ExecuteNonQuery();
                });
            });

            MessageBox.Show(
                "Коди IPI записані в БД СМАРТ.\r\n"
                + "Для їх застосування у поточному сеансі після закриття форми виконайте Оновлення інформації із СМАРТ."
                , "Застосування кодів"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _ipBaseNr = tbIpBaseNr.Text.Trim();
            if(!int.TryParse(tbIpNameNr.Text.Trim(), out _ipNameNr)) _ipNameNr = 0;

            var filterNameTxt = tbIpPartyName.Text.Trim() == "" ? "" : "or Name like @Name";

            Helpers.RunProtected(()  => { 
                Helpers.RunSqlSocWidSubmitEx(cmd =>
                {
                    cmd.CommandText = $@"
                        select top 10 IpBaseNr, IpNameNr, trim(concat(Name, ' ',FstName)), CreDt
                        from SocIpi..IpiName
                        where (
	                           IpBaseNr = @IpBaseNr
	                        or IpNameNr = @IpNameNr
	                        {filterNameTxt}
	                        )
	                        and NameType = 'PA'
                    ";
                
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", tbIpPartyName.Text + "%");
                    cmd.Parameters.AddWithValue("@IpBaseNr", _ipBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", _ipNameNr);

                    using(var r  = cmd.ExecuteReader())
                    {
                        lvIpCodes.Items.Clear();
                        while(r.Read())
                        {
                            var item = new ListViewItem(r.GetString(0));
                            item.SubItems.Add(r.GetInt32(1).ToString());
                            item.SubItems.Add(r.GetString(2));
                            item.SubItems.Add(r.GetDateTime(3).ToString("yyyy-MM-dd"));
                            lvIpCodes.Items.Add(item);
                        }
                    }
                });
                
            });
        }

        private void btnApplyCodes_Click(object sender, EventArgs e)
        {
            if(lvIpCodes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Не обраний правовласник", "Застосувати коди", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = lvIpCodes.SelectedItems[0];
            tbIpBaseNr.Text = item.SubItems[0].Text;
            tbIpNameNr.Text = item.SubItems[1].Text;
            tbIpPartyName.Text = item.SubItems[2].Text;
        }
    }
}
