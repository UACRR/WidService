using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetLicenses : UserControl
    {

        private Customer _customer;
        private AnketaDictionaties _dictionaties;
        public MiddleControlCabinetLicenses()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Джерело даних шапки
        /// </summary>
        /// <param name="comsumerBigRightView"></param>
        public void SetDataSources(object comsumerBigRightView)
        {
            ctrlAgrInfo.DataSource = comsumerBigRightView;
        }

        public void SetDictionary(AnketaDictionaties dictionaties)
        {
            _dictionaties = dictionaties;
        }

        public void SetData(Customer customer, object sourceGrid)
        {
            _customer = customer;
            gvViewLicences.DataSource = sourceGrid;

        }

        private void gvViewLicences_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if(gvViewLicences.Rows.Count == 0 || e?.CurrentRow?.DataBoundItem == null)
            {
                pageView.Enabled = false;
                return;
            }

            if (pageView.Enabled == false)
                pageView.Enabled = true;

            ctrlInformation.InfoDataSource = e.CurrentRow.DataBoundItem as VbrLicense;
        }

        #region FILTERING (пошук)

        private void gvViewConsumers_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvViewLicences.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvViewLicences.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }

                gvViewLicences.EndUpdate(false);
                return;
            }

            //фільтр не пустий
            gvViewLicences.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvViewLicences.ColumnCount; i++)
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

                gvViewLicences.EndUpdate(false);
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvViewLicences.MasterTemplate.Refresh();
        }

        #endregion

        private void gvViewLicences_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //TODO видалення ліцензії
            
            //_customer.Client.LicenseAgreement.SingleOrDefault()?.LicenseBigR.Remove();
        }

        private void btnCloseAgr_Click(object sender, EventArgs e)
        {

        }

        private void btnToProlongation_Click(object sender, EventArgs e)
        {

        }

        private void btnToAccept_Click(object sender, EventArgs e)
        {

        }
    }
}
