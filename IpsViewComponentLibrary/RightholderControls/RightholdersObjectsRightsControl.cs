using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using Telerik.WinControls.UI;
using ipsFormsDesign.Services;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.EventAggregator;
using ipsFormsDesign.Events;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;
using System.Drawing;
using IpsViewComponentLibrary.ObjectRightControls;
using System.ComponentModel;
using System.Threading.Tasks;
using IpsCommonTypes.Wrappers;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class RightholdersObjectsRightsControl : UserControl,
        ISubscriber<ObjectRightUpdatedEvent>
    {
        public ObjectRightForRightholder _objectRight;
        public ObjectRightForRightholder SelectedObject
        {
            get => gvRightholdersObjectsRights.CurrentRow?.DataBoundItem as ObjectRightForRightholder;
            set
            {
                if (_objectRight != value)
                {
                    _objectRight = value;

                    var row = gvRightholdersObjectsRights.Rows.FirstOrDefault(r => (int)r.Cells["ObjId"].Value == _objectRight.ObjId);
                    if (row != null)
                    {
                        gvRightholdersObjectsRights.CurrentRow = row;
                        gvRightholdersObjectsRights.TableElement.ScrollToRow(row);
                    }
                }
            }
        }

        public RightholderMainView SelectedRightholder
        {
            get => ctrlRightholderSelector.Rightholder;
            set => ctrlRightholderSelector.Rightholder = value;
        }

        public RightholderMainView SelectedRightholderSecondary
        {
            get => ctrlRightholderSelectorSecondary.Rightholder;
            set => ctrlRightholderSelectorSecondary.Rightholder = value;
        }

        public List<ObjectRightForRightholder> ObjectsRightsList => objectRightForRightholderBindingSource.List.Cast<ObjectRightForRightholder>().ToList();

        private readonly List<ObjectRightForRightholder> _markedObjects = new List<ObjectRightForRightholder>();
        public List<ObjectRightForRightholder> MarkedObjectsRights => _markedObjects;

        private bool _showRightholderSelector = true;
        public bool ShowRightholderSelector
        {
            get => _showRightholderSelector;
            set
            {
                _showRightholderSelector = value;
                ctrlRightholderSelector.Visible = _showRightholderSelector;
                ctrlRightholderSelectorSecondary.Visible = _showRightholderSelector;
            }
        }

        private bool _allowMarkingRows = false;
        public bool AllowMarkingRows
        {
            get => _allowMarkingRows;
            set
            {
                _allowMarkingRows = value;
                gvRightholdersObjectsRights.SetColumnVisibility("IsSelected", _allowMarkingRows);
            }
        }

        private bool _isInheritance = false;
        public bool IsInheritance
        {
            get => _isInheritance;
            set
            {
                _isInheritance = value;
                ctrlRightholderSelectorSecondary.Visible = !_isInheritance;
            }
        }

        public event EventHandler<ObjectRightForRightholder> EditObjectCommandExecuted;
        public event EventHandler<RightholderMainView> RightholderChanged;
        public event CancelEventHandler RightholderChanging
        {
            add => ctrlRightholderSelector.RightholderChanging += value;
            remove => ctrlRightholderSelector.RightholderChanging -= value;
        }
        public event CancelEventHandler RightholderSecondaryChanging
        {
            add => ctrlRightholderSelectorSecondary.RightholderChanging += value;
            remove => ctrlRightholderSelectorSecondary.RightholderChanging -= value;
        }
        public event EventHandler<RightholderMainView> ShowAnketaCommandExetuted;
        public event EventHandler MarkedObjectsRightsChanged;

        public RightholdersObjectsRightsControl()
        {
            InitializeComponent();
            ctrlGridRowCount.RadGridViewDataSource = gvRightholdersObjectsRights;

            gvRightholdersObjectsRights.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);

            ApplicationController.Instance.EventAggregator.SubsribeEvent(this);

            ctrlRightholderSelector.Visible = false;
            ctrlRightholderSelectorSecondary.Visible = false;
            ctrlRightholderSelectorSecondary.Enabled = false;
            gvRightholdersObjectsRights.SetColumnVisibility("IsSelected", false);
        }

        #region gvRightholdersObjectsRights event handlers

        private void gvRightholdersObjectsRights_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                OnEditObjectCommandExecuted(SelectedObject);
            }
        }

        private void gvRightholdersObjectsRights_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            OnEditObjectCommandExecuted(SelectedObject);
        }

        private void gvRightholdersObjectsRights_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            Utilities.GridViewHelper.SetTooltipText(sender, e);
        }

        private void gvRightholdersObjectsRights_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (!_allowMarkingRows)
                return;

            if (e.Column.Name == "IsSelected")
            {
                if (e.Value != null && (bool)e.Value)
                {
                    _markedObjects.Add((ObjectRightForRightholder)e.Row.DataBoundItem);
                }
                else
                {
                    _markedObjects.Remove((ObjectRightForRightholder)e.Row.DataBoundItem);
                }

                OnMarkedObjectsRightsChanged();
            }
        }

        private void gvRightholdersObjectsRights_ValueChanged(object sender, EventArgs e)
        {
            gvRightholdersObjectsRights.EndEdit();
        }

        #endregion

        /// <summary>
        /// Після зміни правовласника оновити виконати оновлення контролів
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="selectedRightholder"></param>
        private void ctrlRightholderSelector_RightholderChanged(object sender, RightholderMainView selectedRightholder)
        {
            UpdateList();

            ctrlRightholderSelectorSecondary.Enabled = selectedRightholder != null;

            OnRightholderChanged(selectedRightholder);

            _markedObjects.Clear();
            OnMarkedObjectsRightsChanged();
        }

        /// <summary>
        /// Після зміни додаткового правовласника оновити виконати оновлення контролів
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctrlRightholderSelectorSecondary_RightholderChanged(object sender, RightholderMainView e)
        {
            if (e == null)
                return;

            UpdateList();

            _markedObjects.Clear();
            OnMarkedObjectsRightsChanged();
        }

        /// <summary>
        /// Оновити список об'єків права залежно від обраних правовласників
        /// </summary>
        private async void UpdateList()
        {
            var service = new ObjectRightService();

            var custId = ctrlRightholderSelector.Rightholder?.CustId;
            var custIdSecondary = ctrlRightholderSelectorSecondary.Rightholder?.CustId;

            ItemListResponse<ObjectRightForRightholder> result = null;
            
            //waitingBar.StartWaiting();
            await Task.Factory.StartNew(() =>
            {
                result = service.GetRightholdersObjectsRights(custId, custIdSecondary, navigatorPanel.Skip, navigatorPanel.Take);
            });
            //waitingBar.StopWaiting();

            objectRightForRightholderBindingSource.DataSource = result?.List;
            navigatorPanel.TotalPages = (int)Math.Ceiling((result?.TotalItems ?? 0d) / navigatorPanel.PageSize);
        }

        /// <summary>
        /// Показати анкету обраного правовласника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="selectedRighthoder"></param>
        private void ctrlRightholderSelector_ShowAnketaCommandExecuted(object sender, RightholderMainView selectedRighthoder)
        {
            OnShowAnketaCommandExetuted(selectedRighthoder);
        }

        #region Raise event methods

        protected void OnEditObjectCommandExecuted(ObjectRightForRightholder selectedObject)
        {
            if (selectedObject.Category == "M")
            {
                using (var view = new ObjectRightSrView())
                {
                    var presenter = new ObjectRightSrPresenter(view);
                    presenter.Show(selectedObject.ObjId);
                }
            }
            else
            {
                using (var view = new ObjectRightBrView())
                {
                    var presenter = new ObjectRightBrPresenter(view);
                    presenter.Show(selectedObject.ObjId);
                }
            }

            EditObjectCommandExecuted?.Invoke(this, selectedObject);
        }

        protected void OnRightholderChanged(RightholderMainView selectedRightholder)
        {
            RightholderChanged?.Invoke(this, selectedRightholder);
        }

        protected void OnShowAnketaCommandExetuted(RightholderMainView selectedRightholder)
        {
            ShowAnketaCommandExetuted?.Invoke(this, selectedRightholder);
        }

        protected void OnMarkedObjectsRightsChanged()
        {
            if (!_allowMarkingRows)
                return;

            MarkedObjectsRightsChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public void HandleEvent(ObjectRightUpdatedEvent e)
        {
            UpdateList();
        }


        private void navigatorPanel_CurrentPageChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void navigatorPanel_PageSizeChanged(object sender, EventArgs e)
        {
            navigatorPanel.CurrentPage = 1;
        }
    }
}
