using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WidSubmit.UcRightHolders;
using static WidSubmit.UcSubmRightHolders;

namespace WidSubmit
{
    public partial class FormSubmissionRightHolders : Form
    {
        private int _submissionId;

        private bool _isSuscribedToEvents;

        private UcSubmRightHolders.RightHolder _candidateRightHolder;

        private bool _forceClose = false;

        public FormSubmissionRightHolders()
        {
            InitializeComponent();
        }

        private void FormSubmissionRightHolders_Load(object sender, EventArgs e)
        {
            Configure();
            UpdateContent();
        }

        private void Configure()
        {
            ucSubmRightHolders.Init(PresentationMode.RIGHTHOLDER_SELECT);
            SuscribeToEvents();

            lvCurSubmRightHolders.FullRowSelect = true;
            lvCurSubmRightHolders.GridLines = true;
            lvCurSubmRightHolders.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvCurSubmRightHolders.MultiSelect = false;
            lvCurSubmRightHolders.View = View.Details;
            lvCurSubmRightHolders.SmallImageList = ilStatuses;

            lvCurSubmRightHolders.Columns.Clear();
            lvCurSubmRightHolders.Columns.Add("№", 40);
            lvCurSubmRightHolders.Columns.Add("Код СМАРТ", 80);
            lvCurSubmRightHolders.Columns.Add("Назва СМАРТ", 200);
            lvCurSubmRightHolders.Columns.Add("Приналежність для WID", 120);

            btnAddSelected.Enabled = false;
            btnRemoveSelected.Enabled = false;
            btnToggleSubmType.Enabled = false;
        }

        private void SuscribeToEvents()
        {
            if(_isSuscribedToEvents) { return; }
            ucSubmRightHolders.RightHolderSelected += OnRightHolderSelected;
            ucSubmRightHolders.RightHolderUnselected += OnRightHolderUnselected;

            _isSuscribedToEvents = true;
        }

        private void UpdateContent()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = "select dbo.FnCurSubmId()";
                _submissionId = (int)cmd.ExecuteScalar();

