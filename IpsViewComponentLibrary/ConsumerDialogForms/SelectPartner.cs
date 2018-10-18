using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class SelectPartner : Telerik.WinControls.UI.RadForm
    {
        private List<PartnerList> _partnerList = new List<PartnerList>();
        private List<Customer> _customers;

        public SelectPartner(int? partnerId)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            PartnerId = partnerId;
            ctrlSearch.SetUsageGrid(gvPartnerList);
        }

        public int? PartnerId { get; private set; }

        public void SetPartnerList(List<Customer> customers)
        {
            _customers = customers.Where(i => i.Partner?.AgreementAddPartner?.SingleOrDefault()?.AgrStatus == 2).ToList();
            List<PartnerList> listTemp = new List<PartnerList>();
            foreach (var customer in _customers)
            {
                var person = customer.Person?.AnketaPerson?.SingleOrDefault();
                listTemp.Add(new PartnerList
                {
                    CustId = customer.CustId,
                    PartnerName = person?.LastName + " " + person?.FirstName + " " + person?.SurName,
                });
            }
            _partnerList = listTemp.OrderBy(rec => rec.PartnerName).ToList();
            gvPartnerList.DataSource = _partnerList;
        }

        private void SelectedPartnerChanged(object sender, EventArgs e)
        {
            if (!((gvPartnerList?.CurrentRow?.DataBoundItem as PartnerList)?.CustId is int custId)) return;

            UpdateData(custId);
            PartnerId = custId;
        }

        private void UpdateData(int? custId)
        {
            if(custId == null) return;

            var person =  _customers.SingleOrDefault(rec => rec.CustId == custId)?.Person.AnketaPerson.SingleOrDefault();
            var agreement = _customers.SingleOrDefault(rec => rec.CustId == custId)?.Partner?.AgreementAddPartner.SingleOrDefault();
            lblAgrDate.Text = agreement?.AgrDate?.ToString("d");
            lblAgrStatus.Text = IpsGlobal.AnketaDictionaties?.agreementStatus?.SingleOrDefault(r => r?.CodeI == agreement?.AgrStatus)?.Name;
            lblAgrNumber.Text = agreement?.AgrNumber;
            lblMobile.Text = person?.PhoneMobileMain;
            lblEmail.Text = person?.EMail;
        }

        private void SelectPartner_Load(object sender, EventArgs e)
        {
            gvPartnerList.CurrentRowChanged += SelectedPartnerChanged;
            if (PartnerId != null)
            {
                gvPartnerList.CurrentRow = gvPartnerList.Rows.SingleOrDefault(rec => (rec.DataBoundItem as PartnerList)?.CustId == PartnerId);
                UpdateData(PartnerId);
            }
            else
                UpdateData((gvPartnerList?.Rows?.FirstOrDefault()?.DataBoundItem as PartnerList)?.CustId);
        }

        private void btnSelectPartner_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
    }
    public class PartnerList
    {
        public int CustId { get; set; }
        public string PartnerName { get; set; }
    }
}
