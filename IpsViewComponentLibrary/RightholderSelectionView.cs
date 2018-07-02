using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class RightholderSelectionView : Telerik.WinControls.UI.RadForm
    {
        private RightholderMainView _rightholder;
        public RightholderMainView SelectedRightholder
        {
            get
            {
                return gvRightholdersList.CurrentRow.DataBoundItem as RightholderMainView;
            }
            set
            {
                if (_rightholder != value)
                {
                    _rightholder = value;

                    var row = gvRightholdersList.Rows.FirstOrDefault(r => (int)r.Cells["CustId"].Value == _rightholder.CustId);
                    if (row != null)
                    {
                        gvRightholdersList.CurrentRow = row;
                    }
                }
            }
        }

        public event EventHandler<RightholderMainView> RightholderSelected;

        public RightholderSelectionView()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;

            var service = new RightholderService();
            var list = service.GetMainView();
            rightholderMainViewBindingSource.DataSource = list;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void gvRightholdersList_DoubleClick(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void OnRightholderSelected(RightholderMainView item)
        {
            RightholderSelected?.Invoke(this, item);
        }

        private void SelectAndClose()
        {
            var item = gvRightholdersList.CurrentRow.DataBoundItem as RightholderMainView;

            OnRightholderSelected(item);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void txtSearchRightholder_TextChanged(object sender, EventArgs e)
        {
            gvRightholdersList.MasterTemplate.Refresh();
        }

        private void gvRightholdersList_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchRightholder.Text))
            {
                gvRightholdersList.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvRightholdersList.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvRightholdersList.EndUpdate(false);
                return;
            }

            gvRightholdersList.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvRightholdersList.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearchRightholder.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    e.Visible = true;
                    e.Row.Cells[i].Style.CustomizeFill = true;
                    e.Row.Cells[i].Style.DrawFill = true;
                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                }
                else
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvRightholdersList.EndUpdate(false);
            }
        }
    }
}
