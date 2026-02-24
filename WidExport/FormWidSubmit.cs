using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidExport
{
    public partial class FormWidSubmit : Form
    {
        public class Party
        {
            public int      Id             { get; set; }
            public int      WidSubmGroupId { get; set;} 
            public int      CustId         { get; set; }
            public string   IpBaseNr       { get; set; }
            public int      IpNameNr       { get; set; }
            public string   InterName      { get; set; }
            public string   LocalName      { get; set; }
        }

        private WidSubmGroup _group;
        private int? _custIdToSelect;
        private int? _objIdToSelect;
        private bool _readOnly;

        private List<Party> _parties;

        private bool _ignoreSelectedIndexChanged;

        public FormWidSubmit(WidSubmGroup group, int? custIdToSelect = null, int? objIdToSelect = null)
        {
            InitializeComponent();
            _group = group;
            _custIdToSelect = custIdToSelect;
            _objIdToSelect = objIdToSelect;
            _readOnly = Helpers.IsGroupReadOnly(group.Id);            
        }

        private void FormWidSubmit_Load(object sender, EventArgs e)
        {
            Text = $"{_group.Name} - опрацювання творів для передачі в WID";

            lvParties.Columns.Add("#", 40);
            lvParties.Columns.Add("Name", 300);

            FillParties();

            _ignoreSelectedIndexChanged = true;

            var idx = 0;
            foreach(ListViewItem item in lvParties.Items)
            {
                var party = (Party)item.Tag;
                if(party.CustId == _custIdToSelect)
                {
                    lvParties.SelectedIndices.Add(idx);
                    lvParties.EnsureVisible(idx);
                    break;
                }
                idx++;
            }

            if (lvParties.SelectedIndices.Count == 0)
            {
                lvParties.SelectedIndices.Add(0);
                lvParties.EnsureVisible(0);
            }

            var partyToSelect = (Party)lvParties.SelectedItems[0].Tag;
            panelLeft.SetWidSubmGroupAndParty(_group, _readOnly, partyToSelect.IpNameNr, _objIdToSelect);

            _ignoreSelectedIndexChanged = false;

            btnApplyFilter.Enabled = false;

            SetReadOnly();

            UpdateControls();

        }

        private void SetReadOnly()
        {
            _readOnly = Helpers.IsGroupReadOnly(_group.Id);
        }

        private void UpdateControls()
        {
            if(_group.GroupType != 'M' || _group.Status == WidSubmGroupStatus.Closed)
            {
                btnAddParty.Visible =
                btnRemoveParty.Visible = false;
                return;
            }

            if (lvParties.SelectedItems.Count != 1)
            {
                btnRemoveParty.Enabled = false;
                panelLeft.Visible = false;
            }
            else if(((Party)lvParties.SelectedItems[0].Tag).Id == 0)
            {
                btnRemoveParty.Enabled = false;
                panelLeft.Visible = true;
            }
            else
            {
                btnAddParty.Enabled = !_readOnly;
                btnRemoveParty.Enabled = !_readOnly;
                panelLeft.Visible = true;
            }
        }

        private void FillParties()
        {
            _parties = new List<Party>();
            _parties.Add(new Party
            {
                Id = 0,
                WidSubmGroupId = _group.Id,
                CustId = 0,
                IpBaseNr = "",
                IpNameNr = 0,
                InterName = "<Всі твори групи>",
                LocalName = "<Всі твори групи>",
            });
            Helpers.RunSqlSocWidSubmit(cmd => {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupPartySelect";
                cmd.Parameters.AddWithValue("@groupId", _group.Id);
                using (var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        _parties.Add(new Party
                        {
                            Id              = r.GetInt32(0),
                            WidSubmGroupId  = r.GetInt32(1),
                            CustId          = r.GetInt32(2),
                            IpBaseNr        = r.GetString(3),
                            IpNameNr        = r.GetInt32(4),
                            InterName       = r.GetString(5),
                            LocalName       = r.GetString(6),
                        });
                    }
                }
            });

            UpdateLvParties();
        }

        private bool CheckMeetsFilter(Party party)
        {
            var filter = tbFilter.Text.Trim().ToUpper();
            if(filter != "" &&
               !party.InterName.ToUpper().Contains(filter) &&
               !party.LocalName.ToUpper().Contains(filter))
            {
                return false;
            }
            return true;
        }

        private void UpdateLvParties()
        {
            lvParties.Items.Clear();
            var seqNr = 1;
            var idx = 0;
            _parties.ForEach(x =>
            {
                ListViewItem item;
                if(idx == 0)
                {
                    item = lvParties.Items.Add("");
                    item.SubItems.Add(x.InterName);
                    item.Tag = x;
                }
                else
                {
                    if (CheckMeetsFilter(x))
                    {
                        item = lvParties.Items.Add(seqNr.ToString());
                        item.SubItems.Add(x.InterName);
                        item.Tag = x;
                        seqNr++;
                    }
                }
                idx++;
            });

            lvParties.SelectedIndices.Clear();
            lvParties.SelectedIndices.Add(0);
        }

        public void AddParty(string ipBaseNr, int ipNameNr)
        {
            var errMsg = "";
            Helpers.RunSqlSocWidSubmitT(cmd =>
            {
                cmd.CommandTimeout = 0;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupPartyAdd";

                var retVal = cmd.Parameters.Add("@RetVal", SqlDbType.Int);
                retVal.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.AddWithValue("@WidSubmGroupId", _group.Id);
                cmd.Parameters.AddWithValue("@IpBaseNr", ipBaseNr);
                cmd.Parameters.AddWithValue("@IpNameNr", ipNameNr);

                using (var r = cmd.ExecuteReader())
                {
                    if (r.HasRows)
                    {
                        r.Read();
                        errMsg = r.GetString(5);
                    }
                    else
                    {
                        switch (retVal.Value)
                        {
                            case 1:
                                errMsg = "Автора/правовласника не вдалось знайти в локальній базі даних";
                                break;
                            case 2:
                                errMsg = "Автора/правовласника не вдалось знайти в локальній базі даних - більше одного записа знайдено";
                                break;
                            case 3:
                                errMsg = "Автор/правовласник вже доданий до однієї з груп";
                                break;
                            case 4:
                                r.Read();
                                errMsg = r.GetString(5);
                                break;
                        }
                    }
                }

                if(!string.IsNullOrEmpty(errMsg))
                {
                    return;
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateObjIdToWicFromMs";
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();

                var service = new WidSubmGroupPreProcService();
                service.ProcessNames(cmd, _group.Id, false);
                service.ProcessNames(cmd, _group.Id, true);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupUpdateChecklist";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@groupId", _group.Id);
                cmd.ExecuteNonQuery();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupPreProc";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@groupId", _group.Id);
                cmd.ExecuteNonQuery();

            });
            
            if (!string.IsNullOrEmpty(errMsg))
            {
                MessageBox.Show(errMsg, "Не можливо дадати автора/правовласника", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OnNewPartySelected(string ipBaseNr, int ipNameNr)
        {
            var names = "";
            using (var wc = new WaitCursor())
            {
                Helpers.RunSqlSocWidSubmit(cmd =>
                {
                    cmd.CommandText = @"
                    select distinct t1.WidAuthor
                    from DciWorkToObjId t1
                        join SocWid..widIntrPty t2 on t1.Wic = t2.Wic
                        join SocIpi..IpiName t3 on t2.IpNameNr = t3.IpNameNr
                    where t3.IpNameNr = @IpNameNr
                        and t1.Status = 0
                    order by t1.WidAuthor
                ";
                    cmd.Parameters.AddWithValue("@IpNameNr", ipNameNr);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            if (names != "")
                            {
                                names += ", ";
                            }
                            names += r.GetString(0);
                        }
                    }
                });
            }

            if (names != "")
            {
                var msgTxt = "Серед творів автора і співавторів є такі, що містяться в WID, але для яких не визначена відповідність з творами в локальній базі.\r\n"
                    + $"Це стовується наступних авторів: {names}.\r\n"
                    + "Рекомендується обробити відповідні твори на формі поєднання зі звітом DSI, перш ніж додавати автора до групи. "
                    + "В іншому разі можливе дублювання творів при реєстрації в WID.\r\n"
                    + "Додати автора не зважаючи на вказану обставину?";
                var res = MessageBox.Show(msgTxt, "Додавання автора", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res != DialogResult.Yes)
                {
                    return;
                }
            }

            using (var wc = new WaitCursor())
            { 
                AddParty(ipBaseNr, ipNameNr); 
            }
        }

        private void btnAddParty_Click(object sender, EventArgs e)
        {
            var form = new FormSelectParty(_group.Id);
            form.ShowDialog();
            if(form.SelectedIpNameNr != null)
            {
                OnNewPartySelected(form.SelectedIpBaseNr, (int)form.SelectedIpNameNr);
                FillParties();
                var selectedIndex = 0;
                foreach(ListViewItem item in lvParties.Items)
                {
                    var party = (Party)item.Tag;
                    if(party.IpNameNr == form.SelectedIpNameNr)
                    {
                        break;
                    }
                    selectedIndex++;
                }
                if (selectedIndex < lvParties.Items.Count)
                {
                    lvParties.SelectedIndices.Clear();
                    lvParties.SelectedIndices.Add(selectedIndex);
                }
            }
            UpdateControls();
        }

        private void btnRemoveParty_Click(object sender, EventArgs e)
        {
            var party = (Party)lvParties.SelectedItems[0].Tag;

            if(party.Id == 0) // Всі твори
            {
                return;
            }

            if (
                DialogResult.Yes != MessageBox.Show(
                    "Видалення Автора/Правовласника може призвести до втрати важливої інформації. Видалити?",
                    "Видалення Автора/Правовласника",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                return;
            }

            var canDelete = true;
            using (var wc = new WaitCursor())
            {
                Helpers.RunSqlSocWidSubmit(cmd =>
              {
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.CommandText = "spWidSubmGroupPartyCanDelete";
                  cmd.Parameters.AddWithValue("@ipNameNr", party.IpNameNr);
                  canDelete = (int)cmd.ExecuteScalar() == 1;
              });
            }

            if(!canDelete)
            {
                MessageBox.Show(
                    "Видалення Автора/Правовласника неможливе - твори вже були передані в WID на реєстрацію.",
                    "Видалення Автора/Правовласника",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (var wc = new WaitCursor())
            {
                Helpers.RunSqlSocWidSubmitT(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidSubmGroupPartyDelete";
                    cmd.Parameters.AddWithValue("@IpNameNr", party.IpNameNr);
                    cmd.ExecuteNonQuery();
                });

                panelLeft.SetWidSubmGroupAndParty(_group, _readOnly, null);
                FillParties();
                UpdateControls();
            }
        }

        private void HandleSelectedIndexChanged()
        {
            if (lvParties.SelectedItems.Count == 0)
            {
                panelLeft.SetWidSubmGroupAndParty(_group, _readOnly, null);
            }
            else
            {
                var party = (Party)lvParties.SelectedItems[0].Tag;
                panelLeft.SetWidSubmGroupAndParty(_group, _readOnly, party.IpNameNr);
            }
            UpdateControls();
        }

        private void lvParties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_ignoreSelectedIndexChanged)
            {
                return;
            }

            HandleSelectedIndexChanged();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            btnApplyFilter.Enabled = true;
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            UpdateLvParties();
            btnApplyFilter.Enabled = false;
        }
    }
}
