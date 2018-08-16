using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace IpsViewComponentLibrary
{
    public partial class PayslipsCrEdForm : Telerik.WinControls.UI.RadForm
    {
        private int _tempRegId = 0;
        private IList<BigRightSpectacleView> _spectacleViews;
        private Customer _customer;
        private RegisterRatedList _registerRatedList;
        private ObservableListSource<PayslipsGridDataSource> _source = null;
        private FormType _type;
        public event EventHandler<List<PaidPeriod>> SavePariodCommandExecuted;

        public delegate bool SaveRegister(RegisterRatedList ratedList);
        public SaveRegister SaveRegisterMethod { get; set; }

        public PayslipsCrEdForm()
        {
            InitializeComponent();
        }

        public PayslipsCrEdForm(FormType formType, Customer customer, IList<BigRightSpectacleView> spectacleViews, RegisterRatedList registerRatedList)
        {
            InitializeComponent();
            _type = formType;
            InitFormType(_type);
            ddlPeriod.SelectedValueChanged -= ddlPeriod_SelectedValueChanged;
            DialogResult = DialogResult.None;
            //передача ссилок
            _customer = customer;
            _spectacleViews = spectacleViews;
            _registerRatedList = registerRatedList;
            //список періодів
            var licAgr = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicClass == 1);
            var paidPeriods = licAgr?.PaidPeriod;
            bsPeriodList.DataSource = paidPeriods;

            bsRegisterRatedList.DataSource = _registerRatedList;
            bsRegister.DataSource = _registerRatedList.Register;

            bsSpectacleView.DataSource = _spectacleViews.Where(rec => rec.CustId == _customer.CustId);

            ddlPeriod.SelectedValueChanged += ddlPeriod_SelectedValueChanged;
            if(ddlPeriod.Items.Any() && _type == FormType.Create)
                ddlPeriod.SelectedIndex = ddlPeriod.Items.First.Index;

            if(_registerRatedList.Register != null)
                UpdateRegisterGridDataSource();
        }

        private void UpdateRegisterGridDataSource()
        {
            _source = new ObservableListSource<PayslipsGridDataSource>();
            foreach (var register in _registerRatedList.Register)
            {
                _source.Add(new PayslipsGridDataSource
                {
                    CustId = register.CustId,
                    AuthRate = register.AuthRate,
                    MusicRate = register.MusicRate,
                    AuthAmount = register.AuthAmount,
                    MusicAmount = register.MusicAmount,
                    ObjId = register.RegisterItem.FirstOrDefault()?.ObjId,
                    ObjName = register.RegisterItem.FirstOrDefault()?.ItemName,
                    CountUse = register.RegisterItem.FirstOrDefault()?.CountUse,
                    Royalty = register.RegRoyalty,
                    TempRegId = register.RegId,
                    ActCode = _spectacleViews.SingleOrDefault(rec => rec.ObjId == register.RegisterItem.FirstOrDefault()?.ObjId)?.ActCode,
                    LicId = _spectacleViews.SingleOrDefault(rec => rec.ObjId == register.RegisterItem.FirstOrDefault()?.ObjId)?.LicId,
                });
            }

            gvViewPayslipsItems.DataSource = typeof(PayslipsGridDataSource);
            gvViewPayslipsItems.DataSource = _source;
            gvViewPayslipsItems.MasterTemplate.Refresh();
        }

        private void UpdFullSum()
        {
            var royalty = default(decimal);
            var amount = default(decimal);

            foreach (var items in gvViewPayslipsItems.Rows)
            {
                var item = items.DataBoundItem as PayslipsGridDataSource;
                royalty += (decimal?)item?.Royalty ?? 0;
                amount+=(decimal)((item?.MusicAmount + item?.AuthAmount) ?? 0);
            }
            
            lblRoyalty.Text = royalty.ToString("#,###0.00 грн");
            lblAmount.Text = amount.ToString("#,###0.00 грн");

            decimal.TryParse(txtRoyalty.Text, out decimal rlt);
            decimal.TryParse(txtAmount.Text, out decimal amnt);
            lblRoyalty.ForeColor = Math.Abs(rlt - royalty) < 0.01m ? DefaultForeColor : Color.Red;
            lblAmount.ForeColor = Math.Abs(amnt - amount) < 0.01m ? DefaultForeColor : Color.Red;

        }

        private void InitFormType(FormType type)
        {
            switch (type)
            {
                case FormType.Create:
                {
                    Text = "Новий Р/Л";
                }
                    break;
                case FormType.Edit:
                {
                    Text = "Редагування Р/Л";
                    btnAccept.Visible = true;
                }
                    break;
                case FormType.View:
                {
                    Text = "Перегляд Р/Л";
                    btnCancel.Text = "Закрити";
                    btnSave.Visible = false;
                    btnAddPeriod.Enabled = false;
                    btnAddCheckedSpectacle.Enabled = false;
                    gvViewPayslipsItems.ReadOnly = true;
                    ddlPeriod.ReadOnly = true;
                    txtAmount.ReadOnly = true;
                    txtRoyalty.ReadOnly = true;
                }
                    break;
            }
        }

        //при зміні обраного періоду
        private void ddlPeriod_SelectedValueChanged(object sender, EventArgs e)
        {
            _registerRatedList.PeriodId = (int?)ddlPeriod?.SelectedItem?.Value ?? default(int);
        }

        //додати виставу
        private void btnAddCheckedSpectacle_Click(object sender, EventArgs e)
        {
            _registerRatedList.Register.Add(new Register
            {
                RgStatus = 0,
                CustId = _customer.CustId,
                RegisterItem = new ObservableListSource<RegisterItem> { new RegisterItem
                    {
                        Ticks = 1,
                        CodeItem = 2,
                    }
                },
                RegId = _tempRegId++
            });
            UpdateRegisterGridDataSource();
        }

        //Натискання кнопки видалення на гріду
        private void gvViewPayslipsItems_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if(_type == FormType.View) return;

            var item = e.Row.DataBoundItem as PayslipsGridDataSource;
            var delitem = _registerRatedList.Register.SingleOrDefault(rec =>rec.RegId == item?.TempRegId);
           _registerRatedList.Register.Remove(delitem);
            UpdateRegisterGridDataSource();
            UpdFullSum();
        }

        //зміна значень полів гріда
        private void gvViewPayslipsItems_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if(e.Row.DataBoundItem is PayslipsGridDataSource item)
            {
                var sw = _spectacleViews.SingleOrDefault(rec => rec.ObjId == item.ObjId);
                var reg = _registerRatedList?.Register?.SingleOrDefault(rec => rec.RegId == item?.TempRegId);
                var regItem = _registerRatedList?.Register?.SingleOrDefault(rec => rec.RegId == item?.TempRegId)?.RegisterItem.SingleOrDefault();
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
                        reg.LicId = sw?.LicId;
                        //var mus = _customer?.Client?.LicenseAgreement?.SingleOrDefault(m => m.LicId == sw?.LicId)?.LicenseBigR?.MusicalDesign;

                    }
                    else if (e.Column.FieldName == "Royalty")
                    {
                        reg.RegRoyalty = item.Royalty;
                        reg.AuthAmount = (decimal?)(reg.RegRoyalty/100*reg.AuthRate);
                        reg.MusicAmount = (decimal?)(reg.RegRoyalty / 100 * reg.MusicRate);
                    }
                    else if (e.Column.FieldName == "CountUse")
                    {
                        regItem.CountUse = item.CountUse;
                    }
                }
                UpdateRegisterGridDataSource();
                UpdFullSum();
            }
        }

        private void btnAddPeriod_Click(object sender, EventArgs e)
        {
            var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicClass == 1);
            var currentAgree = license.LicenseAgrParam.SingleOrDefault(rec =>rec.LicVersion == license.LicVersion);
            CreatePeriod dialog = new CreatePeriod(license)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SavePariodCommandExecuted?.Invoke(this, license?.PaidPeriod?.ToList());
                
                //UpdateData?.Invoke(_customer.CustId);
            }
            UpdFullSum();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!_registerRatedList.Register.Any())
                ExtensionUtils.ShowInfoMessage("Не додано жодної вистави!", "Не можливо зберегти", MessageBoxIcon.Stop);
            if(_type == FormType.Create)
                foreach (var item in _registerRatedList.Register)
                {
                    item.RegId = 0;
                }
            //_registerRatedList.Period = _;
            DialogResult = DialogResult.OK;
            Close();
        }

        //при переході на вкладку музичного супроводу
        private void UpdateMusicDesignData()
        {
            if(gvViewPayslipsItems.Rows.Count == 0) return;
            
            var rec = gvViewPayslipsItems.CurrentRow.DataBoundItem as PayslipsGridDataSource;
            cName.TextValue = rec?.ObjName;
            cActCode.TextValue = _spectacleViews.SingleOrDefault(item => item.ObjId == rec?.ObjId)?.ActCode.ToString();
            cCountUse.TextValue = rec?.CountUse.ToString();
            cAmount.TextValue = rec?.Royalty.ToString();
            cAuthorAmount.TextValue = rec?.AuthAmount.ToString();
            cAuthorRate.TextValue = rec?.AuthRate.ToString();
            cMusAmount.TextValue = rec?.MusicAmount.ToString();
            cMusRate.TextValue = rec?.MusicRate.ToString();
            

            var mus = _customer.Client.LicenseAgreement.SingleOrDefault(item => item.LicId == rec?.LicId)?.LicenseBigR?.MusicalDesign;

            gvMusicDesignView.DataSource = mus;
        }

        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if(gvViewPayslipsItems?.CurrentRow == null) return;
            
            if(pageView.SelectedPage == pvMusicDesign)
                UpdateMusicDesignData();
        }

        private void txtRoyalty_Leave(object sender, EventArgs e)
        {
            UpdFullSum();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            _registerRatedList.Status = 2;
            if(SaveRegisterMethod?.Invoke(_registerRatedList) ?? false)
                ExtensionUtils.ShowInfoMessage("Розрахунковий лист погоджено!", "Успішно", MessageBoxIcon.Information);
        }
    }

    /// <summary>
    /// Тип ініціалізації форми
    /// </summary>
    public enum FormType
    {
        /// <summary>
        /// Створення нового Р/Л
        /// </summary>
        Create,
        /// <summary>
        /// Редагування Р/Л
        /// </summary>
        Edit,
        /// <summary>
        /// Перегляд
        /// </summary>
        View,
    }

    internal class PayslipsGridDataSource
    {
        public int CustId { get; set; }
        public int RmId { get; set; }
        public int? LicId { get; set; }
        public int? TempRegId { get; set; }


        public int? ObjId { get; set; }
        public string ObjName { get; set; }
        public int? ActCode { get; set; }
        public int? CountUse { get; set; }
        public decimal? Royalty { get; set; }
        
        public decimal? AuthAmount { get; set; }
        public decimal? AuthRate { get; set; }
        public decimal? MusicAmount { get; set; }
        public decimal? MusicRate { get; set; }
    }
}