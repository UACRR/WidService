using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetPayments : UserControl
    {
        private DateTime? _dateBegin = null, _dateEnd = null;

        public MiddleControlCabinetPayments()
        {
            InitializeComponent();
            SetFilterValues();
        }

        private void Filter(PaymentFilter filter)
        {
            if(filter == PaymentFilter.None) return;

            switch (filter)
            {
                case PaymentFilter.None:
                    return;
                case PaymentFilter.All:
                {

                }
                    break;
                case PaymentFilter.Remainder:
                {

                }
                    break;
                case PaymentFilter.Usage:
                {

                }
                    break;
            }

            if (DateFilterEnable)
            {
                if (_dateBegin == null && _dateEnd == null)
                {

                }
                else if (_dateBegin != null && _dateEnd == null)
                {

                }
                else if (_dateBegin == null && _dateEnd != null)
                {

                }
                else if (_dateBegin != null && _dateEnd != null)
                {


                }
            }
            else
            {

            }
        }

        private void Filter(UsageFilter filter)
        {
            switch (filter)
            {
                case UsageFilter.None:
                    return;
                case UsageFilter.All:
                {

                }
                    break;
                case UsageFilter.Periods:
                {

                }
                    break;
                case UsageFilter.Avances:
                {

                }
                    break;
            }
        }

        //додати в випадаючі списки значення для фільтрів
        private void SetFilterValues()
        {
            //елементи для фільтра платежів
            ddlFirstFilter.Items.Add(new RadListDataItem
            {
                Text = "Всі",
                Value = PaymentFilter.All
            });
            ddlFirstFilter.Items.Add(new RadListDataItem
            {
                Text = "Залишок",
                Value = PaymentFilter.Remainder
            });
            ddlFirstFilter.Items.Add(new RadListDataItem
            {
                Text = "Використані",
                Value = PaymentFilter.Usage
            });

            //елементи для фільтра "використано"
            ddlSecondFilter.Items.Add(new RadListDataItem
            {
                Text = "Всі",
                Value = UsageFilter.All
            });
            ddlSecondFilter.Items.Add(new RadListDataItem
            {
                Text = "Періоди",
                Value = UsageFilter.Periods
            });
            ddlSecondFilter.Items.Add(new RadListDataItem
            {
                Text = "Аванси",
                Value = UsageFilter.Avances
            });
        }

        /// <summary>
        /// Індикатор чи використовується фільтр по датах
        /// </summary>
        public bool DateFilterEnable
        {
            get => checkDateFilterEnable.Checked;
            private set
            {
                lblBegin.Enabled = value;
                lblEnd.Enabled = value;
                dtDateBegin.Enabled = value;
                dtDateEnd.Enabled = value;
            }
        }

        private void checkDateFilterEnable_CheckStateChanged(object sender, EventArgs e)
        {
            DateFilterEnable = (sender as RadCheckBox)?.Checked ?? false;
        }

        private void ddlFirstFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            Filter((PaymentFilter)((sender as RadDropDownList)?.SelectedItem.Value ?? PaymentFilter.None));
        }

        private void ddlSecondFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            Filter((UsageFilter)((sender as RadDropDownList)?.SelectedItem.Value ?? UsageFilter.None));
        }

        private void dtDateBegin_ValueChanged(object sender, EventArgs e)
        {
            _dateBegin = (sender as RadDateTimePicker)?.Value;
        }

        private void dtDateEnd_ValueChanged(object sender, EventArgs e)
        {
            _dateEnd = (sender as RadDateTimePicker)?.Value;
        }
    }

    /// <summary>
    /// Фільтр платежів 
    /// </summary>
    internal enum PaymentFilter
    {
        /// <summary>
        /// Empty
        /// </summary>
        None,
        /// <summary>
        /// Всі
        /// </summary>
        All,
        /// <summary>
        /// Залишок
        /// </summary>
        Remainder,
        /// <summary>
        /// Використані
        /// </summary>
        Usage
    }

    internal enum UsageFilter
    {
        /// <summary>
        /// Empty
        /// </summary>
        None,
        /// <summary>
        /// Всі
        /// </summary>
        All,
        /// <summary>
        /// Періоди
        /// </summary>
        Periods,
        /// <summary>
        /// Аванси
        /// </summary>
        Avances
    }
}
