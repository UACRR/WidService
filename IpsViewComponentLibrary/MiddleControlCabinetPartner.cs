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
    public partial class MiddleControlCabinetPartner : UserControl
    {
        private List<AnketaPerson> _anketaPersons;
        private List<PartnerList> _partnerList = new List<PartnerList>();
        public MiddleControlCabinetPartner()
        {
            InitializeComponent();
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
            if(custId != null)
                UpdateData((int)custId);
        }

        private void UpdateData(int custId)
        {
            var item = _anketaPersons.SingleOrDefault(rec => rec.CustId == custId);
            lblFullName.Text = item?.LastName + " " + item?.FirstName + " " + item?.SurName;
            lblAgrDate.Text = "";
            lblAgrDateEnd.Text = "";
            lblAgrNumber.Text = "";
            lblMobile.Text = item?.PhoneMobileMain;
            lblEmail.Text = item?.EMail;
            
        }
    }

    public class PartnerList
    {
        public int CustId { get; set; }
        public string PartnerName { get; set; }
    }
    
}
