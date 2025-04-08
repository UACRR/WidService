using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidExport
{
    public partial class UcMainRightHolderOwnership : UserControl
    {

        public class RightHolder
        {
            public int CustId { get; set; }
            public string IpBaseNr { get; set; }
            public int IpNameNr { get; set; }
            public string Name { get; set; }
            public string Ownership { get; set; }
        }

        private List<RightHolder> _rightHolders;

        private bool _ignoreCheckChanged = false;

        public UcMainRightHolderOwnership()
        {
            InitializeComponent();
        }

        public void RefreshControls()
        {
            LoadRightHolders();
            FillRightHolders();
        }

        private void UcMainRightHolderOwnership_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvRightHolder.FullRowSelect = true;
            lvRightHolder.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvRightHolder.MultiSelect = false;
            lvRightHolder.View = View.Details;
            lvRightHolder.Columns.Add("Код СМАРТ", 100);
            lvRightHolder.Columns.Add("Міднародний код", 100);
            lvRightHolder.Columns.Add("Код назви", 100);
            lvRightHolder.Columns.Add("Назва правовласника", 300);
            lvRightHolder.Columns.Add("За договором", 90).TextAlign = HorizontalAlignment.Center;
            lvRightHolder.Columns.Add("Свій", 60).TextAlign = HorizontalAlignment.Center;
            lvRightHolder.Columns.Add("Сторонній", 70).TextAlign = HorizontalAlignment.Center;
        }

        private void LoadRightHolders()
        {
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSelectRightHolderOwnership";
                using(var r = cmd.ExecuteReader())
                {
                    _rightHolders = new List<RightHolder>();
                    while(r.Read())
                    {
                        _rightHolders.Add(new RightHolder
                        {
                            CustId = r.GetInt32(0),
                            IpBaseNr = r.GetString(1),
                            IpNameNr = r.GetInt32(2),
                            Name = r.GetString(3),
                            Ownership = r.GetString(4),

                        });
                    }
                }
            });

        }

        private void FillRightHolders()
        {
            List<RightHolder> selectedRightHolders;
            if (tbFilter.Text.Trim() == "")
            {
                selectedRightHolders = _rightHolders.OrderBy(x => x.Name).ToList();
            }
            else
            {
                var text = tbFilter.Text.Trim().ToLower();
                selectedRightHolders = _rightHolders
                    .Where(x => x.Name.ToLower().Contains(text)
                        || x.CustId.ToString().Contains(text)
                        || x.IpBaseNr.ToLower().Contains(text)
                        || x.IpNameNr.ToString().Contains(text)
                     )
                    .OrderBy(x => x.Name).ToList();
            }

            lvRightHolder.Items.Clear();
            selectedRightHolders.ForEach(x =>
            {
                var item = lvRightHolder.Items.Add(x.CustId.ToString());
                item.SubItems.Add(x.IpBaseNr);
                item.SubItems.Add(x.IpNameNr.ToString());
                item.SubItems.Add(x.Name);
                item.SubItems.Add(x.Ownership == "D" ? "x" : "");
                item.SubItems.Add(x.Ownership == "O" ? "x" : "");
                item.SubItems.Add(x.Ownership == "F" ? "x" : "");
                item.Tag = x;
            });

            panelBottom.Visible = false;
        }

        private void ChangeOwnership(string newOwnership)
        {
            if (lvRightHolder.SelectedItems.Count == 0)
            {
                return;
            }

            var selectedItem = lvRightHolder.SelectedItems[0];
            var rightHolder = (RightHolder)selectedItem.Tag;
            rightHolder.Ownership = newOwnership;

            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = @"
                    update RightHolderOwnership
                    set RightHolderOwnershipTypeId = @ownership
                    where CustId = @custId
                ";
                cmd.Parameters.AddWithValue("@ownership", rightHolder.Ownership);
                cmd.Parameters.AddWithValue("@custId", rightHolder.CustId);
                cmd.ExecuteNonQuery();
            });

            selectedItem.SubItems[4].Text = rightHolder.Ownership == "D" ? "x" : "";
            selectedItem.SubItems[5].Text = rightHolder.Ownership == "O" ? "x" : "";
            selectedItem.SubItems[6].Text = rightHolder.Ownership == "F" ? "x" : "";
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            FillRightHolders();
        }

        private void lvRightHolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRightHolder.SelectedItems.Count == 0)
            {
                panelBottom.Visible = false;
                return;
            }

            var rightHolder = (RightHolder)lvRightHolder.SelectedItems[0].Tag;

            panelBottom.Visible = true;

            _ignoreCheckChanged = true;
            rbAuto.Checked = rightHolder.Ownership == "D";
            rbOwn.Checked = rightHolder.Ownership == "O";
            rbForeign.Checked = rightHolder.Ownership == "F";
            _ignoreCheckChanged = false;
        }

        private void rbAuto_CheckedChanged(object sender, EventArgs e)
        {
            if(_ignoreCheckChanged)
            {
                return;
            }

            ChangeOwnership("D");
        }

        private void rbOwn_CheckedChanged(object sender, EventArgs e)
        {
            if(_ignoreCheckChanged)
            {
                return;
            }

            ChangeOwnership("O");
        }

        private void rbForeign_CheckedChanged(object sender, EventArgs e)
        {
            if(_ignoreCheckChanged)
            {
                return;
            }

            ChangeOwnership("F");
        }
    }
}
