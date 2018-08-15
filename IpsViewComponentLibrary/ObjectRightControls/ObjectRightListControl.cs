using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Services;
using ipsFormsDesign.Dictionary;
using Telerik.WinControls.UI;
using ipsFormsDesign.EventAggregator;
using ipsFormsDesign.Events;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class ObjectRightListControl : UserControl,
        ISubscriber<ObjectRightUpdatedEvent>
    {
        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        private ObjectRightMainView _objectRight;
        public ObjectRightMainView SelectedObject
        {
            get
            {
                if (gvObjectsRightsList.CurrentRow == null)
                    return null;

                return gvObjectsRightsList.CurrentRow.DataBoundItem as ObjectRightMainView;
            }
            set
            {
                if (_objectRight != value)
                {
                    _objectRight = value;

                    var row = gvObjectsRightsList.Rows.FirstOrDefault(r => (int)r.Cells["ObjId"].Value == _objectRight.ObjId);
                    if (row != null)
                    {
                        gvObjectsRightsList.CurrentRow = row;
                    }
                }
            }
        }

        public event EventHandler<ObjectRightMainView> ObjectSelected = delegate { };
        public event EventHandler<ObjectRightMainView> EditCommandExecuted = delegate { };

        public ObjectRightListControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                ApplicationController.Instance.EventAggregator.SubsribeEvent(this);

                var states = new[] {
                    new { CodeI = -1, Name = "Всі" },
                    new { CodeI = 0, Name = "Не підтверджені" },
                    new { CodeI = 1, Name = "Не прив'язані" },
                    new { CodeI = 2, Name = "Не розподілені" },
                };

                ddlState.SetDataSource(states);

                UpdateList();
            }
        }

        public void UpdateList()
        {
            UpdateList(SelectedObject);
        }

        public void UpdateList(ObjectRightMainView currentObject)
        {
            var query = new ObjectRightQuery();

            if (ddlState.SelectedValue != null && (int)ddlState.SelectedValue != -1)
                query.State = (ObjectRightStates)ddlState.SelectedValue;

            var service = new ObjectRightService();
            var list = service.GetObjectRights(query);
            objectRightMainViewBindingSource.DataSource = list;

            //SelectedObject = currentObject; // TODO: is it realy need?
        }

        private void gvObjectsRightsList_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            OnObjectSelected(SelectedObject);
        }

        private void gvObjectsRightsList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                OnEditCommandExecuted(SelectedObject);
            }
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void ddlState_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            UpdateList();
        }

        protected virtual void OnObjectSelected(ObjectRightMainView selectedObject)
        {
            ObjectSelected(this, selectedObject);
        }

        protected virtual void OnEditCommandExecuted(ObjectRightMainView selectedObject)
        {
            EditCommandExecuted(this, selectedObject);
        }

        public void HandleEvent(ObjectRightUpdatedEvent e)
        {
            UpdateList();
        }

        #region Search

        private void txtSearchObject_TextChanged(object sender, EventArgs e)
        {
            gvObjectsRightsList.MasterTemplate.Refresh();
        }

        private void gvObjectsRightsList_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchObject.Text))
            {
                gvObjectsRightsList.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvObjectsRightsList.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvObjectsRightsList.EndUpdate(false);
                return;
            }

            gvObjectsRightsList.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvObjectsRightsList.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearchObject.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    e.Visible = true;
                    e.Row.Cells[i].Style.CustomizeFill = true;
                    e.Row.Cells[i].Style.DrawFill = true;
                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                }
                else
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvObjectsRightsList.EndUpdate(false);
            }
        }

        #endregion
    }
}
