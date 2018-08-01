using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ipsFormsDesign.Interfaces;
using IpsViewComponentLibrary.Utilities;
using ipsFormsDesign.Data;
using System.Linq;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class CopyrightRequestControl : UserControl
    {
        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        private CopyrightRequestPresenter _presenter;
        public CopyrightRequestPresenter Presenter
        {
            get { return _presenter; }
            set
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object RightholderListDataSource
        {
            get { return rightolderBindingSource.DataSource; }
            set
            {
                if (rightolderBindingSource.DataSource != value)
                {
                    rightolderBindingSource.DataSource = value;
                }
            }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object ObjectRightListDataSource
        {
            get { return objectRightBindingSource.DataSource; }
            set
            {
                if (objectRightBindingSource.DataSource != value)
                {
                    objectRightBindingSource.DataSource = value;
                }
            }
        }

        private RightolderWithNotAcceptedCopyrightViewModel _selectedRightholder;
        public RightolderWithNotAcceptedCopyrightViewModel SelectedRightholder
        {
            get
            {
                if (gvRightholdersList.CurrentRow == null)
                    return null;

                return gvRightholdersList.CurrentRow.DataBoundItem as RightolderWithNotAcceptedCopyrightViewModel;
            }
            set
            {
                if (_selectedRightholder != value)
                {
                    _selectedRightholder = value;

                    var row = gvRightholdersList.Rows.FirstOrDefault(r => (int)r.Cells["CustId"].Value == _selectedRightholder.CustId);
                    if (row != null)
                    {
                        gvRightholdersList.CurrentRow = row;
                    }
                }
            }
        }

        public CopyrightRequestControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                SetDictionaries();
            }
        }

        private void SetDictionaries()
        {
            var allowedStatuses = new[] { 1, 4, 5 };
            gvObjectsRightsList.SetComboboxColumnDataSource("WorkTypeRh", IpsGlobal.AnketaDictionaties.workType.Where(w => allowedStatuses.Contains(w.CodeI)));
        }

        private void CopyrightRequestControl_Load(object sender, EventArgs e)
        {
            _presenter.UpdateRightholderList();
        }

        private void gvRightholdersList_SelectionChanged(object sender, EventArgs e)
        {
            var custId = ((RightolderWithNotAcceptedCopyrightViewModel)gvRightholdersList.CurrentRow.DataBoundItem).CustId;

            _presenter.UpdateObjectsList(custId);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }

        #region Search rightolder

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

        #endregion

        private void gvRightholdersList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "PrintColumn")
            {
                _presenter.Print();
            }
        }
    }
}
