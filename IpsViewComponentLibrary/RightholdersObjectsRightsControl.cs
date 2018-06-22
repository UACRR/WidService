using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using Telerik.WinControls.UI;
using ipsFormsDesign.Services;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary
{
    public partial class RightholdersObjectsRightsControl : UserControl
    {
        public int SelectedObjectRightId
        {
            get
            {
                if (gvRightholdersObjectsRights.CurrentRow == null)
                    return 0;

                return (gvRightholdersObjectsRights.CurrentRow.DataBoundItem as ObjectRightForRightholder).ObjId;
            }
            set
            {
                var row = gvRightholdersObjectsRights.Rows.FirstOrDefault(r => (int)r.Cells["ObjId"].Value == value);
                if (row != null)
                {
                    gvRightholdersObjectsRights.CurrentRow = row;
                }
            }
        }

        public event EventHandler<RightholderMainView> RightholderChanged = delegate { };
        public event EventHandler<int> EditObjectCommandExecuted = delegate { };

        public RightholdersObjectsRightsControl()
        {
            InitializeComponent();
        }
        
        #region gvRightholdersObjectsRights event handlers

        private void gvRightholdersObjectsRights_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                //EditObjectRight(SelectedRghtholdersObjectRightId);
                OnEditObjectCommandExecuted(SelectedObjectRightId);
            }
        }

        private void gvRightholdersObjectsRights_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            //EditObjectRight(SelectedRghtholdersObjectRightId);
            OnEditObjectCommandExecuted(SelectedObjectRightId);
        }

        #endregion

        private void ctrlRightholderSelector_RightholderChanged(object sender, RightholderMainView selectedRightholder)
        {
            UpdateRightholdersObjectsRightList();

            OnRightholderChanged(selectedRightholder);
        }

        private void ctrlRightholderSelector_ShowAnketaCommandExecuted(object sender, EventArgs e)
        {

        }

        private void UpdateRightholdersObjectsRightList(int selectedObjectId = 0)
        {
            var _objectRightService = new ObjectRightService(); // TODO: move to presenter

            var rightholdersObjectsRightsList = _objectRightService.GetRightholdersObjectsRights(ctrlRightholderSelector.Rightholder.CustId);

            objectRightForRightholderBindingSource.DataSource = rightholdersObjectsRightsList;

            if (selectedObjectId != 0)
            {
                SelectedObjectRightId = selectedObjectId;
            }
        }

        #region Raise event methods

        protected void OnRightholderChanged(RightholderMainView selectedRightholder)
        {
            RightholderChanged(this, selectedRightholder);
        }

        protected void OnEditObjectCommandExecuted(int objId)
        {
            EditObjectCommandExecuted(this, objId);
        }

        #endregion
    }
}
