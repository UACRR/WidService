using InvoicingLib;
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

namespace DdexInvoicing
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

        internal class Share
        {
	        internal int     Id           { get; set; }
	        internal int     ObjId        { get; set; }
	        internal int     RhCustId     { get; set; }
	        internal string  RhName       { get; set; }
	        internal string  PerSocCode   { get; set; }
	        internal string  PerSocName   { get; set; }
	        internal decimal RhPerShr     { get; set; }
	        internal decimal RhPerShrRes  { get; set; }
	        internal string  MecSocCode   { get; set; }
	        internal string  MecSocName   { get; set; }
	        internal decimal RhMecShr     { get; set; }
	        internal decimal RhMecShrRes  { get; set; }
        }

        internal class ExcSet
        {
            internal int Id {  get; set; }
            internal string Name { get; set; }
        }

        private int _objId;
        private List<Share> _shares;
        private List<ExcSet> _excSets;

        public UcShareCalc()
        {
            InitializeComponent();

            _objId = 0;
            _excSets = new List<ExcSet>();
        }

        public void SetWork(int? objId, string name)
        {
            if (objId == null)
            {
                Clear();
                return;
            }
            Helpers.RunProtected(() =>
            {
                _objId = (int)objId;

                tbWorkCode.Text = objId.ToString();
                
                Helpers.RunSqlOperationDdex(cmd =>
                {
                    cmd.CommandText = "select Name from MediaService..ObjectRight where ObjId = @objId";
                    cmd.Parameters.AddWithValue("@objId", _objId);
                    tbWorkName.Text = (string)cmd.ExecuteScalar();
                });
                
                lvShareDetails.Items.Clear();
                RefreshControls();
                CalcShares();
                LoadShares();
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

            panelShares.SplitterDistance = 600;

            RefreshControls();
        }

        private void RefreshControls()
        {
        }

        private void LoadShares()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from ShareCalc..vShareDetails where ObjId = @objId order by Id";
                cmd.Parameters.AddWithValue("@objId", _objId);
 
                _shares = new List<Share>();
                using(var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var share = new Share();
                        var idx = 0;
	                    share.Id           = r.GetInt32(idx++);
	                    share.ObjId        = r.GetInt32(idx++);
	                    share.RhCustId     = r.GetInt32(idx++);
	                    share.RhName       = r.GetString(idx++);
	                    share.PerSocCode   = r.GetString(idx++);
	                    share.PerSocName   = r.GetString(idx++);
	                    share.RhPerShr     = r.GetDecimal(idx++);
	                    share.RhPerShrRes  = r.GetDecimal(idx++);
	                    share.MecSocCode   = r.GetString(idx++);
	                    share.MecSocName   = r.GetString(idx++);
	                    share.RhMecShr     = r.GetDecimal(idx++);
	                    share.RhMecShrRes  = r.GetDecimal(idx++);
                        _shares.Add(share);
                    }
                }
            });
            
        }

        private void FillExcSets()
        {
            if(_excSets.Count > 0) return;

            _excSets.Add(new ExcSet { Id = 0, Name = ""});

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "select SetCode, SetName from Ddex..ExceptionSet";
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
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ShareCalc..spCalcShares";
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

        private Color GetCellColor(decimal shareValue)
        {
            return shareValue == 0 ? Color.LightSalmon : Color.LightGreen;
        }

        private void FillShares()
        {
            lvShares.Items.Clear();
            ListViewItem item;
            for(var itemIdx = 0; itemIdx < _shares.Count; itemIdx++)
            {
                var share = _shares[itemIdx];
                var rhText = $"({share.RhCustId}) {share.RhName}";
                var shrPerText = $"({share.PerSocCode}) {share.PerSocName} {share.RhPerShr} / {share.RhPerShrRes}";
                var shrMecText = $"({share.MecSocCode}) {share.MecSocName} {share.RhMecShr} / {share.RhMecShrRes}";
                item = new ListViewItem(rhText);
                item.SubItems.Add(shrPerText).BackColor = GetCellColor(share.RhPerShrRes);
                item.SubItems.Add(shrMecText).BackColor = GetCellColor(share.RhMecShrRes);
                item.Tag = share;
                item.UseItemStyleForSubItems = false;
                lvShares.Items.Add(item);
            }
        
            var rhPerShrTotal = _shares.Sum(x => x.RhPerShr);
            var rhPerShrResTotal = _shares.Sum(x => x.RhPerShrRes);
            var rhMecShrTotal = _shares.Sum(x => x.RhMecShr);
            var rhMecShrResTotal = _shares.Sum(x => x.RhMecShrRes);
            var shrPerTextTotal = $"{rhPerShrTotal} / {rhPerShrResTotal}";
            var shrMecTextTotal = $"{rhMecShrTotal} / {rhMecShrResTotal}";
            
            item = new ListViewItem("");
            lvShares.Items.Add(item);

            item = new ListViewItem("Загалом");
            item.SubItems.Add(shrPerTextTotal).BackColor = GetCellColor(rhPerShrResTotal == rhPerShrTotal ? 100 : 0);
            item.SubItems.Add(shrMecTextTotal).BackColor = GetCellColor(rhMecShrResTotal == rhMecShrTotal ? 100 : 0);
            item.UseItemStyleForSubItems = false;
            lvShares.Items.Add(item);

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

            if(shareItem.Tag == null)
            {
                lvShareDetails.Items.Clear();
                return;
            }
            
            var id = ((Share)shareItem.Tag).Id;

            Helpers.RunSqlOperationDdex(cmd =>
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
                    from ShareCalc..Shares
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
                LoadShares();
                FillShares();
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
                LoadShares();
                FillShares();
                UpdateShareDetailImages();
            });
        }

        private void chkTikTok_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                CalcShares();
                LoadShares();
                FillShares();
                UpdateShareDetailImages();
            });
        }
    }
}
