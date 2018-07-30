using System;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using ipsFormsDesign.Dictionary;
using System.Collections.ObjectModel;
using IpsViewComponentLibrary.Utilities;
using IpsViewComponentLibrary.ObjectRightControls;
using ipsFormsDesign.Utilities;
using System.Drawing;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.RegisterControls
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
                SetColumnVisible("ShowObjectColumn", _allowShowObjectCommand);
            }
        }

        private bool _allowCreateObjectCommand = true;
        public bool AllowCreateObjectCommand
        {
            get { return _allowCreateObjectCommand; }
            set
            {
                _allowCreateObjectCommand = value;
                SetColumnVisible("CreateObjectColumn", _allowCreateObjectCommand);
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

        private bool _allowUnlinkCommand = true;
        public bool AllowUnlinkCommand
        {
            get { return _allowUnlinkCommand; }
            set
            {
                _allowUnlinkCommand = value;
                SetColumnVisible("UnlinkColumn", _allowUnlinkCommand);
            }
        }

        public bool MultiSelect
        {
            get => gvRegisterItemList.MultiSelect;
            set => gvRegisterItemList.MultiSelect = value;
        }

        public event EventHandler<RegisterItemViewModel> ShowObjectCommandExecuted;
        public event EventHandler<RegisterItemViewModel> CreateObjectCommandExecuted;
        public event EventHandler<RegisterItemViewModel> FindCommandExecuted;
        public event EventHandler<RegisterItemViewModel> LinkCommandExecuted;
        public event EventHandler<RegisterItemViewModel> UnlinkCommandExecuted;

        public RegisterItemListControl()
        {
            InitializeComponent();

            gvRegisterItemList.DataSource = registerItemViewModelBindingSource;
            ddlLinkedStatus.SelectedIndex = 0;

            gvRegisterItemList.SetCommandColumnImageAlignment("FindColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("LinkColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("UnlinkColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("ShowObjectColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("ShowObjectColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("CreateObjectColumn", ContentAlignment.MiddleCenter);
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
            else if (currentColumnName == "UnlinkColumn")
            {
                OnUnlinkCommandExecuted(SelectedRegisterItem);
            }

            else if (currentColumnName == "ShowObjectColumn")
            {
                OnShowObjectCommandExecuted(SelectedRegisterItem);
            }
            else if (currentColumnName == "CreateObjectColumn")
            {
                OnCreateObjectCommandExecuted(SelectedRegisterItem);
            }
        }

        private void gvRegisterItemList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            Utilities.GridViewHelper.SetTooltipTextForColumnHeader(sender, e);
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

        private void OnUnlinkCommandExecuted(RegisterItemViewModel selectedRegisterItem)
        {
            if (_allowUnlinkCommand)
                UnlinkCommandExecuted?.Invoke(this, selectedRegisterItem);

            selectedRegisterItem.ClearObjectData();
        }

        private void SelectionView_ObjectSelected(object sender, ObjectRightMainView selectedObject)
        {
            SelectedRegisterItem.SetObjectData(
                selectedObject.ObjId,
                selectedObject.Name,
                selectedObject.Author,
                selectedObject.Performer,
                selectedObject.Duration
            );
        }

        private void OnShowObjectCommandExecuted(RegisterItemViewModel selectedRegisterItem)
        {
            if (_allowShowObjectCommand)
                ShowObjectCommandExecuted?.Invoke(this, selectedRegisterItem);

            if (selectedRegisterItem.ObjId != null)
            {
                using (var view = new ObjectRightSrView())
                {
                    var presenter = new ObjectRightSrPresenter(view);
                    presenter.Show((int)selectedRegisterItem.ObjId);
                }
            }
        }

        private void OnCreateObjectCommandExecuted(RegisterItemViewModel selectedRegisterItem)
        {
            if (_allowCreateObjectCommand)
                CreateObjectCommandExecuted?.Invoke(this, selectedRegisterItem);

            var service = new ipsFormsDesign.Services.ObjectRightService(); // TODO: move to presenter or application controller
            var newObject = service.NewObjectRight(5);
            newObject.SetDataFromRegisterItem(selectedRegisterItem);

            using (var view = new ObjectRightSrView())
            {
                var presenter = new ObjectRightSrPresenter(view);
                presenter.Show(newObject);
            }

            // if object heve been saved
            if (newObject.ObjId != 0)
            {
                selectedRegisterItem.SetObjectData(
                    newObject.ObjId,
                    newObject.Name,
                    newObject.Author,
                    newObject.Performer,
                    newObject.MediaTrack.Duration
                );
            }
        }

        private void SetColumnVisible(string columnName, bool isVisible)
        {
            gvRegisterItemList.Columns[columnName].IsVisible = isVisible;
        }

        private void gvRegisterItemList_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            var registerItem = e.RowElement.RowInfo.DataBoundItem as RegisterItemViewModel;

            if (registerItem != null)
            {
                if (registerItem.IsAuto)
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.GradientStyle = GradientStyles.Solid;
                    e.RowElement.BackColor = Color.LemonChiffon;
                }
                else
                {
                    e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                    e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                    e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                }
            }
        }
    }
}
