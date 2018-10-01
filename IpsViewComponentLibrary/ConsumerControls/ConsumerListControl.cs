using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ipsFormsDesign.ViewModels.Fixations;
using IpsViewComponentLibrary.Utilities;
using ipsFormsDesign.Data;
using ipsFormsDesign.EventAggregator;
using ipsFormsDesign.Events;
using IpsViewComponentLibrary.AppController;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.Common;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary.ConsumerControls
{ 
    public partial class ConsumerListControl : UserControl // , ISubscriber<FixationUpdatedEvent> // to fix
    {
        private ConsumerListPresenter _presenter;

        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object ConsumerDataSource
        {
            get { return bsConsumerMainView.DataSource; }
            set
            {
                if (bsConsumerMainView.DataSource != value)
                    bsConsumerMainView.DataSource = value;
            }
        }

        private ConsumerMainView _selectedConsumer;
        public ConsumerMainView SelectedConsumer
        {
            get
            {
                if (gvConsumerList.CurrentRow == null)
                    return null;

                return gvConsumerList.CurrentRow.DataBoundItem as ConsumerMainView;
            }
            set
            {
                if (_selectedConsumer != value)
                {
                    _selectedConsumer = value;

                    UpdateCurrentRow();
                }
            }
        }

        private void UpdateCurrentRow()
        {
            if (_selectedConsumer != null)
            {
                var row = gvConsumerList.Rows.FirstOrDefault(r => (int)r.Cells["CustId"].Value == _selectedConsumer.CustId);
                if (row != null)
                {
                    gvConsumerList.CurrentRow = row;
                    gvConsumerList.TableElement.ScrollToRow(row);
                }
            }
        }

        public ConsumerListControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                //ApplicationController.Instance.EventAggregator.SubsribeEvent(this); // to fix

                _presenter = new ConsumerListPresenter(this);
            }
        }

        private void ConsumerListControl_Load(object sender, EventArgs e)
        {
            gvConsumerList.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);

            if (!IsDesignMode)
            {
                UpdateList();
            }
        }

        private void gvConsumerList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            IpsViewComponentLibrary.Utilities.GridViewHelper.SetTooltipText(sender, e);
        }

        private void gvConsumerList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                OnEditCommandExecuted();
            }
        }

        private void gvConsumerList_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            OnEditCommandExecuted();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _presenter.Add();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        protected virtual void OnEditCommandExecuted()
        {
            _presenter.Edit();
        }

        private void UpdateList()
        {
            _presenter.UpdateList();
            UpdateCurrentRow();
        }

        //public void HandleEvent(FixationUpdatedEvent e) // to fix
        //{
        //    UpdateList();
        //}

        #region Search consumer

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvConsumerList.MasterTemplate.Refresh();
        }

        private void gvConsumerList_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvConsumerList.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvConsumerList.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvConsumerList.EndUpdate(false);
                return;
            }

            gvConsumerList.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvConsumerList.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearch.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
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
                gvConsumerList.EndUpdate(false);
            }
        }

        #endregion
    }
}
