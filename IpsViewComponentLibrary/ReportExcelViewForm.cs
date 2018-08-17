using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;
using Excel = Microsoft.Office.Interop.Excel;

namespace IpsViewComponentLibrary
{
    public partial class ReportExcelViewForm : Telerik.WinControls.UI.RadForm
    {
        private readonly string _filePath;
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


        public ReportExcelViewForm(Register register, bool isManual = false)
        {
            InitializeComponent();
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
                if (txtReportPeriod.Text == string.Empty)
                {
                    MessageBox.Show("Введіть назву періоду!", "Не всі поля заповнені",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }

                if (!_datasource.Any())
                {
                    MessageBox.Show("Не додано жодного твору!", "Відсутні твори в звіті", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DialogResult = DialogResult.OK;
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
                
            });
            gvReportContentView.DataSource = bindingRegItems.DataSource;
        }

        private void gvReportContentView_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.FieldName == "DurationItem" || e.Column.FieldName == "CountUse")
                if(e?.Row?.DataBoundItem is RegisterItem item && item.DurationItem != null)
                {
                    item.DurationUse = TimeSpan.FromSeconds(item.DurationItem.Value.TotalSeconds * item.CountUse ?? default(double));
                    item.Ticks = (int) (item.DurationUse.Value.Ticks / 10000);
                }
        }

        private void gvReportContentView_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e?.Row?.DataBoundItem is RegisterItem item)
            {
                _datasource.Remove(item);
                gvReportContentView.DataSource = bindingRegItems.DataSource;
            }
        }
    }
}
