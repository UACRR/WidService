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
using Telerik.WinControls.Enumerations;
using System.Drawing;
using System.Collections.Generic;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class AuthorRightholderBrListControl : UserControl
    {
        public delegate void GetWorkRhEventHandler(WorkRh workRh);
        public event GetWorkRhEventHandler OnGetWorkRh;

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => objectAuthorRightholderBrViewModelBindingSource.DataSource;
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
            get => _listMode;
            set
            {
                if (_listMode != value)
                {
                    _listMode = value;
                    SetAdditionalColumnsVisibility();
                }
            }
        }

        private bool _allowEditList = false;
        public bool AllowEditList
        {
            get => _allowEditList;
            set
            {
                _allowEditList = value;

                gvAuthorRightholderList.ReadOnly = !_allowEditList;
                gvAuthorRightholderList.Columns["DeleteColumn"].IsVisible = _allowEditList;
                btnAdd.Visible = _allowEditList;
            }
        }

        private string _roleRateErrorText = "";
        public string RoleRateErrorText
        {
            get => _roleRateErrorText;
            set
            {
                _roleRateErrorText = value;
                SetErrorText();
            }
        }

        private ObjectAuthorRightholderBrViewModel _authorRightholder;
        public ObjectAuthorRightholderBrViewModel SelectedAuthorRightholder
        {
            get => objectAuthorRightholderBrViewModelBindingSource.Current as ObjectAuthorRightholderBrViewModel;
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

        public event EventHandler CurrentAuthorRightholderChanged;

        public AuthorRightholderBrListControl()
        {
            InitializeComponent();

            gvAuthorRightholderList.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);
            gvAuthorRightholderList.SetCommandColumnImageAlignment("DeleteColumn", ContentAlignment.MiddleCenter);

            if (!IsDesignMode)
            {
                SetDictionaries();
            }
        }

        private void SetErrorText()
        {
            foreach (var row in gvAuthorRightholderList.Rows)
            {
                row.Cells["RoleRate"].ErrorText = RoleRateErrorText;
            }
        }

        private void SetDictionaries()
        {
            var creativeRoleTypeData = IpsGlobal.ObjectRightDictionaries.creativeRoleType
                .Where(rec => rec.CategoryCode == 6 && rec.Crtype == 1).ToList();
            gvAuthorRightholderList.SetComboboxColumnDataSource("RoleCode", creativeRoleTypeData);
            gvAuthorRightholderList.SetComboboxColumnDataSource("PrepayType", IpsGlobal.AnketaDictionaties.PrePayType);
            gvAuthorRightholderList.SetComboboxColumnDataSource("Currency", IpsGlobal.AnketaDictionaties.klR030, "r030", "a3");
            gvAuthorRightholderList.SetComboboxColumnDataSource("WorkTypeRh", IpsGlobal.AnketaDictionaties.workType);
            gvAuthorRightholderList.SetComboboxColumnDataSource("WorkTypeCl", IpsGlobal.AnketaDictionaties.workType);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            gvAuthorRightholderList.Rows.AddNew();
            gvAuthorRightholderList.CurrentRow.Cells[0].BeginEdit();
        }

        private void GvObjectsRightsList_CommandCellClick(object sender, GridViewCellEventArgs e)
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
            gvAuthorRightholderList.SetColumnVisibility("PrepaySumAuthor", visibility);
            gvAuthorRightholderList.SetColumnVisibility("WorkTypeRh", visibility);
            gvAuthorRightholderList.SetColumnVisibility("WorkTypeCl", visibility);
        }

        private void GvAuthorRightholderList_EditorRequired(object sender, EditorRequiredEventArgs e)
        {
            var columnName = gvAuthorRightholderList.CurrentColumn.Name;

            var isRightholder = ((ObjectAuthorRightholderBrViewModel) gvAuthorRightholderList.CurrentRow.DataBoundItem).IsRightholder;

            if (isRightholder && columnName == "AuthorName")
            {
                // set ExtendedRadBrowseEditorElement instead of RadTextBoxEditorElement
                var browseEditor = new ExtendedBrowseEditor();
                ((ExtendedRadBrowseEditorElement) browseEditor.EditorElement).ValueSelection += AuthorName_ValueSelection;
                e.Editor = browseEditor;
            }
        }

        private void GvAuthorRightholderList_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            var columnName = gvAuthorRightholderList.CurrentColumn.Name;

            if (columnName == "IsRightholder")
            {
                var cbEditor = (RadCheckBoxEditor)e.ActiveEditor;
                cbEditor.ValueChanged -= IsRightholder_ValueChanged;
                cbEditor.ValueChanged += IsRightholder_ValueChanged;
            }
        }

        private void IsRightholder_ValueChanged(object sender, EventArgs e)
        {
            var authorRightholder = SelectedAuthorRightholder;
            var cbEditor = (RadCheckBoxEditor)sender;

            if ((ToggleState)cbEditor.Value == ToggleState.On)
            {
                using (var selectionView = new RightholderSelectionView())
                {
                    //selectionView.SelectedRightholder = rightholder; // TODO
                    selectionView.RightholderSelected += (s, selectedRightholder) =>
                    {
                        authorRightholder.Author.CustId = selectedRightholder.CustId;
                        authorRightholder.Author.AuthorName = selectedRightholder.Name;
                        authorRightholder.InnerCode = selectedRightholder.InnerCode;
                        authorRightholder.Country = selectedRightholder.Country;
                    };
                    selectionView.SelectionCanceled += (s, ea) =>
                    {
                        authorRightholder.IsRightholder = false;
                        cbEditor.Value = ToggleState.Off;
                    };
                    selectionView.SearchText = authorRightholder.Author.AuthorName;
                    selectionView.ShowDialog();
                }
            }
            gvAuthorRightholderList.EndEdit();
        }

        private void AuthorName_ValueSelection(object sender, ValueSelectionEventArgs e)
        {
            using (var selectionView = new RightholderSelectionView())
            {
                //selectionView.SelectedRightholder = rightholder; // TODO
                selectionView.RightholderSelected += (s, selectedRightholder) =>
                {
                    e.Value = selectedRightholder.Name;

                    var authorRightholder = SelectedAuthorRightholder;
                    authorRightholder.Author.CustId = selectedRightholder.CustId;
                    authorRightholder.Author.AuthorName = selectedRightholder.Name;
                    authorRightholder.InnerCode = selectedRightholder.InnerCode;
                    authorRightholder.Country = selectedRightholder.Country;
                    objectAuthorRightholderBrViewModelBindingSource.ResetCurrentItem();
                };
                selectionView.ShowDialog();
            }
        }

        private void GvAuthorRightholderList_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            OnGetWorkRh?.Invoke((e.CurrentRow.DataBoundItem as ObjectAuthorRightholderBrViewModel)?.WorkRh);
        }

        private void GvAuthorRightholderList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            Utilities.GridViewHelper.SetTooltipText(sender, e);
        }

        private void GvAuthorRightholderList_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            var readOnlyColumns = "RoleRate, PrepayType, Currency, PrepaySumAuthor, WorkTypeRh, WorkTypeCl";

            if (!SelectedAuthorRightholder.IsRightholder && readOnlyColumns.Contains(e.Column.Name))
                e.Cancel = true;
        }

        private void GvAuthorRightholderList_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Utilities.GridViewHelper.DisplayErrors(sender, e);
        }

        private void GvAuthorRightholderList_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            OnCurrentAuthorRightholderChanged();
        }

        protected virtual void OnCurrentAuthorRightholderChanged()
        {
            CurrentAuthorRightholderChanged?.Invoke(this, EventArgs.Empty);
        }

        internal void SetInvalidProlong( string errText )
        {
            foreach (var row in gvAuthorRightholderList.Rows)
            {
                if( (row.DataBoundItem as ObjectAuthorRightholderBrViewModel).WorkRh.WorkTypeRh != 4 )
                    row.Cells["WorkTypeRh"].ErrorText = errText;
            }
        }

        internal void ResetErrorText()
        {
            RoleRateErrorText = "";
            foreach (var row in gvAuthorRightholderList.Rows)
            {
               row.Cells["WorkTypeRh"].ErrorText = "";
            }
        }

        internal int GetCountNoPogod()
        {
            var count = gvAuthorRightholderList.Rows.Count(rec => (rec.DataBoundItem as ObjectAuthorRightholderBrViewModel).WorkRh.WorkTypeRh != 4);
            return count;
        }

        public decimal GetAuthorRates()
        {
            var list = ((BindingSource) gvAuthorRightholderList.DataSource).List as IEnumerable<ObjectAuthorRightholderBrViewModel>;
            decimal retRate = list?.Sum(rec => rec.CopyRight?.RoleRate ?? 0) ?? 0;
            return retRate;
        }
    }
}
