using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class SelectPartner : Telerik.WinControls.UI.RadForm
    {
        private List<AnketaPerson> _anketaPersons;
        private List<PartnerList> _partnerList = new List<PartnerList>();

        public SelectPartner(int? partnerId)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            PartnerId = partnerId;
        }

        public int? PartnerId { get; private set; }

        public void SetPartnerList(List<AnketaPerson> anketaPersons)
        {
            _anketaPersons = anketaPersons;
            List<PartnerList> listTemp = new List<PartnerList>();
            foreach (var person in anketaPersons)
            {
                listTemp.Add(new PartnerList
                {
                    CustId = person.CustId,
                    PartnerName = person.LastName + " " + person.FirstName + " " + person.SurName,
                });
            }
            _partnerList = listTemp.OrderBy(rec => rec.PartnerName).ToList();
            ddlPartnersList.DataSource = _partnerList;
            ddlPartnersList.SelectedValue = "CustId";
            ddlPartnersList.DisplayMember = "PartnerName";
        }

        private void ddlPartnersList_SelectedValueChanged(object sender, EventArgs e)
        {
            var custId = ((PartnerList)((Telerik.WinControls.UI.RadDropDownList)sender)?.SelectedItem?.Value)?.CustId;
            if (custId != null)
            {
                UpdateData((int)custId);
                PartnerId = (int) custId;
            }
        }

        private void UpdateData(int custId)
        {
            var item = _anketaPersons.SingleOrDefault(rec => rec.CustId == custId);
            lblAgrDate.Text = "";
            lblAgrDateEnd.Text = "";
            lblAgrNumber.Text = "";
            lblMobile.Text = item?.PhoneMobileMain;
            lblEmail.Text = item?.EMail;
        }

        private void SelectPartner_Load(object sender, EventArgs e)
        {
            ddlPartnersList.SelectedValueChanged += ddlPartnersList_SelectedValueChanged;
            if (PartnerId != null && ddlPartnersList.Items.SingleOrDefault(rec => (rec.DataBoundItem as PartnerList)?.CustId == PartnerId)?.Index is int index)
                ddlPartnersList.SelectedIndex = index;
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
