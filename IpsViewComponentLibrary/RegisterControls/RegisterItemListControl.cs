using System;
using System.Collections.Generic;
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
using IpsViewComponentLibrary.AppController;
using ipsFormsDesign.Events;
using ipsFormsDesign.Data;
using System.ComponentModel;
using ipsFormsDesign.ViewModels.Fixations;

namespace IpsViewComponentLibrary.RegisterControls
{
    public partial class RegisterItemListControl : UserControl
    {
        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        public object DataSource
        {
            get { return bsRegisterItemViewModel.DataSource; }
            set
            {
                if (bsRegisterItemViewModel.DataSource != value)
                {
                    bsRegisterItemViewModel.DataSource = value;
                }
            }
        }

        public object DataSourceRegisterExtra
        {
            get { return bsRegisterExtra.DataSource; }
            set
            {
                if (bsRegisterExtra.DataSource != value)
                {
                    bsRegisterExtra.DataSource = value;
                }
            }
        }

        public object DataSourceRegisterCount
        {
            get { return bsRegisterCountViewModel.DataSource; }
            set
            {
                if (bsRegisterCountViewModel.DataSource != value)
                {
                    bsRegisterCountViewModel.DataSource = value;
                }
            }
        }

        //TODO: повернути значення
        public IList<RegisterItemViewModel> GetDataSource => ((System.Windows.Forms.BindingSource)gvRegisterItemList.DataSource).List as IList<RegisterItemViewModel>;

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

                    if (registerItem != null)
                        registerItemsList.Add(registerItem);
                }

