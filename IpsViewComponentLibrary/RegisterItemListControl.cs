using System;
using System.Linq;
using System.Windows.Forms;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using ipsFormsDesign.Dictionary;
using System.Collections.ObjectModel;

namespace IpsViewComponentLibrary
{
    public partial class RegisterItemListControl : UserControl
    {
        public object DataSource
        {
            get { return registerItemViewModelBindingSource.DataSource; }
            set
            {
                if (registerItemViewModelBindingSource.DataSource != value)
                {
                    registerItemViewModelBindingSource.DataSource = value;
                }
            }
        }

        private RegisterItemViewModel _registerItem;
        public RegisterItemViewModel SelectedRegisterItem
        {
            get
            {
                if (gvRegisterItemList.CurrentRow == null)
                    return null;

                return gvRegisterItemList.CurrentRow.DataBoundItem as RegisterItemViewModel;
            }
            set
            {
                if (_registerItem != value)
                {
                    _registerItem = value;

                    if (_registerItem != null)
                    {
                        var row = gvRegisterItemList.Rows.FirstOrDefault(r => (int)r.Cells["RegIitemId"].Value == _registerItem.RegIitemId);
                        if (row != null)
                        {
                            gvRegisterItemList.CurrentRow = row;
                        }
                    }
                }
            }
        }

        public Collection<RegisterItemViewModel> SelectedRegisterItems
        {
            get
            {
                var registerItemsList = new Collection<RegisterItemViewModel>();

                foreach (var row in gvRegisterItemList.SelectedRows)
                {
                    var registerItem = row.DataBoundItem as RegisterItemViewModel;
                    registerItemsList.Add(registerItem);
                }

                return registerItemsList;
            }
        }

        private bool _allowFindCommand = true;
        public bool AllowFindCommand
        {
            get { return _allowFindCommand; }
            set
            {
                _allowFindCommand = value;
                SetColumnVisible("FindColumn", _allowFindCommand);
            }
        }

        private bool _allowShowObjectCommand = true;
        public bool AllowShowObjectCommand
        {
            get { return _allowShowObjectCommand; }
            set
            {
                _allowShowObjectCommand = value;
                SetColumnVisible("ObjectColumn", _allowShowObjectCommand);
            }
        }

        private bool _allowLinkCommand = true;
        public bool AllowLinkCommand
        {
            get { return _allowLinkCommand; }
            set
            {
                _allowLinkCommand = value;
                SetColumnVisible("LinkColumn", _allowLinkCommand);
            }
        }

        public bool MultiSelect
        {
            get => gvRegisterItemList.MultiSelect;
            set => gvRegisterItemList.MultiSelect = value;
        }

        public event EventHandler<RegisterItemViewModel> ShowObjectCommandExecuted;
        public event EventHandler<RegisterItemViewModel> FindCommandExecuted;
        public event EventHandler<RegisterItemViewModel> LinkCommandExecuted;

        public RegisterItemListControl()
        {
            InitializeComponent();

            gvRegisterItemList.DataSource = registerItemViewModelBindingSource;
            ddlLinkedStatus.SelectedIndex = 0;
        }

        private void gvRegisterItemList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "FindColumn")
            {
                OnFindCommandExecuted(SelectedRegisterItem);
            }
            else if (currentColumnName == "LinkColumn")
            {
                OnLinkCommandExecuted(SelectedRegisterItem);
            }
            else if (currentColumnName == "ObjectColumn")
            {
                OnShowObjectCommandExecuted(SelectedRegisterItem);
            }
        }

        private void gvRegisterItemList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            GridViewTooltipHelper.SetTooltipTextForColumnHeader(sender, e);
        }

        private void ddlLinkedStatus_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            SetFilter(ddlLinkedStatus.SelectedIndex);
        }

        private void SetFilter(int linkedStatus)
        {
            gvRegisterItemList.FilterDescriptors.Clear();

            if (linkedStatus != 0)
            {
                FilterDescriptor filterByObjId = new FilterDescriptor();
                filterByObjId.PropertyName = "ObjId";
                filterByObjId.Operator = linkedStatus == 1 ? FilterOperator.IsNotEqualTo : FilterOperator.IsEqualTo;
                filterByObjId.Value = null;
                filterByObjId.IsFilterEditor = true;
                gvRegisterItemList.FilterDescriptors.Add(filterByObjId);
            }
        }

        private void OnFindCommandExecuted(RegisterItemViewModel selectedRegisterItem)
        {
            if (_allowFindCommand)
                FindCommandExecuted?.Invoke(this, selectedRegisterItem);
        }

        private void OnLinkCommandExecuted(RegisterItemViewModel selectedRegisterItem)
        {
            if (_allowLinkCommand)
                LinkCommandExecuted?.Invoke(this, selectedRegisterItem);

            // TODO: move to presenter
            using (var selectionView = new ObjectRightSelectionView())
            {
                selectionView.ObjectSelected += SelectionView_ObjectSelected;
                selectionView.ShowDialog();
            }
        }

        private void SelectionView_ObjectSelected(object sender, ObjectRightMainView selectedObject)
        {
            SelectedRegisterItem.ObjId = selectedObject.ObjId;
            SelectedRegisterItem.ObjectName = selectedObject.Name;
            SelectedRegisterItem.ObjectAuthors = selectedObject.Author;
            SelectedRegisterItem.ObjectPerformers = selectedObject.Performer;
            SelectedRegisterItem.ObjectDuration = selectedObject.Duration;
        }

        private void OnShowObjectCommandExecuted(RegisterItemViewModel selectedRegisterItem)
        {
            if (_allowShowObjectCommand)
                ShowObjectCommandExecuted?.Invoke(this, selectedRegisterItem);

            if (selectedRegisterItem.ObjId != null)
            {
                using (var view = new ObjectRightItemView())
                {
                    var presenter = new ObjectRightItemPresenter(view);
                    presenter.Show((int)selectedRegisterItem.ObjId);
                }
            }
        }

        private void SetColumnVisible(string columnName, bool isVisible)
        {
            gvRegisterItemList.Columns[columnName].IsVisible = isVisible;
        }
    }
}
