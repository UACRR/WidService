using System;
using System.ComponentModel;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Utilities;
using IpsViewComponentLibrary.RightholderControls;
using System.Linq;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class AuthorRightholderBrListControl : UserControl
    {
        public delegate void GetWorkRhEventHandler(WorkRh workRh);
        public event GetWorkRhEventHandler OnGetWorkRh;

        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get { return objectAuthorRightholderBrViewModelBindingSource.DataSource; }
            set
            {
                if (objectAuthorRightholderBrViewModelBindingSource.DataSource != value)
                {
                    objectAuthorRightholderBrViewModelBindingSource.DataSource = value;
                }
            }
        }

        private AuthorRightholderBrListMode _listMode;
        public AuthorRightholderBrListMode ListMode
        {
            get { return _listMode; }
            set
            {
                if (_listMode != value)
                {
                    _listMode = value;
                    SetAdditionalColumnsVisibility();
                }
            }
        }

        private ObjectAuthorRightholderBrViewModel _authorRightholder;
        public ObjectAuthorRightholderBrViewModel SelectedAuthorRightholder
        {
            get { return objectAuthorRightholderBrViewModelBindingSource.Current as ObjectAuthorRightholderBrViewModel; }
            set
            {
                _authorRightholder = value;

                var row = gvAuthorRightholderList.Rows.FirstOrDefault(r => (ObjectAuthorRightholderBrViewModel)r.DataBoundItem == _authorRightholder);
                if (row != null)
                {
                    gvAuthorRightholderList.CurrentRow = row;
                }
            }
        }

        public AuthorRightholderBrListControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                SetDictionaries();
            }
        }

        private void SetDictionaries()
        {
            gvAuthorRightholderList.SetComboboxColumnDataSource("RoleCode", IpsGlobal.ObjectRightDictionaries.creativeRoleType);
            gvAuthorRightholderList.SetComboboxColumnDataSource("PrepayType", IpsGlobal.AnketaDictionaties.PrePayType);
            gvAuthorRightholderList.SetComboboxColumnDataSource("Currency", IpsGlobal.AnketaDictionaties.klR030, "r030", "a3");
            gvAuthorRightholderList.SetComboboxColumnDataSource("WorkTypeRh", IpsGlobal.AnketaDictionaties.workType);
            gvAuthorRightholderList.SetComboboxColumnDataSource("WorkTypeCl", IpsGlobal.AnketaDictionaties.workType);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gvAuthorRightholderList.Rows.AddNew();
            gvAuthorRightholderList.CurrentRow.Cells[0].BeginEdit();
        }

        private void gvObjectsRightsList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "DeleteColumn")
            {
                gvAuthorRightholderList.Rows.Remove(gvAuthorRightholderList.CurrentRow);
            }
        }

        private void SetAdditionalColumnsVisibility()
        {
            var visibility = _listMode == AuthorRightholderBrListMode.Full;

            gvAuthorRightholderList.SetColumnVisibility("RoleRate", visibility);
            gvAuthorRightholderList.SetColumnVisibility("PrepayType", visibility);
            gvAuthorRightholderList.SetColumnVisibility("Currency", visibility);
            gvAuthorRightholderList.SetColumnVisibility("PrepaySum", visibility);
            gvAuthorRightholderList.SetColumnVisibility("WorkTypeRh", visibility);
            gvAuthorRightholderList.SetColumnVisibility("WorkTypeCl", visibility);
        }

        private void gvAuthorRightholderList_EditorRequired(object sender, EditorRequiredEventArgs e)
        {
            var columnName = gvAuthorRightholderList.CurrentColumn.Name;

            if (columnName == "AuthorName")
            {
                // set ExtendedRadBrowseEditorElement instead of RadTextBoxEditorElement
                var browseEditor = new ExtendedBrowseEditor();
                (browseEditor.EditorElement as ExtendedRadBrowseEditorElement).ValueSelection += AuthorName_ValueSelection;
                e.Editor = browseEditor;
            }
        }

        private void AuthorName_ValueSelection(object sender, ValueSelectionEventArgs e)
        {
            using (var selectionView = new RightholderSelectionView())
            {
                //selectionView.SelectedRightholder = rightholder; // TODO
                selectionView.RightholderSelected += (s, selectedRightholder) =>
                {
                    e.Value = selectedRightholder.Name;

                    var current = (ObjectAuthorRightholderBrViewModel)gvAuthorRightholderList.CurrentRow.DataBoundItem;
                    current.Author.CustId = selectedRightholder.CustId;
                    current.Author.AuthorName = selectedRightholder.Name;
                    current.InnerCode = selectedRightholder.InnerCode;
                    current.Country = selectedRightholder.Country;
                    objectAuthorRightholderBrViewModelBindingSource.ResetCurrentItem();
                };
                selectionView.ShowDialog();
            }
        }

        private void gvAuthorRightholderList_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            OnGetWorkRh?.Invoke((e.CurrentRow.DataBoundItem as ObjectAuthorRightholderBrViewModel)?.WorkRh);
        }
    }
}
