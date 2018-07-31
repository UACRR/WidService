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
        private IList<BigRightSpectacleView> _spectacleViews;
        private Customer _customer;

        public PayslipsCrEdForm()
        {
            InitializeComponent();
        }

        public PayslipsCrEdForm(FormType formType, Customer customer, IList<BigRightSpectacleView> spectacleViews)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;

            _customer = customer;
            _spectacleViews = spectacleViews;

            InitFormType(formType);

            bsBrRegister.DataSource = _customer.Client.BrRegister.LastOrDefault();
            bsSpectacleView.DataSource = _spectacleViews.Where(rec => rec.CustId == _customer.CustId);
            InitFormType(formType);
            var licAgr = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicClass == 1);
            var paidPeriods = licAgr?.PaidPeriod;
            bsPeriodList.DataSource = paidPeriods;
        }

        private void UpdFullSum()
        {
            var famount = default(decimal);
            var frate = default(decimal);
            foreach (var brRegItem in _customer?.Client?.BrRegister?.LastOrDefault()?.BrRegItem)
            {
                if (brRegItem.FullAmount != null) famount += (decimal) brRegItem.FullAmount;
                if (brRegItem.RAmount != null) frate += (decimal)brRegItem.RAmount;
            }

            var reg = _customer.Client.BrRegister.LastOrDefault();
            if (reg != null)
            {
                reg.FullAmount = famount;
                reg.RAmount = frate;
            }

            txtAllAmount.Text = famount.ToString("#,###0.00 грн");
            txtAllRateAmount.Text = frate.ToString("#,###0.00 грн");

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
                }
                    break;
            }
        }

        //при зміні обраного періоду
        private void ddlPeriod_SelectedValueChanged(object sender, EventArgs e)
        {
            _customer.Client.BrRegister.LastOrDefault().PeriodId = (int)ddlPeriod.SelectedItem.Value;
        }

        //додати виставу
        private void btnAddCheckedSpectacle_Click(object sender, EventArgs e)
        {
            _customer.Client.BrRegister.LastOrDefault()?.BrRegItem.Add(new BrRegItem());
            gvViewRl.DataSource = _customer.Client.BrRegister.LastOrDefault()?.BrRegItem;
            UpdFullSum();
        }

        //Натискання кнопки видалення на гріду
        private void gvViewRl_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            _customer.Client.BrRegister.LastOrDefault()?.BrRegItem.Remove(e.Row.DataBoundItem as BrRegItem);
            gvViewRl.DataSource = _customer.Client.BrRegister.LastOrDefault()?.BrRegItem;
            UpdFullSum();
        }

        //зміна значень полів гріда
        private void gvViewRl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            var item = e.Row.DataBoundItem as BrRegItem;

            if (e.Column.Name == "ItemName" &&  item !=null)
            {
                var spectv = _spectacleViews.SingleOrDefault(rec => rec.ObjId == item?.ObjId);

                item.ItemName = spectv?.Name;
                item.MusicRate = spectv?.RateMusic;
                item.FullRate = spectv?.Rate;
                item.LicId = spectv?.LicId;
            }

            if (item != null)
            {
                item.RAmount = item.FullAmount / 100 * item.FullRate;
                item.MusicAmount = item.FullAmount / 100 * item.MusicRate;
            }

            e.Row.Cells["ActCode"].Value = _spectacleViews.SingleOrDefault(rec => rec.ObjId == item?.ObjId)?.ActCode;

            UpdFullSum();
        }

        private void btnAddPeriod_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        //при переході на вкладку музичного супроводу
        private void UpdateMusicDesignData()
        {
            if(gvViewRl.Rows.Count == 0) return;
            
            var rec = gvViewRl.CurrentRow.DataBoundItem as BrRegItem;
            cName.TextValue = rec?.ItemName;
            cActCode.TextValue = _spectacleViews.SingleOrDefault(item => item.ObjId == rec?.ObjId)?.ActCode.ToString();
            cCountUse.TextValue = rec?.CountUse.ToString();
            cAmount.TextValue = rec?.FullAmount.ToString();
            cAuthorAmount.TextValue = rec?.RAmount.ToString();
            cAuthorRate.TextValue = rec?.FullRate.ToString();
            cMusAmount.TextValue = rec?.MusicAmount.ToString();
            cMusRate.TextValue = rec?.MusicRate.ToString();


            var mus = _customer.Client.LicenseAgreement.SingleOrDefault(item => item.LicId == rec?.LicId)?.LicenseBigR?.MusicalDesign;

            gvMusicDesignView.DataSource = mus;
        }

        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if(pageView.SelectedPage == pvMusicDesign)
                UpdateMusicDesignData();
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
    }
}
