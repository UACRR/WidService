using IPSComponentLibrary.Extensions;
using ipsFormsDesign.CustomModel;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.Calculation
{
    public partial class ChangePeriodAmount : RadForm
    {
        private ChangePeriodAmountModel Model { get; set; }
        private readonly PaidPeriod _tempPeriod;

        public ChangePeriodAmount(PaidPeriod paidPeriod)
        {
            InitializeComponent();
            saveCancel.SaveClck += SaveCancel_SaveClck;
            saveCancel.CancelClick += SaveCancel_CancelClick;
            bindingSource.DataSource = new ChangePeriodAmountModel
            {
                OldAmount = paidPeriod.Amount,
                NewAmount = paidPeriod.Amount,
            };

            _tempPeriod = paidPeriod;
        }

        private void SaveCancel_CancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void SaveCancel_SaveClck(object sender, EventArgs e)
        {
            var item = (ChangePeriodAmountModel)bindingSource.DataSource;
            if (item.NewAmount < 0)
            {
                MessageShow.ShowWarning("Нова сума вимоги не може бути менше 0!");
                return;
            }
            if (item.NewAmount == item.OldAmount)
            {
                return;
            }

            _tempPeriod.Amount = decimal.Round(item.NewAmount, 2);
            var result = await CalculationService.GetInstance().ChangePeriodOfAmount(_tempPeriod);
            result.Message = $"Суму вимоги змінено на '{_tempPeriod.Amount:N2}'!";
            MessageShow.ShowInfoByResult(result);
            
            if (result.IsSuccess)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void txtNewAmount_Validating(object sender, CancelEventArgs e)
        {
            bool isValid = decimal.TryParse(txtNewAmount.Text, out decimal _);
            if (isValid)
                errorProvider.Clear();
            else
                errorProvider.SetError(txtNewAmount, "Число в форматі 0,00");
        }
    }
}
