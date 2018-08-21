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
        }

        private void ObjectRightListControl_Load(object sender, EventArgs e)
        {
            if (!IsDesignMode)
            {
                ApplicationController.Instance.EventAggregator.SubsribeEvent(this);

                SetDictionaries();

                UpdateList();
            }
        }

        private void SetDictionaries()
        {
            ddlState.SelectedValueChanged -= ddlState_SelectedValueChanged;

            var states = new[] {
                    new { CodeI = -1, Name = "Всі" },
                    new { CodeI = 0, Name = "Не підтверджені" },
                    new { CodeI = 1, Name = "Не прив'язані" },
                    new { CodeI = 2, Name = "Не розподілені" },
                };

            ddlState.SetDataSource(states);

            ddlState.SelectedValueChanged += ddlState_SelectedValueChanged;
        }

        public void UpdateList()
        {
            UpdateList(SelectedObject);
        }

        public void UpdateList(ObjectRightMainView currentObject)
        {
            var query = new ObjectRightQuery();

            query.Page = navigatorPanel.CurrentPage;
            query.PageSize = navigatorPanel.PageSize;

            if (ddlState.SelectedValue != null && (int)ddlState.SelectedValue != -1)
                query.State = (ObjectRightStates)ddlState.SelectedValue;
            if (!string.IsNullOrWhiteSpace(txtSearchObject.Text))
                query.SearchText = txtSearchObject.Text;

            var service = new ObjectRightService();
            var result = service.GetObjectRights(query);
            objectRightMainViewBindingSource.DataSource = result.List;

            navigatorPanel.TotalPages = (int) Math.Ceiling((double)result.TotalItems / (int)query.PageSize);

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

        private void ddlState_SelectedValueChanged(object sender, EventArgs e)
        {
            navigatorPanel.CurrentPage = 1;
        }

        private void navigatorPanel_CurrentPageChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void navigatorPanel_PageSizeChanged(object sender, EventArgs e)
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

        private void timerSearch_Tick(object sender, EventArgs e)
        {
            timerSearch.Stop();
            navigatorPanel.CurrentPage = 1;
        }

        private void txtSearchObject_TextChanged(object sender, EventArgs e)
        {
            timerSearch.Stop();
            timerSearch.Start();
        }
    }
}
