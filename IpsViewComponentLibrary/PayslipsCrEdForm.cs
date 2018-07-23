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

            bsBrRegister.DataSource = _customer.Client.BrRegister.LastOrDefault();

            InitFormType(formType);
            bsSpectacleView.DataSource = spectacleViews.Where(rec => rec.CustId == _customer.CustId);
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

        private void ddlPeriod_SelectedValueChanged(object sender, EventArgs e)
        {
            _customer.Client.BrRegister.LastOrDefault().PeriodId = (int)ddlPeriod.SelectedItem.Value;
        }

        private void btnAddCheckedSpectacle_Click(object sender, EventArgs e)
        {
            _customer.Client.BrRegister.LastOrDefault()?.BrRegItem.Add(new BrRegItem());

            gvViewRl.DataSource = _customer.Client.BrRegister.LastOrDefault()?.BrRegItem;
            UpdFullSum();
        }

        private void gvViewRl_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            gvViewRl.DataSource = _customer.Client.BrRegister.LastOrDefault()?.BrRegItem.Remove(e.Row.DataBoundItem as BrRegItem);
            UpdFullSum();
        }

        private void gvViewRl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ItemName" && e.Row.DataBoundItem is BrRegItem temp)
            {
                var spectv = _spectacleViews.SingleOrDefault(rec => rec.ObjId == temp?.ObjId);

                temp.ItemName = spectv?.Name;
                temp.MusicRate = spectv?.RateMusic;
                temp.FullRate = spectv?.Rate;
            }

            if (e.Row.DataBoundItem is BrRegItem item)
            {
                item.RAmount = item.FullAmount / 100 * item.FullRate;
                item.MusicAmount = item.FullAmount / 100 * item.MusicRate;
            }

            UpdFullSum();
        }

        private void gvViewRl_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
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
