using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight.Reports
{
    public partial class ReportExcelForm : RadForm
    {
        private const string EmptyReportNameWarningMsg = "Введіть назву звіту!";
        private const string EmptyRegisterItemListWarningMsg = "Не додано жодного твору!";

        private ObservableListSource<RegisterItem> _datasource = new ObservableListSource<RegisterItem>();
        public bool IsManual { get; private set; }

        public object ReportNameBindingSource
        {
            get => bsRegisterName.DataSource;
            set => bsRegisterName.DataSource = value;
        }

        public bool CanEditRow
        {
            get => gvReportContentView.ReadOnly;
            set
            {
                gvReportContentView.ReadOnly = !value;
                if (!value)
                    gvReportContentView.Columns["DurationUse"].ReadOnly = true;
            }
        }

        public ReportExcelForm(Register register, bool isManual = false)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            ctrlGridRowCount.RadGridViewDataSource = gvReportContentView;
            IsManual = isManual;
            DialogResult = DialogResult.None;
            if (isManual)
            {
                ReportNameBindingSource = register;
                btn.Text = "Зберегти";
                CanEditRow = true;
                gvReportContentView.Columns["Delete"].IsVisible = true;
                btnAddRow.Visible = true;
                _datasource = register.RegisterItem;
                bindingRegItems.DataSource = _datasource;
            }
            else
            {
                if(register?.RegisterItem?.Any() ?? false)
                    bindingRegItems.DataSource = register.RegisterItem.OrderBy(rec => rec.RegIitemId);
                ReportNameBindingSource = register;
                btn.Text = "Закрити";
                txtReportPeriod.TextBoxElement.DrawBorder = false;
                txtReportPeriod.TextBoxElement.IsReadOnly = true;
                txtReportPeriod.TextBoxElement.IsReadOnlyCaretVisible = false;
                CanEditRow = false;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if(IsManual)
            {
                if (string.IsNullOrEmpty(txtReportPeriod.Text))
                {
                    MessageShow.ShowWarning(EmptyReportNameWarningMsg);
                    return;
                }

                if (!_datasource.Any())
                {
                    MessageShow.ShowWarning(EmptyRegisterItemListWarningMsg);
                    return;
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            _datasource.Add(new RegisterItem
            {
                DurationItem = TimeSpan.FromSeconds(1),
                CountUse = 1,
                DurationUse = TimeSpan.FromSeconds(1),
                CodeItem = 1,
                Ticks = 1,
                
            });
            gvReportContentView.DataSource = bindingRegItems.DataSource;
            gvReportContentView.CurrentRow = gvReportContentView.Rows.LastOrDefault();
        }

        private void gvReportContentView_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if(e.Column.FieldName == "DurationItem" || e.Column.FieldName == "CountUse")
            {
                if (e.Row?.DataBoundItem is RegisterItem item && item.DurationItem != null)
                {
                    item.DurationUse = TimeSpan.FromSeconds(item.DurationItem.Value.TotalSeconds * item.CountUse ?? default(double));
                    item.Ticks = (int) (item.DurationUse.Value.Ticks / 10000);
                }
            }
        }

        private void gvReportContentView_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (!(e?.Row?.DataBoundItem is RegisterItem item))
                return;

            _datasource.Remove(item);
            gvReportContentView.DataSource = bindingRegItems.DataSource; 
        }
    }
}
