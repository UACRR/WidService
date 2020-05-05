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
using IPSViewComponentLibraryWPF.IPSExtensions;

namespace IpsViewComponentLibrary.RegisterControls
{
    public partial class RegisterItemListControl : UserControl
    {
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public object DataSource
        {
            get => bsRegisterItemViewModel.DataSource;
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
            get => bsRegisterExtra.DataSource;
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

        private RegisterItemViewModel _selectedRegisterItem;
        public RegisterItemViewModel SelectedRegisterItem
        {
            get => _selectedRegisterItem;
            set
            {
                _selectedRegisterItem = value;
                OnSelectedRegisterItemChanged();
            }
        }

        public Collection<RegisterItemViewModel> SelectedRegisterItems
        {
            get
            {
                var registerItemsList = new Collection<RegisterItemViewModel>();

                foreach (GridViewRowInfo row in gvRegisterItemList.SelectedRows)
                {

                    if (row.DataBoundItem is RegisterItemViewModel registerItem)
                        registerItemsList.Add(registerItem);
                }

                return registerItemsList;
            }
        }

        private bool _allowEditList = false;
        public bool AllowEditList
        {
            get => _allowEditList;
            set
            {
                _allowEditList = value;

                panelCommand.Visible = _allowEditList;
                gvRegisterItemList.SetColumnVisibility("DeleteColumn", _allowEditList);
                gvRegisterItemList.SetColumnReadOnly("ItemName", !_allowEditList);
                gvRegisterItemList.SetColumnReadOnly("Performer", !_allowEditList);
                gvRegisterItemList.SetColumnReadOnly("AuthorMusic", !_allowEditList);
                gvRegisterItemList.SetColumnReadOnly("AuthorText", !_allowEditList);
                gvRegisterItemList.SetColumnReadOnly("DurationItem", !_allowEditList);
                gvRegisterItemList.SetColumnReadOnly("CountUse", !_allowEditList);
            }
        }

        public bool AllowActionRegisterItem { get; set; } = true;

        private bool _allowFindCommand = true;
        public bool AllowFindCommand
        {
            get => _allowFindCommand;
            set
            {
                _allowFindCommand = value;
                gvRegisterItemList.SetColumnVisibility("FindColumn", _allowFindCommand);
            }
        }

        private bool _allowShowDurationItem;
        public bool AllowShowDurationItem
        {
            get => _allowShowDurationItem;
            set
            {
                _allowShowDurationItem = value;
                gvRegisterItemList.SetColumnVisibility("DurationItem", value);
            }
        }

            private bool _allowShowDeleteCommand = true;
        /// <summary>
        /// Видимість командної кнопки "Видалити"
        /// </summary>
        public bool AllowShowDeleteCommand
        {
            get => _allowShowDeleteCommand;
            set
            {
                _allowShowDeleteCommand = value;
                gvRegisterItemList.SetColumnVisibility("DeleteColumn", _allowShowDeleteCommand);
                var registerCount = gvRegisterItemList.Templates[1];
                if( !registerCount.Columns.Contains("DeleteRhColumn") )
                    return;
                registerCount.Columns["DeleteRhColumn"].IsVisible = _allowShowDeleteCommand;
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
            get => _showObjectInfo;
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
            get => _showObjectInfo;
            set
            {
                _showAuthors = value;

                gvRegisterItemList.SetColumnVisibility("Performer", _showAuthors);
                gvRegisterItemList.SetColumnVisibility("AuthorMusic", _showAuthors);
                gvRegisterItemList.SetColumnVisibility("AuthorText", _showAuthors);
            }
        }

        private bool _showGenre = false;
        public bool ShowGenre
        {
            get => _showGenre;
            set
            {
                _showGenre = value;
                gvRegisterItemList.SetColumnVisibility("Genre", _showGenre);

                gvRegisterItemList.SetColumnVisibility("DurationItem", !_showGenre);
                gvRegisterItemList.SetColumnVisibility("CountUse", !_showGenre);
                gvRegisterItemList.SetColumnVisibility("DurationUse", !_showGenre);
            }
        }

        private bool _showGenreAndRate = false;
        public bool ShowGenreAndRate
        {
            get => _showGenreAndRate;
            set
            {
                _showGenreAndRate = value;
                gvRegisterItemList.SetColumnVisibility("Genre", _showGenreAndRate);
                gvRegisterItemList.SetColumnVisibility("Rate", _showGenreAndRate);

                gvRegisterItemList.SetColumnVisibility("DurationItem", !_showGenreAndRate);
                gvRegisterItemList.SetColumnVisibility("DurationUse", !_showGenreAndRate);
            }
        }

        private bool _showTimeStartEnd;
        public bool ShowTimeStartEnd
        {
            get => _showTimeStartEnd;
            set
            {
                _showTimeStartEnd = value;
                gvRegisterItemList.SetColumnVisibility("TimeStart", _showTimeStartEnd);
                gvRegisterItemList.SetColumnVisibility("TimeEnd", _showTimeStartEnd);
            }
        }

        private bool _showFilters = true;
        public bool ShowFilters
        {
            get => _showFilters;
            set
            {
                _showFilters = value;
                panelFilters.Visible = _showFilters;
            }
        }

        public bool ShowObjectDuration
        {
            set => gvRegisterItemList.SetColumnVisibility("ObjectDuration", value);
        }
        
        public bool ShowObjectSource
        {
            set => gvRegisterItemList.SetColumnVisibility("ObjectSource", value);
        }

        public RegisterItemListMode Mode { get; set; } = RegisterItemListMode.Default;

        public event EventHandler<RegisterItemViewModel> ShowObjectCommandExecuted;
        public event EventHandler<RegisterItemViewModel> CreateObjectCommandExecuted;
        public event EventHandler<RegisterItemViewModel> FindCommandExecuted;
        public event EventHandler<RegisterItemViewModel> LinkCommandExecuted;
        public event EventHandler<RegisterItemViewModel> UnlinkCommandExecuted;
        public event EventHandler SelectedRegisterItemChanged;
        public event EventHandler<ObjectLinkedEventArgs> ObjectLinked;
        public event EventHandler<RegisterItemAddedEventArgs> RegisterItemAdded;
        public event EventHandler<RegisterCountViewModel> RegisterCountDeleted;
        public event EventHandler<CancelEventArgs> RegisterItemListValidating;
        public event EventHandler<RowValidatingEventArgs> RegisterItemRowValidating;

        public RegisterItemListControl()
        {
            InitializeComponent();

            gvRegisterItemList.DataSource = bsRegisterItemViewModel;
            ddlLinkedStatus.SelectedIndex = 0;

            gvRegisterItemList.SubscribeToolTipTextNeeded();

            gvRegisterItemList.SetCommandColumnImageAlignment("FindColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("LinkColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("UnlinkColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("ShowObjectColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("ShowObjectColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("CreateObjectColumn", ContentAlignment.MiddleCenter);
            gvRegisterItemList.SetCommandColumnImageAlignment("DeleteColumn", ContentAlignment.MiddleCenter);
            (gvRegisterItemList.Templates[1].Columns["DeleteRhColumn"] as GridViewCommandColumn).ImageAlignment = ContentAlignment.MiddleCenter;

            ShowTimeStartEnd = false;
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

        private void GvRegisterItemList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (!AllowActionRegisterItem)
                return;

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

        public void ResetErrorText()
        {
            foreach( var row in gvRegisterItemList.Rows )
            {
                row.Cells["ObjectName"].ErrorText = "";
            }
        }

        public void SetErrorForUnlinkRows( string errTxt )
        {
            foreach (var row in gvRegisterItemList.Rows)
            {
                if( (row.DataBoundItem as RegisterItemViewModel)?.ObjId == null )
                    row.Cells["ObjectName"].ErrorText = errTxt;
            }
        }

        public int GetCountUnlink()
        {
            var cnt = gvRegisterItemList.Rows.Count(rec => (rec.DataBoundItem as RegisterItemViewModel)?.ObjId == null);
            return cnt;
        }

        private void GvRegisterItemList_RowFormatting(object sender, RowFormattingEventArgs e)
        {

            if (e.RowElement.RowInfo.DataBoundItem is RegisterItemViewModel registerItem)
            {
                if (!e.RowElement.IsCurrent && !e.RowElement.IsSelected)
                {
                    // yellow colour for row with automatically founded object
                    if (registerItem.IsAuto)
                    {
                        e.RowElement.DrawFill = true;
                        e.RowElement.GradientStyle = GradientStyles.Solid;
                        e.RowElement.BackColor = Color.LemonChiffon;
                    }
                    // gray colour and bold font for row if it is a parent row and there is records in the register extra list
                    else if (bsRegisterExtra.List.Count > 0 || bsRegisterCountViewModel.List.Count > 0)
                    {
                        if (e.RowElement.ViewTemplate.Parent == null)
                        {
                            e.RowElement.Font = new Font(e.RowElement.Font, FontStyle.Bold);
                            e.RowElement.DrawFill = true;
                            e.RowElement.GradientStyle = GradientStyles.Solid;
                            e.RowElement.BackColor = Color.LightGray;
                        }
                    }
                    // clear row format
                    else
                    {
                        e.RowElement.DrawFill = true;
                        e.RowElement.GradientStyle = GradientStyles.Solid;
                        e.RowElement.BackColor = Color.White;
                    }
                }
                else
                {
                    e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                    e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                    e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                    e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                }
            }
        }

        private void GvRegisterItemList_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Utilities.GridViewHelper.DisplayErrors(sender, e);
        }

        private void GvRegisterItemList_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            // collapse page tabs, as in one moment only one tab must be visible (RegisterExtra or RegisterCount)
            if (e.CellElement is GridDetailViewCellElement detailCell)
            {
                detailCell.PageViewElement.Header.Visibility = ElementVisibility.Collapsed;

                if (detailCell.PageViewElement is RadPageViewStripElement el)
                {
                    foreach (RadPageViewItem item in el.Items)
                    {
                        item.Visibility = ElementVisibility.Collapsed;
                    }
                }
            }
        }

        private void GvRegisterItemList_SelectionChanged(object sender, EventArgs e)
        {
            if (gvRegisterItemList.CurrentRow == null)
                return;

            if (gvRegisterItemList.CurrentRow.DataBoundItem is RegisterItemViewModel registerItem)
            {
                SelectedRegisterItem = registerItem;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
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

        private void DdlLinkedStatus_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            SetFilter(ddlLinkedStatus.SelectedIndex);
        }

        /// <summary>
        /// Відфільтрувати об'єкти
        /// </summary>
        /// <param name="linkedStatus"></param>
        private void SetFilter(int linkedStatus)
        {
            if (linkedStatus == 1)
                gvRegisterItemList.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
            else if (linkedStatus == 2)
                gvRegisterItemList.FilterDescriptors.LogicalOperator = FilterLogicalOperator.And;

            gvRegisterItemList.FilterDescriptors.Clear();

            if (linkedStatus != 0)
            {
                var filterByObjId = new FilterDescriptor
                {
                    PropertyName = "ObjId",
                    Operator = linkedStatus == 1 ? FilterOperator.IsNotEqualTo : FilterOperator.IsEqualTo,
                    Value = null,
                    IsFilterEditor = true
                };
                gvRegisterItemList.FilterDescriptors.Add(filterByObjId);

                var filterByWic = new FilterDescriptor
                {
                    PropertyName = "Wic",
                    Operator = linkedStatus == 1 ? FilterOperator.IsNotEqualTo : FilterOperator.IsEqualTo,
                    Value = null,
                    IsFilterEditor = true
                };
                gvRegisterItemList.FilterDescriptors.Add(filterByWic);
            }
        }

        /// <summary>
        /// Прив'язати за не строгим пошуком (лупа)
        /// </summary>
        /// <param name="selectedRegisterItem"></param>
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

        /// <summary>
        /// Прив'язати за строгим пошуком 
        /// </summary>
        /// <param name="selectedRegisterItem"></param>
        private void OnLinkCommandExecuted(RegisterItemViewModel selectedRegisterItem)
        {
            if (!_allowLinkCommand)
                return;

            LinkCommandExecuted?.Invoke(this, selectedRegisterItem);

            using (var selectionView = new ObjectRightSelectionExtendedView())
            {
                selectionView.RegisterItemViewModel = selectedRegisterItem;
                if (selectionView.ShowDialog() == DialogResult.OK)
                {
                    SelectedRegisterItem.SetObjectData(selectionView.ObjectRight);
                }
            }
        }

        /// <summary>
        /// Відв'язати прив'язаний об'єкт
        /// </summary>
        /// <param name="selectedRegisterItem"></param>
        private void OnUnlinkCommandExecuted(RegisterItemViewModel selectedRegisterItem)
        {
            if (!_allowUnlinkCommand)
                return;

            UnlinkCommandExecuted?.Invoke(this, selectedRegisterItem);

            selectedRegisterItem.ClearObjectData();
        }

        private void BsRegisterItemViewModel_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged && e.PropertyDescriptor.Name == "ObjId")
            {
                var registerItem = bsRegisterItemViewModel.List[e.NewIndex] as RegisterItemViewModel;

                if (registerItem.ObjId.HasValue)
                    OnObjectLinked(registerItem, registerItem.ObjId.Value);
            }
        }

        private void OnObjectLinked(RegisterItemViewModel registerItem, int objId)
        {
            ObjectLinked?.Invoke(this, new ObjectLinkedEventArgs { RegisterItem = registerItem, ObjId = objId });
        }

        /// <summary>
        /// Показати прив'язаний об'єкт
        /// </summary>
        /// <param name="selectedRegisterItem"></param>
        private void OnShowObjectCommandExecuted(RegisterItemViewModel selectedRegisterItem)
        {
            if (!_allowShowObjectCommand)
                return;

            ShowObjectCommandExecuted?.Invoke(this, selectedRegisterItem);

            if (selectedRegisterItem.ObjId.HasValue)
            {
                using (var view = new ObjectRightSrView())
                {
                    var presenter = new ObjectRightSrPresenter(view);
                    presenter.Show(selectedRegisterItem.ObjId.Value);
                }
            }
            else if (selectedRegisterItem.Wic.HasValue)
            {
                using (var viewWid = new ObjectRightWIDView())
                {
                    viewWid.LoadData(selectedRegisterItem.Wic.Value);
                    viewWid.ShowDialog();
                }
            }
        }

        private async void OnCreateObjectCommandExecuted(RegisterItemViewModel selectedRegisterItem)
        {
            if (!_allowCreateObjectCommand)
                return;

            if(selectedRegisterItem.ObjId != null )
            {
                MessageBox.Show("Неможливо створити об'єкт який прив'язано", "Створення об'єкта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var service = ipsFormsDesign.Services.ObjectRightService.GetInstance();
            
            var isUnique = await service.CheckUniqueObject(selectedRegisterItem);
            if (!isUnique)
            {
                string message = $"Можливий дубль об'єкта права! Об'єкт права з назвою «{selectedRegisterItem.ItemName}» наявний в системі!\nРекомендовано створити об'єкт права вручну та прив'язати або прив'язати існуючий.";
                ShowMessage.ShowWarning(message);
                return;
            }

            CreateObjectCommandExecuted?.Invoke(this, selectedRegisterItem);

            var newObject = service.New(5);
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

        private void OnRegisterItemListValidating(object sender, CancelEventArgs e)
        {
            RegisterItemListValidating?.Invoke(sender, e);
        }

        private void OnRegisterItemRowValidating(object sender, RowValidatingEventArgs e)
        {
            RegisterItemRowValidating?.Invoke(sender, e);
        }

        #region Validation

        private void GvRegisterItemList_Validating(object sender, CancelEventArgs e)
        {
            OnRegisterItemListValidating(sender, e);
        }

        private void GvRegisterItemList_RowValidating(object sender, RowValidatingEventArgs e)
        {
            // this event is for register item validation only (not reg. count ang reg. fix)
            if (e.Row.ViewTemplate == gvRegisterItemList.MasterTemplate)
                OnRegisterItemRowValidating(sender, e);
        }

        #endregion
    }

    public enum RegisterItemListMode
    {
        Default = 0,
        RightholderIdentification = 1,
    }

    public class RegisterItemAddedEventArgs : EventArgs
    {
        public RegisterItemViewModel NewRegisterItem { get; set; }
    }

    public class ObjectLinkedEventArgs : EventArgs
    {
        public RegisterItemViewModel RegisterItem { get; set; }
        public int ObjId { get; set; }
    }
}
