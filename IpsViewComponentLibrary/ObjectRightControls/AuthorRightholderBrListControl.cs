using System;
using System.ComponentModel;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Utilities;
using IpsViewComponentLibrary.RightholderControls;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class AuthorRightholderBrListControl : UserControl
    {
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
            var newItem = new ObjectAuthorRightholderBrViewModel();
            objectAuthorRightholderBrViewModelBindingSource.Add(newItem);
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
                (browseEditor.EditorElement as ExtendedRadBrowseEditorElement).BrowseButtonClick += AuthorName_BrowseButtonClick;
                e.Editor = browseEditor;
            }
        }

        private void AuthorName_BrowseButtonClick(object sender, EventArgs e)
        {
            using (var selectionView = new RightholderSelectionView())
            {
                //selectionView.SelectedRightholder = rightholder; // TODO
                selectionView.RightholderSelected += (s, selectedRightholder) =>
                {
                    var current = (ObjectAuthorRightholderBrViewModel)gvAuthorRightholderList.CurrentRow.DataBoundItem;
                    current.Author.CustId = selectedRightholder.CustId;
                    current.Author.AuthorName = selectedRightholder.Name;
                    current.InnerCode = selectedRightholder.InnerCode;
                    current.Country = ""; // TODO
                    objectAuthorRightholderBrViewModelBindingSource.ResetCurrentItem();

                    ((ExtendedBrowseEditor)gvAuthorRightholderList.ActiveEditor).Value = selectedRightholder.Name;
                };
                selectionView.ShowDialog();
            }
        }
    }
}