                ucSubmRightHolders.UpdateContent(_submissionId);
                //LoadRightHolders();
                FillLvSubmRightHolders();

            });
        }

        private void FillLvSubmRightHolders()
        {
            // Викорустовуємо посилання на правовласників в контролі
            var rightHolders = ucSubmRightHolders. GetSubmRightHolders();
            lvCurSubmRightHolders.BeginUpdate();
            lvCurSubmRightHolders.Items.Clear();
            var seqNr = 1;
            rightHolders.ForEach(x =>
            {
                if (x.IsInCurSubm)
                {
                    var item = new ListViewItem(seqNr.ToString());
                    item.SubItems.Add(x.CustId.ToString());
                    item.SubItems.Add($"{x.Name} {x.FstName}".Trim());
                    item.SubItems.Add(x.IsOwn ? "свій" : "чужий");
                    item.ImageIndex = x.IsOwn ? 0 : 1;
                    item.Tag = x;
                    lvCurSubmRightHolders.Items.Add(item);
                    seqNr++;
                }
            });
            lvCurSubmRightHolders.EndUpdate();
        }

        private ListViewItem FindRightHolderItem(UcSubmRightHolders.RightHolder rightHolder)
        {
            foreach(ListViewItem item in lvCurSubmRightHolders.Items)
            {
                if((UcSubmRightHolders.RightHolder)item.Tag == rightHolder)
                {
                    return item;
                }
            }
            return null;
        }
        
        public void OnRightHolderSelected(object sender, RightHolderSelectedEventArgs e)
        {
           _candidateRightHolder = e.RightHolder;
           btnAddSelected.Enabled = !_candidateRightHolder.IsInCurSubm && _candidateRightHolder.IsActive;
        }

        public void OnRightHolderUnselected(object sender, EventArgs e)
        {
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            ucSubmRightHolders.AddShownToCurSubm();
            FillLvSubmRightHolders();
            btnRemoveAll.Enabled = true;
            btnRemoveSelected.Enabled = false;
            btnToggleSubmType.Enabled = false;
        }

        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            _candidateRightHolder.IsInCurSubm = true;
            ucSubmRightHolders.UpdateRightHolderItem(_candidateRightHolder);
            FillLvSubmRightHolders();
            var item = FindRightHolderItem(_candidateRightHolder);
            if( item != null )
            {
                item.Selected = true;
                item.EnsureVisible();
            }
        }
        
        private void btnAddFromCbd_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsText())
            {
                Helpers.ShowErrMsg("Відсутні коди правовласників в буфері обміну");
                return;
            }
            
            var rawText = Clipboard.GetText();
            var custIds = new List<int>();
            using (StringReader reader = new StringReader(rawText))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if(!Helpers.IsDigitString(line))
                    {
                        Helpers.ShowErrMsg("Невірні коди правовласників в буфері обміну");
                        return;
                    }
                    custIds.Add(int.Parse(line));
                }
            }

            ucSubmRightHolders.AddFromCbd(custIds);
            FillLvSubmRightHolders();
            btnRemoveAll.Enabled = true;
            btnRemoveSelected.Enabled = false;
            btnToggleSubmType.Enabled = false;
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if(lvCurSubmRightHolders.SelectedItems.Count == 0) return;
            var item = lvCurSubmRightHolders.SelectedItems[0];
            var rh = (UcSubmRightHolders.RightHolder)item.Tag;
            rh.IsInCurSubm = false;
            ucSubmRightHolders.UpdateRightHolderItem(rh);
            lvCurSubmRightHolders.Items.Remove(item);
            
            btnRemoveSelected.Enabled =
            btnToggleSubmType.Enabled = false;
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            lvCurSubmRightHolders.Items.Clear();
            ucSubmRightHolders.RemoveAllFromCurSubm();

            btnRemoveAll.Enabled = false;
            btnRemoveSelected.Enabled = false;
            btnToggleSubmType.Enabled = false;
        }

        private void btnToggleSubmType_Click(object sender, EventArgs e)
        {
            if(lvCurSubmRightHolders.SelectedItems.Count == 0) return;

            var item = lvCurSubmRightHolders.SelectedItems[0];
            var rh = (UcSubmRightHolders.RightHolder)item.Tag;
            rh.IsOwn = !rh.IsOwn;
            item.SubItems[3].Text = rh.IsOwn ? "свій" : "чужий";
            item.ImageIndex = rh.IsOwn ? 0 : 1;
        }

        private void lvSubmRightHolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveSelected.Enabled =
            btnToggleSubmType.Enabled = lvCurSubmRightHolders.SelectedItems.Count > 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(lvCurSubmRightHolders.Items.Count == 0)
            {
                MessageBox.Show("Треба вибрати хоча б одного правовласника для поточної публікації", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var res = MessageBox.Show("Застосувати зміни і закрити форму?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.No)
            {
                return;
            }

            _forceClose = true;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Helpers.RunSqlSocWidSubmitExT(cmd =>
                {
                    cmd.CommandText = "select newid()";
                    var guid = cmd.ExecuteScalar();

                    cmd.CommandText = "insert Z_SubmRightHolder values(@guid, @rightHolderId, @submAsOwn)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.Parameters.AddWithValue("@rightHolderId", 0);
                    cmd.Parameters.AddWithValue("@submAsOwn", 1);

                    foreach(ListViewItem item in lvCurSubmRightHolders.Items)
                    {
                        var rh = (UcSubmRightHolders.RightHolder)item.Tag;
                        cmd.Parameters[1].Value = rh.Id;
                        cmd.Parameters[2].Value = rh.IsOwn;
                        cmd.ExecuteNonQuery();
                    }

                    cmd.CommandText = "spSubmRightHoldersSave";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.ExecuteNonQuery();
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Збереження результатів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormSubmissionRightHolders_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_forceClose)
            {
                e.Cancel = false;
                return;
            }
            var res = MessageBox.Show("Відмінити зміни і закрити форму?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = res == DialogResult.No;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
