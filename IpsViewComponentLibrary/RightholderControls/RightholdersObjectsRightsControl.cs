using System;
using System.Collections.Generic;
using System.Data;
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

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class RightholdersObjectsRightsControl : UserControl,
        ISubscriber<ObjectRightUpdatedEvent>
    {
        public ObjectRightForRightholder _objectRight;
        public ObjectRightForRightholder SelectedObject
        {
            get
            {
                if (gvRightholdersObjectsRights.CurrentRow == null)
                    return null;

                return gvRightholdersObjectsRights.CurrentRow.DataBoundItem as ObjectRightForRightholder;
            }
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
            get { return ctrlRightholderSelector.Rightholder; }
            set { ctrlRightholderSelector.Rightholder = value; }
        }

        public List<ObjectRightForRightholder> ObjectsRightsList
        {
            get
            {
                return objectRightForRightholderBindingSource.List.Cast<ObjectRightForRightholder>().ToList();
            }
        }

        private List<ObjectRightForRightholder> _markedObjects = new List<ObjectRightForRightholder>();
        public List<ObjectRightForRightholder> MarkedObjectsRights
        {
            get
            {
                return _markedObjects;
            }
        }

        private bool _showRightholderSelector = true;
        public bool ShowRightholderSelector
        {
            get { return _showRightholderSelector; }
            set
            {
                _showRightholderSelector = value;
                ctrlRightholderSelector.Visible = _showRightholderSelector;
            }
        }

        private bool _allowMarkingRows = false;
        public bool AllowMarkingRows
        {
            get { return _allowMarkingRows; }
            set
            {
                _allowMarkingRows = value;
                gvRightholdersObjectsRights.SetColumnVisibility("IsSelected", _allowMarkingRows);
            }
        }

        public event EventHandler<ObjectRightForRightholder> EditObjectCommandExecuted;
        public event EventHandler<RightholderMainView> RightholderChanged;
        public event CancelEventHandler RightholderChanging
        {
            add => ctrlRightholderSelector.RightholderChanging += value;
            remove => ctrlRightholderSelector.RightholderChanging -= value;
        }
        public event EventHandler<RightholderMainView> ShowAnketaCommandExetuted;
        public event EventHandler MarkedObjectsRightsChanged;

        public RightholdersObjectsRightsControl()
        {
            InitializeComponent();

            gvRightholdersObjectsRights.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);

            ApplicationController.Instance.EventAggregator.SubsribeEvent(this);

            ctrlRightholderSelector.Visible = false;
            gvRightholdersObjectsRights.SetColumnVisibility("IsSelected", false);
        }

        public void UpdateList()
        {
            UpdateList(SelectedObject);
        }

        public void UpdateList(ObjectRightForRightholder currentObject)
        {
            var service = new ObjectRightService();

            if (ctrlRightholderSelector.Rightholder != null)
            {
                var rightholdersObjectsRightsList = service.GetRightholdersObjectsRights(ctrlRightholderSelector.Rightholder.CustId);

                objectRightForRightholderBindingSource.DataSource = rightholdersObjectsRightsList;

                //SelectedObject = currentObject;
            }
            else
            {
                objectRightForRightholderBindingSource.DataSource = null;
            }
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
            if (e.Column.Name == "IsSelected")
            {
                if (e.Value != null && (bool)e.Value == true)
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

        private void ctrlRightholderSelector_RightholderChanged(object sender, RightholderMainView selectedRightholder)
        {
            UpdateList();

            OnRightholderChanged(selectedRightholder);

            _markedObjects.Clear();
            OnMarkedObjectsRightsChanged();
        }

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
            MarkedObjectsRightsChanged.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public void HandleEvent(ObjectRightUpdatedEvent e)
        {
            UpdateList();
        }
    }
}
