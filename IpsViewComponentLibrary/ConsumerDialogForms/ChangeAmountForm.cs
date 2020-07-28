using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using IpsViewComponentLibrary.DataBindingModel;
using IpsViewComponentLibrary.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class ChangeAmountForm : Telerik.WinControls.UI.RadForm
    {

        public ChangeAmountForm(decimal amount)
        {
            InitializeComponent();

            ctrlSaveCancel.ButtonSaveDialogResult = DialogResult.OK;

            bsAmount.DataSource = new ChangeAmountBindingModel(amount);
        }

        public decimal Amount
        {
            get
            {
                var model = (ChangeAmountBindingModel)bsAmount.DataSource;
                return model.Amount ?? 0m;
            }
        }
    }
}
