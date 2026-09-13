using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ShareCalc.UcShareCalc;
using static System.Net.Mime.MediaTypeNames;

namespace ShareCalc
{
    public partial class UcShareCalc : UserControl
    {
        private static readonly string[] EXC_DESC = new string[] {
            "Товариство правовласника визначене",
            "Наявність сервісу від УААСП",
            "Наявність договору УААСП з товариством правовласника",
            "Дозвіл користувача збирати кошти на користь партнерського товариства",
            "Дозвіл користувача збирати кошти на користь правовласника",
            "Дозвіл користувача збирати кошти за наявності видавництв",
        };

        internal class ExcSet
        {
            internal int Id {  get; set; }
            internal string Name { get; set; }
        }

        private int _objId;
        private List<ExcSet> _excSets;

        public UcShareCalc()
        {
            InitializeComponent();

            _objId = 0;
            _excSets = new List<ExcSet>();
        }

        public void SetWork(int objId, string name)
        {
            Helpers.RunProtected(() =>
            {
                _objId = objId;
                tbWorkCode.Text = objId.ToString();
                tbWorkName.Text = name;
                lvShareDetails.Items.Clear();
                RefreshControls();
                CalcShares();
                FillShares();
            });
        }

        public void Clear()
        {
            tbWorkCode.Text = "";
            tbWorkName.Text = "";
            lvShares.Items.Clear();
        }

        private void UcShareCalc_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            cbExcSets.DropDownStyle = ComboBoxStyle.DropDownList;

            lvShares.FullRowSelect = true;
            lvShares.GridLines = true;
            lvShares.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvShares.MultiSelect = false;
            lvShares.View = View.Details;
            lvShares.Columns.Clear();
            lvShares.Columns.Add("Правовласник", 200);
            lvShares.Columns.Add("Пуб%", 200);
            lvShares.Columns.Add("Мех%", 200);

            lvShareDetails.FullRowSelect = true;
            lvShareDetails.GridLines = true;
            lvShareDetails.HeaderStyle = ColumnHeaderStyle.None;
            lvShareDetails.MultiSelect = false;
            lvShareDetails.View = View.Details;
            lvShareDetails.SmallImageList = ilStatuses;
            lvShareDetails.Columns.Clear();
            lvShareDetails.Columns.Add("", 450);

            panelShares.SplitterDistance = 130;

            RefreshControls();
        }

        private void RefreshControls()
        {
        }


        private void FillExcSets()
        {
            if(_excSets.Count > 0) return;

            _excSets.Add(new ExcSet { Id = 0, Name = ""});

            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = "select Id, Name from ExcSet";
                using(var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var extSet = new ExcSet();
                        extSet.Id = r.GetInt32(0);
                        extSet.Name = r.GetString(1);
                        _excSets.Add(extSet);
                    }
                }
            });

            _excSets.ForEach(extSet => {
                cbExcSets.Items.Add(extSet.Name);
            });
        }

        private void CalcShares()
        {
            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCalcShares";
                cmd.Parameters.AddWithValue("@objId", _objId);
                if(cbExcSets.SelectedIndex > 0)
                {
                    cmd.Parameters.AddWithValue("@excSetId", _excSets[cbExcSets.SelectedIndex].Id);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@excSetId", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@applyTikTokRules", chkTikTok.Checked ? 1 : 0);
                cmd.ExecuteNonQuery();
            });
        }

        private void FillShares(bool updateOnly = false)
        {
            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from vShares where ObjId = @objId order by Id";
                cmd.Parameters.AddWithValue("@objId", _objId);
 
                var itemIdx = 0;
                using(var r = cmd.ExecuteReader())
                {
                    if(!updateOnly) lvShares.Items.Clear();
                    while(r.Read())
                    {
                        if(updateOnly)
                        {
                            var item = lvShares.Items[itemIdx];
                            item.Text = r.GetString(3);
                            item.SubItems.Add(r.GetString(4));
                            item.SubItems.Add(r.GetString(5));
                        }
                        else
                        {
                            var item = new ListViewItem(r.GetString(3));
                            item.SubItems.Add(r.GetString(4));
                            item.SubItems.Add(r.GetString(5));
                            item.Tag = r.GetInt32(0);
                            lvShares.Items.Add(item);
                        }

                        itemIdx++;
                    }
                }
            });
        }

        private void FillShareDetails()
        {
            lvShareDetails.Items.Clear();

            if(lvShares.SelectedItems.Count == 0)
            {
                return;
            }

            for(var idx = 0; idx < 2 * EXC_DESC.Length; idx++)
            {
                if(idx == 0 || idx == EXC_DESC.Length)
                {
                    var titleItem = lvShareDetails.Items.Add(idx == 0 ? "Публічне використання" : "Механічне використання");
                    titleItem.Font = new Font(titleItem.Font, titleItem.Font.Style | FontStyle.Bold);
                }

                lvShareDetails.Items.Add(EXC_DESC[idx < EXC_DESC.Length ? idx : idx - EXC_DESC.Length]);
                        
            }

        }

        private void UpdateShareDetailImages()
        {
            if(lvShares.SelectedItems.Count == 0)
            {
                return;
            }

            var shareItem = lvShares.SelectedItems[0];
            var id = (int)shareItem.Tag;

            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = @"
                    select	 
	                      case when PerSoc is null then cast(1 as bit) else cast(0 as bit) end
	                    , PerRhSvcExc
	                    , PerSocAgrExc
	                    , PerSocExc
	                    , PerRhExc
	                    , PerAdvExc

	                    , case when MecSoc is null then cast(1 as bit) else cast(0 as bit) end
	                    , MecRhSvcExc
	                    , MecSocAgrExc
	                    , MecSocExc
	                    , MecRhExc
	                    , MecAdvExc
                    from Shares
                    where Id = @id
                ";
                cmd.Parameters.AddWithValue("@id", id);

                using(var r = cmd.ExecuteReader())
                {
                    lvShareDetails.BeginUpdate();
                    while(r.Read())
                    {
                        var itemIdx = 1;
                        for(var idx = 0; idx < 2 * EXC_DESC.Length; idx++)
                        {
                            if(idx == EXC_DESC.Length)
                            {
                                itemIdx++;
                            }

                            var excItem = lvShareDetails.Items[itemIdx];
                            excItem.ImageIndex = r.IsDBNull(idx) ? -1 : r.GetBoolean(idx) ? 3 : 2;
                        
                            itemIdx++;
                        }

                    }
                    lvShareDetails.EndUpdate();
                }
            });
        }

        private void cbExcSets_DropDown(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                FillExcSets();
            });
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                CalcShares();
                FillShares(true);
                UpdateShareDetailImages();
            });
        }

        private void lvShares_SelectedIndexChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                FillShareDetails();
                UpdateShareDetailImages();
            });
        }

        private void cbExcSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                CalcShares();
                FillShares(true);
                UpdateShareDetailImages();
            });
        }

        private void chkTikTok_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                CalcShares();
                FillShares(false);
                UpdateShareDetailImages();
            });
        }
    }
}
