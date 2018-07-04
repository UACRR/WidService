using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Services;
using ipsFormsDesign.Dictionary;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class ObjectRightListControl : UserControl
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
                var service = new ObjectRightService();
                var list = service.GetMainView();
                objectRightMainViewBindingSource.DataSource = list;
            }
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

        protected virtual void OnObjectSelected(ObjectRightMainView selectedObject)
        {
            ObjectSelected(this, selectedObject);
        }

        protected virtual void OnEditCommandExecuted(ObjectRightMainView selectedObject)
        {
            EditCommandExecuted(this, selectedObject);
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
