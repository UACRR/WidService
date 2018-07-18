using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetRequest : UserControl
    {
        private Customer _customer;
        public MiddleControlCabinetRequest()
        {
            InitializeComponent();
            bsDictionary.DataSource = IpsGlobal.AnketaDictionaties.workType;
        }

        /// <summary>
        /// Дані для контрола
        /// </summary>
        /// <param name="comsumerBigRightView"></param>
        public void SetAndUpdateData(Customer customer, ConsumerBigRightView bigRightView, IList<BigRightRequests> listRequests, IList<BigRightRequestBidAuthors> author)
        {
            _customer = customer;
            ctrlAgrInfo.DataSource = bigRightView;
            gvViewRequests.DataSource = listRequests;
            bindingSource1.DataSource = author;
            // gvCreativeRole.DataSource = author;
        }

        private void gvViewRequests_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }

        private void gvViewRequests_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            var item = e.CurrentRow.DataBoundItem as BigRightRequests;

        }

        #region FILTERING (пошук)

        private void gvViewRequests_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvViewRequests.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvViewRequests.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }

                gvViewRequests.EndUpdate(false);
                return;
            }

            //фільтр не пустий
            gvViewRequests.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvViewRequests.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearch.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    e.Visible = true;
                    e.Row.Cells[i].Style.CustomizeFill = true;
                    e.Row.Cells[i].Style.DrawFill = true;
                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                }
                else
                {
                    e.Row.Cells[i].Style.Reset();
                }

                gvViewRequests.EndUpdate(false);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvViewRequests.MasterTemplate.Refresh();
        }

        #endregion

        private void gvCreativeRole_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var item = e.Row.DataBoundItem as BigRightRequestBidAuthors;
        }
    }
}
