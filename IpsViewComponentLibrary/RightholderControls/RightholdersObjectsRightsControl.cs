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

        public event EventHandler<ObjectRightForRightholder> EditObjectCommandExecuted = delegate { };
        public event EventHandler<RightholderMainView> RightholderChanged = delegate { };
        public event EventHandler<RightholderMainView> ShowAnketaCommandExetuted = delegate { };

        public RightholdersObjectsRightsControl()
        {
            InitializeComponent();

            gvRightholdersObjectsRights.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);

            ApplicationController.Instance.EventAggregator.SubsribeEvent(this);

            ctrlRightholderSelector.Visible = false;
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

                SelectedObject = currentObject;
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

        #endregion

        private void ctrlRightholderSelector_RightholderChanged(object sender, RightholderMainView selectedRightholder)
        {
            UpdateList();

            OnRightholderChanged(selectedRightholder);
        }

        private void ctrlRightholderSelector_ShowAnketaCommandExecuted(object sender, RightholderMainView selectedRighthoder)
        {
            OnShowAnketaCommandExetuted(selectedRighthoder);
        }

        #region Raise event methods

        protected void OnEditObjectCommandExecuted(ObjectRightForRightholder selectedObject)
        {
            EditObjectCommandExecuted(this, selectedObject);
        }

        protected void OnRightholderChanged(RightholderMainView selectedRightholder)
        {
            RightholderChanged(this, selectedRightholder);
        }

        protected void OnShowAnketaCommandExetuted(RightholderMainView selectedRightholder)
        {
            ShowAnketaCommandExetuted(this, selectedRightholder);
        }

        #endregion

        public void HandleEvent(ObjectRightUpdatedEvent e)
        {
            UpdateList();
        }
    }
}
