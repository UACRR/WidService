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

        public SelectPartner()
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
        }

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
                UpdateData((int)custId);
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
            ddlPartnersList.SelectedIndex = ddlPartnersList.Items.First.Index;
        }

        private void btnSavePartner_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
    public class PartnerList
    {
        public int CustId { get; set; }
        public string PartnerName { get; set; }
    }
}