                return registerItemsList;
            }
        }

        private bool _allowEditList = false;
        public bool AllowEditList
        {
            get { return _allowEditList; }
            set
            {
                _allowEditList = value;

                btnAdd.Visible = _allowEditList;
                gvRegisterItemList.SetColumnVisibility("DeleteColumn", _allowEditList);
                gvRegisterItemList.SetColumnReadOnly("ItemName", !_allowEditList);
                gvRegisterItemList.SetColumnReadOnly("Performer", !_allowEditList);
                gvRegisterItemList.SetColumnReadOnly("AuthorMusic", !_allowEditList);
                gvRegisterItemList.SetColumnReadOnly("AuthorText", !_allowEditList);
                gvRegisterItemList.SetColumnReadOnly("DurationItem", !_allowEditList);
                gvRegisterItemList.SetColumnReadOnly("CountUse", !_allowEditList);
            }
        }

        private bool _allowFindCommand = true;
        public bool AllowFindCommand
        {
            get { return _allowFindCommand; }
            set
            {
                _allowFindCommand = value;
                gvRegisterItemList.SetColumnVisibility("FindColumn", _allowFindCommand);
            }
        }

        private bool _allowShowObjectCommand = true;
        public bool AllowShowObjectCommand
        {
            get { return _allowShowObjectCommand; }
            set
            {
                _allowShowObjectCommand = value;
                gvRegisterItemList.SetColumnVisibility("ShowObjectColumn", _allowShowObjectCommand);
            }
        }

        private bool _allowCreateObjectCommand = true;
        public bool AllowCreateObjectCommand
        {
            get { return _allowCreateObjectCommand; }
            set
            {
                _allowCreateObjectCommand = value;
                gvRegisterItemList.SetColumnVisibility("CreateObjectColumn", _allowCreateObjectCommand);
            }
        }

        private bool _allowLinkCommand = true;
        public bool AllowLinkCommand
        {
            get { return _allowLinkCommand; }
            set
            {
                _allowLinkCommand = value;
                gvRegisterItemList.SetColumnVisibility("LinkColumn", _allowLinkCommand);
            }
        }

        private bool _allowUnlinkCommand = true;
        public bool AllowUnlinkCommand
        {
            get { return _allowUnlinkCommand; }
            set
            {
                _allowUnlinkCommand = value;
                gvRegisterItemList.SetColumnVisibility("UnlinkColumn", _allowUnlinkCommand);
            }
        }

        private bool _showDurationUse = true;
        public bool ShowDurationUse
        {
            get => _showDurationUse;
            set
            {
                _showDurationUse = value;
                gvRegisterItemList.SetColumnVisibility("DurationUse", _showDurationUse);
            }
        }

        private bool _showLinked = true;
        public bool ShowLinked
        {
            get => _showLinked;
            set
            {
                _showLinked = value;
                gvRegisterItemList.SetColumnVisibility("Linked", _showLinked);
            }
        }

        public bool MultiSelect
        {
            get => gvRegisterItemList.MultiSelect;
            set => gvRegisterItemList.MultiSelect = value;
        }

        private bool _showObjectInfo = true;
        public bool ShowObjectInfo
        {
            get { return _showObjectInfo; }
            set
            {
                _showObjectInfo = value;

                var objectGroup = ((ColumnGroupsViewDefinition)gvRegisterItemList.ViewDefinition).ColumnGroups["objectGroup"];
                objectGroup.IsVisible = _showObjectInfo;

                var commandGroup = ((ColumnGroupsViewDefinition)gvRegisterItemList.ViewDefinition).ColumnGroups["commandGroup"];
                commandGroup.ShowHeader = _showObjectInfo;

                var registerGroup = ((ColumnGroupsViewDefinition)gvRegisterItemList.ViewDefinition).ColumnGroups["registerGroup"];
                registerGroup.ShowHeader = _showObjectInfo;
            }
        }

        private bool _showAuthors = true;
        public bool ShowAuthors
        {
            get { return _showObjectInfo; }
            set
            {
                _showAuthors = value;

                gvRegisterItemList.SetColumnVisibility("Performer", _showAuthors);
                gvRegisterItemList.SetColumnVisibility("AuthorMusic", _showAuthors);
                gvRegisterItemList.SetColumnVisibility("AuthorText", _showAuthors);
            }
        }

        public event EventHandler<RegisterItemViewModel> ShowObjectCommandExecuted;
        public event EventHandler<RegisterItemViewModel> CreateObjectCommandExecuted;
        public event EventHandler<RegisterItemViewModel> FindCommandExecuted;
        public event EventHandler<RegisterItemViewModel> LinkCommandExecuted;
        public event EventHandler<RegisterItemViewModel> UnlinkCommandExecuted;
        public event EventHandler SelectedRegisterItemChanged;
        public event EventHandler<ObjectLinkedEventArgs> ObjectLinked;
        public event EventHandler<RegisterItemAddedEventArgs> RegisterItemAdded;
        public event EventHandler<RegisterCountViewModel> RegisterCountDeleted;


        public RegisterItemListControl()
        {
            InitializeComponent();

            gvRegisterItemList.DataSource = bsRegisterItemViewModel;
            ddlLinkedStatus.SelectedIndex = 0;

            gvRegisterItemList.SetCommandColumnImageAlignment("FindColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("LinkColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("UnlinkColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("ShowObjectColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("ShowObjectColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("CreateObjectColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("DeleteColumn", ContentAlignment.MiddleCenter);
            (gvRegisterItemList.Templates[1].Columns["DeleteRhColumn"] as GridViewCommandColumn).ImageAlignment = ContentAlignment.MiddleCenter;

            gvRegisterItemList.SetColumnTimeSpanEditor("TimeStart");
            gvRegisterItemList.SetColumnTimeSpanEditor("TimeEnd");

            if (!IsDesignMode)
            {
                SetDictionaries();
            }
        }

        private void SetDictionaries()
        {
            var col = gvRegisterItemList.Templates[0].Columns["RoleCode"] as GridViewComboBoxColumn;
            col.DataSource = IpsGlobal.AnketaDictionaties.creativeRoleType;
            col.ValueMember = "CodeI";
            col.DisplayMember = "Name";
        }

        public void ExpandAll()
        {
            gvRegisterItemList.MasterTemplate.ExpandAll();
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
            else if (currentColumnName == "DeleteColumn")
            {
                if (!_allowEditList)
                    return;

                gvRegisterItemList.Rows.Remove(gvRegisterItemList.CurrentRow);
            }
            else if (currentColumnName == "DeleteRhColumn")
            {
                if (!_allowEditList)
                    return;

                var registerCount = gvRegisterItemList.CurrentRow.DataBoundItem as RegisterCountViewModel;

                gvRegisterItemList.Templates[1].Rows.Remove(gvRegisterItemList.CurrentRow);

                OnRegisterCountDeleted(registerCount);
            }
        }

        private void gvRegisterItemList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            Utilities.GridViewHelper.SetTooltipText(sender, e);
        }

        private void gvRegisterItemList_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            // yellow colour for row with automatically founded object
            var registerItem = e.RowElement.RowInfo.DataBoundItem as RegisterItemViewModel;

            if (registerItem != null)
            {
                if (registerItem.IsAuto && !e.RowElement.IsCurrent && !e.RowElement.IsSelected)
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

            // gray colour and bold font for row if it is a parent row and there is records in the register extra list
            if (bsRegisterExtra.List.Count > 0 || bsRegisterCountViewModel.List.Count > 0)
            {
                if (e.RowElement.ViewTemplate.Parent == null)
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.GradientStyle = GradientStyles.Solid;
                    e.RowElement.BackColor = Color.LightGray;
                    e.RowElement.Font = new Font(e.RowElement.Font, FontStyle.Bold);
                }
            }
        }

        private void gvRegisterItemList_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            // collapse page tabs, as in one moment only one tab must be visible (RegisterExtra or RegisterCount)
            GridDetailViewCellElement detailCell = e.CellElement as GridDetailViewCellElement;
            if (detailCell != null)
            {
                detailCell.PageViewElement.Header.Visibility = ElementVisibility.Collapsed;

                RadPageViewStripElement el = detailCell.PageViewElement as RadPageViewStripElement;
                if (el != null)
                {
                    foreach (RadPageViewItem item in el.Items)
                    {
                        item.Visibility = ElementVisibility.Collapsed;
                    }
                }
            }
        }

        private void gvRegisterItemList_SelectionChanged(object sender, EventArgs e)
        {
            OnSelectedRegisterItemChanged();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!_allowEditList)
                return;

            var newRow = gvRegisterItemList.Rows.AddNew();

            OnRegisterItemAdded(newRow.DataBoundItem as RegisterItemViewModel);

            gvRegisterItemList.CurrentRow.Cells[1].BeginEdit();
        }

        private void OnRegisterItemAdded(RegisterItemViewModel registerItem)
        {
            var args = new RegisterItemAddedEventArgs { NewRegisterItem = registerItem };

            RegisterItemAdded?.Invoke(this, args);
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
            if (!_allowFindCommand)
                return;

            using (var view = new SearchObjectView())
            {
                var presenter = new SearchObjectPresenter(view, new ipsFormsDesign.Services.RegisterService());
                presenter.Show(selectedRegisterItem);
            }

            FindCommandExecuted?.Invoke(this, selectedRegisterItem);
        }

        private void OnLinkCommandExecuted(RegisterItemViewModel selectedRegisterItem)
        {
            if (!_allowLinkCommand)
                return;

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
            if (!_allowUnlinkCommand)
                return;

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

            OnObjectLinked(selectedObject);
        }

        private void OnObjectLinked(ObjectRightMainView linkedObject)
        {
            ObjectLinked?.Invoke(this, new ObjectLinkedEventArgs { RegisterItem = SelectedRegisterItem, ObjectRight = linkedObject });
        }

        private void OnShowObjectCommandExecuted(RegisterItemViewModel selectedRegisterItem)
        {
            if (!_allowShowObjectCommand)
                return;

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
            if (!_allowCreateObjectCommand)
                return;

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

            ApplicationController.Instance.EventAggregator.PublishEvent(new ObjectRightUpdatedEvent());
        }

        private void OnSelectedRegisterItemChanged()
        {
            SelectedRegisterItemChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnRegisterCountDeleted(RegisterCountViewModel registerCount)
        {
            RegisterCountDeleted.Invoke(this, registerCount);
        }
    }

    public class RegisterItemAddedEventArgs : EventArgs
    {
        public RegisterItemViewModel NewRegisterItem { get; set; }
    }

    public class ObjectLinkedEventArgs : EventArgs
    {
        public RegisterItemViewModel RegisterItem { get; set; }
        public ObjectRightMainView ObjectRight { get; set; }
    }
}
