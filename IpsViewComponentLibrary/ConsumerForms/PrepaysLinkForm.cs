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

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class PrepaysLinkForm : RadForm
    {
        private static MoneyReceived _moneyReceived;
        private static FT_TSK_1_BRMoneyPrepay _moneyPrepay;
        private static PrepaysBindingModel _prepaysBindingModel;

        private readonly bool isPrepaySumChangeNeed = false;

        private bool IsComponentEnabled
        {
            set
            {
                groupBoxTop.Enabled = value;
                groupBoxBottom.Enabled = value;
                ctrlSaveCancel.Enabled = value;
            }
        }

        public PrepaysLinkForm(MoneyReceived moneyReceived, FT_TSK_1_BRMoneyPrepay moneyPrepay)
        {
            InitializeComponent();
            IsComponentEnabled = false;
            Load += PrepaysLinkForm_Load;
            ctrlSaveCancel.SaveClck += CtrlSaveCancel_SaveClck;
            ctrlSaveCancel.ButtonSaveDialogResult = DialogResult.None;

            _moneyReceived = moneyReceived;
            _moneyPrepay = moneyPrepay;

            if (_moneyPrepay.R030 == "980")
            {
                if (_moneyPrepay.PrepaySum != _moneyPrepay.PrepaySumAuthor)
                {
                    isPrepaySumChangeNeed = true;
                    _moneyPrepay.PrepaySum = _moneyPrepay.PrepaySumAuthor;
                }

                btnChangeAmount.Enabled = false;
            }

            bsMoneyReceived.DataSource = _moneyReceived;
            bsMoneyPrepays.DataSource = _moneyPrepay;

            //txtBalance.Text = $"{moneyReceived.Amount - (moneyReceived.DestribAmount + moneyReceived.DestribPrepay):N2}";
            txtBalance.Text = $"{Balance:N2}";

            _prepaysBindingModel = new PrepaysBindingModel
            {
                LinkAmount = LinkAmount,
            };
            bsPrepaysModel.DataSource = _prepaysBindingModel;
            
            ChangeReadOnly();
        }

        private async void PrepaysLinkForm_Load(object sender, EventArgs e)
        {
            if (!isPrepaySumChangeNeed)
            {
                IsComponentEnabled = true;
                return;
            }

            var service = CalculationBRService.GetInstance();

            var data = new ChangePrepaySumParams
            {
                LicId = _moneyPrepay.LicId.Value,
                LicVersion = _moneyPrepay.LicVersion.Value,
                CustIdRH = _moneyPrepay.CustIdRH.Value,
                NewAmount = _moneyPrepay.PrepaySum.Value,
            };

            var result = await service.ChangePrepaySumAsync(data);
            if (result.HasException)
            {
                ShowMessage.ShowError(result.Exception);
                btnChangeAmount.Enabled = true;
            }

            IsComponentEnabled = true;
        }

        /// <summary>
        /// Доступний залишок платежу
        /// </summary>
        private static decimal Balance => _moneyReceived.Amount - (_moneyReceived.DestribAmount + (_moneyReceived.DestribPrepay ?? 0m));

        /// <summary>
        /// Заборгованість по авансу
        /// </summary>
        private static decimal Borg => _moneyPrepay.PrePayBorgLink ?? 0m;

        /// <summary>
        /// Сума прив'язки
        /// </summary>
        private static decimal LinkAmount
        {
            get
            {
                if (Borg != 0m)
                {
                    return Balance < Borg ? Balance : Borg;
                }
                else
                {
                    if ((_moneyPrepay.PrepaySum ?? 0m) == 0)
                        return 0m;

                    var amount = (_moneyPrepay.PrepaySum ?? 0m) - (_moneyPrepay.LinkAmount ?? 0m);

                    return Balance < amount ? Balance : amount;
                }
            }
        }

        private void ChangeReadOnly()
        {
            if (Balance == 0m || Borg == 0m && _moneyPrepay.LinkAmount == _moneyPrepay.PrepaySum)
            {
                btnChangeAmount.Enabled = false;
                ctrlSaveCancel.SaveButtonEnabled = false;
                checkAutocalculate.Enabled = false;
            }
        }

        private void checkAutocalculate_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            bool isChecked = args.ToggleState == ToggleState.On;

            if (isChecked)
                _prepaysBindingModel.LinkAmount = LinkAmount;
            
            bsPrepaysModel.ResetBindings(false);
            txtLinkAmount.ReadOnly = isChecked;
        }

        private void txtPrepaySum_TextChanged(object sender, EventArgs e)
        {
            if (!_moneyPrepay.PrepaySum.HasValue || _moneyPrepay.PrepaySum.Value == 0m)
                errorProvider.SetError(txtPrepaySum, "Необхідно заповнити суму авансу в грн!");
            else
                errorProvider.Clear();
        }

        /// <summary>
        /// Змінити суму авансу в грн
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    ShowMessage.ShowInfo("Суму в грн змінено");
                    _moneyPrepay.PrepaySum = changeAmountForm.Amount;
                }
                else
                {
                    if(result.HasException)
                        ShowMessage.ShowError(result.Exception);
                    else
                        ShowMessage.ShowError("Неможливо змінити суму в грн!");
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

            if (Balance < _prepaysBindingModel.LinkAmount.Value)
            {
                ShowMessage.ShowWarning("Сума прив'язки перевищує залишок по платежу!");
                return;
            }

            if (_prepaysBindingModel.LinkAmount.Value > _moneyPrepay.PrepaySum.Value - (_moneyPrepay.LinkAmount?? 0m))
            {
                ShowMessage.ShowWarning("Сума прив'язки перевищує допустиму суму!");
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
                PrepayType = _moneyPrepay.PrepayType,
            };

            var result = await service.SavePrepayLinkAsync(moneyPrepayLink);
            if (result.IsSuccess)
            {
                ShowMessage.ShowInfo("Платіж до авансу/паушального платежу прив'язано!");
                DialogResult = DialogResult.OK;
            }
        }
    }
}
