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

namespace WidSubmit
{
    public partial class FormIpBaseToName : Form
    {
        public class RightHolder
        {
            public int    CustId           {  get; set; }
            public string IpBaseNr         {  get; set; }
            public string FullNameMs       {  get; set; }
            public string IpNameNrFound    {  get; set; }
            public string FullNameIpiFound {  get; set; }
        }

        private List<RightHolder> _rightHolders;

        public FormIpBaseToName()
        {
            InitializeComponent();
        }

        private void FormIpBaseToName_Load(object sender, EventArgs e)
        {
            Configure();
            LoadRightHolders();
            FillRightHolders();
        }

        private void Configure()
        {
            Helpers.ConfigureListView(lvRhMs
                , "CustId"        
                , "IpBaseNr"    
                , "Імя SMART (трансліт)"         
                , "IpNameNr (знайд)"          
                , "Імя IPI (знайд)"       
            );

            cbColName.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColName.Items.Clear();
            cbColName.Items.Add("IpBaseNr");
            cbColName.Items.Add("IpNameNr (знайд)");
            cbColName.SelectedIndex = 1;
        }

        private void LoadRightHolders()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    if (select count(*) from Z_LostIpNameNrs) = 0
                    begin
	                    insert Z_LostIpNameNrs select * from vLostIpNameNrs
                    end
                    select * from Z_LostIpNameNrs order by FullNameIpiFound, FullNameMs, CustId
                ";
                _rightHolders = Helpers.CreateListFromCmd<RightHolder>(cmd);
            });
        }

        private void FillRightHolders()
        {
            Helpers.FillListView(_rightHolders, lvRhMs, rh =>
            {
                return false;
            });
        }

        private void ApplyFieldValue()
        {
            if(lvRhMs.SelectedItems.Count == 0)
            {
                return;
            }

            var item = lvRhMs.SelectedItems[0];
            var rh = (RightHolder)item.Tag;
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                if(cbColName.SelectedIndex == 0)
                {
                    cmd.CommandText = "update Z_LostIpNameNrs set IpBaseNr = @ipBaseNr where CustId = @custId";
                    cmd.Parameters.AddWithValue("@custId", rh.CustId);
                    cmd.Parameters.AddWithValue("@ipBaseNr", tbNewValue.Text.Trim());
                    cmd.ExecuteNonQuery();
                    rh.IpBaseNr = tbNewValue.Text;
                    item.SubItems[2].Text = tbNewValue.Text;

                }
                else
                {
                    cmd.CommandText = "update Z_LostIpNameNrs set IpNameNrFound = @ipNameNr where CustId = @custId";
                    cmd.Parameters.AddWithValue("@custId", rh.CustId);
                    cmd.Parameters.AddWithValue("@ipNameNr", int.Parse(tbNewValue.Text).ToString());
                    cmd.ExecuteNonQuery();
                    rh.IpBaseNr = tbNewValue.Text;
                    item.SubItems[4].Text = tbNewValue.Text;
               }
            });
        }

        private void CbdCopy()
        {
            var sw = new StringWriter();
            sw.WriteLine("Z_LostIpNameNrs");
            _rightHolders.ForEach(x => {
                sw.WriteLine($"{x.CustId}\t{x.IpBaseNr}\t{x.FullNameMs}\t{x.IpNameNrFound}\t{x.FullNameIpiFound}");
            });
            Clipboard.SetText(sw.ToString());
        }

        private void CbdPaste()
        {
            if(!Clipboard.ContainsText())
            {
                Helpers.ShowErrMsg("Невірна інформація в буфері обміну - відсутній текст");
                return;
            }

            var rawText = Clipboard.GetText();
            var lines = rawText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            if(lines.Length == 0 || lines[0].ToUpper() != "Z_LostIpNameNrs".ToUpper())
            {
                Helpers.ShowErrMsg("Невірна інформація в буфері обміну - мусить містити інформацію для таблиці Z_LostIpNameNrs");
                return;
            }

            Helpers.RunSqlSocWidSubmitExT(cmd =>
            {
                cmd.CommandText = "truncate table Z_LostIpNameNrs";
                cmd.ExecuteNonQuery();

                var upl = new BulkUploadToSql();
                upl.conn = cmd.Connection;
                upl.TableName = "Z_LostIpNameNrs";
                upl.tran = cmd.Transaction;

                for(int rowIdx = 1; rowIdx < lines.Length; rowIdx++)
                {
                    var line = lines[rowIdx];
                    if(line.Trim() == "")
                        break;
                    var cols = line.Split('\t');
                    var data = new List<object>();
                    for(int colIdx = 0; colIdx < cols.Length; colIdx++)
                    {
                        data.Add(cols[colIdx]);
                    }
                    upl.AddData(data);
                }

                upl.Flush();
            });

            LoadRightHolders();
            FillRightHolders();
        }

        private void Apply()
        {
            Helpers.RunSqlSocWidSubmitExT(cmd =>
            {
                cmd.CommandText = @"
                    update t1
                    set t1.InterCode = t2.IpBaseNr, t1.IPIBase = t2.IpNameNrFound
                    from MediaService..RightHolder t1
	                    join Z_LostIpNameNrs t2 on t1.CustId = t2.CustId
                    truncate table Z_LostIpNameNrs
                ";
                cmd.ExecuteNonQuery();
            });

            LoadRightHolders();
            FillRightHolders();
        }

        private void lvRhMs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvRhMs.SelectedItems.Count == 0)
            {
                tbNewValue.Text = "";
                return;
            }

            var item = lvRhMs.SelectedItems[0];
            var rightHolder = (RightHolder)item.Tag;
            tbNewValue.Text = "";
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(!Helpers.ConfirmAction("Передати оновлену інформцію в БД СМАРТ?"))
                return;
            
            Helpers.RunProtected(() =>
            {
                Apply();
            });

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApplyFieldValue_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                ApplyFieldValue();
            });

            Close();
        }

        private void btnCbdCopy_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                CbdCopy();
            });
        }

        private void btnCbdPaste_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                CbdPaste();
            });
        }
    }
}
