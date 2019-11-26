using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IPSComponentLibrary.Extensions;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.Reports.Forms
{
    public partial class ReportExcelForm : RadForm
    {
        private const string EmptyReportNameWarningMsg = "Введіть назву звіту!";
        private const string EmptyRegisterItemListWarningMsg = "Не додано жодного твору!";

        private readonly ObservableListSource<RegisterItem> _datasource = new ObservableListSource<RegisterItem>();
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

            RemoveEmptyRecord(_datasource);

            if (!CheckDoubleRecord(_datasource))
            {
                DialogResult = DialogResult.OK;
            }
        }

        private const string WarningMsg = "Неможливо обробити звіт! В звіті наявні дублі (поля: назва твору, виконавець, автор музики, автор тексту)!";
        private const string EmptyRecordFoundMsg = "Знайдені записи з пустими полями \"назва твору\", \"виконавець\", \"автор музики\" та \"автор тексту\"! Такі записи будуть видалені автомаично!";

        private static void RemoveEmptyRecord(ICollection<RegisterItem> items)
        {
            ICollection<RegisterItem> removeListCollection = items.Where(rec =>
            {
                return string.IsNullOrWhiteSpace(rec.ItemName) &&
                       string.IsNullOrWhiteSpace(rec.Performer) &&
                       string.IsNullOrWhiteSpace(rec.AuthorMusic) &&
                       string.IsNullOrWhiteSpace(rec.AuthorText);
            }).ToList();

            if (removeListCollection.Any())
                MessageShow.ShowInfo(EmptyRecordFoundMsg);

            foreach (var registerItem in removeListCollection)
                items.Remove(registerItem);
        }

        public static bool CheckDoubleRecord(ICollection<RegisterItem> items)
        {
            var arrayItems = items.ToArray();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                var remainsList = arrayItems.Skip(i + 1).ToArray();
                foreach (var registerItem in remainsList)
                {
                    var eqItemName = string.Equals(registerItem.ItemName, arrayItems[i].ItemName, StringComparison.CurrentCultureIgnoreCase);
                    var eqPerformer = string.Equals(registerItem.Performer, arrayItems[i].Performer, StringComparison.CurrentCultureIgnoreCase);
                    var eqAuthorMusic = string.Equals(registerItem.AuthorMusic, arrayItems[i].AuthorMusic, StringComparison.CurrentCultureIgnoreCase);
                    var eqAuthorText = string.Equals(registerItem.AuthorText, arrayItems[i].AuthorText, StringComparison.CurrentCultureIgnoreCase);
                    if (eqItemName && eqPerformer && eqAuthorMusic && eqAuthorText)
                    {
                        MessageShow.ShowWarning(WarningMsg);
                        return true;
                    }
                }
            }

            return false;
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
