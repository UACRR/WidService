using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using IpsCommonTypes.DataModels;
using IpsCommonTypes.SQLViews;
using IPSComponentLibrary.Extensions;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ConsumerDialogForms;
using IpsViewComponentLibrary.DataBindingModel;
using IpsViewComponentLibrary.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using MessageShow = IPSComponentLibrary.Extensions.MessageShow;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class PrepaysLinkForm : RadForm
    {
        private static MoneyReceived _moneyReceived;
        private static FT_TSK_1_BRMoneyPrepay _moneyPrepay;
        private static PrepaysBindingModel _prepaysBindingModel;

        public PrepaysLinkForm(MoneyReceived moneyReceived, FT_TSK_1_BRMoneyPrepay moneyPrepay)
        {
            InitializeComponent();
            ctrlSaveCancel.SaveClck += CtrlSaveCancel_SaveClck;

            _moneyReceived = moneyReceived;
            _moneyPrepay = moneyPrepay;

            bsMoneyReceived.DataSource = moneyReceived;
            bsMoneyPrepays.DataSource = moneyPrepay;

            txtBalance.Text = $"{moneyReceived.Amount - (moneyReceived.DestribAmount + moneyReceived.DestribPrepay):N2}";

            _prepaysBindingModel = new PrepaysBindingModel
            {
                LinkAmount = GetLinkAmount(),
            };
            bsPrepaysModel.DataSource = _prepaysBindingModel;
            //txtLinkAmount.Text = $"{GetLinkAmount():N2}";
        }

        private static decimal GetLinkAmount()
        {
            // доступний залишок платежу
            decimal balance = _moneyReceived.Amount - (_moneyReceived.DestribAmount + (_moneyReceived.DestribPrepay ?? 0m));
            // заборгованість по авансу
            decimal borg = _moneyPrepay.PrePayBorgLink ?? 0m;

            decimal amount = balance < borg ? balance : borg;

            return amount;
        }

        private void checkAutocalculate_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            bool isChecked = args.ToggleState == ToggleState.On;

            if (isChecked)
                _prepaysBindingModel.LinkAmount = GetLinkAmount();
            
            txtLinkAmount.ReadOnly = isChecked;
        }

        private void txtPrepaySum_TextChanged(object sender, EventArgs e)
        {
            if (!_moneyPrepay.PrepaySum.HasValue || _moneyPrepay.PrepaySum.Value == 0m)
                errorProvider.SetError(txtPrepaySum, "Необхідно заповнити суму авансу в грн!");
            else
                errorProvider.Clear();
        }

        private async void btnChangeAmount_Click(object sender, EventArgs e)
        {
            var changeAmountForm = new ChangeAmountForm(_moneyPrepay.PrepaySum ?? 0m);
            var dialogResult = changeAmountForm.ShowDialog();
            
            if (dialogResult == DialogResult.OK)
            {
                _moneyPrepay.PrepaySum = changeAmountForm.Amount;
                var service = CalculationBRService.GetInstance();

                var data = new ChangePrepaySumParams
                {
                    LicId = _moneyPrepay.LicId.Value,
                    LicVersion = _moneyPrepay.LicVersion.Value,
                    CustIdRH = _moneyPrepay.CustIdRH.Value,
                    NewAmount = changeAmountForm.Amount
                };

                var result = await service.ChangePrepaySumAsync(data);

                if (result.IsSuccess)
                {
                    ShowMessage.ShowInfo("Суму авансу в грн змінено");
                }
                else
                {
                    if(result.HasException)
                        ShowMessage.ShowError(result.Exception);
                    else
                        ShowMessage.ShowError("Неможливо змінити суму авансу в грн!");
                }
            }
        }

        private async void CtrlSaveCancel_SaveClck(object sender, EventArgs e)
        {
            if (!_prepaysBindingModel.LinkAmount.HasValue || _prepaysBindingModel.LinkAmount.Value == 0m)
            {
                ShowMessage.ShowWarning("В поле сума прив'язки необхідно ввести число!");
                return;
            }

            // доступний залишок платежу
            decimal balance = _moneyReceived.Amount - (_moneyReceived.DestribAmount + (_moneyReceived.DestribPrepay ?? 0m));
            // заборгованість по авансу

            if (balance < _prepaysBindingModel.LinkAmount.Value)
            {
                ShowMessage.ShowWarning("Сума прив'язки перевищує залишок по платежу!");
                return;
            }

            var service = CalculationBRService.GetInstance();
            
            var moneyPrepayLink = new MoneyPrepayLink
            {
                PaidId = _moneyReceived.PaidId,
                LicId = _moneyPrepay.LicId.Value,
                LicVersion = _moneyPrepay.LicVersion.Value,
                CustIdRh = _moneyPrepay.CustIdRH.Value,
                Amount = _prepaysBindingModel.LinkAmount.Value,
                //PrepayType
            };

            var result = await service.SavePrepayLink(moneyPrepayLink);
            if (result.IsSuccess)
            {
                ShowMessage.ShowInfo("Платіж до авансу прив'язано!");
                //DialogResult = DialogResult.OK;
            }
        }

    }
}
