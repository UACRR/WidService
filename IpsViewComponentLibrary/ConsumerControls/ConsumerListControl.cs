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
    public partial class ConsumerListControl : UserControl, ISubscriber<ConsumerExternalUpdatedEvent>
    {
        private ConsumerListPresenter _presenter;

        public event CancelEventHandler ConsumerSelected;

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
            get { return _selectedConsumer; }                
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
                ApplicationController.Instance.EventAggregator.SubsribeEvent(this);

                _presenter = new ConsumerListPresenter(this);
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            ApplicationController.Instance.EventAggregator.UnsubscribeEvent(this);

            base.Dispose(disposing);
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

            OnConsumerSelected();
        }

        private void gvConsumerList_SelectionChanged(object sender, EventArgs e)
        {
            if (gvConsumerList.CurrentRow == null)
                SelectedConsumer = null;

            _selectedConsumer = gvConsumerList.CurrentRow.DataBoundItem as ConsumerMainView;
            // fire OnSelectedEntityChanged ivent if it is neened
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

        protected virtual void OnConsumerSelected()
        {
            if (ConsumerSelected != null)
            {
                var args = new CancelEventArgs();

                var handlers = ConsumerSelected.GetInvocationList();

                foreach (CancelEventHandler handler in handlers)
                {
                    handler(this, args);

                    if (args.Cancel)
                    {
                        return;
                    }
                }
            }

            // default behavior is editing current entity
            OnEditCommandExecuted();
        }

        private void UpdateList()
        {
            var tmp = _selectedConsumer;
            _presenter.UpdateList();
            _selectedConsumer = tmp;
            UpdateCurrentRow();
        }

        public void HandleEvent(ConsumerExternalUpdatedEvent e)
        {
            UpdateList();
        }

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
