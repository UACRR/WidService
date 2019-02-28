using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class RegisterRatedListForm : RadForm
    {
        private const string NotAddedSpectacleWarning = "Не додано жодної вистави!";
        private const string EmptyListSpectaclesWarning = "В даного користувача відсутні вистави (ліцензії) які можна додати!";

        private const string TitleTextNewRL = "Новий Р/Л";
        private const string TitleTextEditRL = "Редагування Р/Л";
        private const string TitleTextViewRL = "Перегляд Р/Л";
        private const string CancelButtonAltText = "Закрити";

        private const string MoneyStringFormat = "#,###0.00 грн";

        public event SaveAndReturnNewPeriodListEventHandler SavePariodCommandExecuted;

        private int _tempRegId = 0;
        private ObservableListSource<RegisterRatedListGridDataSource> _source;
        private readonly Customer _customer;
        private readonly RegisterRatedList _registerRatedList;
        private readonly IList<BigRightSpectacleView> _spectacleViews;
        private readonly ScopeOfUseForm _scopeOfUseForm;

        public RegisterRatedListForm(ScopeOfUseForm scopeOfUseForm, Customer customer, IList<BigRightSpectacleView> spectacleViews, RegisterRatedList registerRatedList)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            DialogResult = DialogResult.None;
            Load += RegisterRatedListForm_Load;

            _scopeOfUseForm = scopeOfUseForm;
            _customer = customer;
            _spectacleViews = spectacleViews.Where(rec => rec.LicType == 1 && rec.CustId == _customer.CustId).ToList();
            _registerRatedList = registerRatedList;

            bsSpectacleView.DataSource = _spectacleViews;

            var licAgr = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicClass == 1 && rec.LicStatus == 2);
            var paidPeriods = licAgr?.PaidPeriod;
            bsPeriodList.DataSource = paidPeriods;
            
            bsRegisterRatedList.DataSource = _registerRatedList;
            bsRegister.DataSource = _registerRatedList.Register;

            if(_scopeOfUseForm == ScopeOfUseForm.Create)
                ddlPeriod.SelectedValueChanged += ddlPeriod_SelectedValueChanged;

            if (_registerRatedList.Register != null)
                UpdateRegisterGridDataSource();

        }

        private void RegisterRatedListForm_Load(object sender, EventArgs e)
        {
            if (ddlPeriod.Items.Any() && _scopeOfUseForm == ScopeOfUseForm.Create)
                ddlPeriod.SelectedIndex = ddlPeriod.Items.First.Index;
            else if (ddlPeriod.Items.Any())
            {
                var index = ddlPeriod.Items.SingleOrDefault(rec => (int)rec?.Value == _registerRatedList.PeriodId).Index;
                ddlPeriod.SelectedIndex = index;
            }

            InitializeFormType(_scopeOfUseForm);
            UpdateFullSum();
        }

        private void InitializeFormType(ScopeOfUseForm type)
        {
            switch (type)
            {
                case ScopeOfUseForm.Create:
                    Text = TitleTextNewRL;
                    break;

                case ScopeOfUseForm.Edit:
                    Text = TitleTextEditRL;
                    ddlPeriod.ReadOnly = true;
                    break;

                case ScopeOfUseForm.View:
                    Text = TitleTextViewRL;
                    btnCancel.Text = CancelButtonAltText;
                    btnSave.Visible = false;
                    btnAddPeriod.Enabled = false;
                    btnAddCheckedSpectacle.Enabled = false;
                    gvRegisterView.ReadOnly = true;
                    ddlPeriod.ReadOnly = true;
                    txtRoyalty.ReadOnly = true;
                    txtAmount.ReadOnly = true;
                    break;
            }
        }

        private void UpdateRegisterGridDataSource()
        {
            _source = new ObservableListSource<RegisterRatedListGridDataSource>();
            foreach (var register in _registerRatedList.Register)
            {
                _source.Add(new RegisterRatedListGridDataSource
                {
                    CustId = register.CustId,
                    AuthRate = register?.AuthRate ?? 0m,
                    MusicRate = register?.MusicRate ?? 0m,
                    AuthAmount = register.AuthAmount,
                    MusicAmount = register.MusicAmount,
                    ObjId = register.RegisterItem.FirstOrDefault()?.ObjId,
                    ObjName = register.RegisterItem.FirstOrDefault()?.ItemName,
                    CountUse = register.RegisterItem.FirstOrDefault()?.CountUse,
                    Amount = register.RegAmount,
                    TempRegId = register.RegId,
                    ActCode = _spectacleViews.SingleOrDefault(rec => rec.ObjId == register.RegisterItem.FirstOrDefault()?.ObjId)?.ActCode,
                    LicId = _spectacleViews.SingleOrDefault(rec => rec.ObjId == register.RegisterItem.FirstOrDefault()?.ObjId)?.LicId,
                });
            }

            gvRegisterView.DataSource = typeof(RegisterRatedListGridDataSource);
            gvRegisterView.DataSource = _source;
            gvRegisterView.MasterTemplate.Refresh();
        }

        /// <summary>
        /// Перерахувати та перевірити суму зборів та суму авторської винагороди
        /// </summary>
        private void UpdateFullSum()
        {
            var royalty = default(decimal);
            var amount = default(decimal);

            foreach (var items in gvRegisterView.Rows)
            {
                var item = items.DataBoundItem as RegisterRatedListGridDataSource;
                amount += item?.Amount ?? 0m;
                royalty += (item?.MusicAmount ?? 0m) + (item?.AuthAmount ?? 0m);
            }
            
            lblRoyalty.Text = amount.ToString(MoneyStringFormat);
            lblAmount.Text = royalty.ToString(MoneyStringFormat);

            decimal.TryParse(txtAmount.Text, out decimal amnt);
            decimal.TryParse(txtRoyalty.Text, out decimal rlt );
            lblAmount.ForeColor = Math.Round(rlt, 2) == Math.Round(royalty, 2) ? DefaultForeColor : Color.Red;
            lblRoyalty.ForeColor = Math.Round(amnt,2) == Math.Round(amount, 2) ? DefaultForeColor : Color.Red;
        }

        // при зміні обраного періоду
        private void ddlPeriod_SelectedValueChanged(object sender, EventArgs e)
        {
            _registerRatedList.PeriodId = (int?)ddlPeriod?.SelectedItem?.Value ?? default(int);
        }

        // додати виставу
        private void btnAddCheckedSpectacle_Click(object sender, EventArgs e)
        {
            if (!_spectacleViews.Any())
            {
                MessageShow.ShowWarning(EmptyListSpectaclesWarning);
                return;
            }

            _registerRatedList.Register.Add(new Register
            {
                RgStatus = 0,
                CustId = _customer.CustId,
                LicId = default(int),
                
                RegisterItem = new ObservableListSource<RegisterItem>
                {
                    new RegisterItem
                    {
                        CategoryCode = 6,
                        Ticks = 1,
                        CodeItem = 2,
                    }
                },
                RegId = _tempRegId++,
            });
            UpdateRegisterGridDataSource();
        }

        // додати період
        private void btnAddPeriod_Click(object sender, EventArgs e)
        {
            var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicClass == 1);
            var dialog = new CreatePeriod(license)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var paidPeriodList = license?.PaidPeriod?.ToList();
                var periodlist = SavePariodCommandExecuted?.Invoke(_customer.CustId, paidPeriodList)?.Where(lId => lId.LicId == license?.LicId).ToList();
                if (periodlist != null)
                {
                    foreach (var period in paidPeriodList?.Where(rec => rec.PeriodId == 0)?.ToList())
                    {
                        period.SetFields(periodlist.SingleOrDefault(rec => rec.PeriodName == period.PeriodName));
                    }
                }
                bsPeriodList.ResetBindings(false);
            }
            UpdateFullSum();
        }

        // зберегти розрахунковий лист
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_registerRatedList.Register.Any())
            {
                MessageShow.ShowWarning(NotAddedSpectacleWarning);
                return;
            }

            if (_scopeOfUseForm == ScopeOfUseForm.Create)
                foreach (var item in _registerRatedList.Register)
                {
                    item.RegId = 0;
                }

            DialogResult = DialogResult.OK;
            Close();
        }

        // натискання кнопки [видалення] на гріду
        private void gvRegisterView_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if(_scopeOfUseForm == ScopeOfUseForm.View)
                return;

            var item = e.Row.DataBoundItem as RegisterRatedListGridDataSource;
            var delitem = _registerRatedList.Register.SingleOrDefault(rec =>rec.RegId == item?.TempRegId);
            _registerRatedList.Register.Remove(delitem);
            UpdateRegisterGridDataSource();
            UpdateFullSum();
        }

        // зміна значень полів гріда
        private void gvRegisterView_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (!(e.Row.DataBoundItem is RegisterRatedListGridDataSource item))
                return;

            var sw = _spectacleViews.SingleOrDefault(rec => rec.ObjId == item.ObjId);
            var reg = _registerRatedList?.Register?.SingleOrDefault(rec => rec.RegId == item.TempRegId);
            var regItem = _registerRatedList?.Register?.SingleOrDefault(rec => rec.RegId == item.TempRegId)?.RegisterItem.SingleOrDefault();
            if (reg != null && regItem != null)
            {
                if (e.Column.FieldName == "ObjId")
                {
                    regItem.ItemName = sw?.Name;
                    regItem.ObjId = sw?.ObjId;
                    item.ActCode = sw?.ActCode;
                    reg.AuthRate = sw?.Rate;
                    reg.MusicRate = sw?.RateMusic;
                    item.LicId = sw?.LicId;
                    reg.LicId = (sw?.LicId ?? default(int));
                    //var mus = _customer?.Client?.LicenseAgreementChange?.SingleOrDefault(m => m.LicId == sw?.LicId)?.LicenseBigR?.MusicalDesign;
                }
                else if (e.Column.FieldName == "Amount")
                {
                    reg.RegAmount = item.Amount;
                    reg.AuthAmount = reg.RegAmount / 100 * reg.AuthRate;
                    reg.MusicAmount = reg.RegAmount / 100 * reg.MusicRate;
                }
                else if (e.Column.FieldName == "CountUse")
                {
                    regItem.CountUse = item.CountUse;
                }
            }
            UpdateRegisterGridDataSource();
            UpdateFullSum();
        }

        // при переході на вкладку музичного супроводу
        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if(!(gvRegisterView.CurrentRow.DataBoundItem is RegisterRatedListGridDataSource item))
                return;

            if (pageView.SelectedPage == pvMusicDesign)
            {
                cName.TextValue = item.ObjName;
                cActCode.TextValue = _spectacleViews.SingleOrDefault(rec => rec.ObjId == item.ObjId)?.ActCode.ToString();
                cCountUse.TextValue = item.CountUse.ToString();
                cAmount.TextValue = item.Amount.ToString();
                cAuthorAmount.TextValue = item.AuthAmount.ToString();
                cAuthorRate.TextValue = item.AuthRate.ToString();
                cMusAmount.TextValue = item.MusicAmount.ToString();
                cMusRate.TextValue = item.MusicRate.ToString();

                var mus = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId)?.LicenseBigR?.MusicalDesign;
                gvMusicDesignView.DataSource = mus;
            }
        }

        private void txtRoyalty_Leave(object sender, EventArgs e)
        {
            UpdateFullSum();
        }
    }

    internal class RegisterRatedListGridDataSource
    {
        public int CustId { get; set; }
        public int RmId { get; set; }
        public int? LicId { get; set; }
        public int? TempRegId { get; set; }

        public int? ObjId { get; set; }
        public string ObjName { get; set; }
        public int? ActCode { get; set; }
        public int? CountUse { get; set; }
        public decimal? Amount { get; set; }
        
        public decimal? AuthAmount { get; set; }
        public decimal? AuthRate { get; set; }
        public decimal? MusicAmount { get; set; }
        public decimal? MusicRate { get; set; }
    }
}